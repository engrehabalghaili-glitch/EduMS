export interface CreateEmployeeMentorPayload {
    mentorEmployeeId: number;
    menteeEmployeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    assignmentDate: string;
    endDate?: string;
    mentoringGoals?: string;
    isActive: boolean;
    notes?: string;
}

export interface EmployeeMentor {
    id: number;
    mentorEmployeeId: number;
    menteeEmployeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    assignmentDate: string;
    endDate?: string;
    mentoringGoals?: string;
    isActive: boolean;
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

export interface UpdateEmployeeMentorPayload {
    id?: number;
    mentorEmployeeId?: number;
    menteeEmployeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    assignmentDate?: string;
    endDate?: string;
    mentoringGoals?: string;
    isActive?: boolean;
    notes?: string;
}
