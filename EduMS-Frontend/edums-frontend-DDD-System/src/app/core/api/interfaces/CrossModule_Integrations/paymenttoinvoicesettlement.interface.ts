export interface CreatePaymentToInvoiceSettlementPayload {
    paymentVoucherId: number;
    feeInvoiceId: number;
    studentId: number;
    schoolId: number;
    allocatedAmount: number;
    notes?: string;
}

export interface PaymentToInvoiceSettlement {
    id: number;
    paymentVoucherId: number;
    feeInvoiceId: number;
    studentId: number;
    schoolId: number;
    allocatedAmount: number;
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

export interface UpdatePaymentToInvoiceSettlementPayload {
    id?: number;
    paymentVoucherId?: number;
    feeInvoiceId?: number;
    studentId?: number;
    schoolId?: number;
    allocatedAmount?: number;
    notes?: string;
}
