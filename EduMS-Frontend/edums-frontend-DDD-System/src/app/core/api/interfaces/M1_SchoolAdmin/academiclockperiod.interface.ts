export interface AcademicLockPeriod {
    id: number;
    officeId: number;
    schoolId: number;
    periodName: string;
    startDate: string;
    endDate: string;
    isActive: boolean;
    lockGradeRosters: boolean;
    lockEnrollmentSnapshots: boolean;
    lockPeriodStatisticalReports: boolean;
    lockAttendanceLogs: boolean;
    lockBehavioralRecords: boolean;
    lockFinancialFeeAssessments: boolean;
    unlockReasonDescription?: string;
    initiatedByEmployeeId?: number;
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

export interface CreateAcademicLockPeriodPayload {
    officeId: number;
    schoolId: number;
    periodName: string;
    startDate: string;
    endDate: string;
    lockGradeRosters: boolean;
    lockEnrollmentSnapshots: boolean;
    lockPeriodStatisticalReports: boolean;
    lockAttendanceLogs: boolean;
    lockBehavioralRecords: boolean;
    lockFinancialFeeAssessments: boolean;
    unlockReasonDescription?: string;
    initiatedByEmployeeId?: number;
}

export interface UpdateAcademicLockPeriodPayload {
    id?: number;
    officeId?: number;
    periodName?: string;
    startDate?: string;
    endDate?: string;
    lockGradeRosters?: boolean;
    lockEnrollmentSnapshots?: boolean;
    lockPeriodStatisticalReports?: boolean;
    lockAttendanceLogs?: boolean;
    lockBehavioralRecords?: boolean;
    lockFinancialFeeAssessments?: boolean;
    unlockReasonDescription?: string;
    initiatedByEmployeeId?: number;
}
