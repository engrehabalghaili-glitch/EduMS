export interface CreateEmployeeAdditionalTaskPayload {
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    taskTitleAr: string;
    taskDescription?: string;
    taskType: number;
    startDate: string;
    endDate?: string;
    hasFinancialCompensation: boolean;
    compensationAmount: number;
    assignedByEmployeeId?: number;
    taskStatus: number;
    notes?: string;
}

export interface EmployeeAdditionalTask {
    id: number;
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    taskTitleAr: string;
    taskDescription?: string;
    taskType: number;
    startDate: string;
    endDate?: string;
    hasFinancialCompensation: boolean;
    compensationAmount: number;
    assignedByEmployeeId?: number;
    taskStatus: number;
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

export interface UpdateEmployeeAdditionalTaskPayload {
    id?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    taskTitleAr?: string;
    taskDescription?: string;
    taskType?: number;
    startDate?: string;
    endDate?: string;
    hasFinancialCompensation?: boolean;
    compensationAmount?: number;
    assignedByEmployeeId?: number;
    taskStatus?: number;
    notes?: string;
}
