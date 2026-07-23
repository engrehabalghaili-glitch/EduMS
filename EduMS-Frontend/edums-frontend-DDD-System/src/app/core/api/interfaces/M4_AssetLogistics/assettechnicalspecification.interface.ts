export interface AssetTechnicalSpecification {
    id: number;
    schoolId?: number;
    specCode: string;
    specNameAr: string;
    specNameEn?: string;
    assetCategoryId?: number;
    assetTypeDescription?: string;
    technicalDetailsJson?: string;
    requiredCertifications?: string;
    acceptanceCriteria?: string;
    qualityStandards?: string;
    warrantyRequirements?: string;
    safetyRequirements?: string;
    isActive: boolean;
    validFrom?: string;
    validTo?: string;
    specVersion: string;
    attachmentsJson?: string;
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

export interface CreateAssetTechnicalSpecificationPayload {
    schoolId?: number;
    specCode: string;
    specNameAr: string;
    specNameEn?: string;
    assetCategoryId?: number;
    assetTypeDescription?: string;
    technicalDetailsJson?: string;
    requiredCertifications?: string;
    acceptanceCriteria?: string;
    qualityStandards?: string;
    warrantyRequirements?: string;
    safetyRequirements?: string;
    isActive: boolean;
    validFrom?: string;
    validTo?: string;
    specVersion: string;
    attachmentsJson?: string;
    notes?: string;
}

export interface UpdateAssetTechnicalSpecificationPayload {
    id?: number;
    schoolId?: number;
    specCode?: string;
    specNameAr?: string;
    specNameEn?: string;
    assetCategoryId?: number;
    assetTypeDescription?: string;
    technicalDetailsJson?: string;
    requiredCertifications?: string;
    acceptanceCriteria?: string;
    qualityStandards?: string;
    warrantyRequirements?: string;
    safetyRequirements?: string;
    isActive?: boolean;
    validFrom?: string;
    validTo?: string;
    specVersion?: string;
    attachmentsJson?: string;
    notes?: string;
}
