export interface CreateKpiMetricRecordPayload {
    kpiConfigId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    periodType: number;
    periodValue: number;
    periodStartDate: string;
    periodEndDate: string;
    actualValue: number;
    targetValue?: number;
    previousValue?: number;
    changePercentage: number;
    statusColor?: string;
    calculationMethod: number;
    calculationDate: string;
    calculatedByUserId?: number;
    isVerified: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
    notes?: string;
}

export interface KpiMetricRecord {
    id: number;
    kpiConfigId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    periodType: number;
    periodValue: number;
    periodStartDate: string;
    periodEndDate: string;
    actualValue: number;
    targetValue?: number;
    previousValue?: number;
    changePercentage: number;
    statusColor?: string;
    calculationMethod: number;
    calculationDate: string;
    calculatedByUserId?: number;
    isVerified: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
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

export interface UpdateKpiMetricRecordPayload {
    id?: number;
    kpiConfigId?: number;
    schoolId?: number;
    schoolAcademicYearId?: number;
    periodType?: number;
    periodValue?: number;
    periodStartDate?: string;
    periodEndDate?: string;
    actualValue?: number;
    targetValue?: number;
    previousValue?: number;
    changePercentage?: number;
    statusColor?: string;
    calculationMethod?: number;
    calculationDate?: string;
    calculatedByUserId?: number;
    isVerified?: boolean;
    verifiedByUserId?: number;
    verifiedAt?: string;
    notes?: string;
}
