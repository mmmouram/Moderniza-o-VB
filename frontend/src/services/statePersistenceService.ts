import axios, { AxiosError } from "axios";

/**
 * DTO for persisting state and positions of controls (list views, checkboxes, etc.)
 */
export interface OrderDetailStatePersistenceDto {
  itemsListSelectedKey?: string;
  observationsListSelectedKey?: string;
  blocksListSelectedKey?: string;
  invoicesListSelectedKey?: string;
  autoLoadItemsChecked?: boolean;
  autoLoadObservationsChecked?: boolean;
  autoLoadBlocksChecked?: boolean;
  autoLoadInvoicesChecked?: boolean;
}

/**
 * API base URL for state persistence
 */
const API_BASE_URL = "/api/OrderDetails";

/**
 * Helper to handle API errors and throw user-friendly messages.
 */
function handleApiError(error: any): never {
  if (axios.isAxiosError(error)) {
    const err = error as AxiosError<{ message?: string }>;
    if (err.response && err.response.data && err.response.data.message) {
      throw new Error(err.response.data.message);
    }
    if (err.message) {
      throw new Error(err.message);
    }
  }
  throw new Error("Ocorreu um erro inesperado ao processar sua solicitação.");
}

/**
 * Persists the state of list view positions and checkbox values for a given order.
 * @param orderNumber The order number.
 * @param state The state persistence DTO containing positions and checkbox values.
 */
export async function persistState(
  orderNumber: string,
  state: OrderDetailStatePersistenceDto
): Promise<void> {
  try {
    await axios.post(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/state`, state);
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Retrieves the persisted state of list view positions and checkbox values for a given order.
 * @param orderNumber The order number.
 * @returns The persisted state DTO.
 */
export async function getPersistedState(
  orderNumber: string
): Promise<OrderDetailStatePersistenceDto> {
  try {
    const response = await axios.get<OrderDetailStatePersistenceDto>(
      `${API_BASE_URL}/${encodeURIComponent(orderNumber)}/state`
    );
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

export default {
  persistState,
  getPersistedState,
};