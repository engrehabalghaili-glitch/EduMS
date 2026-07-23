export interface CreateSchoolShiftPayload {
    schoolId: number;
    shiftNameAr: string;
    shiftNameEn: string;
    startTime: string;
    endTime: string;
    shiftCode?: string;
    totalPeriodsCount: number;
    periodDurationMinutes: number;
    breakDurationMinutes: number;
}

export interface SchoolShift {
    id: number;
    schoolId: number;
    shiftNameAr: string;
    shiftNameEn: string;
    startTime: string;
    endTime: string;
    shiftCode?: string;
    totalPeriodsCount: number;
    periodDurationMinutes: number;
    breakDurationMinutes: number;
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

export interface UpdateSchoolShiftPayload {
    id?: number;
    shiftNameAr?: string;
    shiftNameEn?: string;
    startTime?: string;
    endTime?: string;
    shiftCode?: string;
    totalPeriodsCount?: number;
    periodDurationMinutes?: number;
    breakDurationMinutes?: number;
}
