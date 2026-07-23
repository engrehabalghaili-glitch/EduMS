export interface AssetFinancialSummaryReport {
    id: number;
    schoolId: number;
    fiscalYear: string;
    reportDate: string;
    reportType: string;
    assetCategoryId?: number;
    totalBookValue: number;
    totalDepreciation: number;
    totalAssetsCount: number;
    totalAcquisitionCost: number;
    fullyDepreciatedAssetsCount: number;
    assetsWithImpairmentCount: number;
    revaluationGains?: string;
    revaluationLosses?: string;
    auditStatus: string;
    auditFirmName?: string;
    auditorName?: string;
    auditDate?: string;
    auditorSignature?: string;
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

export interface CreateAssetFinancialSummaryReportPayload {
    schoolId: number;
    fiscalYear: string;
    reportDate: string;
    reportType: string;
    assetCategoryId?: number;
    totalBookValue: number;
    totalDepreciation: number;
    totalAssetsCount: number;
    totalAcquisitionCost: number;
    fullyDepreciatedAssetsCount: number;
    assetsWithImpairmentCount: number;
    revaluationGains?: string;
    revaluationLosses?: string;
    auditStatus: string;
    auditFirmName?: string;
    auditorName?: string;
    auditDate?: string;
    auditorSignature?: string;
    notes?: string;
}

export interface UpdateAssetFinancialSummaryReportPayload {
    id?: number;
    schoolId?: number;
    fiscalYear?: string;
    reportDate?: string;
    reportType?: string;
    assetCategoryId?: number;
    totalBookValue?: number;
    totalDepreciation?: number;
    totalAssetsCount?: number;
    totalAcquisitionCost?: number;
    fullyDepreciatedAssetsCount?: number;
    assetsWithImpairmentCount?: number;
    revaluationGains?: string;
    revaluationLosses?: string;
    auditStatus?: string;
    auditFirmName?: string;
    auditorName?: string;
    auditDate?: string;
    auditorSignature?: string;
    notes?: string;
}
