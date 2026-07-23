export interface AssetInspectionLog {
    id: number;
    assetId: number;
    schoolId: number;
    relatedTransactionType: string;
    relatedTransactionId?: number;
    inspectionType: number;
    inspectionDate: string;
    inspectorUserId: number;
    physicalCondition: number;
    damageDetails?: string;
    damagePhotosJson?: string;
    functionalStatus: number;
    missingPartsJson?: string;
    inspectionResult: number;
    recommendedAction?: string;
    estimatedRepairCost: number;
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

export interface CreateAssetInspectionLogPayload {
    assetId: number;
    schoolId: number;
    relatedTransactionType: string;
    relatedTransactionId?: number;
    inspectionType: number;
    inspectionDate: string;
    inspectorUserId: number;
    physicalCondition: number;
    damageDetails?: string;
    damagePhotosJson?: string;
    functionalStatus: number;
    missingPartsJson?: string;
    inspectionResult: number;
    recommendedAction?: string;
    estimatedRepairCost: number;
    notes?: string;
}

export interface UpdateAssetInspectionLogPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    relatedTransactionType?: string;
    relatedTransactionId?: number;
    inspectionType?: number;
    inspectionDate?: string;
    inspectorUserId?: number;
    physicalCondition?: number;
    damageDetails?: string;
    damagePhotosJson?: string;
    functionalStatus?: number;
    missingPartsJson?: string;
    inspectionResult?: number;
    recommendedAction?: string;
    estimatedRepairCost?: number;
    notes?: string;
}
