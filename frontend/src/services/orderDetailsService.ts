import axios, { AxiosError } from "axios";

/**
 * DTOs for Order Details Modernized Form
 */

// State persistence DTO
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

// Order Item DTO
export interface OrderItemDto {
  orderNumber: string;
  productCode: string;
  sequentialId: number;
  orderedQuantity?: number;
  invoicedQuantity?: number;
  destinedQuantity?: number;
  committedQuantity?: number;
  status?: string;
  priceValue?: number;
  balanceValue?: number;
  unitValue?: number;
  discount?: number;
  paymentCondition?: string;
  priceTable?: string;
  fiscalGroupPricing?: string;
  fiscalOperationPricing?: string;
  fiscalGroupDelivery?: string;
  fiscalOperationDelivery?: string;
  earlyDate?: string;
  lateDate?: string;
  baseDate?: string;
  productShortDescription?: string;
  productLongDescription?: string;
}

// Order Observation DTO
export interface OrderObservationDto {
  orderNumber: string;
  sequentialId: number;
  operationTypeDescription?: string;
  stateRegistration?: string;
  name?: string;
  address?: string;
  mrh?: string;
  city?: string;
  state?: string;
  municipality?: string;
  invoiceText?: string;
  freeText?: string;
}

// Order Block DTO
export interface OrderBlockDto {
  orderNumber: string;
  lineNumber?: string;
  sequentialId: number;
  blockDescription?: string;
  status?: string;
  statusDate?: string;
  message?: string;
  blockTypeId?: string;
}

// Order Invoice DTO
export interface OrderInvoiceDto {
  invoiceCode: string;
  series: string;
  orderNumber?: string;
  clientCode?: string;
  establishment?: string;
  factoryCode?: string;
  statusCode?: string;
  invoiceType?: string;
  emissionDate?: string;
  merchandiseExitDate?: string;
  icmsBaseValue?: number;
  icmsValue?: number;
  ipiValue?: number;
  icmsAliquotValue?: number;
  netWeight?: number;
  grossWeight?: number;
  discountValue?: number;
  totalValue?: number;
  totalInvoicedUnits?: number;
  volumeQuantity?: number;
  transportWay?: string;
  transportDescription?: string;
  additionalDiscountValue?: number;
  qualityDescription?: string;
  currencyCode?: string;
  factoryDescription?: string;
  clientCnpj?: string;
  clientRazaoSocial?: string;
  clientTradeName?: string;
  transportCode?: string;
}

// Main Order Details DTO
export interface OrderDetailsDto {
  orderNumber: string;
  clientCnpj: string;
  clientRazaoSocial: string;
  inclusionDate?: string;
  establishment?: string;
  clientCode?: string;
  transportDescription?: string;
  lastUpdateDate?: string;
  clientOrderNumber?: string;
  post?: string;
  totalOrderValue?: number;
  commercialConditionDescription?: string;
  billingStatusDescription?: string;
  orderStatusCode?: string;
  orderStatusDescription?: string;
  requiredDate?: string;
  items: OrderItemDto[];
  observations: OrderObservationDto[];
  blocks: OrderBlockDto[];
  invoices: OrderInvoiceDto[];
  autoLoadItems?: boolean;
  autoLoadObservations?: boolean;
  autoLoadBlocks?: boolean;
  autoLoadInvoices?: boolean;
  statePersistence?: OrderDetailStatePersistenceDto;
}

/**
 * Error response from API
 */
export interface ApiErrorResponse {
  message: string;
  code?: string;
  details?: any;
  timestamp?: string;
  traceId?: string;
}

/**
 * API base URL
 */
const API_BASE_URL = "/api/OrderDetails";

/**
 * Helper to handle API errors and throw user-friendly messages.
 */
function handleApiError(error: any): never {
  if (axios.isAxiosError(error)) {
    const err = error as AxiosError<ApiErrorResponse>;
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
 * Get all order details, including client info, items, observations, blocks, invoices, and persisted state.
 */
export async function getOrderDetails(orderNumber: string): Promise<OrderDetailsDto> {
  try {
    const response = await axios.get<OrderDetailsDto>(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}`);
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Update and get the latest list of items for a given order.
 */
export async function updateOrderItems(orderNumber: string): Promise<OrderItemDto[]> {
  try {
    const response = await axios.get<OrderItemDto[]>(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/items`);
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Update and get the latest list of observations for a given order.
 */
export async function updateOrderObservations(orderNumber: string): Promise<OrderObservationDto[]> {
  try {
    const response = await axios.get<OrderObservationDto[]>(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/observations`);
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Update and get the latest list of blocks for a given order.
 */
export async function updateOrderBlocks(orderNumber: string): Promise<OrderBlockDto[]> {
  try {
    const response = await axios.get<OrderBlockDto[]>(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/blocks`);
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Update and get the latest list of invoices for a given order.
 */
export async function updateOrderInvoices(orderNumber: string): Promise<OrderInvoiceDto[]> {
  try {
    const response = await axios.get<OrderInvoiceDto[]>(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/invoices`);
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Export the specified list type (items, observations, blocks, invoices) for a given order to an Excel file.
 * Returns a Blob for download.
 */
export async function exportListToExcel(orderNumber: string, listType: "items" | "observations" | "blocks" | "invoices"): Promise<Blob> {
  try {
    const response = await axios.get(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/export/${listType}`, {
      responseType: "blob",
    });
    return response.data as Blob;
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Persist the state of list view positions and checkbox values for a given order.
 */
export async function persistState(orderNumber: string, state: OrderDetailStatePersistenceDto): Promise<void> {
  try {
    await axios.post(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/state`, state);
  } catch (error) {
    handleApiError(error);
  }
}

/**
 * Retrieve the persisted state of list view positions and checkbox values for a given order.
 */
export async function getPersistedState(orderNumber: string): Promise<OrderDetailStatePersistenceDto> {
  try {
    const response = await axios.get<OrderDetailStatePersistenceDto>(`${API_BASE_URL}/${encodeURIComponent(orderNumber)}/state`);
    return response.data;
  } catch (error) {
    handleApiError(error);
  }
}

export default {
  getOrderDetails,
  updateOrderItems,
  updateOrderObservations,
  updateOrderBlocks,
  updateOrderInvoices,
  exportListToExcel,
  persistState,
  getPersistedState,
};