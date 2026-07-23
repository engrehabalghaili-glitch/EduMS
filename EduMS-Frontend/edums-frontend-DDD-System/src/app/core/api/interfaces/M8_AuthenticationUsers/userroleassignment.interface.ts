export interface CreateUserRoleAssignmentPayload {
    userId: number;
    roleId: number;
    schoolId?: number;
    isPrimary: boolean;
    scopeContextJson?: string;
    startDate?: string;
    endDate?: string;
    isActive: boolean;
    assignedByUserId?: number;
    assignedAt?: string;
    notes?: string;
}

export interface UpdateUserRoleAssignmentPayload {
    id?: number;
    userId?: number;
    roleId?: number;
    schoolId?: number;
    isPrimary?: boolean;
    scopeContextJson?: string;
    startDate?: string;
    endDate?: string;
    isActive?: boolean;
    assignedByUserId?: number;
    assignedAt?: string;
    notes?: string;
}

export interface UserRoleAssignment {
    id: number;
    userId: number;
    roleId: number;
    schoolId?: number;
    isPrimary: boolean;
    scopeContextJson?: string;
    startDate?: string;
    endDate?: string;
    isActive: boolean;
    assignedByUserId?: number;
    assignedAt?: string;
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
