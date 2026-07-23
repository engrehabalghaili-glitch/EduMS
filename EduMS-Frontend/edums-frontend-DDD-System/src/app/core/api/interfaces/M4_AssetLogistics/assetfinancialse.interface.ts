export interface AssetFinancials {
    id: number;
    assetId: number;
    schoolId: number;
    purchasePrice: number;
    shippingCosts: number;
    customsFees: number;
    installationCosts: number;
    otherCosts: number;
    totalInitialCost: number;
    currency?: string;
    exchangeRateToSar: number;
    salvageValue: number;
    residualValueLastUpdate?: string;
    fiscalYear?: string;
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

export interface CreateAssetFinancialsPayload {
    assetId: number;
    schoolId: number;
    purchasePrice: number;
    shippingCosts: number;
    customsFees: number;
    installationCosts: number;
    otherCosts: number;
    totalInitialCost: number;
    currency?: string;
    exchangeRateToSar: number;
    salvageValue: number;
    residualValueLastUpdate?: string;
    fiscalYear?: string;
}

export interface UpdateAssetFinancialsPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    purchasePrice?: number;
    shippingCosts?: number;
    customsFees?: number;
    installationCosts?: number;
    otherCosts?: number;
    totalInitialCost?: number;
    currency?: string;
    exchangeRateToSar?: number;
    salvageValue?: number;
    residualValueLastUpdate?: string;
    fiscalYear?: string;
}
