export interface CreateRoleMatrixPayload {
    schoolId?: number;
    roleCode: string;
    roleNameAr: string;
    roleNameEn?: string;
    roleType: number;
    permissionsJson?: string;
    descriptionAr?: string;
    isActive: boolean;
    sortOrder: number;
}

export interface RoleMatrix {
    id: number;
    schoolId?: number;
    roleCode: string;
    roleNameAr: string;
    roleNameEn?: string;
    roleType: number;
    permissionsJson?: string;
    descriptionAr?: string;
    isActive: boolean;
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

export interface UpdateRoleMatrixPayload {
    id?: number;
    schoolId?: number;
    roleCode?: string;
    roleNameAr?: string;
    roleNameEn?: string;
    roleType?: number;
    permissionsJson?: string;
    descriptionAr?: string;
    isActive?: boolean;
    sortOrder?: number;
}
