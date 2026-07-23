export interface CreateStudentCustodyAssetLinkPayload {
    studentInventoryCustodyId: number;
    schoolAssetId?: number;
    inventoryItemId?: number;
    studentId: number;
    schoolId: number;
    replacementValue: number;
    isReturned: boolean;
    returnDate?: string;
    conditionOnReturn: number;
    notes?: string;
}

export interface StudentCustodyAssetLink {
    id: number;
    studentInventoryCustodyId: number;
    schoolAssetId?: number;
    inventoryItemId?: number;
    studentId: number;
    schoolId: number;
    replacementValue: number;
    isReturned: boolean;
    returnDate?: string;
    conditionOnReturn: number;
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

export interface UpdateStudentCustodyAssetLinkPayload {
    id?: number;
    studentInventoryCustodyId?: number;
    schoolAssetId?: number;
    inventoryItemId?: number;
    studentId?: number;
    schoolId?: number;
    replacementValue?: number;
    isReturned?: boolean;
    returnDate?: string;
    conditionOnReturn?: number;
    notes?: string;
}
