export interface CreateWarehousePayload {
    warehouseName: string;
    ownerType: string;
    ownerId: number;
    locationAddress?: string;
    isActive: boolean;
}

export interface UpdateWarehousePayload {
    id?: number;
    warehouseName?: string;
    ownerType?: string;
    ownerId?: number;
    locationAddress?: string;
    isActive?: boolean;
}

export interface Warehouse {
    id: number;
    warehouseName: string;
    ownerType: string;
    ownerId: number;
    locationAddress?: string;
    isActive: boolean;
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
