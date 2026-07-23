export interface CreateSchoolCanteenItemPayload {
    schoolId: number;
    facilityId?: number;
    itemCode: string;
    itemNameAr: string;
    unitPrice: number;
    stockQuantity: number;
    nutritionalCategory: number;
    isApprovedByHealthOfficer: boolean;
    itemNameEn?: string;
    costPrice: number;
    reorderThresholdQuantity: number;
    barcodeNumber?: string;
    dailySalesLimitPerStudent: number;
    isAvailable: boolean;
}

export interface SchoolCanteenItem {
    id: number;
    schoolId: number;
    facilityId?: number;
    itemCode: string;
    itemNameAr: string;
    unitPrice: number;
    stockQuantity: number;
    nutritionalCategory: number;
    isApprovedByHealthOfficer: boolean;
    itemNameEn?: string;
    costPrice: number;
    reorderThresholdQuantity: number;
    barcodeNumber?: string;
    dailySalesLimitPerStudent: number;
    isAvailable: boolean;
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

export interface UpdateSchoolCanteenItemPayload {
    id?: number;
    facilityId?: number;
    itemCode?: string;
    itemNameAr?: string;
    unitPrice?: number;
    stockQuantity?: number;
    nutritionalCategory?: number;
    isApprovedByHealthOfficer?: boolean;
    itemNameEn?: string;
    costPrice?: number;
    reorderThresholdQuantity?: number;
    barcodeNumber?: string;
    dailySalesLimitPerStudent?: number;
    isAvailable?: boolean;
}
