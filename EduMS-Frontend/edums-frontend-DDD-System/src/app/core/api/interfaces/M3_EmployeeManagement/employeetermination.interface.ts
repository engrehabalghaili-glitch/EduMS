export interface CreateEmployeeTerminationPayload {
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    terminationReferenceNumber: string;
    terminationDate: string;
    terminationType: number;
    terminationReason: string;
    lastWorkingDay?: string;
    custodyCleared: boolean;
    custodyClearanceDate?: string;
    financialCleared: boolean;
    financialClearanceDate?: string;
    gratuityAmount: number;
    finalSalarySettlement: number;
    decisionDocumentUrl?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    terminationStatus: number;
    notes?: string;
}

export interface EmployeeTermination {
    id: number;
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    terminationReferenceNumber: string;
    terminationDate: string;
    terminationType: number;
    terminationReason: string;
    lastWorkingDay?: string;
    custodyCleared: boolean;
    custodyClearanceDate?: string;
    financialCleared: boolean;
    financialClearanceDate?: string;
    gratuityAmount: number;
    finalSalarySettlement: number;
    decisionDocumentUrl?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    terminationStatus: number;
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

export interface UpdateEmployeeTerminationPayload {
    id?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    terminationReferenceNumber?: string;
    terminationDate?: string;
    terminationType?: number;
    terminationReason?: string;
    lastWorkingDay?: string;
    custodyCleared?: boolean;
    custodyClearanceDate?: string;
    financialCleared?: boolean;
    financialClearanceDate?: string;
    gratuityAmount?: number;
    finalSalarySettlement?: number;
    decisionDocumentUrl?: string;
    approvedByUserId?: number;
    approvalDate?: string;
    terminationStatus?: number;
    notes?: string;
}
