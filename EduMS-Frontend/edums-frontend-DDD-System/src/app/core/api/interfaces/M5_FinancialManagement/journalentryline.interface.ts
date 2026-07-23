export interface CreateJournalEntryLinePayload {
    journalEntryId: number;
    accountId: number;
    debitAmount: number;
    creditAmount: number;
    description: string;
}

export interface JournalEntryLine {
    id: number;
    journalEntryId: number;
    accountId: number;
    debitAmount: number;
    creditAmount: number;
    description: string;
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

export interface UpdateJournalEntryLinePayload {
    id?: number;
    journalEntryId?: number;
    accountId?: number;
    debitAmount?: number;
    creditAmount?: number;
    description?: string;
}
