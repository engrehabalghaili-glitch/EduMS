export interface AssetExpense {
    id: number;
    assetId: number;
    schoolId: number;
    expenseType: number;
    expenseDate: string;
    amount: number;
    currency?: string;
    description?: string;
    relatedMaintenanceExecutionId?: number;
    isCapitalized: boolean;
    capitalizationDate?: string;
    accountedInFinancials: boolean;
    accountedInDepreciation: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
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

export interface CreateAssetExpensePayload {
    assetId: number;
    schoolId: number;
    expenseType: number;
    expenseDate: string;
    amount: number;
    currency?: string;
    description?: string;
    relatedMaintenanceExecutionId?: number;
    isCapitalized: boolean;
    capitalizationDate?: string;
    accountedInFinancials: boolean;
    accountedInDepreciation: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface UpdateAssetExpensePayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    expenseType?: number;
    expenseDate?: string;
    amount?: number;
    currency?: string;
    description?: string;
    relatedMaintenanceExecutionId?: number;
    isCapitalized?: boolean;
    capitalizationDate?: string;
    accountedInFinancials?: boolean;
    accountedInDepreciation?: boolean;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
