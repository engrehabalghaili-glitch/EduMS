export interface CreateStatisticalReportSnapshotPayload {
    schoolId: number;
    academicLockPeriodId?: number;
    reportCode: string;
    reportNameAr: string;
    reportCategory: string;
    snapshotPayloadJson: string;
    snapshotDate: string;
    isVerifiedByOffice: boolean;
}

export interface StatisticalReportSnapshot {
    id: number;
    schoolId: number;
    academicLockPeriodId?: number;
    reportCode: string;
    reportNameAr: string;
    reportCategory: string;
    snapshotPayloadJson: string;
    snapshotDate: string;
    isVerifiedByOffice: boolean;
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

export interface UpdateStatisticalReportSnapshotPayload {
    id?: number;
    schoolId?: number;
    academicLockPeriodId?: number;
    reportCode?: string;
    reportNameAr?: string;
    reportCategory?: string;
    snapshotPayloadJson?: string;
    snapshotDate?: string;
    isVerifiedByOffice?: boolean;
}
