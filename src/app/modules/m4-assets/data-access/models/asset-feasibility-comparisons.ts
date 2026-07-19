export interface AssetFeasibilityComparison {
  id: number;
  assetId: number;
  schoolId: number;
  comparisonDate: string;
  repairEstimate: number;
  repairEstimateBreakdownJson: string | null;
  replacementCost: number;
  replacementCostBreakdownJson: string | null;
  tcoAnalysisJson: string | null;
  recommendation: number;
  recommendationReason: string | null;
  decisionStatus: number;
  decisionDate: string | null;
  approvedByUserId: number | null;
  notes: string | null;
}

export type CreateAssetFeasibilityComparisonRequest = Omit<AssetFeasibilityComparison, 'id'>;
export type UpdateAssetFeasibilityComparisonRequest = AssetFeasibilityComparison;
