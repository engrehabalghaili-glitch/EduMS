export interface CreateEmployeeTrainingPayload {
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    courseName: string;
    courseCode?: string;
    trainingType: number;
    providerName: string;
    startDate: string;
    endDate: string;
    durationHours: number;
    trainingLocation?: string;
    trainingCost: number;
    fundingSource?: string;
    completionStatus: number;
    score?: number;
    gradeLevel?: string;
    certificateUrl?: string;
    certificateExpiryDate?: string;
    trainingOutcomesSummary?: string;
    notes?: string;
}

export interface EmployeeTraining {
    id: number;
    employeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    courseName: string;
    courseCode?: string;
    trainingType: number;
    providerName: string;
    startDate: string;
    endDate: string;
    durationHours: number;
    trainingLocation?: string;
    trainingCost: number;
    fundingSource?: string;
    completionStatus: number;
    score?: number;
    gradeLevel?: string;
    certificateUrl?: string;
    certificateExpiryDate?: string;
    trainingOutcomesSummary?: string;
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

export interface UpdateEmployeeTrainingPayload {
    id?: number;
    employeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    courseName?: string;
    courseCode?: string;
    trainingType?: number;
    providerName?: string;
    startDate?: string;
    endDate?: string;
    durationHours?: number;
    trainingLocation?: string;
    trainingCost?: number;
    fundingSource?: string;
    completionStatus?: number;
    score?: number;
    gradeLevel?: string;
    certificateUrl?: string;
    certificateExpiryDate?: string;
    trainingOutcomesSummary?: string;
    notes?: string;
}
