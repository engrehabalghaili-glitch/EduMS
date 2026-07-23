export interface CreateSystemPermissionPayload {
    permissionKey: string;
    module: string;
    subModule?: string;
    actionType?: string;
    permissionTypeId?: number;
    defaultScope?: string;
    nameAr: string;
    nameEn?: string;
    descriptionAr?: string;
    riskLevel?: string;
    isSensitive: boolean;
    requiresLogging: boolean;
    conditionsJson?: string;
    isActive: boolean;
}

export interface SystemPermission {
    id: number;
    permissionKey: string;
    module: string;
    subModule?: string;
    actionType?: string;
    permissionTypeId?: number;
    defaultScope?: string;
    nameAr: string;
    nameEn?: string;
    descriptionAr?: string;
    riskLevel?: string;
    isSensitive: boolean;
    requiresLogging: boolean;
    conditionsJson?: string;
    isActive: boolean;
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

export interface UpdateSystemPermissionPayload {
    id?: number;
    permissionKey?: string;
    module?: string;
    subModule?: string;
    actionType?: string;
    permissionTypeId?: number;
    defaultScope?: string;
    nameAr?: string;
    nameEn?: string;
    descriptionAr?: string;
    riskLevel?: string;
    isSensitive?: boolean;
    requiresLogging?: boolean;
    conditionsJson?: string;
    isActive?: boolean;
}
