import React, { useMemo } from "react";
import {
  Box,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  CircularProgress,
} from "@mui/material";
import { OrderItemDto, OrderObservationDto, OrderBlockDto, OrderInvoiceDto } from "../../services/orderDetailsService";

type ListViewType = "items" | "observations" | "blocks" | "invoices";

interface OrderListViewProps {
  type: ListViewType;
  data: OrderItemDto[] | OrderObservationDto[] | OrderBlockDto[] | OrderInvoiceDto[];
  selectedKey?: string;
  onRowSelect?: (key: string) => void;
  loading?: boolean;
}

const columnsConfig: Record<
  ListViewType,
  {
    label: string;
    width?: number | string;
    align?: "left" | "right" | "center";
    getValue: (row: any) => React.ReactNode;
    key: string;
  }[]
> = {
  items: [
    { label: "Seq.", width: 60, getValue: (row) => row.sequentialId, key: "sequentialId" },
    { label: "Cód.Prod. Cliente", width: 120, getValue: (row) => row.productCode, key: "productCode" },
    { label: "Descr. Curta Prod.", width: 180, getValue: (row) => row.productShortDescription, key: "productShortDescription" },
    { label: "Descr. Longa Prod.", width: 220, getValue: (row) => row.productLongDescription, key: "productLongDescription" },
    { label: "Qtde Pedida", width: 100, align: "right", getValue: (row) => row.orderedQuantity, key: "orderedQuantity" },
    { label: "Qtde Faturada", width: 100, align: "right", getValue: (row) => row.invoicedQuantity, key: "invoicedQuantity" },
    { label: "Qtde Destinada", width: 100, align: "right", getValue: (row) => row.destinedQuantity, key: "destinedQuantity" },
    { label: "Qtde Empenhada", width: 100, align: "right", getValue: (row) => row.committedQuantity, key: "committedQuantity" },
    { label: "Situação", width: 100, getValue: (row) => row.status, key: "status" },
    { label: "Preço", width: 100, align: "right", getValue: (row) => row.priceValue, key: "priceValue" },
    { label: "Saldo", width: 100, align: "right", getValue: (row) => row.balanceValue, key: "balanceValue" },
    { label: "Unitário", width: 100, align: "right", getValue: (row) => row.unitValue, key: "unitValue" },
    { label: "Desconto", width: 100, align: "right", getValue: (row) => row.discount, key: "discount" },
    { label: "Condição Pagamento", width: 140, getValue: (row) => row.paymentCondition, key: "paymentCondition" },
    { label: "Tabela Preço", width: 100, getValue: (row) => row.priceTable, key: "priceTable" },
    { label: "Data Base", width: 100, getValue: (row) => row.baseDate ? formatDate(row.baseDate) : "", key: "baseDate" },
    { label: "Data Cedo", width: 100, getValue: (row) => row.earlyDate ? formatDate(row.earlyDate) : "", key: "earlyDate" },
    { label: "Data Tarde", width: 100, getValue: (row) => row.lateDate ? formatDate(row.lateDate) : "", key: "lateDate" },
    { label: "Grupo Op.Fiscal", width: 120, getValue: (row) => row.fiscalGroupPricing, key: "fiscalGroupPricing" },
    { label: "Oper. Fiscal", width: 120, getValue: (row) => row.fiscalOperationPricing, key: "fiscalOperationPricing" },
    { label: "Grp Op.Fiscal Entrega", width: 140, getValue: (row) => row.fiscalGroupDelivery, key: "fiscalGroupDelivery" },
    { label: "Oper. Fiscal Entrega", width: 140, getValue: (row) => row.fiscalOperationDelivery, key: "fiscalOperationDelivery" },
  ],
  observations: [
    { label: "Seq.", width: 60, getValue: (row) => row.sequentialId, key: "sequentialId" },
    { label: "Tipo Operação", width: 140, getValue: (row) => row.operationTypeDescription, key: "operationTypeDescription" },
    { label: "Inscrição Estadual Cliente", width: 160, getValue: (row) => row.stateRegistration, key: "stateRegistration" },
    { label: "Nome", width: 140, getValue: (row) => row.name, key: "name" },
    { label: "Endereço", width: 180, getValue: (row) => row.address, key: "address" },
    { label: "Cidade", width: 120, getValue: (row) => row.city, key: "city" },
    { label: "UF", width: 60, getValue: (row) => row.state, key: "state" },
    { label: "Município", width: 120, getValue: (row) => row.municipality, key: "municipality" },
    { label: "MRH", width: 80, getValue: (row) => row.mrh, key: "mrh" },
    { label: "Texto Nota Fiscal", width: 180, getValue: (row) => row.invoiceText, key: "invoiceText" },
    { label: "Texto Livre", width: 180, getValue: (row) => row.freeText, key: "freeText" },
  ],
  blocks: [
    { label: "Seq.", width: 60, getValue: (row) => row.sequentialId, key: "sequentialId" },
    { label: "Descrição Bloqueio", width: 180, getValue: (row) => row.blockDescription, key: "blockDescription" },
    { label: "Status", width: 100, getValue: (row) => row.status === "A" ? "Ativo" : "Inativo", key: "status" },
    { label: "Data do Status", width: 120, getValue: (row) => row.statusDate ? formatDate(row.statusDate) : "", key: "statusDate" },
    { label: "Mensagem", width: 180, getValue: (row) => row.message, key: "message" },
    { label: "Tipo Bloqueio", width: 120, getValue: (row) => blockTypeDescription(row.blockTypeId), key: "blockTypeId" },
  ],
  invoices: [
    { label: "Código", width: 100, getValue: (row) => row.invoiceCode, key: "invoiceCode" },
    { label: "Série", width: 80, getValue: (row) => row.series, key: "series" },
    { label: "Estabelecimento", width: 120, getValue: (row) => row.establishment, key: "establishment" },
    { label: "Fábrica", width: 120, getValue: (row) => row.factoryDescription, key: "factoryDescription" },
    { label: "Status NF", width: 100, getValue: (row) => invoiceStatusDescription(row.statusCode), key: "statusCode" },
    { label: "Tipo NF", width: 100, getValue: (row) => row.invoiceType, key: "invoiceType" },
    { label: "Data Emissão", width: 110, getValue: (row) => row.emissionDate ? formatDate(row.emissionDate) : "", key: "emissionDate" },
    { label: "Data Saída Mercadoria", width: 140, getValue: (row) => row.merchandiseExitDate ? formatDate(row.merchandiseExitDate) : "", key: "merchandiseExitDate" },
    { label: "Valor BCICM", width: 110, align: "right", getValue: (row) => row.icmsBaseValue, key: "icmsBaseValue" },
    { label: "ICM", width: 90, align: "right", getValue: (row) => row.icmsValue, key: "icmsValue" },
    { label: "IPI", width: 90, align: "right", getValue: (row) => row.ipiValue, key: "ipiValue" },
    { label: "ALIQICM", width: 90, align: "right", getValue: (row) => row.icmsAliquotValue, key: "icmsAliquotValue" },
    { label: "Peso Líquido", width: 110, align: "right", getValue: (row) => row.netWeight, key: "netWeight" },
    { label: "Peso Bruto", width: 110, align: "right", getValue: (row) => row.grossWeight, key: "grossWeight" },
    { label: "Valor Descr.", width: 110, align: "right", getValue: (row) => row.discountValue, key: "discountValue" },
    { label: "Valor Total", width: 110, align: "right", getValue: (row) => row.totalValue, key: "totalValue" },
    { label: "Total Unidade Faturada", width: 160, align: "right", getValue: (row) => row.totalInvoicedUnits, key: "totalInvoicedUnits" },
    { label: "Qtde Volume", width: 110, align: "right", getValue: (row) => row.volumeQuantity, key: "volumeQuantity" },
    { label: "VIA Transporte", width: 120, getValue: (row) => row.transportWay, key: "transportWay" },
    { label: "Descr. Transporte", width: 140, getValue: (row) => row.transportDescription, key: "transportDescription" },
    { label: "Valor Descr. Pont.", width: 130, align: "right", getValue: (row) => row.additionalDiscountValue, key: "additionalDiscountValue" },
    { label: "Cód. Moeda", width: 100, getValue: (row) => row.currencyCode, key: "currencyCode" },
    { label: "Qualidade", width: 120, getValue: (row) => row.qualityDescription, key: "qualityDescription" },
  ],
};

