export interface CreateSchoolAccreditationLogPayload {
    schoolId: number;
    licenseNumber: string;
    accreditationBody: string;
    issueDate: string;
    expiryDate: string;
    licenseType: number;
    accreditationGrade?: string;
    certificateAttachmentUrl?: string;
    renewalSubmittedDate?: string;
}

export interface SchoolAccreditationLog {
    id: number;
    schoolId: number;
    licenseNumber: string;
    accreditationBody: string;
    issueDate: string;
    expiryDate: string;
    status: number;
    licenseType: number;
    accreditationGrade?: string;
    certificateAttachmentUrl?: string;
    renewalSubmittedDate?: string;
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

export interface UpdateSchoolAccreditationLogPayload {
    id?: number;
    licenseNumber?: string;
    accreditationBody?: string;
    issueDate?: string;
    expiryDate?: string;
    licenseType?: number;
    accreditationGrade?: string;
    certificateAttachmentUrl?: string;
    renewalSubmittedDate?: string;
}
