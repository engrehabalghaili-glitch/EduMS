export interface CreateSchoolFinancialSummaryReportPayload {
    schoolId: number;
    fiscalYear: string;
    reportDate: string;
    reportType: number;
    totalBookValue: number;
    totalDepreciation: number;
    totalAssetsCount: number;
    totalAcquisitionCost: number;
    totalRevaluationGains: number;
    totalImpairmentLosses: number;
    totalRevenue: number;
    totalExpenses: number;
    netIncome: number;
    auditStatus?: string;
    auditFirmName?: string;
    auditDate?: string;
    approvalStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    filePath?: string;
    notes?: string;
}

export interface SchoolFinancialSummaryReport {
    id: number;
    schoolId: number;
    fiscalYear: string;
    reportDate: string;
    reportType: number;
    totalBookValue: number;
    totalDepreciation: number;
    totalAssetsCount: number;
    totalAcquisitionCost: number;
    totalRevaluationGains: number;
    totalImpairmentLosses: number;
    totalRevenue: number;
    totalExpenses: number;
    netIncome: number;
    auditStatus?: string;
    auditFirmName?: string;
    auditDate?: string;
    approvalStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    filePath?: string;
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

export interface UpdateSchoolFinancialSummaryReportPayload {
    id?: number;
    schoolId?: number;
    fiscalYear?: string;
    reportDate?: string;
    reportType?: number;
    totalBookValue?: number;
    totalDepreciation?: number;
    totalAssetsCount?: number;
    totalAcquisitionCost?: number;
    totalRevaluationGains?: number;
    totalImpairmentLosses?: number;
    totalRevenue?: number;
    totalExpenses?: number;
    netIncome?: number;
    auditStatus?: string;
    auditFirmName?: string;
    auditDate?: string;
    approvalStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    filePath?: string;
    notes?: string;
}
