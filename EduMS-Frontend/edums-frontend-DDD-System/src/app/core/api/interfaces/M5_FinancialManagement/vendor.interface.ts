export interface CreateVendorPayload {
    vendorName: string;
    taxNumber?: string;
    contactName?: string;
    contactEmail?: string;
    contactPhone?: string;
    isActive: boolean;
}

export interface UpdateVendorPayload {
    id?: number;
    vendorName?: string;
    taxNumber?: string;
    contactName?: string;
    contactEmail?: string;
    contactPhone?: string;
    isActive?: boolean;
}

export interface Vendor {
    id: number;
    vendorName: string;
    taxNumber?: string;
    contactName?: string;
    contactEmail?: string;
    contactPhone?: string;
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
