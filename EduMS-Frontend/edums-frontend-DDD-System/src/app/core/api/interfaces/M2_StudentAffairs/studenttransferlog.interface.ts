export interface CreateStudentTransferLogPayload {
    studentId: number;
    fromSchoolId: number;
    toSchoolId: number;
    transferDate: string;
    reason: string;
    transferCertificateNumber?: string;
    ministryApprovalReference?: string;
    transferRemarks?: string;
}

export interface StudentTransferLog {
    id: number;
    studentId: number;
    fromSchoolId: number;
    toSchoolId: number;
    transferDate: string;
    reason: string;
    status: number;
    transferCertificateNumber?: string;
    approvedByEmployeeId?: number;
    ministryApprovalReference?: string;
    transferRemarks?: string;
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

export interface UpdateStudentTransferLogPayload {
    id?: number;
    fromSchoolId?: number;
    toSchoolId?: number;
    transferDate?: string;
    reason?: string;
    transferCertificateNumber?: string;
    ministryApprovalReference?: string;
    transferRemarks?: string;
}
