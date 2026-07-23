export interface CreateTrendAnalysisResultPayload {
    schoolId: number;
    studyPeriod: string;
    startYear: string;
    endYear: string;
    kpiCode: string;
    historicalValuesJson?: string;
    trendDirection?: string;
    slope?: number;
    correlationCoefficient?: number;
    forecastedValueNext1Year?: number;
    forecastedValueNext2Year?: number;
    confidenceLevel?: number;
    lowerBound?: number;
    upperBound?: number;
    forecastingMethod?: string;
    analysisDate: string;
    analyzedByUserId?: number;
    analysisStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface TrendAnalysisResult {
    id: number;
    schoolId: number;
    studyPeriod: string;
    startYear: string;
    endYear: string;
    kpiCode: string;
    historicalValuesJson?: string;
    trendDirection?: string;
    slope?: number;
    correlationCoefficient?: number;
    forecastedValueNext1Year?: number;
    forecastedValueNext2Year?: number;
    confidenceLevel?: number;
    lowerBound?: number;
    upperBound?: number;
    forecastingMethod?: string;
    analysisDate: string;
    analyzedByUserId?: number;
    analysisStatus: number;
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

export interface UpdateTrendAnalysisResultPayload {
    id?: number;
    schoolId?: number;
    studyPeriod?: string;
    startYear?: string;
    endYear?: string;
    kpiCode?: string;
    historicalValuesJson?: string;
    trendDirection?: string;
    slope?: number;
    correlationCoefficient?: number;
    forecastedValueNext1Year?: number;
    forecastedValueNext2Year?: number;
    confidenceLevel?: number;
    lowerBound?: number;
    upperBound?: number;
    forecastingMethod?: string;
    analysisDate?: string;
    analyzedByUserId?: number;
    analysisStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
