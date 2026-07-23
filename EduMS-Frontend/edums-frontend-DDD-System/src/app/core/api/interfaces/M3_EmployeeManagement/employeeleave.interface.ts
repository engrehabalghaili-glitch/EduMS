export interface CreateEmployeeLeavePayload {
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    leaveType: number;
    startDate: string;
    endDate: string;
    totalDays: number;
    leaveReason: string;
    supportingDocumentUrl?: string;
    approvalStatus: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    isEmergency: boolean;
    replacementEmployeeName?: string;
    notes?: string;
}

export interface EmployeeLeave {
    id: number;
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    leaveType: number;
    startDate: string;
    endDate: string;
    totalDays: number;
    leaveReason: string;
    supportingDocumentUrl?: string;
    approvalStatus: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    isEmergency: boolean;
    replacementEmployeeName?: string;
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

export interface UpdateEmployeeLeavePayload {
    id?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    leaveType?: number;
    startDate?: string;
    endDate?: string;
    totalDays?: number;
    leaveReason?: string;
    supportingDocumentUrl?: string;
    approvalStatus?: number;
    approvedByEmployeeId?: number;
    approvalDate?: string;
    rejectionReason?: string;
    isEmergency?: boolean;
    replacementEmployeeName?: string;
    notes?: string;
}
