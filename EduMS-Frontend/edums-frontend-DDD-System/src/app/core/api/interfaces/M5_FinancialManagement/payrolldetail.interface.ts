export interface CreatePayrollDetailPayload {
    payrollRunId: number;
    employeeId: number;
    baseSalary: number;
    totalAllowances: number;
    totalDeductions: number;
    netSalary: number;
    status: number;
}

export interface PayrollDetail {
    id: number;
    payrollRunId: number;
    employeeId: number;
    baseSalary: number;
    totalAllowances: number;
    totalDeductions: number;
    netSalary: number;
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

export interface UpdatePayrollDetailPayload {
    id?: number;
    payrollRunId?: number;
    employeeId?: number;
    baseSalary?: number;
    totalAllowances?: number;
    totalDeductions?: number;
    netSalary?: number;
    status?: number;
}
