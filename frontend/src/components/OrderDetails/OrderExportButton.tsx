import React from "react";
import { IconButton, Tooltip } from "@mui/material";
import { SaveAlt } from "@mui/icons-material";

export interface OrderExportButtonProps {
  /**
   * Called when the export button is clicked.
   */
  onClick: () => void;
  /**
   * If true, disables the button.
   */
  disabled?: boolean;
  /**
   * Optional style overrides.
   */
  sx?: object;
  /**
   * Optional tooltip text (default: "Exportar para Excel").
   */
  tooltip?: string;
}

/**
 * OrderExportButton
 *
 * Button for exporting the current list view to Excel.
 * Used in each tab of the order details form.
 *
 * Props:
 * - onClick: () => void (required)
 * - disabled: boolean (optional)
 * - sx: object (optional, for styling)
 * - tooltip: string (optional, default: "Exportar para Excel")
 */
const OrderExportButton: React.FC<OrderExportButtonProps> = ({
  onClick,
  disabled = false,
  sx = {},
  tooltip = "Exportar para Excel",
}) => {
  return (
    <Tooltip title={tooltip}>
      <span>
        <IconButton
          color="primary"
          onClick={onClick}
          disabled={disabled}
          sx={sx}
          size="small"
          aria-label="Exportar para Excel"
        >
          <SaveAlt />
        </IconButton>
      </span>
    </Tooltip>
  );
};

export default OrderExportButton;