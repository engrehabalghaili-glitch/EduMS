export interface CreateStudentExtracurricularAchievementPayload {
    studentId: number;
    competitionTitleAr: string;
    competitionTitleEn?: string;
    competitionLevel: number;
    organizingInstitutionName: string;
    achievementDate: string;
    rankOrMedalAchieved: number;
    awardDescription?: string;
    monetaryPrizeAmount: number;
    supervisingCoachEmployeeId?: number;
    certificateOrMedalPhotoUrl?: string;
}

export interface StudentExtracurricularAchievement {
    id: number;
    studentId: number;
    competitionTitleAr: string;
    competitionTitleEn?: string;
    competitionLevel: number;
    organizingInstitutionName: string;
    achievementDate: string;
    rankOrMedalAchieved: number;
    awardDescription?: string;
    monetaryPrizeAmount: number;
    supervisingCoachEmployeeId?: number;
    certificateOrMedalPhotoUrl?: string;
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

export interface UpdateStudentExtracurricularAchievementPayload {
    id?: number;
    competitionTitleAr?: string;
    competitionTitleEn?: string;
    competitionLevel?: number;
    organizingInstitutionName?: string;
    achievementDate?: string;
    rankOrMedalAchieved?: number;
    awardDescription?: string;
    monetaryPrizeAmount?: number;
    supervisingCoachEmployeeId?: number;
    certificateOrMedalPhotoUrl?: string;
}
