export interface CreateExamDistributionTimetablePayload {
    schoolId: number;
    subjectId: number;
    classroomId: number;
    facilityId?: number;
    proctorEmployeeId?: number;
    examDate: string;
    startTime: string;
    endTime: string;
    maxSeatCount: number;
    examSessionNameAr?: string;
    examType: number;
    termSemesterNumber: number;
    assistantProctorEmployeeId?: number;
    isSeatingChartPublished: boolean;
}

export interface ExamDistributionTimetable {
    id: number;
    schoolId: number;
    subjectId: number;
    classroomId: number;
    facilityId?: number;
    proctorEmployeeId?: number;
    examDate: string;
    startTime: string;
    endTime: string;
    maxSeatCount: number;
    status: number;
    examSessionNameAr?: string;
    examType: number;
    termSemesterNumber: number;
    assistantProctorEmployeeId?: number;
    isSeatingChartPublished: boolean;
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

export interface UpdateExamDistributionTimetablePayload {
    id?: number;
    subjectId?: number;
    classroomId?: number;
    facilityId?: number;
    proctorEmployeeId?: number;
    examDate?: string;
    startTime?: string;
    endTime?: string;
    maxSeatCount?: number;
    examSessionNameAr?: string;
    examType?: number;
    termSemesterNumber?: number;
    assistantProctorEmployeeId?: number;
    isSeatingChartPublished?: boolean;
}
