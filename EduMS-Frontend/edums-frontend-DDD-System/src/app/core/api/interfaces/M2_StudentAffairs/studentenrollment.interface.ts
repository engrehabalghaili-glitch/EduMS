export interface CreateStudentEnrollmentPayload {
    studentId: number;
    schoolId: number;
    classroomId: number;
    academicYear: string;
    semesterNumber: number;
    enrollmentDate: string;
    isCurrentTerm: boolean;
    enrollmentType: number;
    assignedRollNumber: number;
    enrollmentRemarks?: string;
}

export interface StudentEnrollment {
    id: number;
    studentId: number;
    schoolId: number;
    classroomId: number;
    academicYear: string;
    semesterNumber: number;
    enrollmentDate: string;
    enrollmentStatus: number;
    isCurrentTerm: boolean;
    enrollmentType: number;
    assignedRollNumber: number;
    promotionStatus: number;
    enrollmentRemarks?: string;
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

export interface UpdateStudentEnrollmentPayload {
    id?: number;
    classroomId?: number;
    academicYear?: string;
    semesterNumber?: number;
    enrollmentDate?: string;
    isCurrentTerm?: boolean;
    enrollmentType?: number;
    assignedRollNumber?: number;
    enrollmentRemarks?: string;
}
