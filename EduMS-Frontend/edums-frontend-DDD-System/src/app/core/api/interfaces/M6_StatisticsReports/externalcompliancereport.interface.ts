export interface CreateExternalComplianceReportPayload {
    schoolId: number;
    reportNumber: string;
    targetEntityName: string;
    entityType: number;
    standardType?: string;
    reportType: number;
    periodStart?: string;
    periodEnd?: string;
    generationDate: string;
    generatedByUserId?: number;
    filePath?: string;
    submissionDate?: string;
    submissionMethod: number;
    receiptReference?: string;
    receiptDate?: string;
    submissionStatus: number;
    rejectionReason?: string;
    isFinal: boolean;
    finalApprovalDate?: string;
    notes?: string;
}

export interface ExternalComplianceReport {
    id: number;
    schoolId: number;
    reportNumber: string;
    targetEntityName: string;
    entityType: number;
    standardType?: string;
    reportType: number;
    periodStart?: string;
    periodEnd?: string;
    generationDate: string;
    generatedByUserId?: number;
    filePath?: string;
    submissionDate?: string;
    submissionMethod: number;
    receiptReference?: string;
    receiptDate?: string;
    submissionStatus: number;
    rejectionReason?: string;
    isFinal: boolean;
    finalApprovalDate?: string;
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

export interface UpdateExternalComplianceReportPayload {
    id?: number;
    schoolId?: number;
    reportNumber?: string;
    targetEntityName?: string;
    entityType?: number;
    standardType?: string;
    reportType?: number;
    periodStart?: string;
    periodEnd?: string;
    generationDate?: string;
    generatedByUserId?: number;
    filePath?: string;
    submissionDate?: string;
    submissionMethod?: number;
    receiptReference?: string;
    receiptDate?: string;
    submissionStatus?: number;
    rejectionReason?: string;
    isFinal?: boolean;
    finalApprovalDate?: string;
    notes?: string;
}
