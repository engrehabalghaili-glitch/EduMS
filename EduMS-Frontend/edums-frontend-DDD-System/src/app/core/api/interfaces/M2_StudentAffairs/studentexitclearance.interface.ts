export interface CreateStudentExitClearancePayload {
    studentId: number;
    clearanceReferenceNumber: string;
    clearanceReason: number;
    initiationDate: string;
    completionDate?: string;
    isLibraryClearanceApproved: boolean;
    isFinancialClearanceApproved: boolean;
    isCanteenClearanceApproved: boolean;
    isSportsEquipmentClearanceApproved: boolean;
    clearanceNotes?: string;
}

export interface StudentExitClearance {
    id: number;
    studentId: number;
    clearanceReferenceNumber: string;
    clearanceReason: number;
    initiationDate: string;
    completionDate?: string;
    isLibraryClearanceApproved: boolean;
    isFinancialClearanceApproved: boolean;
    isCanteenClearanceApproved: boolean;
    isSportsEquipmentClearanceApproved: boolean;
    overallClearanceStatus: number;
    approvedByDirectorEmployeeId?: number;
    clearanceNotes?: string;
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

export interface UpdateStudentExitClearancePayload {
    id?: number;
    clearanceReferenceNumber?: string;
    clearanceReason?: number;
    initiationDate?: string;
    completionDate?: string;
    isLibraryClearanceApproved?: boolean;
    isFinancialClearanceApproved?: boolean;
    isCanteenClearanceApproved?: boolean;
    isSportsEquipmentClearanceApproved?: boolean;
    clearanceNotes?: string;
}
