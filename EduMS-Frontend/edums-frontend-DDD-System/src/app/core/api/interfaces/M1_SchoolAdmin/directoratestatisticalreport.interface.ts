export interface CreateDirectorateStatisticalReportPayload {
    directorateId: number;
    reportCode: string;
    reportTitleAr: string;
    reportTitleEn?: string;
    targetCategory: number;
    periodType: number;
    targetAcademicYear: string;
    statisticalDataPayloadJson: string;
    analyticalSummary?: string;
    recommendationsText?: string;
    generationDate: string;
    compiledByEmployeeId?: number;
}

export interface DirectorateStatisticalReport {
    id: number;
    directorateId: number;
    reportCode: string;
    reportTitleAr: string;
    reportTitleEn?: string;
    targetCategory: number;
    periodType: number;
    targetAcademicYear: string;
    statisticalDataPayloadJson: string;
    analyticalSummary?: string;
    recommendationsText?: string;
    generationDate: string;
    compiledByEmployeeId?: number;
    verificationStatus: number;
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

export interface UpdateDirectorateStatisticalReportPayload {
    id?: number;
    reportCode?: string;
    reportTitleAr?: string;
    reportTitleEn?: string;
    targetCategory?: number;
    periodType?: number;
    targetAcademicYear?: string;
    statisticalDataPayloadJson?: string;
    analyticalSummary?: string;
    recommendationsText?: string;
    generationDate?: string;
    compiledByEmployeeId?: number;
}
