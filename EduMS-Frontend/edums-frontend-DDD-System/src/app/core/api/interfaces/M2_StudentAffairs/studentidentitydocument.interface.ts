export interface CreateStudentIdentityDocumentPayload {
    studentId: number;
    documentType: number;
    documentNumber: string;
    issueCountry?: string;
    issueDate?: string;
    expiryDate?: string;
    attachmentUrl?: string;
    isVerified: boolean;
    issuePlace?: string;
    verifiedByEmployeeId?: number;
    verificationDate?: string;
}

export interface StudentIdentityDocument {
    id: number;
    studentId: number;
    documentType: number;
    documentNumber: string;
    issueCountry?: string;
    issueDate?: string;
    expiryDate?: string;
    attachmentUrl?: string;
    isVerified: boolean;
    issuePlace?: string;
    verifiedByEmployeeId?: number;
    verificationDate?: string;
    documentStatus: number;
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

export interface UpdateStudentIdentityDocumentPayload {
    id?: number;
    documentType?: number;
    documentNumber?: string;
    issueCountry?: string;
    issueDate?: string;
    expiryDate?: string;
    attachmentUrl?: string;
    isVerified?: boolean;
    issuePlace?: string;
    verifiedByEmployeeId?: number;
    verificationDate?: string;
}
