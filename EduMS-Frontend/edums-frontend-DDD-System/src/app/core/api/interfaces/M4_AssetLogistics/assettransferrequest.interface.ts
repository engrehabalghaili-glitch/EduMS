export interface AssetTransferRequest {
    id: number;
    assetId: number;
    schoolId: number;
    requestNumber: string;
    fromEntityType: number;
    fromEntityId: number;
    toEntityType: number;
    toEntityId: number;
    transferType: number;
    requestReason?: string;
    requestedByUserId?: number;
    requestDate: string;
    approvalStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    transferExecutionDate?: string;
    executedByUserId?: number;
    requestStatus: number;
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

export interface CreateAssetTransferRequestPayload {
    assetId: number;
    schoolId: number;
    requestNumber: string;
    fromEntityType: number;
    fromEntityId: number;
    toEntityType: number;
    toEntityId: number;
    transferType: number;
    requestReason?: string;
    requestedByUserId?: number;
    requestDate: string;
    approvalStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    transferExecutionDate?: string;
    executedByUserId?: number;
    requestStatus: number;
    notes?: string;
}

export interface UpdateAssetTransferRequestPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    requestNumber?: string;
    fromEntityType?: number;
    fromEntityId?: number;
    toEntityType?: number;
    toEntityId?: number;
    transferType?: number;
    requestReason?: string;
    requestedByUserId?: number;
    requestDate?: string;
    approvalStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    transferExecutionDate?: string;
    executedByUserId?: number;
    requestStatus?: number;
    notes?: string;
}
