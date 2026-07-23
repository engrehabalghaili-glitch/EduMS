export interface CreateEmergencyIncidentAssetImpactPayload {
    emergencyIncidentId: number;
    schoolAssetId: number;
    schoolId: number;
    impactType: number;
    estimatedDamageValue: number;
    damageDescription?: string;
    requiresMaintenance: boolean;
    maintenanceTicketId?: number;
    notes?: string;
}

export interface EmergencyIncidentAssetImpact {
    id: number;
    emergencyIncidentId: number;
    schoolAssetId: number;
    schoolId: number;
    impactType: number;
    estimatedDamageValue: number;
    damageDescription?: string;
    requiresMaintenance: boolean;
    maintenanceTicketId?: number;
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

export interface UpdateEmergencyIncidentAssetImpactPayload {
    id?: number;
    emergencyIncidentId?: number;
    schoolAssetId?: number;
    schoolId?: number;
    impactType?: number;
    estimatedDamageValue?: number;
    damageDescription?: string;
    requiresMaintenance?: boolean;
    maintenanceTicketId?: number;
    notes?: string;
}
