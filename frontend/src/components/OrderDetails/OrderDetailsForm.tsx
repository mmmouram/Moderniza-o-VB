import React, { useCallback, useEffect, useMemo, useRef, useState } from "react";
import {
  Box,
  Button,
  Checkbox,
  CircularProgress,
  FormControlLabel,
  Grid,
  Paper,
  Tab,
  Tabs,
  TextField,
  Typography,
  Snackbar,
  Alert,
} from "@mui/material";
import { SaveAlt, Refresh, Description, Visibility } from "@mui/icons-material";
import { OrderDetailsDto, OrderItemDto, OrderObservationDto, OrderBlockDto, OrderInvoiceDto, OrderDetailStatePersistenceDto } from "../../services/orderDetailsService";
import { getOrderDetails, updateOrderItems, updateOrderObservations, updateOrderBlocks, updateOrderInvoices, exportListToExcel, persistState, getPersistedState } from "../../services/orderDetailsService";
import { downloadExcelFile } from "../../utils/excelExport";
import OrderListView from "./OrderListView";
import OrderExportButton from "./OrderExportButton";
import OrderAutoLoadCheckbox from "./OrderAutoLoadCheckbox";

type TabKey = "items" | "observations" | "blocks" | "invoices";

const TAB_LABELS: Record<TabKey, string> = {
  items: "Itens do Pedido",
  observations: "Observações",
  blocks: "Bloqueios de Pedido",
  invoices: "Nota Fiscal",
};

interface OrderDetailsFormProps {
  orderNumber: string;
  onClose?: () => void;
}

