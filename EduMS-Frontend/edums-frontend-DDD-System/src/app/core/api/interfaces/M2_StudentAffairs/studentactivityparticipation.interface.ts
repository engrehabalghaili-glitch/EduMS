export interface CreateStudentActivityParticipationPayload {
    studentId: number;
    schoolId: number;
    activityNameAr: string;
    activityType: number;
    supervisorEmployeeId?: number;
    participationDate: string;
    achievementDetail?: string;
    scoreBonus: number;
    activityNameEn?: string;
    participationRole?: string;
    totalHoursLogged: number;
    awardLevel?: string;
}

export interface StudentActivityParticipation {
    id: number;
    studentId: number;
    schoolId: number;
    activityNameAr: string;
    activityType: number;
    supervisorEmployeeId?: number;
    participationDate: string;
    achievementDetail?: string;
    scoreBonus: number;
    activityNameEn?: string;
    participationRole?: string;
    totalHoursLogged: number;
    awardLevel?: string;
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

export interface UpdateStudentActivityParticipationPayload {
    id?: number;
    activityNameAr?: string;
    activityType?: number;
    supervisorEmployeeId?: number;
    participationDate?: string;
    achievementDetail?: string;
    scoreBonus?: number;
    activityNameEn?: string;
    participationRole?: string;
    totalHoursLogged?: number;
    awardLevel?: string;
}
