import React from "react";
import { Checkbox, FormControlLabel } from "@mui/material";

export interface OrderAutoLoadCheckboxProps {
  label?: string;
  checked: boolean;
  onChange: (checked: boolean) => void;
  disabled?: boolean;
  sx?: object;
}

/**
 * OrderAutoLoadCheckbox
 * 
 * Checkbox component for "Carregar Automaticamente" option in each tab of the order details form.
 * Used to allow the user to choose whether the list should be auto-loaded on form open.
 * 
 * Props:
 * - label: string (optional, default: "Carregar Automaticamente")
 * - checked: boolean (required)
 * - onChange: (checked: boolean) => void (required)
 * - disabled: boolean (optional)
 * - sx: object (optional, for styling)
 */
const OrderAutoLoadCheckbox: React.FC<OrderAutoLoadCheckboxProps> = ({
  label = "Carregar Automaticamente",
  checked,
  onChange,
  disabled = false,
  sx = {},
}) => {
  return (
    <FormControlLabel
      control={
        <Checkbox
          checked={checked}
          onChange={e => onChange(e.target.checked)}
          color="primary"
          disabled={disabled}
          sx={sx}
        />
      }
      label={label}
      sx={sx}
    />
  );
};

export default OrderAutoLoadCheckbox;