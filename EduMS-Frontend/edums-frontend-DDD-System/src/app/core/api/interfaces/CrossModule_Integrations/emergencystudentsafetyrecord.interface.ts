export interface CreateEmergencyStudentSafetyRecordPayload {
    emergencyIncidentId: number;
    studentId: number;
    schoolId: number;
    safetyStatus: number;
    parentNotified: boolean;
    parentNotificationTime?: string;
    location?: string;
    notes?: string;
}

export interface EmergencyStudentSafetyRecord {
    id: number;
    emergencyIncidentId: number;
    studentId: number;
    schoolId: number;
    safetyStatus: number;
    parentNotified: boolean;
    parentNotificationTime?: string;
    location?: string;
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

export interface UpdateEmergencyStudentSafetyRecordPayload {
    id?: number;
    emergencyIncidentId?: number;
    studentId?: number;
    schoolId?: number;
    safetyStatus?: number;
    parentNotified?: boolean;
    parentNotificationTime?: string;
    location?: string;
    notes?: string;
}
