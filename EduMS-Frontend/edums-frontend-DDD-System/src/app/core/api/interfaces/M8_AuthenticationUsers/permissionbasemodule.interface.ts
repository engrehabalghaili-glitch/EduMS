export interface CreatePermissionBaseModulePayload {
    moduleCode: string;
    moduleNameAr: string;
    moduleNameEn?: string;
    sectionCode?: string;
    sectionNameAr?: string;
    sectionNameEn?: string;
    description?: string;
    defaultPermissionsJson?: string;
    isActive: boolean;
    sortOrder: number;
}

export interface PermissionBaseModule {
    id: number;
    moduleCode: string;
    moduleNameAr: string;
    moduleNameEn?: string;
    sectionCode?: string;
    sectionNameAr?: string;
    sectionNameEn?: string;
    description?: string;
    defaultPermissionsJson?: string;
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

export interface UpdatePermissionBaseModulePayload {
    id?: number;
    moduleCode?: string;
    moduleNameAr?: string;
    moduleNameEn?: string;
    sectionCode?: string;
    sectionNameAr?: string;
    sectionNameEn?: string;
    description?: string;
    defaultPermissionsJson?: string;
    isActive?: boolean;
    sortOrder?: number;
}
