export interface AssetDepreciation {
    id: number;
    assetId: number;
    schoolId: number;
    methodType: number;
    usefulLifeYears: number;
    depreciationRate: number;
    currentBookValue: number;
    accumulatedDepreciation: number;
    netBookValue: number;
    depreciableAmount: number;
    lastDepreciationDate?: string;
    lastDepreciationPeriod?: string;
    isFullyDepreciated: boolean;
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

export interface CreateAssetDepreciationPayload {
    assetId: number;
    schoolId: number;
    methodType: number;
    usefulLifeYears: number;
    depreciationRate: number;
    currentBookValue: number;
    accumulatedDepreciation: number;
    netBookValue: number;
    depreciableAmount: number;
    lastDepreciationDate?: string;
    lastDepreciationPeriod?: string;
    isFullyDepreciated: boolean;
    notes?: string;
}

export interface UpdateAssetDepreciationPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    methodType?: number;
    usefulLifeYears?: number;
    depreciationRate?: number;
    currentBookValue?: number;
    accumulatedDepreciation?: number;
    netBookValue?: number;
    depreciableAmount?: number;
    lastDepreciationDate?: string;
    lastDepreciationPeriod?: string;
    isFullyDepreciated?: boolean;
    notes?: string;
}
