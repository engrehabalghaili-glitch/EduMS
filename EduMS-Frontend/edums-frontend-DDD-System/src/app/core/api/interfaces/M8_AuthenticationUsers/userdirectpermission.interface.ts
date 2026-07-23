export interface CreateUserDirectPermissionPayload {
    userId: number;
    permissionId: number;
    schoolId?: number;
    scopeOverride?: string;
    isActive: boolean;
    startDate?: string;
    endDate?: string;
    grantedByUserId?: number;
    grantedAt?: string;
    reason?: string;
    notes?: string;
}

export interface UpdateUserDirectPermissionPayload {
    id?: number;
    userId?: number;
    permissionId?: number;
    schoolId?: number;
    scopeOverride?: string;
    isActive?: boolean;
    startDate?: string;
    endDate?: string;
    grantedByUserId?: number;
    grantedAt?: string;
    reason?: string;
    notes?: string;
}

export interface UserDirectPermission {
    id: number;
    userId: number;
    permissionId: number;
    schoolId?: number;
    scopeOverride?: string;
    isActive: boolean;
    startDate?: string;
    endDate?: string;
    grantedByUserId?: number;
    grantedAt?: string;
    reason?: string;
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
