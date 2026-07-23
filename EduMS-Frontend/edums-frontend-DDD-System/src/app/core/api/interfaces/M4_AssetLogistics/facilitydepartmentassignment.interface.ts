export interface CreateFacilityDepartmentAssignmentPayload {
    schoolId: number;
    facilityType: number;
    facilityId: number;
    departmentId?: number;
    responsibleEmployeeId?: number;
    assignmentType: number;
    startDate: string;
    endDate?: string;
    isShared: boolean;
    sharedWithDepartmentsJson?: string;
    sharingScheduleJson?: string;
    priority: number;
    assignmentStatus: number;
    notes?: string;
}

export interface FacilityDepartmentAssignment {
    id: number;
    schoolId: number;
    facilityType: number;
    facilityId: number;
    departmentId?: number;
    responsibleEmployeeId?: number;
    assignmentType: number;
    startDate: string;
    endDate?: string;
    isShared: boolean;
    sharedWithDepartmentsJson?: string;
    sharingScheduleJson?: string;
    priority: number;
    assignmentStatus: number;
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

export interface UpdateFacilityDepartmentAssignmentPayload {
    id?: number;
    schoolId?: number;
    facilityType?: number;
    facilityId?: number;
    departmentId?: number;
    responsibleEmployeeId?: number;
    assignmentType?: number;
    startDate?: string;
    endDate?: string;
    isShared?: boolean;
    sharedWithDepartmentsJson?: string;
    sharingScheduleJson?: string;
    priority?: number;
    assignmentStatus?: number;
    notes?: string;
}
