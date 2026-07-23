export interface CreateEducationalStagePayload {
    stageCode: string;
    stageNameAr: string;
    stageNameEn: string;
    minAge: number;
    maxAge: number;
    defaultDurationYears: number;
    ministryCurriculumCode?: string;
    requiresGraduationCertificate: boolean;
    displayOrder: number;
}

export interface EducationalStage {
    id: number;
    stageCode: string;
    stageNameAr: string;
    stageNameEn: string;
    minAge: number;
    maxAge: number;
    defaultDurationYears: number;
    ministryCurriculumCode?: string;
    requiresGraduationCertificate: boolean;
    displayOrder: number;
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

export interface UpdateEducationalStagePayload {
    id?: number;
    stageCode?: string;
    stageNameAr?: string;
    stageNameEn?: string;
    minAge?: number;
    maxAge?: number;
    defaultDurationYears?: number;
    ministryCurriculumCode?: string;
    requiresGraduationCertificate?: boolean;
    displayOrder?: number;
}
