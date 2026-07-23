export interface CreateMaintenanceSparePartPayload {
    schoolId: number;
    partCode: string;
    partNameAr: string;
    partNameEn?: string;
    partCategory?: string;
    manufacturer?: string;
    compatibleAssetsJson?: string;
    unitOfMeasure: string;
    currentStockQuantity: number;
    minStockLevel: number;
    maxStockLevel: number;
    reorderQuantity: number;
    unitCost: number;
    supplierName?: string;
    locationInWarehouse?: string;
    isActive: boolean;
    stockStatus: number;
    lastRestockDate?: string;
    totalConsumed: number;
    notes?: string;
}

export interface MaintenanceSparePart {
    id: number;
    schoolId: number;
    partCode: string;
    partNameAr: string;
    partNameEn?: string;
    partCategory?: string;
    manufacturer?: string;
    compatibleAssetsJson?: string;
    unitOfMeasure: string;
    currentStockQuantity: number;
    minStockLevel: number;
    maxStockLevel: number;
    reorderQuantity: number;
    unitCost: number;
    supplierName?: string;
    locationInWarehouse?: string;
    isActive: boolean;
    stockStatus: number;
    lastRestockDate?: string;
    totalConsumed: number;
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

export interface UpdateMaintenanceSparePartPayload {
    id?: number;
    schoolId?: number;
    partCode?: string;
    partNameAr?: string;
    partNameEn?: string;
    partCategory?: string;
    manufacturer?: string;
    compatibleAssetsJson?: string;
    unitOfMeasure?: string;
    currentStockQuantity?: number;
    minStockLevel?: number;
    maxStockLevel?: number;
    reorderQuantity?: number;
    unitCost?: number;
    supplierName?: string;
    locationInWarehouse?: string;
    isActive?: boolean;
    stockStatus?: number;
    lastRestockDate?: string;
    totalConsumed?: number;
    notes?: string;
}
