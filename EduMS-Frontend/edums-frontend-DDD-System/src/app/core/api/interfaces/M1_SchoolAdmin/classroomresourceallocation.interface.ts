export interface ClassroomResourceAllocation {
    id: number;
    classroomId: number;
    resourceNameAr: string;
    resourceCode: string;
    resourceType: number;
    quantity: number;
    assignedDate: string;
    conditionStatus?: string;
    resourceNameEn?: string;
    assetSerialNumber?: string;
    unitPurchaseCost: number;
    lastInspectionDate?: string;
    nextMaintenanceDate?: string;
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

export interface CreateClassroomResourceAllocationPayload {
    classroomId: number;
    resourceNameAr: string;
    resourceCode: string;
    resourceType: number;
    quantity: number;
    assignedDate: string;
    resourceNameEn?: string;
    assetSerialNumber?: string;
    unitPurchaseCost: number;
    lastInspectionDate?: string;
    nextMaintenanceDate?: string;
}

export interface UpdateClassroomResourceAllocationPayload {
    id?: number;
    classroomId?: number;
    resourceNameAr?: string;
    resourceCode?: string;
    resourceType?: number;
    quantity?: number;
    assignedDate?: string;
    resourceNameEn?: string;
    assetSerialNumber?: string;
    unitPurchaseCost?: number;
    lastInspectionDate?: string;
    nextMaintenanceDate?: string;
}
