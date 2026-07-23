export interface CreateStudentPreviousAcademicHistoryPayload {
    studentId: number;
    previousSchoolName: string;
    previousDirectorateName: string;
    academicYearCompleted: string;
    gradeLevelCompleted: number;
    cumulativeScoreEarned: number;
    maximumPossibleScore: number;
    percentagePercentage: number;
    leavingCertificateNumber?: string;
    leavingDate: string;
    transcriptDocumentUrl?: string;
}

export interface StudentPreviousAcademicHistory {
    id: number;
    studentId: number;
    previousSchoolName: string;
    previousDirectorateName: string;
    academicYearCompleted: string;
    gradeLevelCompleted: number;
    cumulativeScoreEarned: number;
    maximumPossibleScore: number;
    percentagePercentage: number;
    leavingCertificateNumber?: string;
    leavingDate: string;
    verificationStatus: number;
    transcriptDocumentUrl?: string;
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

export interface UpdateStudentPreviousAcademicHistoryPayload {
    id?: number;
    previousSchoolName?: string;
    previousDirectorateName?: string;
    academicYearCompleted?: string;
    gradeLevelCompleted?: number;
    cumulativeScoreEarned?: number;
    maximumPossibleScore?: number;
    percentagePercentage?: number;
    leavingCertificateNumber?: string;
    leavingDate?: string;
    transcriptDocumentUrl?: string;
}
