export interface CreateStudentPayload {
    enrollmentNumber: string;
    enrollmentDate: string;
    schoolId?: number;
    classroomId?: number;
    guardianId?: number;
    previousSchoolName?: string;
    admissionGradeLevel: number;
    currentAcademicYear?: string;
    specialEducationNeeds?: string;
    busStopLocationDescription?: string;
}

export interface Student {
    enrollmentNumber: string;
    enrollmentDate: string;
    schoolId?: number;
    classroomId?: number;
    guardianId?: number;
    previousSchoolName?: string;
    admissionGradeLevel: number;
    currentAcademicYear?: string;
    studentStatus: number;
    specialEducationNeeds?: string;
    busStopLocationDescription?: string;
    isActive: boolean;
}

export interface UpdateStudentPayload {
    enrollmentNumber?: string;
    enrollmentDate?: string;
    classroomId?: number;
    guardianId?: number;
    previousSchoolName?: string;
    admissionGradeLevel?: number;
    currentAcademicYear?: string;
    specialEducationNeeds?: string;
    busStopLocationDescription?: string;
}