function formatDate(date: string | Date): string {
  if (!date) return "";
  const d = typeof date === "string" ? new Date(date) : date;
  if (isNaN(d.getTime())) return "";
  return d.toLocaleDateString("pt-BR");
}

function blockTypeDescription(typeId: string): string {
  switch (typeId) {
    case "A": return "Alteração";
    case "B": return "Cobrança";
    case "C": return "Cliente";
    case "E": return "Frete";
    case "F": return "Configurador";
    case "G": return "Grupo Ordem";
    case "H": return "Entrega";
    case "K": return "S Comp Kit";
    case "L": return "Local Entrega";
    case "M": return "Margem Min / Max";
    case "N": return "Preço Min";
    case "O": return "Vlr.Max Venda";
    case "P": return "Produto";
    case "Q": return "Qtde Min / Max";
    case "R": return "Verif.Crédito";
    case "S": return "Venda";
    case "T": return "Cotas";
    case "U": return "Fech.Ciclo";
    case "V": return "Vendor HLD";
    case "X": return "Qtde Min/Max CO";
    case "Y": return "Tolerância.Zero";
    case "Z": return "Prazo Médio";
    default: return typeId;
  }
}

function invoiceStatusDescription(status: string): string {
  switch (status) {
    case "A": return "Contabilizado";
    case "C": return "Encerrado";
    case "E": return "Editado";
    case "H": return "Suspenso";
    case "O": return "Aberto";
    case "V": return "Transf.Voucher";
    case "X": return "Excluido";
    default: return status;
  }
}