const OrderDetailsForm: React.FC<OrderDetailsFormProps> = ({ orderNumber, onClose }) => {
  // State
  const [orderDetails, setOrderDetails] = useState<OrderDetailsDto | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [activeTab, setActiveTab] = useState<TabKey>("items");
  const [error, setError] = useState<string | null>(null);
  const [snackbar, setSnackbar] = useState<{ open: boolean; message: string; severity: "success" | "error" }>({ open: false, message: "", severity: "success" });

  // For persisting state
  const [statePersistence, setStatePersistence] = useState<OrderDetailStatePersistenceDto | null>(null);

  // For controlling auto-load checkboxes
  const [autoLoad, setAutoLoad] = useState({
    items: true,
    observations: true,
    blocks: true,
    invoices: true,
  });

  // For controlling selected row in each list
  const [selectedKeys, setSelectedKeys] = useState<{
    items?: string;
    observations?: string;
    blocks?: string;
    invoices?: string;
  }>({});

  // For controlling list data
  const [items, setItems] = useState<OrderItemDto[]>([]);
  const [observations, setObservations] = useState<OrderObservationDto[]>([]);
  const [blocks, setBlocks] = useState<OrderBlockDto[]>([]);
  const [invoices, setInvoices] = useState<OrderInvoiceDto[]>([]);

  // Refs to avoid stale closures
  const orderNumberRef = useRef(orderNumber);

  // Load persisted state and order details on mount
  useEffect(() => {
    let isMounted = true;
    setLoading(true);
    (async () => {
      try {
        // Load persisted state
        const persisted = await getPersistedState(orderNumber);
        if (isMounted) {
          setStatePersistence(persisted);
          setAutoLoad({
            items: persisted?.autoLoadItemsChecked ?? true,
            observations: persisted?.autoLoadObservationsChecked ?? true,
            blocks: persisted?.autoLoadBlocksChecked ?? true,
            invoices: persisted?.autoLoadInvoicesChecked ?? true,
          });
          setSelectedKeys({
            items: persisted?.itemsListSelectedKey,
            observations: persisted?.observationsListSelectedKey,
            blocks: persisted?.blocksListSelectedKey,
            invoices: persisted?.invoicesListSelectedKey,
          });
        }

        // Load order details
        const details = await getOrderDetails(orderNumber);
        if (isMounted) {
          setOrderDetails(details);
          setItems(details.items ?? []);
          setObservations(details.observations ?? []);
          setBlocks(details.blocks ?? []);
          setInvoices(details.invoices ?? []);
        }
      } catch (err: any) {
        setError(err?.message || "Erro ao carregar detalhes do pedido.");
      } finally {
        if (isMounted) setLoading(false);
      }
    })();
    return () => {
      isMounted = false;
    };
  }, [orderNumber]);

  // Auto-load lists if checkboxes are checked
  useEffect(() => {
    if (!orderDetails) return;
    if (autoLoad.items) handleUpdateList("items");
    if (autoLoad.observations) handleUpdateList("observations");
    if (autoLoad.blocks) handleUpdateList("blocks");
    if (autoLoad.invoices) handleUpdateList("invoices");
    // eslint-disable-next-line
  }, [orderDetails, autoLoad.items, autoLoad.observations, autoLoad.blocks, autoLoad.invoices]);

  // Persist state on unmount or when relevant state changes
  useEffect(() => {
    return () => {
      persistCurrentState();
    };
    // eslint-disable-next-line
  }, [autoLoad, selectedKeys]);

  // Helper: persist current state
  const persistCurrentState = useCallback(() => {
    if (!orderNumberRef.current) return;
    const state: OrderDetailStatePersistenceDto = {
      itemsListSelectedKey: selectedKeys.items,
      observationsListSelectedKey: selectedKeys.observations,
      blocksListSelectedKey: selectedKeys.blocks,
      invoicesListSelectedKey: selectedKeys.invoices,
      autoLoadItemsChecked: autoLoad.items,
      autoLoadObservationsChecked: autoLoad.observations,
      autoLoadBlocksChecked: autoLoad.blocks,
      autoLoadInvoicesChecked: autoLoad.invoices,
    };
    persistState(orderNumberRef.current, state).catch(() => { /* ignore */ });
  }, [autoLoad, selectedKeys]);

  // Tab change handler
  const handleTabChange = (_: React.SyntheticEvent, newValue: TabKey) => {
    setActiveTab(newValue);
  };

  // Update list handler
  const handleUpdateList = useCallback(
    async (tab: TabKey) => {
      try {
        switch (tab) {
          case "items":
            setLoading(true);
            const itemsData = await updateOrderItems(orderNumber);
            setItems(itemsData);
            setSnackbar({ open: true, message: "Itens do pedido atualizados.", severity: "success" });
            break;
          case "observations":
            setLoading(true);
            const obsData = await updateOrderObservations(orderNumber);
            setObservations(obsData);
            setSnackbar({ open: true, message: "Observações atualizadas.", severity: "success" });
            break;
          case "blocks":
            setLoading(true);
            const blocksData = await updateOrderBlocks(orderNumber);
            setBlocks(blocksData);
            setSnackbar({ open: true, message: "Bloqueios atualizados.", severity: "success" });
            break;
          case "invoices":
            setLoading(true);
            const invoicesData = await updateOrderInvoices(orderNumber);
            setInvoices(invoicesData);
            setSnackbar({ open: true, message: "Notas fiscais atualizadas.", severity: "success" });
            break;
        }
      } catch (err: any) {
        setError(err?.message || "Erro ao atualizar lista.");
      } finally {
        setLoading(false);
      }
    },
    [orderNumber]
  );

  // Export to Excel handler
  const handleExportExcel = useCallback(
    async (tab: TabKey) => {
      try {
        setLoading(true);
        const blob = await exportListToExcel(orderNumber, tab);
        const fileName = `Pedido_${orderNumber}_${tab}_${new Date().toISOString().replace(/[-:T.]/g, "").slice(0, 14)}.xlsx`;
        downloadExcelFile(blob, fileName);
        setSnackbar({ open: true, message: "Exportação para Excel realizada com sucesso.", severity: "success" });
      } catch (err: any) {
        setError(err?.message || "Erro ao exportar para Excel.");
      } finally {
        setLoading(false);
      }
    },
    [orderNumber]
  );

  // Checkbox change handler
  const handleAutoLoadChange = (tab: TabKey, checked: boolean) => {
    setAutoLoad((prev) => ({ ...prev, [tab]: checked }));
    // Persist immediately
    persistCurrentState();
  };

  // List row selection handler
  const handleRowSelect = (tab: TabKey, key: string) => {
    setSelectedKeys((prev) => ({ ...prev, [tab]: key }));
    // Persist immediately
    persistCurrentState();
  };

  // Detail handler for invoices (Nota Fiscal)
  const handleDetailInvoice = () => {
    // For demo: just show a snackbar. In a real app, open a modal or navigate.
    setSnackbar({ open: true, message: "Detalhamento de Nota Fiscal não implementado nesta versão.", severity: "info" });
  };

  // Renderers for each tab
  const renderTabContent = useMemo(() => {
    switch (activeTab) {
      case "items":
        return (
          <Box>
            <Box display="flex" alignItems="center" mb={1}>
              <OrderAutoLoadCheckbox
                label="Carregar Automaticamente"
                checked={autoLoad.items}
                onChange={(checked) => handleAutoLoadChange("items", checked)}
              />
              <Button
                variant="contained"
                color="primary"
                size="small"
                startIcon={<Refresh />}
                onClick={() => handleUpdateList("items")}
                sx={{ ml: 1 }}
                disabled={loading}
              >
                Atualizar
              </Button>
              <OrderExportButton
                onClick={() => handleExportExcel("items")}
                disabled={loading}
                sx={{ ml: 1 }}
              />
            </Box>
            <OrderListView
              type="items"
              data={items}
              selectedKey={selectedKeys.items}
              onRowSelect={(key) => handleRowSelect("items", key)}
              loading={loading}
            />
          </Box>
        );
      case "observations":
        return (
          <Box>
            <Box display="flex" alignItems="center" mb={1}>
              <OrderAutoLoadCheckbox
                label="Carregar Automaticamente"
                checked={autoLoad.observations}
                onChange={(checked) => handleAutoLoadChange("observations", checked)}
              />
              <Button
                variant="contained"
                color="primary"
                size="small"
                startIcon={<Refresh />}
                onClick={() => handleUpdateList("observations")}
                sx={{ ml: 1 }}
                disabled={loading}
              >
                Atualizar
              </Button>
              <OrderExportButton
                onClick={() => handleExportExcel("observations")}
                disabled={loading}
                sx={{ ml: 1 }}
              />
            </Box>
            <OrderListView
              type="observations"
              data={observations}
              selectedKey={selectedKeys.observations}
              onRowSelect={(key) => handleRowSelect("observations", key)}
              loading={loading}
            />
          </Box>
        );
      case "blocks":
        return (
          <Box>
            <Box display="flex" alignItems="center" mb={1}>
              <OrderAutoLoadCheckbox
                label="Carregar Automaticamente"
                checked={autoLoad.blocks}
                onChange={(checked) => handleAutoLoadChange("blocks", checked)}
              />
              <Button
                variant="contained"
                color="primary"
                size="small"
                startIcon={<Refresh />}
                onClick={() => handleUpdateList("blocks")}
                sx={{ ml: 1 }}
                disabled={loading}
              >
                Atualizar
              </Button>
              <OrderExportButton
                onClick={() => handleExportExcel("blocks")}
                disabled={loading}
                sx={{ ml: 1 }}
              />
            </Box>
            <OrderListView
              type="blocks"
              data={blocks}
              selectedKey={selectedKeys.blocks}
              onRowSelect={(key) => handleRowSelect("blocks", key)}
              loading={loading}
            />
          </Box>
        );
      case "invoices":
        return (
          <Box>
            <Box display="flex" alignItems="center" mb={1}>
              <OrderAutoLoadCheckbox
                label="Carregar Automaticamente"
                checked={autoLoad.invoices}
                onChange={(checked) => handleAutoLoadChange("invoices", checked)}
              />
              <Button
                variant="contained"
                color="primary"
                size="small"
                startIcon={<Refresh />}
                onClick={() => handleUpdateList("invoices")}
                sx={{ ml: 1 }}
                disabled={loading}
              >
                Atualizar
              </Button>
              <Button
                variant="contained"
                color="secondary"
                size="small"
                startIcon={<Visibility />}
                onClick={handleDetailInvoice}
                sx={{ ml: 1 }}
                disabled={loading}
              >
                Detalhar
              </Button>
              <OrderExportButton
                onClick={() => handleExportExcel("invoices")}
                disabled={loading}
                sx={{ ml: 1 }}
              />
            </Box>
            <OrderListView
              type="invoices"
              data={invoices}
              selectedKey={selectedKeys.invoices}
              onRowSelect={(key) => handleRowSelect("invoices", key)}
              loading={loading}
            />
          </Box>
        );
      default:
        return null;
    }
    // eslint-disable-next-line
  }, [
    activeTab,
    autoLoad.items,
    autoLoad.observations,
    autoLoad.blocks,
    autoLoad.invoices,
    loading,
    items,
    observations,
    blocks,
    invoices,
    selectedKeys,
  ]);

  // Error snackbar
  const handleSnackbarClose = () => setSnackbar((prev) => ({ ...prev, open: false }));

  // Main render
  return (
    <Paper elevation={3} sx={{ p: 3, minWidth: 1100, minHeight: 700 }}>
      <Box mb={2}>
        <Typography variant="h5" color="primary" fontWeight={700}>
          Pedido - Detalhe
        </Typography>
      </Box>
      <Grid container spacing={2} mb={2}>
        <Grid item xs={12} md={3}>
          <TextField
            label="Número"
            value={orderDetails?.orderNumber || ""}
            InputProps={{ readOnly: true }}
            fullWidth
            variant="outlined"
            size="small"
          />
        </Grid>
        <Grid item xs={12} md={3}>
          <TextField
            label="CNPJ"
            value={orderDetails?.clientCnpj || ""}
            InputProps={{ readOnly: true }}
            fullWidth
            variant="outlined"
            size="small"
          />
        </Grid>
        <Grid item xs={12} md={6}>
          <TextField
            label="Razão Social"
            value={orderDetails?.clientRazaoSocial || ""}
            InputProps={{ readOnly: true }}
            fullWidth
            variant="outlined"
            size="small"
          />
        </Grid>
      </Grid>
      <Box>
        <Tabs
          value={activeTab}
          onChange={handleTabChange}
          indicatorColor="primary"
          textColor="primary"
          variant="fullWidth"
        >
          <Tab label={TAB_LABELS.items} value="items" />
          <Tab label={TAB_LABELS.observations} value="observations" />
          <Tab label={TAB_LABELS.blocks} value="blocks" />
          <Tab label={TAB_LABELS.invoices} value="invoices" />
        </Tabs>
        <Box mt={2} minHeight={400}>
          {loading && (
            <Box display="flex" alignItems="center" justifyContent="center" minHeight={200}>
              <CircularProgress />
            </Box>
          )}
          {!loading && renderTabContent}
        </Box>
      </Box>
      <Box mt={3} display="flex" justifyContent="flex-end">
        <Button variant="outlined" color="secondary" onClick={onClose}>
          Sair
        </Button>
      </Box>
      <Snackbar
        open={!!error}
        autoHideDuration={8000}
        onClose={() => setError(null)}
        anchorOrigin={{ vertical: "top", horizontal: "center" }}
      >
        <Alert severity="error" onClose={() => setError(null)} sx={{ width: "100%" }}>
          {error}
        </Alert>
      </Snackbar>
      <Snackbar
        open={snackbar.open}
        autoHideDuration={4000}
        onClose={handleSnackbarClose}
        anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
      >
        <Alert severity={snackbar.severity} onClose={handleSnackbarClose} sx={{ width: "100%" }}>
          {snackbar.message}
        </Alert>
      </Snackbar>
    </Paper>
  );
};

export default OrderDetailsForm;