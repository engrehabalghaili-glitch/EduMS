export interface CreateRolePermissionPayload {
    roleId: number;
    permissionId: number;
    scopeOverride?: string;
    isInherited: boolean;
    inheritedFromRoleId?: number;
    isActive: boolean;
    startDate?: string;
    endDate?: string;
    grantedByUserId?: number;
    grantedAt?: string;
    notes?: string;
}

export interface RolePermission {
    id: number;
    roleId: number;
    permissionId: number;
    scopeOverride?: string;
    isInherited: boolean;
    inheritedFromRoleId?: number;
    isActive: boolean;
    startDate?: string;
    endDate?: string;
    grantedByUserId?: number;
    grantedAt?: string;
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

export interface UpdateRolePermissionPayload {
    id?: number;
    roleId?: number;
    permissionId?: number;
    scopeOverride?: string;
    isInherited?: boolean;
    inheritedFromRoleId?: number;
    isActive?: boolean;
    startDate?: string;
    endDate?: string;
    grantedByUserId?: number;
    grantedAt?: string;
    notes?: string;
}
