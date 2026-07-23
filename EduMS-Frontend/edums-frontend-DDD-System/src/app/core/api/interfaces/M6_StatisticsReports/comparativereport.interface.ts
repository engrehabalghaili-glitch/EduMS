export interface ComparativeReport {
    id: number;
    schoolId: number;
    reportNumber: string;
    comparisonTitle: string;
    firstPeriodLabel: string;
    firstPeriodStart: string;
    firstPeriodEnd: string;
    secondPeriodLabel: string;
    secondPeriodStart: string;
    secondPeriodEnd: string;
    comparisonType: string;
    kpiComparedJson?: string;
    comparisonDataJson?: string;
    autoInsights?: string;
    summary?: string;
    generationDate: string;
    generatedByUserId?: number;
    fileFormat?: string;
    filePath?: string;
    viewCount: number;
    lastViewedAt?: string;
    reportStatus: number;
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

export interface CreateComparativeReportPayload {
    schoolId: number;
    reportNumber: string;
    comparisonTitle: string;
    firstPeriodLabel: string;
    firstPeriodStart: string;
    firstPeriodEnd: string;
    secondPeriodLabel: string;
    secondPeriodStart: string;
    secondPeriodEnd: string;
    comparisonType: string;
    kpiComparedJson?: string;
    comparisonDataJson?: string;
    autoInsights?: string;
    summary?: string;
    generationDate: string;
    generatedByUserId?: number;
    fileFormat?: string;
    filePath?: string;
    viewCount: number;
    lastViewedAt?: string;
    reportStatus: number;
    notes?: string;
}

export interface UpdateComparativeReportPayload {
    id?: number;
    schoolId?: number;
    reportNumber?: string;
    comparisonTitle?: string;
    firstPeriodLabel?: string;
    firstPeriodStart?: string;
    firstPeriodEnd?: string;
    secondPeriodLabel?: string;
    secondPeriodStart?: string;
    secondPeriodEnd?: string;
    comparisonType?: string;
    kpiComparedJson?: string;
    comparisonDataJson?: string;
    autoInsights?: string;
    summary?: string;
    generationDate?: string;
    generatedByUserId?: number;
    fileFormat?: string;
    filePath?: string;
    viewCount?: number;
    lastViewedAt?: string;
    reportStatus?: number;
    notes?: string;
}
