export interface AssetMovementHistory {
    id: number;
    assetId: number;
    schoolId: number;
    actionType: string;
    actionDescription: string;
    oldValueJson?: string;
    newValueJson?: string;
    relatedEntityType?: string;
    relatedEntityId?: number;
    actionDate: string;
    performedByUserId: number;
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

export interface CreateAssetMovementHistoryPayload {
    assetId: number;
    schoolId: number;
    actionType: string;
    actionDescription: string;
    oldValueJson?: string;
    newValueJson?: string;
    relatedEntityType?: string;
    relatedEntityId?: number;
    actionDate: string;
    performedByUserId: number;
    notes?: string;
}

export interface UpdateAssetMovementHistoryPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    actionType?: string;
    actionDescription?: string;
    oldValueJson?: string;
    newValueJson?: string;
    relatedEntityType?: string;
    relatedEntityId?: number;
    actionDate?: string;
    performedByUserId?: number;
    notes?: string;
}
