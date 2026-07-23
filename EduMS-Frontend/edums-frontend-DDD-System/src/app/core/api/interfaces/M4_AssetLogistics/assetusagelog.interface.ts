export interface AssetUsageLog {
    id: number;
    assetId: number;
    schoolId: number;
    usageType: number;
    startDateTime: string;
    endDateTime?: string;
    durationMinutes: number;
    usagePurpose: number;
    purposeDetails?: string;
    usedByUserId?: number;
    userType: number;
    locationId?: number;
    usageStatus: number;
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

export interface CreateAssetUsageLogPayload {
    assetId: number;
    schoolId: number;
    usageType: number;
    startDateTime: string;
    endDateTime?: string;
    durationMinutes: number;
    usagePurpose: number;
    purposeDetails?: string;
    usedByUserId?: number;
    userType: number;
    locationId?: number;
    usageStatus: number;
    notes?: string;
}

export interface UpdateAssetUsageLogPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    usageType?: number;
    startDateTime?: string;
    endDateTime?: string;
    durationMinutes?: number;
    usagePurpose?: number;
    purposeDetails?: string;
    usedByUserId?: number;
    userType?: number;
    locationId?: number;
    usageStatus?: number;
    notes?: string;
}
