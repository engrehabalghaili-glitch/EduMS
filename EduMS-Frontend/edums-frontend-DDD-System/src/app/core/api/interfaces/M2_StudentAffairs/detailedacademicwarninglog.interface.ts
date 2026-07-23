export interface CreateDetailedAcademicWarningLogPayload {
    studentId: number;
    warningDate: string;
    warningCategory: number;
    subjectId?: number;
    warningLevel: number;
    triggerDescription: string;
    guardianAcknowledgedDate?: string;
    issuedByEmployeeId?: number;
    remedialPlanDescription?: string;
    targetResolutionDate?: string;
    isEscalatedToDirector: boolean;
}

export interface DetailedAcademicWarningLog {
    id: number;
    studentId: number;
    warningDate: string;
    warningCategory: number;
    subjectId?: number;
    warningLevel: number;
    triggerDescription: string;
    guardianAcknowledgedDate?: string;
    issuedByEmployeeId?: number;
    remedialPlanDescription?: string;
    targetResolutionDate?: string;
    status: number;
    isEscalatedToDirector: boolean;
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

export interface UpdateDetailedAcademicWarningLogPayload {
    id?: number;
    warningDate?: string;
    warningCategory?: number;
    subjectId?: number;
    warningLevel?: number;
    triggerDescription?: string;
    guardianAcknowledgedDate?: string;
    issuedByEmployeeId?: number;
    remedialPlanDescription?: string;
    targetResolutionDate?: string;
    isEscalatedToDirector?: boolean;
}
