export interface CreateEmergencyFinancialExpenseLinkPayload {
    schoolId: number;
    emergencyIncidentId?: number;
    emergencyHostingId?: number;
    emergencyClosureId?: number;
    journalEntryId: number;
    expenseAmount: number;
    expenseCategory: string;
    notes?: string;
}

export interface EmergencyFinancialExpenseLink {
    id: number;
    schoolId: number;
    emergencyIncidentId?: number;
    emergencyHostingId?: number;
    emergencyClosureId?: number;
    journalEntryId: number;
    expenseAmount: number;
    expenseCategory: string;
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

export interface UpdateEmergencyFinancialExpenseLinkPayload {
    id?: number;
    schoolId?: number;
    emergencyIncidentId?: number;
    emergencyHostingId?: number;
    emergencyClosureId?: number;
    journalEntryId?: number;
    expenseAmount?: number;
    expenseCategory?: string;
    notes?: string;
}
