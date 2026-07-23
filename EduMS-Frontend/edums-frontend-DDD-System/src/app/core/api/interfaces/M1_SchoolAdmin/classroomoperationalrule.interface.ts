export interface ClassroomOperationalRule {
    id: number;
    classroomId: number;
    ruleCode: string;
    ruleTitleAr: string;
    ruleTitleEn: string;
    maxAllowedAbsencePercentage: number;
    requiresDailyAttendanceLog: boolean;
    allowLateArrivalMinutes: number;
    maxAllowedConsecutiveAbsenceDays: number;
    penaltyTypeForExceedingLimit: number;
    effectiveStartDate?: string;
    isActive: boolean;
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

export interface CreateClassroomOperationalRulePayload {
    classroomId: number;
    ruleCode: string;
    ruleTitleAr: string;
    ruleTitleEn: string;
    maxAllowedAbsencePercentage: number;
    requiresDailyAttendanceLog: boolean;
    allowLateArrivalMinutes: number;
    maxAllowedConsecutiveAbsenceDays: number;
    penaltyTypeForExceedingLimit: number;
    effectiveStartDate?: string;
}

export interface UpdateClassroomOperationalRulePayload {
    id?: number;
    classroomId?: number;
    ruleCode?: string;
    ruleTitleAr?: string;
    ruleTitleEn?: string;
    maxAllowedAbsencePercentage?: number;
    requiresDailyAttendanceLog?: boolean;
    allowLateArrivalMinutes?: number;
    maxAllowedConsecutiveAbsenceDays?: number;
    penaltyTypeForExceedingLimit?: number;
    effectiveStartDate?: string;
}
