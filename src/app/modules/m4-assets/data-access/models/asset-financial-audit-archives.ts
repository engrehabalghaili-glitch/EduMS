export interface AssetFinancialAuditArchive {
  id: number;
  schoolId: number;
  reportType: number;
  fiscalYear: string;
  periodStart: string | null;
  periodEnd: string | null;
  generationDate: string;
  archivedDate: string;
  totalAssetsValue: number;
  totalDepreciationValue: number;
  reportFileUrl: string | null;
  isReadOnly: boolean;
  auditStatus: string | null;
  auditFirmName: string | null;
  auditDate: string | null;
  notes: string | null;
}

export type CreateAssetFinancialAuditArchiveRequest = Omit<AssetFinancialAuditArchive, 'id'>;
export type UpdateAssetFinancialAuditArchiveRequest = AssetFinancialAuditArchive;
