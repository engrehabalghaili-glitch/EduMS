export interface PurchaseOrder {
  id: number;
  schoolId: number;
  poNumber: string;
  poDate: string;
  requirementRequestId: number | null;
  supplierName: string;
  supplierContact: string | null;
  totalAmount: number;
  taxAmount: number;
  paymentTerms: string | null;
  deliveryDeadline: string | null;
  actualDeliveryDate: string | null;
  approvedByUserId: number | null;
  approvalDate: string | null;
  poStatus: number;
  budgetAllocationId: number | null;
  attachmentUrl: string | null;
  notes: string | null;
}

export type CreatePurchaseOrderRequest = Omit<PurchaseOrder, 'id'>;
export type UpdatePurchaseOrderRequest = PurchaseOrder;
