export interface CreateUserActivityLogPayload {
    userId: number;
    schoolId?: number;
    activityType: string;
    activityTimestamp: string;
    activityStatus: number;
    failureReason?: string;
    ipAddress?: string;
    deviceType?: string;
    deviceName?: string;
    operatingSystem?: string;
    browser?: string;
    userAgent?: string;
    locationText?: string;
    sessionId?: string;
    actionDetailsJson?: string;
    notes?: string;
}

export interface UpdateUserActivityLogPayload {
    id?: number;
    userId?: number;
    schoolId?: number;
    activityType?: string;
    activityTimestamp?: string;
    activityStatus?: number;
    failureReason?: string;
    ipAddress?: string;
    deviceType?: string;
    deviceName?: string;
    operatingSystem?: string;
    browser?: string;
    userAgent?: string;
    locationText?: string;
    sessionId?: string;
    actionDetailsJson?: string;
    notes?: string;
}

export interface UserActivityLog {
    id: number;
    userId: number;
    schoolId?: number;
    activityType: string;
    activityTimestamp: string;
    activityStatus: number;
    failureReason?: string;
    ipAddress?: string;
    deviceType?: string;
    deviceName?: string;
    operatingSystem?: string;
    browser?: string;
    userAgent?: string;
    locationText?: string;
    sessionId?: string;
    actionDetailsJson?: string;
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
