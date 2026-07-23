export interface CreateStudentSkillAndTalentRecordPayload {
    studentId: number;
    talentCategory: number;
    talentTitleAr: string;
    proficiencyLevel: number;
    discoveredDate: string;
    mentorEmployeeId?: number;
    talentTitleEn?: string;
    developmentPlanDescription?: string;
    portfolioAttachmentUrl?: string;
    isEnrolledInGiftedProgram: boolean;
}

export interface StudentSkillAndTalentRecord {
    id: number;
    studentId: number;
    talentCategory: number;
    talentTitleAr: string;
    proficiencyLevel: number;
    discoveredDate: string;
    mentorEmployeeId?: number;
    talentTitleEn?: string;
    developmentPlanDescription?: string;
    portfolioAttachmentUrl?: string;
    isEnrolledInGiftedProgram: boolean;
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

export interface UpdateStudentSkillAndTalentRecordPayload {
    id?: number;
    talentCategory?: number;
    talentTitleAr?: string;
    proficiencyLevel?: number;
    discoveredDate?: string;
    mentorEmployeeId?: number;
    talentTitleEn?: string;
    developmentPlanDescription?: string;
    portfolioAttachmentUrl?: string;
    isEnrolledInGiftedProgram?: boolean;
}
