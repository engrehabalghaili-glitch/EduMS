export interface BehaviorPermissionRecord {
    id: number;
    schoolId?: number;
    roleId?: number;
    category: string;
    subCategory?: string;
    permissionKey: string;
    allowedActionsJson?: string;
    scope?: string;
    isSensitive: boolean;
    requiresJustification: boolean;
    justificationApprovalRequired: boolean;
    descriptionAr?: string;
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

export interface CreateBehaviorPermissionRecordPayload {
    schoolId?: number;
    roleId?: number;
    category: string;
    subCategory?: string;
    permissionKey: string;
    allowedActionsJson?: string;
    scope?: string;
    isSensitive: boolean;
    requiresJustification: boolean;
    justificationApprovalRequired: boolean;
    descriptionAr?: string;
    isActive: boolean;
}

export interface UpdateBehaviorPermissionRecordPayload {
    id?: number;
    schoolId?: number;
    roleId?: number;
    category?: string;
    subCategory?: string;
    permissionKey?: string;
    allowedActionsJson?: string;
    scope?: string;
    isSensitive?: boolean;
    requiresJustification?: boolean;
    justificationApprovalRequired?: boolean;
    descriptionAr?: string;
    isActive?: boolean;
}
