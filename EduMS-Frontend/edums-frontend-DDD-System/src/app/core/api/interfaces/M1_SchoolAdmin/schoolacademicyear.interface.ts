export interface CreateSchoolAcademicYearPayload {
    schoolId: number;
    yearCode: string;
    yearNameAr: string;
    yearNameEn?: string;
    startDate: string;
    endDate: string;
    registrationStartDate: string;
    registrationEndDate: string;
    addDropStartDate?: string;
    addDropEndDate?: string;
    examsStartDate?: string;
    examsEndDate?: string;
    isCurrentYear: boolean;
    isArchived: boolean;
    archivedDate?: string;
    previousAcademicYearId?: number;
    notes?: string;
}

export interface SchoolAcademicYear {
    id: number;
    schoolId: number;
    yearCode: string;
    yearNameAr: string;
    yearNameEn?: string;
    startDate: string;
    endDate: string;
    registrationStartDate: string;
    registrationEndDate: string;
    addDropStartDate?: string;
    addDropEndDate?: string;
    examsStartDate?: string;
    examsEndDate?: string;
    isCurrentYear: boolean;
    yearStatus: number;
    isArchived: boolean;
    archivedDate?: string;
    previousAcademicYearId?: number;
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

export interface UpdateSchoolAcademicYearPayload {
    id?: number;
    yearCode?: string;
    yearNameAr?: string;
    yearNameEn?: string;
    startDate?: string;
    endDate?: string;
    registrationStartDate?: string;
    registrationEndDate?: string;
    addDropStartDate?: string;
    addDropEndDate?: string;
    examsStartDate?: string;
    examsEndDate?: string;
    isCurrentYear?: boolean;
    isArchived?: boolean;
    archivedDate?: string;
    previousAcademicYearId?: number;
    notes?: string;
}
