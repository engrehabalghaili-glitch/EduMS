export interface CreateStudentBasePermissionPayload {
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    requiresPrincipalApproval: boolean;
    requiresGuardianConsent: boolean;
    isSensitive: boolean;
    allowedRolesJson?: string;
    isActive: boolean;
    notes?: string;
}

export interface StudentBasePermission {
    id: number;
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    requiresPrincipalApproval: boolean;
    requiresGuardianConsent: boolean;
    isSensitive: boolean;
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

export interface UpdateStudentBasePermissionPayload {
    id?: number;
    schoolId?: number;
    permissionKey?: string;
    permissionNameAr?: string;
    permissionNameEn?: string;
    category?: string;
    requiresPrincipalApproval?: boolean;
    requiresGuardianConsent?: boolean;
    isSensitive?: boolean;
    allowedRolesJson?: string;
    isActive?: boolean;
    notes?: string;
}
