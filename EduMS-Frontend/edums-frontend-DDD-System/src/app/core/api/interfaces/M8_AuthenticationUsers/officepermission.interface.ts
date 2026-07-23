export interface CreateOfficePermissionPayload {
    officeId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    scopeType?: string;
    scopeTargetJson?: string;
    canOverrideSchoolDecision: boolean;
    isReadOnly: boolean;
    allowedRolesJson?: string;
    isActive: boolean;
    notes?: string;
}

export interface OfficePermission {
    id: number;
    officeId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    scopeType?: string;
    scopeTargetJson?: string;
    canOverrideSchoolDecision: boolean;
    isReadOnly: boolean;
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

export interface UpdateOfficePermissionPayload {
    id?: number;
    officeId?: number;
    permissionKey?: string;
    permissionNameAr?: string;
    permissionNameEn?: string;
    scopeType?: string;
    scopeTargetJson?: string;
    canOverrideSchoolDecision?: boolean;
    isReadOnly?: boolean;
    allowedRolesJson?: string;
    isActive?: boolean;
    notes?: string;
}
