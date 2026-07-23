export interface CreateSchoolLevelPayload {
    schoolId: number;
    levelNameAr: string;
    levelNameEn?: string;
    levelOrder: number;
    startGrade: string;
    endGrade: string;
    academicTrack?: string;
    minAgeYears: number;
    maxAgeYears: number;
    defaultShiftId?: number;
    notes?: string;
}

export interface SchoolLevel {
    id: number;
    schoolId: number;
    levelNameAr: string;
    levelNameEn?: string;
    levelOrder: number;
    startGrade: string;
    endGrade: string;
    academicTrack?: string;
    minAgeYears: number;
    maxAgeYears: number;
    defaultShiftId?: number;
    isActive: boolean;
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

export interface UpdateSchoolLevelPayload {
    id?: number;
    levelNameAr?: string;
    levelNameEn?: string;
    levelOrder?: number;
    startGrade?: string;
    endGrade?: string;
    academicTrack?: string;
    minAgeYears?: number;
    maxAgeYears?: number;
    defaultShiftId?: number;
    notes?: string;
}
