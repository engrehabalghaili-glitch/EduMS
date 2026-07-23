export interface CreateTeacherSchedulePayload {
    teacherEmployeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    dayOfWeek: string;
    classPeriodId?: number;
    periodNumber: number;
    subjectId?: number;
    classSectionId?: number;
    gradeCapacityId?: number;
    classroomId?: number;
    isSubstitute: boolean;
    originalTeacherEmployeeId?: number;
    substituteDate?: string;
    substituteReason?: string;
    isActive: boolean;
    isCancelled: boolean;
    cancellationReason?: string;
}

export interface TeacherSchedule {
    id: number;
    teacherEmployeeId: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    dayOfWeek: string;
    classPeriodId?: number;
    periodNumber: number;
    subjectId?: number;
    classSectionId?: number;
    gradeCapacityId?: number;
    classroomId?: number;
    isSubstitute: boolean;
    originalTeacherEmployeeId?: number;
    substituteDate?: string;
    substituteReason?: string;
    isActive: boolean;
    isCancelled: boolean;
    cancellationReason?: string;
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

export interface UpdateTeacherSchedulePayload {
    id?: number;
    teacherEmployeeId?: number;
    schoolId?: number;
    directorateId?: number;
    organizationalSectorId?: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    dayOfWeek?: string;
    classPeriodId?: number;
    periodNumber?: number;
    subjectId?: number;
    classSectionId?: number;
    gradeCapacityId?: number;
    classroomId?: number;
    isSubstitute?: boolean;
    originalTeacherEmployeeId?: number;
    substituteDate?: string;
    substituteReason?: string;
    isActive?: boolean;
    isCancelled?: boolean;
    cancellationReason?: string;
}
