export interface CreateReportApprovalPayload {
    systemReportId: number;
    schoolId: number;
    submissionDate: string;
    submittedByUserId: number;
    approvalStatus: number;
    reviewerId?: number;
    reviewDate?: string;
    comments?: string;
    rejectionReason?: string;
    approvalDate?: string;
    approvedByUserId?: number;
    digitalSignatureHash?: string;
    certificateNumber?: string;
    certificatePath?: string;
    isFinal: boolean;
    notes?: string;
}

export interface ReportApproval {
    id: number;
    systemReportId: number;
    schoolId: number;
    submissionDate: string;
    submittedByUserId: number;
    approvalStatus: number;
    reviewerId?: number;
    reviewDate?: string;
    comments?: string;
    rejectionReason?: string;
    approvalDate?: string;
    approvedByUserId?: number;
    digitalSignatureHash?: string;
    certificateNumber?: string;
    certificatePath?: string;
    isFinal: boolean;
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

export interface UpdateReportApprovalPayload {
    id?: number;
    systemReportId?: number;
    schoolId?: number;
    submissionDate?: string;
    submittedByUserId?: number;
    approvalStatus?: number;
    reviewerId?: number;
    reviewDate?: string;
    comments?: string;
    rejectionReason?: string;
    approvalDate?: string;
    approvedByUserId?: number;
    digitalSignatureHash?: string;
    certificateNumber?: string;
    certificatePath?: string;
    isFinal?: boolean;
    notes?: string;
}
