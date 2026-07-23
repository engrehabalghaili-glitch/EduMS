export interface CreateEmployeePayrollFinancialContractPayload {
    employeePayrollId: number;
    employeeId: number;
    organizationalSectorId?: number;
    financialTransactionReferenceNumber: string;
    costCenterCode: string;
    budgetLineCode: string;
    totalGrossAmount: number;
    totalDeductionsAmount: number;
    netDisbursementAmount: number;
    currency: string;
    disbursementStatus: number;
    disbursementDate?: string;
    bankTransferReference?: string;
    financialAuditorEmployeeId?: number;
    financialAuditNotes?: string;
}

export interface EmployeePayrollFinancialContract {
    id: number;
    employeePayrollId: number;
    employeeId: number;
    organizationalSectorId?: number;
    financialTransactionReferenceNumber: string;
    costCenterCode: string;
    budgetLineCode: string;
    totalGrossAmount: number;
    totalDeductionsAmount: number;
    netDisbursementAmount: number;
    currency: string;
    disbursementStatus: number;
    disbursementDate?: string;
    bankTransferReference?: string;
    financialAuditorEmployeeId?: number;
    financialAuditNotes?: string;
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

export interface UpdateEmployeePayrollFinancialContractPayload {
    id?: number;
    employeePayrollId?: number;
    employeeId?: number;
    organizationalSectorId?: number;
    financialTransactionReferenceNumber?: string;
    costCenterCode?: string;
    budgetLineCode?: string;
    totalGrossAmount?: number;
    totalDeductionsAmount?: number;
    netDisbursementAmount?: number;
    currency?: string;
    disbursementStatus?: number;
    disbursementDate?: string;
    bankTransferReference?: string;
    financialAuditorEmployeeId?: number;
    financialAuditNotes?: string;
}
