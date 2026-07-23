export interface CreateStudentFinancePermissionPayload {
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    maxAmountLimit: number;
    maxDiscountPercentage: number;
    requiresDirectorApproval: boolean;
    requiresBoardApproval: boolean;
    allowedRolesJson?: string;
    isActive: boolean;
    notes?: string;
}

export interface StudentFinancePermission {
    id: number;
    schoolId: number;
    permissionKey: string;
    permissionNameAr: string;
    permissionNameEn?: string;
    category?: string;
    maxAmountLimit: number;
    maxDiscountPercentage: number;
    requiresDirectorApproval: boolean;
    requiresBoardApproval: boolean;
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

export interface UpdateStudentFinancePermissionPayload {
    id?: number;
    schoolId?: number;
    permissionKey?: string;
    permissionNameAr?: string;
    permissionNameEn?: string;
    category?: string;
    maxAmountLimit?: number;
    maxDiscountPercentage?: number;
    requiresDirectorApproval?: boolean;
    requiresBoardApproval?: boolean;
    allowedRolesJson?: string;
    isActive?: boolean;
    notes?: string;
}
