export interface CreateStudentDisciplinaryHistoryPayload {
    studentId: number;
    behavioralLogId?: number;
    disciplinaryActionCode: string;
    actionTitleAr: string;
    executionDate: string;
    executedByEmployeeId?: number;
    penaltyDurationDays: number;
    guardianNotifiedDate?: string;
    actionTitleEn?: string;
    appealNotes?: string;
    reinstatementCondition?: string;
}

export interface StudentDisciplinaryHistory {
    id: number;
    studentId: number;
    behavioralLogId?: number;
    disciplinaryActionCode: string;
    actionTitleAr: string;
    executionDate: string;
    executedByEmployeeId?: number;
    penaltyDurationDays: number;
    guardianNotifiedDate?: string;
    appealStatus: number;
    actionTitleEn?: string;
    appealNotes?: string;
    reinstatementCondition?: string;
    status: number;
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

export interface UpdateStudentDisciplinaryHistoryPayload {
    id?: number;
    behavioralLogId?: number;
    disciplinaryActionCode?: string;
    actionTitleAr?: string;
    executionDate?: string;
    executedByEmployeeId?: number;
    penaltyDurationDays?: number;
    guardianNotifiedDate?: string;
    actionTitleEn?: string;
    appealNotes?: string;
    reinstatementCondition?: string;
}
