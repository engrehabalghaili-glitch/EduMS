export interface AssetFinancialAuditArchive {
    id: number;
    schoolId: number;
    reportType: number;
    fiscalYear: string;
    periodStart?: string;
    periodEnd?: string;
    generationDate: string;
    archivedDate: string;
    totalAssetsValue: number;
    totalDepreciationValue: number;
    reportFileUrl?: string;
    isReadOnly: boolean;
    auditStatus?: string;
    auditFirmName?: string;
    auditDate?: string;
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

export interface CreateAssetFinancialAuditArchivePayload {
    schoolId: number;
    reportType: number;
    fiscalYear: string;
    periodStart?: string;
    periodEnd?: string;
    generationDate: string;
    archivedDate: string;
    totalAssetsValue: number;
    totalDepreciationValue: number;
    reportFileUrl?: string;
    isReadOnly: boolean;
    auditStatus?: string;
    auditFirmName?: string;
    auditDate?: string;
    notes?: string;
}

export interface UpdateAssetFinancialAuditArchivePayload {
    id?: number;
    schoolId?: number;
    reportType?: number;
    fiscalYear?: string;
    periodStart?: string;
    periodEnd?: string;
    generationDate?: string;
    archivedDate?: string;
    totalAssetsValue?: number;
    totalDepreciationValue?: number;
    reportFileUrl?: string;
    isReadOnly?: boolean;
    auditStatus?: string;
    auditFirmName?: string;
    auditDate?: string;
    notes?: string;
}
