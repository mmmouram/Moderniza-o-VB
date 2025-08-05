import React from "react";
import { Tabs, Tab, Box } from "@mui/material";
import OrderDetailsForm from "./OrderDetailsForm";

export type OrderTabsKey = "items" | "observations" | "blocks" | "invoices";

export interface OrderTabsProps {
  orderNumber: string;
  onClose?: () => void;
}

const TAB_LABELS: Record<OrderTabsKey, string> = {
  items: "Itens do Pedido",
  observations: "Observações",
  blocks: "Bloqueios de Pedido",
  invoices: "Nota Fiscal",
};

/**
 * OrderTabs component: renders the tab navigation and delegates to OrderDetailsForm,
 * which handles all tab content, state, and business logic.
 * This component is responsible for the tab navigation only.
 */
const OrderTabs: React.FC<OrderTabsProps> = ({ orderNumber, onClose }) => {
  // The OrderDetailsForm already manages the tab state and all business logic,
  // so this component simply renders it.
  return (
    <Box>
      <OrderDetailsForm orderNumber={orderNumber} onClose={onClose} />
    </Box>
  );
};

export default OrderTabs;