export interface AssetRevaluationImpairment {
  id: number;
  assetId: number;
  schoolId: number;
  operationType: number;
  effectiveDate: string;
  oldBookValue: number;
  oldAccumulatedDepreciation: number;
  oldNetBookValue: number;
  newValue: number;
  newNetBookValue: number;
  differenceAmount: number;
  differenceType: number;
  valuationFirmName: string | null;
  valuationReportNumber: string | null;
  valuationReportDate: string | null;
  reason: string | null;
  attachmentUrl: string | null;
  approvedByUserId: number | null;
  approvalDate: string | null;
  operationStatus: number;
  notes: string | null;
}

export type CreateAssetRevaluationImpairmentRequest = Omit<AssetRevaluationImpairment, 'id'>;
export type UpdateAssetRevaluationImpairmentRequest = AssetRevaluationImpairment;
