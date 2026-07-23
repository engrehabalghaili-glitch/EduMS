export interface AssetFeasibilityComparison {
    id: number;
    assetId: number;
    schoolId: number;
    comparisonDate: string;
    repairEstimate: number;
    repairEstimateBreakdownJson?: string;
    replacementCost: number;
    replacementCostBreakdownJson?: string;
    tcoAnalysisJson?: string;
    recommendation: number;
    recommendationReason?: string;
    decisionStatus: number;
    decisionDate?: string;
    approvedByUserId?: number;
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

export interface CreateAssetFeasibilityComparisonPayload {
    assetId: number;
    schoolId: number;
    comparisonDate: string;
    repairEstimate: number;
    repairEstimateBreakdownJson?: string;
    replacementCost: number;
    replacementCostBreakdownJson?: string;
    tcoAnalysisJson?: string;
    recommendation: number;
    recommendationReason?: string;
    decisionStatus: number;
    decisionDate?: string;
    approvedByUserId?: number;
    notes?: string;
}

export interface UpdateAssetFeasibilityComparisonPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    comparisonDate?: string;
    repairEstimate?: number;
    repairEstimateBreakdownJson?: string;
    replacementCost?: number;
    replacementCostBreakdownJson?: string;
    tcoAnalysisJson?: string;
    recommendation?: number;
    recommendationReason?: string;
    decisionStatus?: number;
    decisionDate?: string;
    approvedByUserId?: number;
    notes?: string;
}
