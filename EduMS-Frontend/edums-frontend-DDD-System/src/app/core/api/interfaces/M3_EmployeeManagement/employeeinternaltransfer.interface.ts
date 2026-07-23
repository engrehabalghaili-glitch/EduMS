export interface CreateEmployeeInternalTransferPayload {
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    transferRequestNumber: string;
    requestDate: string;
    fromDepartmentId: number;
    toDepartmentId: number;
    fromJobTitle?: string;
    toJobTitle?: string;
    transferReason: string;
    effectiveDate?: string;
    approvalStatus: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    decisionDocumentUrl?: string;
    notes?: string;
}

export interface EmployeeInternalTransfer {
    id: number;
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    transferRequestNumber: string;
    requestDate: string;
    fromDepartmentId: number;
    toDepartmentId: number;
    fromJobTitle?: string;
    toJobTitle?: string;
    transferReason: string;
    effectiveDate?: string;
    approvalStatus: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    decisionDocumentUrl?: string;
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

export interface UpdateEmployeeInternalTransferPayload {
    id?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    transferRequestNumber?: string;
    requestDate?: string;
    fromDepartmentId?: number;
    toDepartmentId?: number;
    fromJobTitle?: string;
    toJobTitle?: string;
    transferReason?: string;
    effectiveDate?: string;
    approvalStatus?: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    decisionDocumentUrl?: string;
    notes?: string;
}
