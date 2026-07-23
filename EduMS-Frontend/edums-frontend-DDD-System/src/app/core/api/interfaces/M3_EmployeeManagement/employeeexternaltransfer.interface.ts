export interface CreateEmployeeExternalTransferPayload {
    employeeId: number;
    fromSchoolId?: number;
    toSchoolId?: number;
    fromDirectorateId?: number;
    toDirectorateId?: number;
    fromOrganizationalSectorId?: number;
    toOrganizationalSectorId?: number;
    transferRequestNumber: string;
    requestDate: string;
    transferDirection: number;
    transferReason: string;
    effectiveDate?: string;
    returnDate?: string;
    ministryDecisionNumber?: string;
    ministryDecisionDate?: string;
    decisionDocumentUrl?: string;
    approvalStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}

export interface EmployeeExternalTransfer {
    id: number;
    employeeId: number;
    fromSchoolId?: number;
    toSchoolId?: number;
    fromDirectorateId?: number;
    toDirectorateId?: number;
    fromOrganizationalSectorId?: number;
    toOrganizationalSectorId?: number;
    transferRequestNumber: string;
    requestDate: string;
    transferDirection: number;
    transferReason: string;
    effectiveDate?: string;
    returnDate?: string;
    ministryDecisionNumber?: string;
    ministryDecisionDate?: string;
    decisionDocumentUrl?: string;
    approvalStatus: number;
    approvedByUserId?: number;
    approvalDate?: string;
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

export interface UpdateEmployeeExternalTransferPayload {
    id?: number;
    employeeId?: number;
    fromSchoolId?: number;
    toSchoolId?: number;
    fromDirectorateId?: number;
    toDirectorateId?: number;
    fromOrganizationalSectorId?: number;
    toOrganizationalSectorId?: number;
    transferRequestNumber?: string;
    requestDate?: string;
    transferDirection?: number;
    transferReason?: string;
    effectiveDate?: string;
    returnDate?: string;
    ministryDecisionNumber?: string;
    ministryDecisionDate?: string;
    decisionDocumentUrl?: string;
    approvalStatus?: number;
    approvedByUserId?: number;
    approvalDate?: string;
    notes?: string;
}
