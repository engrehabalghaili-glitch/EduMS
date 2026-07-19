export interface AssetFeasibilityRiskAnalysis {
  id: number;
  schoolId: number;
  requirementRequestId: number | null;
  analysisNumber: string;
  analysisDate: string;
  analystEmployeeId: number | null;
  operationalRisks: string | null;
  financialRisks: string | null;
  riskLevel: number;
  riskMitigationPlan: string | null;
  usefulLifeEstimateYears: number;
  roiEstimatePercent: number;
  npvEstimate: number;
  alternativeSolutions: string | null;
  finalRecommendation: number;
  recommendationReason: string | null;
  approvedByUserId: number | null;
  approvalDate: string | null;
  analysisStatus: number;
  attachmentsJson: string | null;
  notes: string | null;
}

export type CreateAssetFeasibilityRiskAnalysisRequest = Omit<AssetFeasibilityRiskAnalysis, 'id'>;
export type UpdateAssetFeasibilityRiskAnalysisRequest = AssetFeasibilityRiskAnalysis;
