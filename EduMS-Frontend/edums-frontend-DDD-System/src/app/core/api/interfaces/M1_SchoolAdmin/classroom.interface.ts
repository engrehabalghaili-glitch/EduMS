export interface Classroom {
    id: number;
    schoolId: number;
    classroomCode: string;
    classroomNameAr: string;
    classroomNameEn: string;
    gradeLevel: number;
    capacity: number;
    roomNumber?: string;
    floorLevel: number;
    buildingSection?: string;
    homeroomTeacherEmployeeId?: number;
    isSmartClassroom: boolean;
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

export interface CreateClassroomPayload {
    schoolId: number;
    classroomCode: string;
    classroomNameAr: string;
    classroomNameEn: string;
    gradeLevel: number;
    capacity: number;
    roomNumber?: string;
    floorLevel: number;
    buildingSection?: string;
    homeroomTeacherEmployeeId?: number;
    isSmartClassroom: boolean;
}

export interface UpdateClassroomPayload {
    id?: number;
    classroomCode?: string;
    classroomNameAr?: string;
    classroomNameEn?: string;
    gradeLevel?: number;
    capacity?: number;
    roomNumber?: string;
    floorLevel?: number;
    buildingSection?: string;
    homeroomTeacherEmployeeId?: number;
    isSmartClassroom?: boolean;
}
