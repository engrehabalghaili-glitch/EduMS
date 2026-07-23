export interface CreateStudentAbsenceExcusalPayload {
    studentId: number;
    startDate: string;
    endDate: string;
    excusalType: number;
    reasonDescription: string;
    medicalReportAttachmentUrl?: string;
    reviewedByEmployeeId?: number;
    submittedByGuardianId?: number;
    submissionDate: string;
    reviewRemarks?: string;
}

export interface StudentAbsenceExcusal {
    id: number;
    studentId: number;
    startDate: string;
    endDate: string;
    excusalType: number;
    reasonDescription: string;
    medicalReportAttachmentUrl?: string;
    reviewStatus: number;
    reviewedByEmployeeId?: number;
    submittedByGuardianId?: number;
    submissionDate: string;
    reviewRemarks?: string;
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

export interface UpdateStudentAbsenceExcusalPayload {
    id?: number;
    startDate?: string;
    endDate?: string;
    excusalType?: number;
    reasonDescription?: string;
    medicalReportAttachmentUrl?: string;
    reviewedByEmployeeId?: number;
    submittedByGuardianId?: number;
    submissionDate?: string;
    reviewRemarks?: string;
}
