export interface CreateGapAnalysisReportPayload {
    schoolId: number;
    analysisNumber: string;
    analysisType: string;
    assetCategoryId?: number;
    gradeCapacityId?: number;
    departmentId?: number;
    requiredQuantity: number;
    availableQuantity: number;
    gapValue: number;
    gapPercentage: number;
    gapType?: string;
    recommendation?: string;
    priority: number;
    estimatedCost: number;
    analysisDate: string;
    analyzedByUserId?: number;
    filePath?: string;
    analysisStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface GapAnalysisReport {
    id: number;
    schoolId: number;
    analysisNumber: string;
    analysisType: string;
    assetCategoryId?: number;
    gradeCapacityId?: number;
    departmentId?: number;
    requiredQuantity: number;
    availableQuantity: number;
    gapValue: number;
    gapPercentage: number;
    gapType?: string;
    recommendation?: string;
    priority: number;
    estimatedCost: number;
    analysisDate: string;
    analyzedByUserId?: number;
    filePath?: string;
    analysisStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
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

export interface UpdateGapAnalysisReportPayload {
    id?: number;
    schoolId?: number;
    analysisNumber?: string;
    analysisType?: string;
    assetCategoryId?: number;
    gradeCapacityId?: number;
    departmentId?: number;
    requiredQuantity?: number;
    availableQuantity?: number;
    gapValue?: number;
    gapPercentage?: number;
    gapType?: string;
    recommendation?: string;
    priority?: number;
    estimatedCost?: number;
    analysisDate?: string;
    analyzedByUserId?: number;
    filePath?: string;
    analysisStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
