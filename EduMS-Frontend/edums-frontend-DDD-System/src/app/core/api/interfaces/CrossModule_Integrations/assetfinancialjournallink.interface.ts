export interface AssetFinancialJournalLink {
    id: number;
    schoolAssetId: number;
    journalEntryId: number;
    schoolId: number;
    entryType: string;
    entryAmount: number;
    entryDate: string;
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

export interface CreateAssetFinancialJournalLinkPayload {
    schoolAssetId: number;
    journalEntryId: number;
    schoolId: number;
    entryType: string;
    entryAmount: number;
    entryDate: string;
    notes?: string;
}

export interface UpdateAssetFinancialJournalLinkPayload {
    id?: number;
    schoolAssetId?: number;
    journalEntryId?: number;
    schoolId?: number;
    entryType?: string;
    entryAmount?: number;
    entryDate?: string;
    notes?: string;
}
