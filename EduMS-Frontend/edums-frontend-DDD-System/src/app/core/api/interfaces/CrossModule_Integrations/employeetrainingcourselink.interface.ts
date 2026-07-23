export interface CreateEmployeeTrainingCourseLinkPayload {
    employeeTrainingId: number;
    trainingCourseOfferingId: number;
    employeeId: number;
    schoolId: number;
    trainingFeeAmount: number;
    fundingSource?: string;
    certificateIssued: boolean;
    certificateUrl?: string;
    notes?: string;
}

export interface EmployeeTrainingCourseLink {
    id: number;
    employeeTrainingId: number;
    trainingCourseOfferingId: number;
    employeeId: number;
    schoolId: number;
    trainingFeeAmount: number;
    fundingSource?: string;
    certificateIssued: boolean;
    certificateUrl?: string;
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

export interface UpdateEmployeeTrainingCourseLinkPayload {
    id?: number;
    employeeTrainingId?: number;
    trainingCourseOfferingId?: number;
    employeeId?: number;
    schoolId?: number;
    trainingFeeAmount?: number;
    fundingSource?: string;
    certificateIssued?: boolean;
    certificateUrl?: string;
    notes?: string;
}
