export interface CreateSchoolEventCalendarPayload {
    schoolId: number;
    eventTitleAr: string;
    eventTitleEn: string;
    startDate: string;
    endDate: string;
    eventType: number;
    isPublic: boolean;
    description?: string;
    organizerEmployeeId?: number;
    targetAudience: number;
    locationDetails?: string;
    requiresAttendanceTracking: boolean;
}

export interface SchoolEventCalendar {
    id: number;
    schoolId: number;
    eventTitleAr: string;
    eventTitleEn: string;
    startDate: string;
    endDate: string;
    eventType: number;
    isPublic: boolean;
    description?: string;
    organizerEmployeeId?: number;
    targetAudience: number;
    locationDetails?: string;
    requiresAttendanceTracking: boolean;
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

export interface UpdateSchoolEventCalendarPayload {
    id?: number;
    eventTitleAr?: string;
    eventTitleEn?: string;
    startDate?: string;
    endDate?: string;
    eventType?: number;
    isPublic?: boolean;
    description?: string;
    organizerEmployeeId?: number;
    targetAudience?: number;
    locationDetails?: string;
    requiresAttendanceTracking?: boolean;
}
