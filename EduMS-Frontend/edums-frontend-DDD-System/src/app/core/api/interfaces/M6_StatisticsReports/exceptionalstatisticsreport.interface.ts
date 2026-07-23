export interface CreateExceptionalStatisticsReportPayload {
    schoolId: number;
    schoolAcademicYearId?: number;
    reportNumber: string;
    totalIncidents: number;
    totalClosureDays: number;
    totalDamageCost: number;
    totalAwardsCount: number;
    totalParticipationsCount: number;
    totalDeficitCount: number;
    totalSurplusCount: number;
    emergencySummaryJson?: string;
    closureSummaryJson?: string;
    awardSummaryJson?: string;
    generationDate: string;
    generatedByUserId?: number;
    filePath?: string;
    reportStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface ExceptionalStatisticsReport {
    id: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    reportNumber: string;
    totalIncidents: number;
    totalClosureDays: number;
    totalDamageCost: number;
    totalAwardsCount: number;
    totalParticipationsCount: number;
    totalDeficitCount: number;
    totalSurplusCount: number;
    emergencySummaryJson?: string;
    closureSummaryJson?: string;
    awardSummaryJson?: string;
    generationDate: string;
    generatedByUserId?: number;
    filePath?: string;
    reportStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
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

export interface UpdateExceptionalStatisticsReportPayload {
    id?: number;
    schoolId?: number;
    schoolAcademicYearId?: number;
    reportNumber?: string;
    totalIncidents?: number;
    totalClosureDays?: number;
    totalDamageCost?: number;
    totalAwardsCount?: number;
    totalParticipationsCount?: number;
    totalDeficitCount?: number;
    totalSurplusCount?: number;
    emergencySummaryJson?: string;
    closureSummaryJson?: string;
    awardSummaryJson?: string;
    generationDate?: string;
    generatedByUserId?: number;
    filePath?: string;
    reportStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
