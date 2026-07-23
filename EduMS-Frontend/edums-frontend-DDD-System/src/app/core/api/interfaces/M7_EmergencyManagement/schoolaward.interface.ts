export interface CreateSchoolAwardPayload {
    schoolId: number;
    awardNumber: string;
    awardName: string;
    awardCategory?: string;
    awardLevel: number;
    issuingBody?: string;
    issuingBodyType?: string;
    awardDate: string;
    awardPlace?: string;
    ranking?: string;
    participantsJson?: string;
    studentParticipantsCount: number;
    teacherParticipantsCount: number;
    awardDetails?: string;
    certificatePath?: string;
    photosPathJson?: string;
    videoPath?: string;
    impact?: string;
    notes?: string;
}

export interface SchoolAward {
    id: number;
    schoolId: number;
    awardNumber: string;
    awardName: string;
    awardCategory?: string;
    awardLevel: number;
    issuingBody?: string;
    issuingBodyType?: string;
    awardDate: string;
    awardPlace?: string;
    ranking?: string;
    participantsJson?: string;
    studentParticipantsCount: number;
    teacherParticipantsCount: number;
    awardDetails?: string;
    certificatePath?: string;
    photosPathJson?: string;
    videoPath?: string;
    impact?: string;
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

export interface UpdateSchoolAwardPayload {
    id?: number;
    schoolId?: number;
    awardNumber?: string;
    awardName?: string;
    awardCategory?: string;
    awardLevel?: number;
    issuingBody?: string;
    issuingBodyType?: string;
    awardDate?: string;
    awardPlace?: string;
    ranking?: string;
    participantsJson?: string;
    studentParticipantsCount?: number;
    teacherParticipantsCount?: number;
    awardDetails?: string;
    certificatePath?: string;
    photosPathJson?: string;
    videoPath?: string;
    impact?: string;
    notes?: string;
}
