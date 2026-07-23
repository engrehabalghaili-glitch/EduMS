export interface CreateDirectorateExamCenterAssignmentPayload {
    directorateId: number;
    hostedAtSchoolId: number;
    examCenterCode: string;
    examSessionTitleAr: string;
    academicYear: string;
    targetEducationalStageId: number;
    totalAllocatedCandidatesCount: number;
    totalExaminationRoomsCount: number;
    chiefSuperintendentEmployeeId?: number;
    residentSecurityOfficerEmployeeId?: number;
    sessionStartDate: string;
    sessionEndDate: string;
}

export interface DirectorateExamCenterAssignment {
    id: number;
    directorateId: number;
    hostedAtSchoolId: number;
    examCenterCode: string;
    examSessionTitleAr: string;
    academicYear: string;
    targetEducationalStageId: number;
    totalAllocatedCandidatesCount: number;
    totalExaminationRoomsCount: number;
    chiefSuperintendentEmployeeId?: number;
    residentSecurityOfficerEmployeeId?: number;
    sessionStartDate: string;
    sessionEndDate: string;
    centerStatus: number;
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

export interface UpdateDirectorateExamCenterAssignmentPayload {
    id?: number;
    hostedAtSchoolId?: number;
    examCenterCode?: string;
    examSessionTitleAr?: string;
    academicYear?: string;
    targetEducationalStageId?: number;
    totalAllocatedCandidatesCount?: number;
    totalExaminationRoomsCount?: number;
    chiefSuperintendentEmployeeId?: number;
    residentSecurityOfficerEmployeeId?: number;
    sessionStartDate?: string;
    sessionEndDate?: string;
}
