export interface AssetLocationRecord {
    id: number;
    schoolId: number;
    parentLocationId?: number;
    locationCode: string;
    locationNameAr: string;
    locationNameEn?: string;
    locationType: number;
    buildingName?: string;
    floorNumber?: number;
    roomNumber?: string;
    isActive: boolean;
    responsiblePersonId?: number;
    mapReference?: string;
    qrCode?: string;
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

export interface CreateAssetLocationRecordPayload {
    schoolId: number;
    parentLocationId?: number;
    locationCode: string;
    locationNameAr: string;
    locationNameEn?: string;
    locationType: number;
    buildingName?: string;
    floorNumber?: number;
    roomNumber?: string;
    isActive: boolean;
    responsiblePersonId?: number;
    mapReference?: string;
    qrCode?: string;
    notes?: string;
}

export interface UpdateAssetLocationRecordPayload {
    id?: number;
    schoolId?: number;
    parentLocationId?: number;
    locationCode?: string;
    locationNameAr?: string;
    locationNameEn?: string;
    locationType?: number;
    buildingName?: string;
    floorNumber?: number;
    roomNumber?: string;
    isActive?: boolean;
    responsiblePersonId?: number;
    mapReference?: string;
    qrCode?: string;
    notes?: string;
}
