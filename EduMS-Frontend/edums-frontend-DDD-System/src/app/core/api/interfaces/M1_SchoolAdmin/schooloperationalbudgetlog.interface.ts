export interface CreateSchoolOperationalBudgetLogPayload {
    directorateId?: number;
    schoolId?: number;
    fiscalYear: string;
    budgetCategoryCode: string;
    categoryNameAr: string;
    allocatedAmount: number;
    consumedAmount: number;
    remainingAmount: number;
    categoryNameEn?: string;
    quarterNumber: number;
    lastTransactionDate?: string;
    notesDescription?: string;
}

export interface SchoolOperationalBudgetLog {
    id: number;
    directorateId?: number;
    schoolId?: number;
    fiscalYear: string;
    budgetCategoryCode: string;
    categoryNameAr: string;
    allocatedAmount: number;
    consumedAmount: number;
    remainingAmount: number;
    status: number;
    categoryNameEn?: string;
    quarterNumber: number;
    approvedByDirectorId?: number;
    lastTransactionDate?: string;
    notesDescription?: string;
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

export interface UpdateSchoolOperationalBudgetLogPayload {
    id?: number;
    fiscalYear?: string;
    budgetCategoryCode?: string;
    categoryNameAr?: string;
    allocatedAmount?: number;
    consumedAmount?: number;
    remainingAmount?: number;
    categoryNameEn?: string;
    quarterNumber?: number;
    lastTransactionDate?: string;
    notesDescription?: string;
}
