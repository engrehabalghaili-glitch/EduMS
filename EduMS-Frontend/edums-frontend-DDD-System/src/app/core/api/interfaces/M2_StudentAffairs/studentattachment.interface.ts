export interface CreateStudentAttachmentPayload {
    studentId: number;
    attachmentTitleAr: string;
    attachmentCategory: number;
    fileName: string;
    filePathUrl: string;
    fileSizeKb: number;
    uploadDate: string;
    attachmentTitleEn?: string;
    mimeType?: string;
    isConfidential: boolean;
    uploadedByEmployeeId?: number;
}

export interface StudentAttachment {
    id: number;
    studentId: number;
    attachmentTitleAr: string;
    attachmentCategory: number;
    fileName: string;
    filePathUrl: string;
    fileSizeKb: number;
    uploadDate: string;
    attachmentTitleEn?: string;
    mimeType?: string;
    isConfidential: boolean;
    uploadedByEmployeeId?: number;
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

export interface UpdateStudentAttachmentPayload {
    id?: number;
    attachmentTitleAr?: string;
    attachmentCategory?: number;
    fileName?: string;
    filePathUrl?: string;
    fileSizeKb?: number;
    uploadDate?: string;
    attachmentTitleEn?: string;
    mimeType?: string;
    isConfidential?: boolean;
    uploadedByEmployeeId?: number;
}
