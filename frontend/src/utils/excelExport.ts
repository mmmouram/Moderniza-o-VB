/**
 * Utility functions for exporting data to Excel in the modernized Order Details form.
 * 
 * This module provides a single function: downloadExcelFile(blob, fileName)
 * which triggers a download of an Excel file (Blob) with the specified file name.
 * 
 * This is used in the "Exportar para Excel" functionality in each tab of the order details form.
 * 
 * All logic for generating the Excel file is handled by the backend API.
 * This utility only handles the download in the browser.
 */

export class ExcelExportUtils {
  /**
   * Triggers a download of a Blob (Excel file) with the given file name.
   * @param blob The Blob object containing the Excel file data.
   * @param fileName The desired file name for the download (should end with .xlsx).
   */
  static downloadExcelFile(blob: Blob, fileName: string): void {
    // Create a temporary URL for the blob
    const url = window.URL.createObjectURL(blob);

    // Create a temporary anchor element
    const a = document.createElement("a");
    a.href = url;
    a.download = fileName;

    // Append to body, trigger click, and remove
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);

    // Revoke the object URL after a short delay
    setTimeout(() => {
      window.URL.revokeObjectURL(url);
    }, 100);
  }
}

/**
 * Shorthand function for downloading an Excel file.
 * @param blob The Blob object containing the Excel file data.
 * @param fileName The desired file name for the download (should end with .xlsx).
 */
export function downloadExcelFile(blob: Blob, fileName: string): void {
  ExcelExportUtils.downloadExcelFile(blob, fileName);
}

export default {
  downloadExcelFile,
  ExcelExportUtils,
};