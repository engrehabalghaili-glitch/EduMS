export interface AssetCategory {
    id: number;
    schoolId?: number;
    parentCategoryId?: number;
    categoryCode: string;
    categoryNameAr: string;
    categoryNameEn?: string;
    categoryLevel: number;
    fullHierarchyPath?: string;
    descriptionAr?: string;
    defaultDepreciationRate: number;
    defaultDepreciationMethod: number;
    defaultUsefulLifeYears: number;
    isActive: boolean;
    isSystemCategory: boolean;
    sortOrder: number;
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

export interface CreateAssetCategoryPayload {
    schoolId?: number;
    parentCategoryId?: number;
    categoryCode: string;
    categoryNameAr: string;
    categoryNameEn?: string;
    categoryLevel: number;
    fullHierarchyPath?: string;
    descriptionAr?: string;
    defaultDepreciationRate: number;
    defaultDepreciationMethod: number;
    defaultUsefulLifeYears: number;
    isActive: boolean;
    isSystemCategory: boolean;
    sortOrder: number;
    notes?: string;
}

export interface UpdateAssetCategoryPayload {
    id?: number;
    schoolId?: number;
    parentCategoryId?: number;
    categoryCode?: string;
    categoryNameAr?: string;
    categoryNameEn?: string;
    categoryLevel?: number;
    fullHierarchyPath?: string;
    descriptionAr?: string;
    defaultDepreciationRate?: number;
    defaultDepreciationMethod?: number;
    defaultUsefulLifeYears?: number;
    isActive?: boolean;
    isSystemCategory?: boolean;
    sortOrder?: number;
    notes?: string;
}
