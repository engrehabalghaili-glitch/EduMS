export interface CreateDashboardKpiConfigurationPayload {
    schoolId?: number;
    kpiCode: string;
    kpiNameAr: string;
    kpiNameEn?: string;
    kpiDescription?: string;
    sourceModule: string;
    sourceTable?: string;
    sourceField?: string;
    aggregationMethod: number;
    chartType: number;
    refreshIntervalMinutes: number;
    targetValue?: number;
    thresholdGreen?: number;
    thresholdYellow?: number;
    thresholdRed?: number;
    alertEnabled: boolean;
    alertRecipientsJson?: string;
    isActive: boolean;
    displayOrder: number;
    dashboardId?: number;
}

export interface DashboardKpiConfiguration {
    id: number;
    schoolId?: number;
    kpiCode: string;
    kpiNameAr: string;
    kpiNameEn?: string;
    kpiDescription?: string;
    sourceModule: string;
    sourceTable?: string;
    sourceField?: string;
    aggregationMethod: number;
    chartType: number;
    refreshIntervalMinutes: number;
    targetValue?: number;
    thresholdGreen?: number;
    thresholdYellow?: number;
    thresholdRed?: number;
    alertEnabled: boolean;
    alertRecipientsJson?: string;
    isActive: boolean;
    displayOrder: number;
    dashboardId?: number;
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

export interface UpdateDashboardKpiConfigurationPayload {
    id?: number;
    schoolId?: number;
    kpiCode?: string;
    kpiNameAr?: string;
    kpiNameEn?: string;
    kpiDescription?: string;
    sourceModule?: string;
    sourceTable?: string;
    sourceField?: string;
    aggregationMethod?: number;
    chartType?: number;
    refreshIntervalMinutes?: number;
    targetValue?: number;
    thresholdGreen?: number;
    thresholdYellow?: number;
    thresholdRed?: number;
    alertEnabled?: boolean;
    alertRecipientsJson?: string;
    isActive?: boolean;
    displayOrder?: number;
    dashboardId?: number;
}
