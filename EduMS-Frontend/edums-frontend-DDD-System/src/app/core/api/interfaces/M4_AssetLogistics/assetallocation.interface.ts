export interface AssetAllocation {
    id: number;
    inventoryItemId: number;
    schoolId: number;
    classroomId?: number;
    assignedToEmployeeId?: number;
    allocatedQuantity: number;
    allocationDate: string;
    status: string;
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

export interface CreateAssetAllocationPayload {
    inventoryItemId: number;
    schoolId: number;
    classroomId?: number;
    assignedToEmployeeId?: number;
    allocatedQuantity: number;
    allocationDate: string;
    status: string;
}

export interface UpdateAssetAllocationPayload {
    id?: number;
    inventoryItemId?: number;
    schoolId?: number;
    classroomId?: number;
    assignedToEmployeeId?: number;
    allocatedQuantity?: number;
    allocationDate?: string;
    status?: string;
}
