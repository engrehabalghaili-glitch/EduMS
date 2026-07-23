export interface CreateReferenceCodingLookupPayload {
    schoolId?: number;
    codeType: string;
    codeKey: string;
    codeValueAr: string;
    codeValueEn?: string;
    descriptionAr?: string;
    descriptionEn?: string;
    sortOrder: number;
    isSystemCode: boolean;
    parentCodeId?: number;
    notes?: string;
}

export interface ReferenceCodingLookup {
    id: number;
    schoolId?: number;
    codeType: string;
    codeKey: string;
    codeValueAr: string;
    codeValueEn?: string;
    descriptionAr?: string;
    descriptionEn?: string;
    sortOrder: number;
    isSystemCode: boolean;
    isActive: boolean;
    parentCodeId?: number;
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

export interface UpdateReferenceCodingLookupPayload {
    id?: number;
    codeType?: string;
    codeKey?: string;
    codeValueAr?: string;
    codeValueEn?: string;
    descriptionAr?: string;
    descriptionEn?: string;
    sortOrder?: number;
    isSystemCode?: boolean;
    parentCodeId?: number;
    notes?: string;
}
