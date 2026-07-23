export interface CreateFeeInvoicePayload {
    studentId: number;
    feeStructureId: number;
    invoiceNumber: string;
    totalAmount: number;
    paidAmount: number;
    dueDate: string;
    status: number;
}

export interface FeeInvoice {
    id: number;
    studentId: number;
    feeStructureId: number;
    invoiceNumber: string;
    totalAmount: number;
    paidAmount: number;
    dueDate: string;
    status: number;
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

export interface UpdateFeeInvoicePayload {
    id?: number;
    studentId?: number;
    feeStructureId?: number;
    invoiceNumber?: string;
    totalAmount?: number;
    paidAmount?: number;
    dueDate?: string;
    status?: number;
}
