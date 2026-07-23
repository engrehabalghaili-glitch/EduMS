export interface CreateSystemReportPayload {
    schoolId: number;
    reportType: string;
    reportSubType?: string;
    reportTitle: string;
    reportFrequency: number;
    periodStart?: string;
    periodEnd?: string;
    generationDate: string;
    generationMethod: number;
    generatedByUserId?: number;
    fileFormat?: string;
    filePath?: string;
    fileSizeBytes: number;
    reportStatus: number;
    isPublished: boolean;
    publishedAt?: string;
    publishedByUserId?: number;
    viewCount: number;
    lastViewedAt?: string;
    notes?: string;
}

export interface SystemReport {
    id: number;
    schoolId: number;
    reportType: string;
    reportSubType?: string;
    reportTitle: string;
    reportFrequency: number;
    periodStart?: string;
    periodEnd?: string;
    generationDate: string;
    generationMethod: number;
    generatedByUserId?: number;
    fileFormat?: string;
    filePath?: string;
    fileSizeBytes: number;
    reportStatus: number;
    isPublished: boolean;
    publishedAt?: string;
    publishedByUserId?: number;
    viewCount: number;
    lastViewedAt?: string;
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

export interface UpdateSystemReportPayload {
    id?: number;
    schoolId?: number;
    reportType?: string;
    reportSubType?: string;
    reportTitle?: string;
    reportFrequency?: number;
    periodStart?: string;
    periodEnd?: string;
    generationDate?: string;
    generationMethod?: number;
    generatedByUserId?: number;
    fileFormat?: string;
    filePath?: string;
    fileSizeBytes?: number;
    reportStatus?: number;
    isPublished?: boolean;
    publishedAt?: string;
    publishedByUserId?: number;
    viewCount?: number;
    lastViewedAt?: string;
    notes?: string;
}
