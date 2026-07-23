export interface BehaviorPermission {
    id: number;
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    isConfidential: boolean;
    requiresSocialWorkerRole: boolean;
    allowedRolesJson?: string;
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

export interface CreateBehaviorPermissionPayload {
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    isConfidential: boolean;
    requiresSocialWorkerRole: boolean;
    allowedRolesJson?: string;
    isActive: boolean;
    notes?: string;
}

export interface UpdateBehaviorPermissionPayload {
    id?: number;
    schoolId?: number;
    permissionKey?: string;
    permissionNameAr?: string;
    permissionNameEn?: string;
    category?: string;
    isConfidential?: boolean;
    requiresSocialWorkerRole?: boolean;
    allowedRolesJson?: string;
    isActive?: boolean;
    notes?: string;
}
