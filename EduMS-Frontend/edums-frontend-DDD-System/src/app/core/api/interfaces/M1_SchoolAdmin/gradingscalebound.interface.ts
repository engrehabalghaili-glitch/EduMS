export interface CreateGradingScaleBoundPayload {
    schoolId: number;
    scaleName: string;
    letterCode: string;
    minPercentage: number;
    maxPercentage: number;
    gradePointValue: number;
    descriptionAr?: string;
    descriptionEn?: string;
    scaleCode?: string;
    isPassingGrade: boolean;
    displayOrder: number;
}

export interface GradingScaleBound {
    id: number;
    schoolId: number;
    scaleName: string;
    letterCode: string;
    minPercentage: number;
    maxPercentage: number;
    gradePointValue: number;
    descriptionAr?: string;
    descriptionEn?: string;
    scaleCode?: string;
    isPassingGrade: boolean;
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

export interface UpdateGradingScaleBoundPayload {
    id?: number;
    scaleName?: string;
    letterCode?: string;
    minPercentage?: number;
    maxPercentage?: number;
    gradePointValue?: number;
    descriptionAr?: string;
    descriptionEn?: string;
    scaleCode?: string;
    isPassingGrade?: boolean;
    displayOrder?: number;
}
