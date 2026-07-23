export interface CreateEmployeeFinancialTransactionPayload {
    employeeId: number;
    organizationalSectorId?: number;
    schoolId?: number;
    directorateId?: number;
    transactionReferenceNumber: string;
    transactionType: number;
    amount: number;
    currency: string;
    transactionDate: string;
    descriptionAr: string;
    descriptionEn?: string;
    approvalStatus: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    module5VoucherReference?: string;
    notes?: string;
}

export interface EmployeeFinancialTransaction {
    id: number;
    employeeId: number;
    organizationalSectorId?: number;
    schoolId?: number;
    directorateId?: number;
    transactionReferenceNumber: string;
    transactionType: number;
    amount: number;
    currency: string;
    transactionDate: string;
    descriptionAr: string;
    descriptionEn?: string;
    approvalStatus: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    module5VoucherReference?: string;
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

export interface UpdateEmployeeFinancialTransactionPayload {
    id?: number;
    employeeId?: number;
    organizationalSectorId?: number;
    schoolId?: number;
    directorateId?: number;
    transactionReferenceNumber?: string;
    transactionType?: number;
    amount?: number;
    currency?: string;
    transactionDate?: string;
    descriptionAr?: string;
    descriptionEn?: string;
    approvalStatus?: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    module5VoucherReference?: string;
    notes?: string;
}
