export interface CreateFieldInventoryLogPayload {
    inventoryPlanId: number;
    schoolId: number;
    scannerUserId: number;
    scanTimestamp: string;
    scannedCode: string;
    assetId?: number;
    physicalLocationText?: string;
    actualCondition: number;
    conditionNotes?: string;
    isFound: boolean;
    notFoundNotes?: string;
    assetPhotoUrl?: string;
    gpsLocation?: string;
    isVerified: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
    notes?: string;
}

export interface FieldInventoryLog {
    id: number;
    inventoryPlanId: number;
    schoolId: number;
    scannerUserId: number;
    scanTimestamp: string;
    scannedCode: string;
    assetId?: number;
    physicalLocationText?: string;
    actualCondition: number;
    conditionNotes?: string;
    isFound: boolean;
    notFoundNotes?: string;
    assetPhotoUrl?: string;
    gpsLocation?: string;
    isVerified: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
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

export interface UpdateFieldInventoryLogPayload {
    id?: number;
    inventoryPlanId?: number;
    schoolId?: number;
    scannerUserId?: number;
    scanTimestamp?: string;
    scannedCode?: string;
    assetId?: number;
    physicalLocationText?: string;
    actualCondition?: number;
    conditionNotes?: string;
    isFound?: boolean;
    notFoundNotes?: string;
    assetPhotoUrl?: string;
    gpsLocation?: string;
    isVerified?: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
    notes?: string;
}
