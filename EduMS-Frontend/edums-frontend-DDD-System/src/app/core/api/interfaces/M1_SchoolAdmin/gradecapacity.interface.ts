export interface CreateGradeCapacityPayload {
    schoolAcademicYearId: number;
    schoolLevelId: number;
    gradeLevelCode: string;
    gradeNameAr: string;
    gradeNameEn?: string;
    maxStudentsPerSection: number;
    maxSectionsCount: number;
    currentEnrolledCount: number;
    genderAllocation: number;
    notes?: string;
}

export interface GradeCapacity {
    id: number;
    schoolAcademicYearId: number;
    schoolLevelId: number;
    gradeLevelCode: string;
    gradeNameAr: string;
    gradeNameEn?: string;
    maxStudentsPerSection: number;
    maxSectionsCount: number;
    currentEnrolledCount: number;
    genderAllocation: number;
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

export interface UpdateGradeCapacityPayload {
    id?: number;
    schoolAcademicYearId?: number;
    schoolLevelId?: number;
    gradeLevelCode?: string;
    gradeNameAr?: string;
    gradeNameEn?: string;
    maxStudentsPerSection?: number;
    maxSectionsCount?: number;
    currentEnrolledCount?: number;
    genderAllocation?: number;
    notes?: string;
}
