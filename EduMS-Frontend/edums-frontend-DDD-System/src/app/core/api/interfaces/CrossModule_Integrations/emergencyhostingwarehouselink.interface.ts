export interface CreateEmergencyHostingWarehouseLinkPayload {
    emergencyHostingId: number;
    warehouseId: number;
    schoolId: number;
    suppliesUsedJson?: string;
    totalSupplyValue: number;
    notes?: string;
}

export interface EmergencyHostingWarehouseLink {
    id: number;
    emergencyHostingId: number;
    warehouseId: number;
    schoolId: number;
    suppliesUsedJson?: string;
    totalSupplyValue: number;
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

export interface UpdateEmergencyHostingWarehouseLinkPayload {
    id?: number;
    emergencyHostingId?: number;
    warehouseId?: number;
    schoolId?: number;
    suppliesUsedJson?: string;
    totalSupplyValue?: number;
    notes?: string;
}
