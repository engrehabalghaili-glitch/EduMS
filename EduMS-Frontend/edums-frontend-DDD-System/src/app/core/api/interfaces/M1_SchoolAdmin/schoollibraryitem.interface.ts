export interface CreateSchoolLibraryItemPayload {
    schoolId: number;
    itemCode: string;
    titleAr: string;
    titleEn?: string;
    authorName: string;
    publisherName?: string;
    isbnNumber?: string;
    category: number;
    totalCopiesCount: number;
    availableCopiesCount: number;
    shelfLocationCode?: string;
    unitPurchaseCost: number;
    acquisitionDate?: string;
}

export interface SchoolLibraryItem {
    id: number;
    schoolId: number;
    itemCode: string;
    titleAr: string;
    titleEn?: string;
    authorName: string;
    publisherName?: string;
    isbnNumber?: string;
    category: number;
    itemStatus: number;
    totalCopiesCount: number;
    availableCopiesCount: number;
    shelfLocationCode?: string;
    unitPurchaseCost: number;
    acquisitionDate?: string;
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

export interface UpdateSchoolLibraryItemPayload {
    id?: number;
    itemCode?: string;
    titleAr?: string;
    titleEn?: string;
    authorName?: string;
    publisherName?: string;
    isbnNumber?: string;
    category?: number;
    totalCopiesCount?: number;
    availableCopiesCount?: number;
    shelfLocationCode?: string;
    unitPurchaseCost?: number;
    acquisitionDate?: string;
}
