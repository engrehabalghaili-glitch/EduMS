export interface AssetProcurementPaymentLink {
    id: number;
    purchaseOrderId: number;
    paymentVoucherId: number;
    schoolId: number;
    paidAmount: number;
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

export interface CreateAssetProcurementPaymentLinkPayload {
    purchaseOrderId: number;
    paymentVoucherId: number;
    schoolId: number;
    paidAmount: number;
    notes?: string;
}

export interface UpdateAssetProcurementPaymentLinkPayload {
    id?: number;
    purchaseOrderId?: number;
    paymentVoucherId?: number;
    schoolId?: number;
    paidAmount?: number;
    notes?: string;
}
