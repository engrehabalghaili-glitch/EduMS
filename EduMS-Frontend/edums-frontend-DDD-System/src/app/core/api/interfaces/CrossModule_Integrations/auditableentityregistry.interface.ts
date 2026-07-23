export interface AuditableEntityRegistry {
    id: number;
    entityTypeKey: string;
    sourceModule: string;
    tableNameHint: string;
    entityNameAr: string;
    entityNameEn?: string;
    isSensitive: boolean;
    requiresApprovalToModify: boolean;
    isActive: boolean;
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

export interface CreateAuditableEntityRegistryPayload {
    entityTypeKey: string;
    sourceModule: string;
    tableNameHint: string;
    entityNameAr: string;
    entityNameEn?: string;
    isSensitive: boolean;
    requiresApprovalToModify: boolean;
    isActive: boolean;
    notes?: string;
}

export interface UpdateAuditableEntityRegistryPayload {
    id?: number;
    entityTypeKey?: string;
    sourceModule?: string;
    tableNameHint?: string;
    entityNameAr?: string;
    entityNameEn?: string;
    isSensitive?: boolean;
    requiresApprovalToModify?: boolean;
    isActive?: boolean;
    notes?: string;
}
