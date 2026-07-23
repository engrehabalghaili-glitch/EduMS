export interface CreatePaymentVoucherPayload {
    schoolId: number;
    vendorId?: number;
    voucherNumber: string;
    voucherDate: string;
    totalAmount: number;
    paymentMethod: string;
    description: string;
    accountId?: number;
}

export interface PaymentVoucher {
    id: number;
    schoolId: number;
    vendorId?: number;
    voucherNumber: string;
    voucherDate: string;
    totalAmount: number;
    paymentMethod: string;
    description: string;
    accountId?: number;
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

export interface UpdatePaymentVoucherPayload {
    id?: number;
    schoolId?: number;
    vendorId?: number;
    voucherNumber?: string;
    voucherDate?: string;
    totalAmount?: number;
    paymentMethod?: string;
    description?: string;
    accountId?: number;
}
