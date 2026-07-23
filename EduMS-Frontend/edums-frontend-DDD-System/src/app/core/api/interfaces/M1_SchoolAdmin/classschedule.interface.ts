export interface ClassSchedule {
    id: number;
    schoolId: number;
    classroomId: number;
    subjectId: number;
    assignedEmployeeId?: number;
    dayOfWeek: number;
    periodNumber: number;
    roomCode?: string;
    startTime?: string;
    endTime?: string;
    termSemesterNumber: number;
    scheduleType: number;
    isActive: boolean;
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

export interface CreateClassSchedulePayload {
    schoolId: number;
    classroomId: number;
    subjectId: number;
    assignedEmployeeId?: number;
    dayOfWeek: number;
    periodNumber: number;
    roomCode?: string;
    startTime?: string;
    endTime?: string;
    termSemesterNumber: number;
    scheduleType: number;
}

export interface UpdateClassSchedulePayload {
    id?: number;
    classroomId?: number;
    subjectId?: number;
    assignedEmployeeId?: number;
    dayOfWeek?: number;
    periodNumber?: number;
    roomCode?: string;
    startTime?: string;
    endTime?: string;
    termSemesterNumber?: number;
    scheduleType?: number;
}
