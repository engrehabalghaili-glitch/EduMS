export interface CreateStaffCustodySummaryPayload {
    employeeId: number;
    custodySummaryJson?: string;
    totalItemsCount: number;
    totalEstimatedValue: number;
    custodyIssuedDate?: string;
    lastUpdateDate?: string;
    custodyStatus: number;
    clearanceDate?: string;
    clearedByUserId?: number;
    clearanceNotes?: string;
    clearanceDocumentUrl?: string;
    notes?: string;
}

export interface StaffCustodySummary {
    id: number;
    employeeId: number;
    custodySummaryJson?: string;
    totalItemsCount: number;
    totalEstimatedValue: number;
    custodyIssuedDate?: string;
    lastUpdateDate?: string;
    custodyStatus: number;
    clearanceDate?: string;
    clearedByUserId?: number;
    clearanceNotes?: string;
    clearanceDocumentUrl?: string;
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

export interface UpdateStaffCustodySummaryPayload {
    id?: number;
    employeeId?: number;
    custodySummaryJson?: string;
    totalItemsCount?: number;
    totalEstimatedValue?: number;
    custodyIssuedDate?: string;
    lastUpdateDate?: string;
    custodyStatus?: number;
    clearanceDate?: string;
    clearedByUserId?: number;
    clearanceNotes?: string;
    clearanceDocumentUrl?: string;
    notes?: string;
}
