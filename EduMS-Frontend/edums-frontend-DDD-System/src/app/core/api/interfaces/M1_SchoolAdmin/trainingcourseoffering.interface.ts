export interface CreateTrainingCourseOfferingPayload {
    directorateId?: number;
    schoolId?: number;
    courseCode: string;
    courseTitleAr: string;
    trainerName?: string;
    startDate: string;
    endDate: string;
    totalHours: number;
    maxParticipants: number;
    costPerParticipant: number;
    courseTitleEn?: string;
    trainingLocation?: string;
    targetSpecialization?: string;
    enrolledParticipantsCount: number;
    certificateTemplateUrl?: string;
}

export interface TrainingCourseOffering {
    id: number;
    directorateId?: number;
    schoolId?: number;
    courseCode: string;
    courseTitleAr: string;
    trainerName?: string;
    startDate: string;
    endDate: string;
    totalHours: number;
    maxParticipants: number;
    costPerParticipant: number;
    courseTitleEn?: string;
    trainingLocation?: string;
    targetSpecialization?: string;
    enrolledParticipantsCount: number;
    certificateTemplateUrl?: string;
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

export interface UpdateTrainingCourseOfferingPayload {
    id?: number;
    courseCode?: string;
    courseTitleAr?: string;
    trainerName?: string;
    startDate?: string;
    endDate?: string;
    totalHours?: number;
    maxParticipants?: number;
    costPerParticipant?: number;
    courseTitleEn?: string;
    trainingLocation?: string;
    targetSpecialization?: string;
    enrolledParticipantsCount?: number;
    certificateTemplateUrl?: string;
}
