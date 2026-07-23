export interface CreatePermissionTypePayload {
    typeCode: string;
    typeNameAr: string;
    typeNameEn?: string;
    category?: string;
    scopeType?: string;
    riskLevel?: string;
    requiresApproval: boolean;
    approvalLevel?: string;
    descriptionAr?: string;
    isActive: boolean;
    isSystem: boolean;
    sortOrder: number;
}

export interface PermissionType {
    id: number;
    typeCode: string;
    typeNameAr: string;
    typeNameEn?: string;
    category?: string;
    scopeType?: string;
    riskLevel?: string;
    requiresApproval: boolean;
    approvalLevel?: string;
    descriptionAr?: string;
    isActive: boolean;
    isSystem: boolean;
    sortOrder: number;
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

export interface UpdatePermissionTypePayload {
    id?: number;
    typeCode?: string;
    typeNameAr?: string;
    typeNameEn?: string;
    category?: string;
    scopeType?: string;
    riskLevel?: string;
    requiresApproval?: boolean;
    approvalLevel?: string;
    descriptionAr?: string;
    isActive?: boolean;
    isSystem?: boolean;
    sortOrder?: number;
}
