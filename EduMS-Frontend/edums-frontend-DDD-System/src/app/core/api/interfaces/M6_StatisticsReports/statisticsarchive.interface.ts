export interface CreateStatisticsArchivePayload {
    submittedStatisticsId: number;
    schoolId: number;
    archivedYear: string;
    periodType: number;
    archivedAt: string;
    archivedByUserId: number;
    finalDataSnapshotJson?: string;
    studentSnapshotJson?: string;
    staffSnapshotJson?: string;
    retentionPeriodYears: number;
    retentionEndDate?: string;
    isReadOnly: boolean;
    notes?: string;
}

export interface StatisticsArchive {
    id: number;
    submittedStatisticsId: number;
    schoolId: number;
    archivedYear: string;
    periodType: number;
    archivedAt: string;
    archivedByUserId: number;
    finalDataSnapshotJson?: string;
    studentSnapshotJson?: string;
    staffSnapshotJson?: string;
    retentionPeriodYears: number;
    retentionEndDate?: string;
    isReadOnly: boolean;
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

export interface UpdateStatisticsArchivePayload {
    id?: number;
    submittedStatisticsId?: number;
    schoolId?: number;
    archivedYear?: string;
    periodType?: number;
    archivedAt?: string;
    archivedByUserId?: number;
    finalDataSnapshotJson?: string;
    studentSnapshotJson?: string;
    staffSnapshotJson?: string;
    retentionPeriodYears?: number;
    retentionEndDate?: string;
    isReadOnly?: boolean;
    notes?: string;
}
