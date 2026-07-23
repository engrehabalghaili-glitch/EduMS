export interface CreateSchoolSemesterPayload {
    schoolAcademicYearId: number;
    semesterNumber: number;
    semesterType: string;
    semesterNameAr: string;
    semesterNameEn?: string;
    startDate: string;
    endDate: string;
    teachingWeeksCount: number;
    examWeeksCount: number;
    registrationOpenDate?: string;
    registrationCloseDate?: string;
    addDropStartDate?: string;
    addDropEndDate?: string;
    examStartDate?: string;
    examEndDate?: string;
    gradingOpenDate?: string;
    gradingCloseDate?: string;
    closureDate?: string;
    isCurrent: boolean;
    notes?: string;
}

export interface SchoolSemester {
    id: number;
    schoolAcademicYearId: number;
    semesterNumber: number;
    semesterType: string;
    semesterNameAr: string;
    semesterNameEn?: string;
    startDate: string;
    endDate: string;
    teachingWeeksCount: number;
    examWeeksCount: number;
    registrationOpenDate?: string;
    registrationCloseDate?: string;
    addDropStartDate?: string;
    addDropEndDate?: string;
    examStartDate?: string;
    examEndDate?: string;
    gradingOpenDate?: string;
    gradingCloseDate?: string;
    closureDate?: string;
    approvalStatus: number;
    isActive: boolean;
    isCurrent: boolean;
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

export interface UpdateSchoolSemesterPayload {
    id?: number;
    schoolAcademicYearId?: number;
    semesterNumber?: number;
    semesterType?: string;
    semesterNameAr?: string;
    semesterNameEn?: string;
    startDate?: string;
    endDate?: string;
    teachingWeeksCount?: number;
    examWeeksCount?: number;
    registrationOpenDate?: string;
    registrationCloseDate?: string;
    addDropStartDate?: string;
    addDropEndDate?: string;
    examStartDate?: string;
    examEndDate?: string;
    gradingOpenDate?: string;
    gradingCloseDate?: string;
    closureDate?: string;
    isCurrent?: boolean;
    notes?: string;
}
