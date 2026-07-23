export interface AssetDocument {
    id: number;
    assetId: number;
    contractId?: number;
    docType: string;
    docCode: string;
    docNameAr: string;
    description?: string;
    fileName?: string;
    filePath?: string;
    fileType?: string;
    uploadDate?: string;
    uploadedByUserId?: number;
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

export interface CreateAssetDocumentPayload {
    assetId: number;
    contractId?: number;
    docType: string;
    docCode: string;
    docNameAr: string;
    description?: string;
    fileName?: string;
    filePath?: string;
    fileType?: string;
    uploadDate?: string;
    uploadedByUserId?: number;
    isVerified: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
    notes?: string;
}

export interface UpdateAssetDocumentPayload {
    id?: number;
    assetId?: number;
    contractId?: number;
    docType?: string;
    docCode?: string;
    docNameAr?: string;
    description?: string;
    fileName?: string;
    filePath?: string;
    fileType?: string;
    uploadDate?: string;
    uploadedByUserId?: number;
    isVerified?: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
    notes?: string;
}
