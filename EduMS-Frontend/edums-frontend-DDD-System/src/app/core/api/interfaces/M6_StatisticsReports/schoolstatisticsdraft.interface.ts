export interface CreateSchoolStatisticsDraftPayload {
    schoolId: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    periodType: number;
    periodValue: number;
    periodStartDate: string;
    periodEndDate: string;
    draftNumber: string;
    draftVersion: string;
    studentDataJson?: string;
    staffDataJson?: string;
    financialSummaryJson?: string;
    assetSummaryJson?: string;
    completenessPercentage: number;
    draftStatus: number;
    isLocked: boolean;
    lockedAt?: string;
    lockedByUserId?: number;
    lastSavedAt?: string;
    savedByUserId?: number;
    notes?: string;
}

export interface SchoolStatisticsDraft {
    id: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    periodType: number;
    periodValue: number;
    periodStartDate: string;
    periodEndDate: string;
    draftNumber: string;
    draftVersion: string;
    studentDataJson?: string;
    staffDataJson?: string;
    financialSummaryJson?: string;
    assetSummaryJson?: string;
    completenessPercentage: number;
    draftStatus: number;
    isLocked: boolean;
    lockedAt?: string;
    lockedByUserId?: number;
    lastSavedAt?: string;
    savedByUserId?: number;
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

export interface UpdateSchoolStatisticsDraftPayload {
    id?: number;
    schoolId?: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    periodType?: number;
    periodValue?: number;
    periodStartDate?: string;
    periodEndDate?: string;
    draftNumber?: string;
    draftVersion?: string;
    studentDataJson?: string;
    staffDataJson?: string;
    financialSummaryJson?: string;
    assetSummaryJson?: string;
    completenessPercentage?: number;
    draftStatus?: number;
    isLocked?: boolean;
    lockedAt?: string;
    lockedByUserId?: number;
    lastSavedAt?: string;
    savedByUserId?: number;
    notes?: string;
}
