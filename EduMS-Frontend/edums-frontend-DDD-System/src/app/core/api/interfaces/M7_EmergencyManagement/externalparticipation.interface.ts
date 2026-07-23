export interface CreateExternalParticipationPayload {
    schoolId: number;
    participationNumber: string;
    eventName: string;
    eventType?: string;
    organizer?: string;
    organizerType?: string;
    location?: string;
    startDate: string;
    endDate?: string;
    results?: string;
    ranking?: string;
    participantsJson?: string;
    studentParticipantsCount: number;
    teacherParticipantsCount: number;
    expensesJson?: string;
    fundingSource?: string;
    attachmentsJson?: string;
    lessonsLearned?: string;
    recommendations?: string;
    notes?: string;
}

export interface ExternalParticipation {
    id: number;
    schoolId: number;
    participationNumber: string;
    eventName: string;
    eventType?: string;
    organizer?: string;
    organizerType?: string;
    location?: string;
    startDate: string;
    endDate?: string;
    results?: string;
    ranking?: string;
    participantsJson?: string;
    studentParticipantsCount: number;
    teacherParticipantsCount: number;
    expensesJson?: string;
    fundingSource?: string;
    attachmentsJson?: string;
    lessonsLearned?: string;
    recommendations?: string;
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

export interface UpdateExternalParticipationPayload {
    id?: number;
    schoolId?: number;
    participationNumber?: string;
    eventName?: string;
    eventType?: string;
    organizer?: string;
    organizerType?: string;
    location?: string;
    startDate?: string;
    endDate?: string;
    results?: string;
    ranking?: string;
    participantsJson?: string;
    studentParticipantsCount?: number;
    teacherParticipantsCount?: number;
    expensesJson?: string;
    fundingSource?: string;
    attachmentsJson?: string;
    lessonsLearned?: string;
    recommendations?: string;
    notes?: string;
}
