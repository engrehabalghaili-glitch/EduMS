export interface CreateEmergencyEmployeeSafetyRecordPayload {
    emergencyIncidentId: number;
    employeeId: number;
    schoolId: number;
    safetyStatus: number;
    isOnDutyDuringIncident: boolean;
    assignedRole?: string;
    notes?: string;
}

export interface EmergencyEmployeeSafetyRecord {
    id: number;
    emergencyIncidentId: number;
    employeeId: number;
    schoolId: number;
    safetyStatus: number;
    isOnDutyDuringIncident: boolean;
    assignedRole?: string;
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

export interface UpdateEmergencyEmployeeSafetyRecordPayload {
    id?: number;
    emergencyIncidentId?: number;
    employeeId?: number;
    schoolId?: number;
    safetyStatus?: number;
    isOnDutyDuringIncident?: boolean;
    assignedRole?: string;
    notes?: string;
}
