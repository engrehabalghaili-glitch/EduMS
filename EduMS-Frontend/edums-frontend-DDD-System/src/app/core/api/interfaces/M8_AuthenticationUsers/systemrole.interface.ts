export interface CreateSystemRolePayload {
    roleCode: string;
    roleNameAr: string;
    roleNameEn?: string;
    roleType: number;
    hierarchyLevel: number;
    parentRoleId?: number;
    isInheritable: boolean;
    isAssignable: boolean;
    isSystem: boolean;
    isActive: boolean;
    descriptionAr?: string;
}

export interface SystemRole {
    id: number;
    roleCode: string;
    roleNameAr: string;
    roleNameEn?: string;
    roleType: number;
    hierarchyLevel: number;
    parentRoleId?: number;
    isInheritable: boolean;
    isAssignable: boolean;
    isSystem: boolean;
    isActive: boolean;
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

export interface UpdateSystemRolePayload {
    id?: number;
    roleCode?: string;
    roleNameAr?: string;
    roleNameEn?: string;
    roleType?: number;
    hierarchyLevel?: number;
    parentRoleId?: number;
    isInheritable?: boolean;
    isAssignable?: boolean;
    isSystem?: boolean;
    isActive?: boolean;
    descriptionAr?: string;
}
