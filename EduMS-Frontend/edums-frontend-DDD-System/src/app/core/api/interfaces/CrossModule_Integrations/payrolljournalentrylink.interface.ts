export interface CreatePayrollJournalEntryLinkPayload {
    payrollDetailId: number;
    journalEntryId: number;
    employeeId: number;
    payrollRunId: number;
    salaryAmount: number;
    notes?: string;
}

export interface PayrollJournalEntryLink {
    id: number;
    payrollDetailId: number;
    journalEntryId: number;
    employeeId: number;
    payrollRunId: number;
    salaryAmount: number;
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

export interface UpdatePayrollJournalEntryLinkPayload {
    id?: number;
    payrollDetailId?: number;
    journalEntryId?: number;
    employeeId?: number;
    payrollRunId?: number;
    salaryAmount?: number;
    notes?: string;
}
