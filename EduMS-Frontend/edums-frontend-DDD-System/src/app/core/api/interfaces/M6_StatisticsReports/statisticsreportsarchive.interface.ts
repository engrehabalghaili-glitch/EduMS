export interface CreateStatisticsReportsArchivePayload {
    sourceReportType: string;
    sourceReportId: number;
    schoolId: number;
    archivedAt: string;
    archivedByUserId: number;
    retentionPeriodYears: number;
    retentionEndDate?: string;
    filePath?: string;
    fileSizeBytes: number;
    isReadOnly: boolean;
    disposalDate?: string;
    disposalStatus: number;
    disposalMethod?: string;
    notes?: string;
}

export interface StatisticsReportsArchive {
    id: number;
    sourceReportType: string;
    sourceReportId: number;
    schoolId: number;
    archivedAt: string;
    archivedByUserId: number;
    retentionPeriodYears: number;
    retentionEndDate?: string;
    filePath?: string;
    fileSizeBytes: number;
    isReadOnly: boolean;
    disposalDate?: string;
    disposalStatus: number;
    disposalMethod?: string;
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

export interface UpdateStatisticsReportsArchivePayload {
    id?: number;
    sourceReportType?: string;
    sourceReportId?: number;
    schoolId?: number;
    archivedAt?: string;
    archivedByUserId?: number;
    retentionPeriodYears?: number;
    retentionEndDate?: string;
    filePath?: string;
    fileSizeBytes?: number;
    isReadOnly?: boolean;
    disposalDate?: string;
    disposalStatus?: number;
    disposalMethod?: string;
    notes?: string;
}
