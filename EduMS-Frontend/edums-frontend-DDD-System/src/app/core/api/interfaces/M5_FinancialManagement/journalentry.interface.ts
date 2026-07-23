export interface CreateJournalEntryPayload {
    schoolId: number;
    entryNumber: string;
    entryDate: string;
    description: string;
    status: number;
}

export interface JournalEntry {
    id: number;
    schoolId: number;
    entryNumber: string;
    entryDate: string;
    description: string;
    status: number;
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

export interface UpdateJournalEntryPayload {
    id?: number;
    schoolId?: number;
    entryNumber?: string;
    entryDate?: string;
    description?: string;
    status?: number;
}
