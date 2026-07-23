export interface AssetFeasibilityRiskAnalysis {
    id: number;
    schoolId: number;
    requirementRequestId?: number;
    analysisNumber: string;
    analysisDate: string;
    analystEmployeeId?: number;
    operationalRisks?: string;
    financialRisks?: string;
    riskLevel: number;
    riskMitigationPlan?: string;
    usefulLifeEstimateYears: number;
    roiEstimatePercent: number;
    npvEstimate: number;
    alternativeSolutions?: string;
    finalRecommendation: number;
    recommendationReason?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    analysisStatus: number;
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

export interface CreateAssetFeasibilityRiskAnalysisPayload {
    schoolId: number;
    requirementRequestId?: number;
    analysisNumber: string;
    analysisDate: string;
    analystEmployeeId?: number;
    operationalRisks?: string;
    financialRisks?: string;
    riskLevel: number;
    riskMitigationPlan?: string;
    usefulLifeEstimateYears: number;
    roiEstimatePercent: number;
    npvEstimate: number;
    alternativeSolutions?: string;
    finalRecommendation: number;
    recommendationReason?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    analysisStatus: number;
    attachmentsJson?: string;
    notes?: string;
}

export interface UpdateAssetFeasibilityRiskAnalysisPayload {
    id?: number;
    schoolId?: number;
    requirementRequestId?: number;
    analysisNumber?: string;
    analysisDate?: string;
    analystEmployeeId?: number;
    operationalRisks?: string;
    financialRisks?: string;
    riskLevel?: number;
    riskMitigationPlan?: string;
    usefulLifeEstimateYears?: number;
    roiEstimatePercent?: number;
    npvEstimate?: number;
    alternativeSolutions?: string;
    finalRecommendation?: number;
    recommendationReason?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    analysisStatus?: number;
    attachmentsJson?: string;
    notes?: string;
}
