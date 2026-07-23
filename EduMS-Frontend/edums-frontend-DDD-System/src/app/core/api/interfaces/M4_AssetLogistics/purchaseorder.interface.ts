export interface CreatePurchaseOrderPayload {
    schoolId: number;
    poNumber: string;
    poDate: string;
    requirementRequestId?: number;
    supplierName: string;
    supplierContact?: string;
    totalAmount: number;
    taxAmount: number;
    paymentTerms?: string;
    deliveryDeadline?: string;
    actualDeliveryDate?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    poStatus: number;
    budgetAllocationId?: number;
    attachmentUrl?: string;
    notes?: string;
}

export interface PurchaseOrder {
    id: number;
    schoolId: number;
    poNumber: string;
    poDate: string;
    requirementRequestId?: number;
    supplierName: string;
    supplierContact?: string;
    totalAmount: number;
    taxAmount: number;
    paymentTerms?: string;
    deliveryDeadline?: string;
    actualDeliveryDate?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    poStatus: number;
    budgetAllocationId?: number;
    attachmentUrl?: string;
    notes?: string;
    createdAt: string;
    createdByUserId: number;
    modifiedAt?: string;
    modifiedByUserId?: number;
    isDeleted: boolean;
    deletedAt?: string;
    deletedByUserId?: number;
    versionToken: string;
    lastSyncedAt?: string;
    syncStatus: string;
}

export interface UpdatePurchaseOrderPayload {
    id?: number;
    schoolId?: number;
    poNumber?: string;
    poDate?: string;
    requirementRequestId?: number;
    supplierName?: string;
    supplierContact?: string;
    totalAmount?: number;
    taxAmount?: number;
    paymentTerms?: string;
    deliveryDeadline?: string;
    actualDeliveryDate?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    poStatus?: number;
    budgetAllocationId?: number;
    attachmentUrl?: string;
    notes?: string;
}
