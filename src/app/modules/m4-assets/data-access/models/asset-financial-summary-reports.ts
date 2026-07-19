export interface AssetFinancialSummaryReport {
  id: number;
  schoolId: number;
  fiscalYear: string;
  reportDate: string;
  reportType: string;
  assetCategoryId: number | null;
  totalBookValue: number;
  totalDepreciation: number;
  totalAssetsCount: number;
  totalAcquisitionCost: number;
  fullyDepreciatedAssetsCount: number;
  assetsWithImpairmentCount: number;
  revaluationGains: string | null;
  revaluationLosses: string | null;
  auditStatus: string;
  auditFirmName: string | null;
  auditorName: string | null;
  auditDate: string | null;
  auditorSignature: string | null;
  notes: string | null;
}

export type CreateAssetFinancialSummaryReportRequest = Omit<AssetFinancialSummaryReport, 'id'>;
export type UpdateAssetFinancialSummaryReportRequest = AssetFinancialSummaryReport;