const getRowKey = (type: ListViewType, row: any): string => {
  switch (type) {
    case "items":
      return row.sequentialId?.toString() ?? "";
    case "observations":
      return row.sequentialId?.toString() ?? "";
    case "blocks":
      return row.sequentialId?.toString() ?? "";
    case "invoices":
      // Combination of invoiceCode and series
      return row.invoiceCode && row.series ? `${row.invoiceCode}_${row.series}` : "";
    default:
      return "";
  }
};

const OrderListView: React.FC<OrderListViewProps> = ({
  type,
  data,
  selectedKey,
  onRowSelect,
  loading,
}) => {
  const columns = columnsConfig[type];

  const handleRowClick = (row: any) => {
    if (onRowSelect) {
      onRowSelect(getRowKey(type, row));
    }
  };

  const isSelected = (row: any) => {
    return selectedKey && getRowKey(type, row) === selectedKey;
  };

  const emptyMessage = useMemo(() => {
    switch (type) {
      case "items":
        return "Nenhum item do pedido encontrado.";
      case "observations":
        return "Nenhuma observação encontrada.";
      case "blocks":
        return "Nenhum bloqueio de pedido encontrado.";
      case "invoices":
        return "Nenhuma nota fiscal encontrada.";
      default:
        return "Nenhum registro encontrado.";
    }
  }, [type]);

  return (
    <Paper variant="outlined" sx={{ width: "100%", overflow: "auto", minHeight: 300 }}>
      <TableContainer>
        <Table size="small" stickyHeader>
          <TableHead>
            <TableRow>
              {columns.map((col) => (
                <TableCell
                  key={col.key}
                  align={col.align || "left"}
                  style={{ minWidth: col.width, fontWeight: 700, background: "#f5f5f5" }}
                >
                  {col.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {loading ? (
              <TableRow>
                <TableCell colSpan={columns.length} align="center">
                  <Box display="flex" alignItems="center" justifyContent="center" minHeight={120}>
                    <CircularProgress size={32} />
                  </Box>
                </TableCell>
              </TableRow>
            ) : data && data.length > 0 ? (
              data.map((row: any, idx: number) => (
                <TableRow
                  key={getRowKey(type, row) || idx}
                  hover
                  selected={isSelected(row)}
                  onClick={() => handleRowClick(row)}
                  sx={{
                    cursor: onRowSelect ? "pointer" : "default",
                    backgroundColor: isSelected(row) ? "#e3f2fd" : undefined,
                  }}
                >
                  {columns.map((col) => (
                    <TableCell
                      key={col.key}
                      align={col.align || "left"}
                      style={{ minWidth: col.width }}
                    >
                      {col.getValue(row)}
                    </TableCell>
                  ))}
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={columns.length} align="center">
                  <Typography variant="body2" color="text.secondary">
                    {emptyMessage}
                  </Typography>
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </Paper>
  );
};

export default OrderListView;