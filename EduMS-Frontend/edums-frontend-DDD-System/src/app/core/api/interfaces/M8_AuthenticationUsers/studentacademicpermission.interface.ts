export interface CreateStudentAcademicPermissionPayload {
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    isTimeBound: boolean;
    allowedWindowDays?: string;
    requiresLockOverride: boolean;
    requiresSupervisorApproval: boolean;
    allowedRolesJson?: string;
    isActive: boolean;
    notes?: string;
}

export interface StudentAcademicPermission {
    id: number;
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    isTimeBound: boolean;
    allowedWindowDays?: string;
    requiresLockOverride: boolean;
    requiresSupervisorApproval: boolean;
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

export interface UpdateStudentAcademicPermissionPayload {
    id?: number;
    schoolId?: number;
    permissionKey?: string;
    permissionNameAr?: string;
    permissionNameEn?: string;
    category?: string;
    isTimeBound?: boolean;
    allowedWindowDays?: string;
    requiresLockOverride?: boolean;
    requiresSupervisorApproval?: boolean;
    allowedRolesJson?: string;
    isActive?: boolean;
    notes?: string;
}
