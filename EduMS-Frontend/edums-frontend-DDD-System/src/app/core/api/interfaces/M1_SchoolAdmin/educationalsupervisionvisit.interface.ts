export interface CreateEducationalSupervisionVisitPayload {
    directorateId: number;
    schoolId: number;
    supervisorName: string;
    visitDate: string;
    visitPurpose: string;
    evaluationScore?: number;
    recommendations?: string;
    supervisorEmployeeId?: number;
    targetDepartmentId?: number;
    followUpRequiredDate?: string;
    actionItemsDetail?: string;
}

export interface EducationalSupervisionVisit {
    id: number;
    directorateId: number;
    schoolId: number;
    supervisorName: string;
    visitDate: string;
    visitPurpose: string;
    evaluationScore?: number;
    recommendations?: string;
    status: number;
    supervisorEmployeeId?: number;
    targetDepartmentId?: number;
    followUpRequiredDate?: string;
    actionItemsDetail?: string;
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

export interface UpdateEducationalSupervisionVisitPayload {
    id?: number;
    supervisorName?: string;
    visitDate?: string;
    visitPurpose?: string;
    evaluationScore?: number;
    recommendations?: string;
    supervisorEmployeeId?: number;
    targetDepartmentId?: number;
    followUpRequiredDate?: string;
    actionItemsDetail?: string;
}
