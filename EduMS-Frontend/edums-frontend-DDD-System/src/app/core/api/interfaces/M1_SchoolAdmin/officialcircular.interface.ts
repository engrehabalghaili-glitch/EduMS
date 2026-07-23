export interface CreateOfficialCircularPayload {
    circularNumber: string;
    issueDate: string;
    titleAr: string;
    titleEn: string;
    circularType: number;
    issuerName: string;
    targetAudience: number;
    contentBody?: string;
    issuerEmployeeId?: number;
    attachmentFileUrl?: string;
    requiresMandatoryAcknowledgment: boolean;
    acknowledgmentDeadline?: string;
}

export interface OfficialCircular {
    id: number;
    circularNumber: string;
    issueDate: string;
    titleAr: string;
    titleEn: string;
    circularType: number;
    issuerName: string;
    targetAudience: number;
    effectiveDate: string;
    isActive: boolean;
    contentBody?: string;
    issuerEmployeeId?: number;
    attachmentFileUrl?: string;
    requiresMandatoryAcknowledgment: boolean;
    acknowledgmentDeadline?: string;
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

export interface UpdateOfficialCircularPayload {
    id?: number;
    circularNumber?: string;
    issueDate?: string;
    titleAr?: string;
    titleEn?: string;
    circularType?: number;
    issuerName?: string;
    targetAudience?: number;
    contentBody?: string;
    issuerEmployeeId?: number;
    attachmentFileUrl?: string;
    requiresMandatoryAcknowledgment?: boolean;
    acknowledgmentDeadline?: string;
}
