export interface CreateStudentDailyAttendanceSummaryPayload {
    studentId: number;
    academicYear: string;
    semesterNumber: number;
    monthNumber: number;
    totalPresentDays: number;
    totalAbsentDays: number;
    totalExcusedDays: number;
    totalLateDays: number;
    totalAbsencePercentage: number;
    isWarningThresholdReached: boolean;
    consecutiveAbsentDaysCount: number;
    lastAbsenceDate?: string;
    isParentNotifiedOfThreshold: boolean;
    calculatedGradeLevel: number;
}

export interface StudentDailyAttendanceSummary {
    id: number;
    studentId: number;
    academicYear: string;
    semesterNumber: number;
    monthNumber: number;
    totalPresentDays: number;
    totalAbsentDays: number;
    totalExcusedDays: number;
    totalLateDays: number;
    totalAbsencePercentage: number;
    isWarningThresholdReached: boolean;
    consecutiveAbsentDaysCount: number;
    lastAbsenceDate?: string;
    isParentNotifiedOfThreshold: boolean;
    calculatedGradeLevel: number;
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

export interface UpdateStudentDailyAttendanceSummaryPayload {
    id?: number;
    academicYear?: string;
    semesterNumber?: number;
    monthNumber?: number;
    totalPresentDays?: number;
    totalAbsentDays?: number;
    totalExcusedDays?: number;
    totalLateDays?: number;
    totalAbsencePercentage?: number;
    isWarningThresholdReached?: boolean;
    consecutiveAbsentDaysCount?: number;
    lastAbsenceDate?: string;
    isParentNotifiedOfThreshold?: boolean;
    calculatedGradeLevel?: number;
}
