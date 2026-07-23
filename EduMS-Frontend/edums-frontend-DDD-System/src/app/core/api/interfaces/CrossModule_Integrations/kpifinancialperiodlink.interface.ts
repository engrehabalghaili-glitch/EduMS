export interface CreateKpiFinancialPeriodLinkPayload {
    kpiMetricRecordId: number;
    payrollRunId?: number;
    journalEntryId?: number;
    schoolId: number;
    periodLabel: string;
    notes?: string;
}

export interface KpiFinancialPeriodLink {
    id: number;
    kpiMetricRecordId: number;
    payrollRunId?: number;
    journalEntryId?: number;
    schoolId: number;
    periodLabel: string;
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

export interface UpdateKpiFinancialPeriodLinkPayload {
    id?: number;
    kpiMetricRecordId?: number;
    payrollRunId?: number;
    journalEntryId?: number;
    schoolId?: number;
    periodLabel?: string;
    notes?: string;
}
