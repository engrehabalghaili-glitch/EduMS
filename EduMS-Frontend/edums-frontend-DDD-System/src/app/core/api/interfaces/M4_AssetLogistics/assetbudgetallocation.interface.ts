export interface AssetBudgetAllocation {
    id: number;
    schoolId: number;
    fiscalYear: string;
    budgetType: number;
    assetCategoryId?: number;
    departmentId?: number;
    allocatedAmount: number;
    spentAmount: number;
    remainingAmount: number;
    budgetLineCode?: string;
    allocationStatus: number;
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

export interface CreateAssetBudgetAllocationPayload {
    schoolId: number;
    fiscalYear: string;
    budgetType: number;
    assetCategoryId?: number;
    departmentId?: number;
    allocatedAmount: number;
    spentAmount: number;
    remainingAmount: number;
    budgetLineCode?: string;
    allocationStatus: number;
    notes?: string;
}

export interface UpdateAssetBudgetAllocationPayload {
    id?: number;
    schoolId?: number;
    fiscalYear?: string;
    budgetType?: number;
    assetCategoryId?: number;
    departmentId?: number;
    allocatedAmount?: number;
    spentAmount?: number;
    remainingAmount?: number;
    budgetLineCode?: string;
    allocationStatus?: number;
    notes?: string;
}
