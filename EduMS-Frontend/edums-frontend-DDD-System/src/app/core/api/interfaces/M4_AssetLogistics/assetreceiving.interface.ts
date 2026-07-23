export interface AssetReceiving {
    id: number;
    schoolId: number;
    purchaseOrderId: number;
    receivingNumber: string;
    receivedDate: string;
    receivedByEmployeeId: number;
    inspectorEmployeeId?: number;
    deliveryNoteNumber?: string;
    deliveryCompany?: string;
    inspectionResult: number;
    inspectionDate?: string;
    inspectionNotes?: string;
    deliveryStatus: number;
    receivedItemsDetailsJson?: string;
    rejectedItemsJson?: string;
    returnRequested: boolean;
    returnDate?: string;
    finalDecision: number;
    attachmentsJson?: string;
    receivingStatus: number;
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

export interface CreateAssetReceivingPayload {
    schoolId: number;
    purchaseOrderId: number;
    receivingNumber: string;
    receivedDate: string;
    receivedByEmployeeId: number;
    inspectorEmployeeId?: number;
    deliveryNoteNumber?: string;
    deliveryCompany?: string;
    inspectionResult: number;
    inspectionDate?: string;
    inspectionNotes?: string;
    deliveryStatus: number;
    receivedItemsDetailsJson?: string;
    rejectedItemsJson?: string;
    returnRequested: boolean;
    returnDate?: string;
    finalDecision: number;
    attachmentsJson?: string;
    receivingStatus: number;
    notes?: string;
}

export interface UpdateAssetReceivingPayload {
    id?: number;
    schoolId?: number;
    purchaseOrderId?: number;
    receivingNumber?: string;
    receivedDate?: string;
    receivedByEmployeeId?: number;
    inspectorEmployeeId?: number;
    deliveryNoteNumber?: string;
    deliveryCompany?: string;
    inspectionResult?: number;
    inspectionDate?: string;
    inspectionNotes?: string;
    deliveryStatus?: number;
    receivedItemsDetailsJson?: string;
    rejectedItemsJson?: string;
    returnRequested?: boolean;
    returnDate?: string;
    finalDecision?: number;
    attachmentsJson?: string;
    receivingStatus?: number;
    notes?: string;
}
