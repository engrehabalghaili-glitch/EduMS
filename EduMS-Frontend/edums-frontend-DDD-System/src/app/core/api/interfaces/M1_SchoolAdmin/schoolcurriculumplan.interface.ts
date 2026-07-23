export interface CreateSchoolCurriculumPlanPayload {
    schoolId: number;
    planNameAr: string;
    planNameEn?: string;
    planCode: string;
    gradeCapacityId?: number;
    schoolLevelId?: number;
    schoolAcademicYearId: number;
    schoolSemesterId?: number;
    planVersion: string;
    adoptionDate: string;
    totalCreditHours: number;
    approvalDocumentUrl?: string;
    expiryDate?: string;
    notes?: string;
}

export interface SchoolCurriculumPlan {
    id: number;
    schoolId: number;
    planNameAr: string;
    planNameEn?: string;
    planCode: string;
    gradeCapacityId?: number;
    schoolLevelId?: number;
    schoolAcademicYearId: number;
    schoolSemesterId?: number;
    planVersion: string;
    adoptionDate: string;
    totalCreditHours: number;
    planStatus: number;
    ministerialApprovalStatus: number;
    approvalDocumentUrl?: string;
    isActive: boolean;
    effectiveDate: string;
    expiryDate?: string;
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

export interface UpdateSchoolCurriculumPlanPayload {
    id?: number;
    planNameAr?: string;
    planNameEn?: string;
    planCode?: string;
    gradeCapacityId?: number;
    schoolLevelId?: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    planVersion?: string;
    adoptionDate?: string;
    totalCreditHours?: number;
    approvalDocumentUrl?: string;
    expiryDate?: string;
    notes?: string;
}
