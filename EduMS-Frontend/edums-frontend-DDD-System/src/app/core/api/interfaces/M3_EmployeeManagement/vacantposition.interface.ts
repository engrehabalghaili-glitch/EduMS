export interface CreateVacantPositionPayload {
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    positionCode: string;
    positionTitleAr: string;
    positionTitleEn?: string;
    departmentId?: number;
    employeeType: number;
    requiredQualification?: string;
    experienceRequiredYears: number;
    salaryRangeMin: number;
    salaryRangeMax: number;
    vacancyStatus: number;
    postingDate: string;
    closingDate?: string;
    specialRequirements?: string;
    notes?: string;
}

export interface UpdateVacantPositionPayload {
    id?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    positionCode?: string;
    positionTitleAr?: string;
    positionTitleEn?: string;
    departmentId?: number;
    employeeType?: number;
    requiredQualification?: string;
    experienceRequiredYears?: number;
    salaryRangeMin?: number;
    salaryRangeMax?: number;
    vacancyStatus?: number;
    postingDate?: string;
    closingDate?: string;
    specialRequirements?: string;
    notes?: string;
}

export interface VacantPosition {
    id: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    positionCode: string;
    positionTitleAr: string;
    positionTitleEn?: string;
    departmentId?: number;
    employeeType: number;
    requiredQualification?: string;
    experienceRequiredYears: number;
    salaryRangeMin: number;
    salaryRangeMax: number;
    vacancyStatus: number;
    postingDate: string;
    closingDate?: string;
    specialRequirements?: string;
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
