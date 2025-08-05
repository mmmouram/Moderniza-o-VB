import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Box, Container, Paper } from "@mui/material";
import OrderTabs from "../components/OrderDetails/OrderTabs";

/**
 * OrderDetailsPage
 *
 * Modernized page for displaying the details of a specific order.
 * Implements all business rules for the new order detail experience,
 * including tab navigation, list views, auto-load checkboxes, Excel export,
 * and state persistence.
 */
const OrderDetailsPage: React.FC = () => {
  // Get order number from route params
  const { orderNumber } = useParams<{ orderNumber: string }>();
  const navigate = useNavigate();

  // Handler for closing the form (navigates back)
  const handleClose = () => {
    navigate(-1);
  };

  if (!orderNumber) {
    return (
      <Container maxWidth="md" sx={{ mt: 8 }}>
        <Paper elevation={2} sx={{ p: 4, textAlign: "center" }}>
          <Box fontSize={20} color="error.main">
            Número do pedido não informado na URL.
          </Box>
        </Paper>
      </Container>
    );
  }

  return (
    <Container maxWidth="xl" sx={{ mt: 4, mb: 4 }}>
      <OrderTabs orderNumber={orderNumber} onClose={handleClose} />
    </Container>
  );
};

export default OrderDetailsPage;