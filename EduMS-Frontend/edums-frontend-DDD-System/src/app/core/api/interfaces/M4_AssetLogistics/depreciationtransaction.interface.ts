export interface CreateDepreciationTransactionPayload {
    assetId: number;
    schoolId: number;
    depreciationPolicyId?: number;
    periodStart: string;
    periodEnd: string;
    periodType: number;
    fiscalYear: string;
    periodNumber: number;
    depreciationAmount: number;
    accumulatedDepreciationAfter: number;
    netBookValueAfter: number;
    isPostedToLedger: boolean;
    ledgerEntryReference?: string;
    postedToLedgerDate?: string;
    calculatedByUserId?: number;
    calculationDate?: string;
    notes?: string;
}

export interface DepreciationTransaction {
    id: number;
    assetId: number;
    schoolId: number;
    depreciationPolicyId?: number;
    periodStart: string;
    periodEnd: string;
    periodType: number;
    fiscalYear: string;
    periodNumber: number;
    depreciationAmount: number;
    accumulatedDepreciationAfter: number;
    netBookValueAfter: number;
    isPostedToLedger: boolean;
    ledgerEntryReference?: string;
    postedToLedgerDate?: string;
    calculatedByUserId?: number;
    calculationDate?: string;
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

export interface UpdateDepreciationTransactionPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    depreciationPolicyId?: number;
    periodStart?: string;
    periodEnd?: string;
    periodType?: number;
    fiscalYear?: string;
    periodNumber?: number;
    depreciationAmount?: number;
    accumulatedDepreciationAfter?: number;
    netBookValueAfter?: number;
    isPostedToLedger?: boolean;
    ledgerEntryReference?: string;
    postedToLedgerDate?: string;
    calculatedByUserId?: number;
    calculationDate?: string;
    notes?: string;
}
