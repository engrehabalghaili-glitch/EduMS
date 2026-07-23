export interface AssetLoan {
    id: number;
    assetId: number;
    schoolId: number;
    borrowerType: number;
    borrowerId: number;
    borrowerName: string;
    borrowerContact?: string;
    loanDate: string;
    expectedReturnDate?: string;
    actualReturnDate?: string;
    loanPurpose?: string;
    issuerUserId?: number;
    conditionAtLoan: number;
    conditionAtReturn: number;
    isOverdue: boolean;
    overdueDays: number;
    fineAmount: number;
    isFinePaid: boolean;
    finePaidDate?: string;
    loanStatus: number;
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

export interface CreateAssetLoanPayload {
    assetId: number;
    schoolId: number;
    borrowerType: number;
    borrowerId: number;
    borrowerName: string;
    borrowerContact?: string;
    loanDate: string;
    expectedReturnDate?: string;
    actualReturnDate?: string;
    loanPurpose?: string;
    issuerUserId?: number;
    conditionAtLoan: number;
    conditionAtReturn: number;
    isOverdue: boolean;
    overdueDays: number;
    fineAmount: number;
    isFinePaid: boolean;
    finePaidDate?: string;
    loanStatus: number;
    notes?: string;
}

export interface UpdateAssetLoanPayload {
    id?: number;
    assetId?: number;
    schoolId?: number;
    borrowerType?: number;
    borrowerId?: number;
    borrowerName?: string;
    borrowerContact?: string;
    loanDate?: string;
    expectedReturnDate?: string;
    actualReturnDate?: string;
    loanPurpose?: string;
    issuerUserId?: number;
    conditionAtLoan?: number;
    conditionAtReturn?: number;
    isOverdue?: boolean;
    overdueDays?: number;
    fineAmount?: number;
    isFinePaid?: boolean;
    finePaidDate?: string;
    loanStatus?: number;
    notes?: string;
}
