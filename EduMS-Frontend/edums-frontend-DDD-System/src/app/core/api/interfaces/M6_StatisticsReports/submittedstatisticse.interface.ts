export interface CreateSubmittedStatisticsPayload {
    statisticsDraftId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    submissionNumber: string;
    submissionTimestamp: string;
    submissionMethod: number;
    submittedByUserId: number;
    directorSignatureHash?: string;
    directorSignatureDate?: string;
    studentDataSnapshotJson?: string;
    staffDataSnapshotJson?: string;
    financialSummarySnapshotJson?: string;
    approvalStatus: number;
    reviewerNotes?: string;
    reviewDate?: string;
    reviewedByUserId?: number;
    rejectionReason?: string;
    approvalDate?: string;
    isFinal: boolean;
    isArchived: boolean;
    archivedAt?: string;
    notes?: string;
}

export interface SubmittedStatistics {
    id: number;
    statisticsDraftId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    submissionNumber: string;
    submissionTimestamp: string;
    submissionMethod: number;
    submittedByUserId: number;
    directorSignatureHash?: string;
    directorSignatureDate?: string;
    studentDataSnapshotJson?: string;
    staffDataSnapshotJson?: string;
    financialSummarySnapshotJson?: string;
    approvalStatus: number;
    reviewerNotes?: string;
    reviewDate?: string;
    reviewedByUserId?: number;
    rejectionReason?: string;
    approvalDate?: string;
    isFinal: boolean;
    isArchived: boolean;
    archivedAt?: string;
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

export interface UpdateSubmittedStatisticsPayload {
    id?: number;
    statisticsDraftId?: number;
    schoolId?: number;
    schoolAcademicYearId?: number;
    submissionNumber?: string;
    submissionTimestamp?: string;
    submissionMethod?: number;
    submittedByUserId?: number;
    directorSignatureHash?: string;
    directorSignatureDate?: string;
    studentDataSnapshotJson?: string;
    staffDataSnapshotJson?: string;
    financialSummarySnapshotJson?: string;
    approvalStatus?: number;
    reviewerNotes?: string;
    reviewDate?: string;
    reviewedByUserId?: number;
    rejectionReason?: string;
    approvalDate?: string;
    isFinal?: boolean;
    isArchived?: boolean;
    archivedAt?: string;
    notes?: string;
}
