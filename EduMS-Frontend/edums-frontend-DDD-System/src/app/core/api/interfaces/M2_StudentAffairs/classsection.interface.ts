export interface ClassSection {
    id: number;
    schoolId: number;
    schoolAcademicYearId: number;
    schoolSemesterId?: number;
    gradeCapacityId?: number;
    classroomId?: number;
    sectionCode: string;
    sectionNameAr: string;
    sectionNameEn?: string;
    maxStudents: number;
    currentEnrolledCount: number;
    homeroomTeacherEmployeeId?: number;
    shiftId?: number;
    sectionStatus: number;
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

export interface CreateClassSectionPayload {
    schoolId: number;
    schoolAcademicYearId: number;
    schoolSemesterId?: number;
    gradeCapacityId?: number;
    classroomId?: number;
    sectionCode: string;
    sectionNameAr: string;
    sectionNameEn?: string;
    maxStudents: number;
    currentEnrolledCount: number;
    homeroomTeacherEmployeeId?: number;
    shiftId?: number;
}

export interface UpdateClassSectionPayload {
    id?: number;
    schoolAcademicYearId?: number;
    schoolSemesterId?: number;
    gradeCapacityId?: number;
    classroomId?: number;
    sectionCode?: string;
    sectionNameAr?: string;
    sectionNameEn?: string;
    maxStudents?: number;
    currentEnrolledCount?: number;
    homeroomTeacherEmployeeId?: number;
    shiftId?: number;
}
