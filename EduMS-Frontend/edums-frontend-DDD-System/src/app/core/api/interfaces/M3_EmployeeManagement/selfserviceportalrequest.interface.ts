export interface CreateSelfServicePortalRequestPayload {
    employeeId: number;
    requestType: number;
    requestTitleAr: string;
    requestDetailsText?: string;
    submissionDate: string;
    requestStatus: number;
    reviewedByUserId?: number;
    reviewDate?: string;
    rejectionReason?: string;
    attachmentUrl?: string;
    notes?: string;
}

export interface SelfServicePortalRequest {
    id: number;
    employeeId: number;
    requestType: number;
    requestTitleAr: string;
    requestDetailsText?: string;
    submissionDate: string;
    requestStatus: number;
    reviewedByUserId?: number;
    reviewDate?: string;
    rejectionReason?: string;
    attachmentUrl?: string;
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

export interface UpdateSelfServicePortalRequestPayload {
    id?: number;
    employeeId?: number;
    requestType?: number;
    requestTitleAr?: string;
    requestDetailsText?: string;
    submissionDate?: string;
    requestStatus?: number;
    reviewedByUserId?: number;
    reviewDate?: string;
    rejectionReason?: string;
    attachmentUrl?: string;
    notes?: string;
}
