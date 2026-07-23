export interface AssetStatusRecord {
    id: number;
    schoolId?: number;
    statusCode: string;
    statusNameAr: string;
    statusNameEn?: string;
    statusType: number;
    isOperational: boolean;
    isAvailableForAssignment: boolean;
    requiresApprovalToEnter: boolean;
    colorCode?: string;
    isActive: boolean;
    isSystemStatus: boolean;
    sortOrder: number;
    descriptionAr?: string;
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

export interface CreateAssetStatusRecordPayload {
    schoolId?: number;
    statusCode: string;
    statusNameAr: string;
    statusNameEn?: string;
    statusType: number;
    isOperational: boolean;
    isAvailableForAssignment: boolean;
    requiresApprovalToEnter: boolean;
    colorCode?: string;
    isActive: boolean;
    isSystemStatus: boolean;
    sortOrder: number;
    descriptionAr?: string;
}

export interface UpdateAssetStatusRecordPayload {
    id?: number;
    schoolId?: number;
    statusCode?: string;
    statusNameAr?: string;
    statusNameEn?: string;
    statusType?: number;
    isOperational?: boolean;
    isAvailableForAssignment?: boolean;
    requiresApprovalToEnter?: boolean;
    colorCode?: string;
    isActive?: boolean;
    isSystemStatus?: boolean;
    sortOrder?: number;
    descriptionAr?: string;
}
