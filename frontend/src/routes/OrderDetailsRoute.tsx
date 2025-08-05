import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import OrderDetailsPage from "../pages/OrderDetailsPage";

/**
 * OrderDetailsRoute
 *
 * Route component for the modernized Order Details form.
 * Handles route params and navigation for the order detail experience.
 * All business rules for the modernized form are implemented in OrderDetailsPage and its children.
 */
const OrderDetailsRoute: React.FC = () => {
  // Get order number from route params
  const { orderNumber } = useParams<{ orderNumber: string }>();
  const navigate = useNavigate();

  // If no order number is provided, redirect or show error (handled in OrderDetailsPage)
  return <OrderDetailsPage />;
};

export default OrderDetailsRoute;