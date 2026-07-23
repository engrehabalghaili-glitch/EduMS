export interface CreateInventoryItemPayload {
    warehouseId: number;
    itemName: string;
    itemCode?: string;
    quantity: number;
    unitOfMeasure: string;
}

export interface InventoryItem {
    id: number;
    warehouseId: number;
    itemName: string;
    itemCode?: string;
    quantity: number;
    unitOfMeasure: string;
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

export interface UpdateInventoryItemPayload {
    id?: number;
    warehouseId?: number;
    itemName?: string;
    itemCode?: string;
    quantity?: number;
    unitOfMeasure?: string;
}
