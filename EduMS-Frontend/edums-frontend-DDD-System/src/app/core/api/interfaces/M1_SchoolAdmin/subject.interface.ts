export interface CreateSubjectPayload {
    schoolId: number;
    subjectCode: string;
    subjectNameAr: string;
    subjectNameEn: string;
    specialization?: string;
    weeklyHours: number;
    gradeLevel: number;
    textbookTitle?: string;
    totalMarks: number;
    passingMarks: number;
    creditHours: number;
    isCoreSubject: boolean;
}

export interface Subject {
    id: number;
    schoolId: number;
    subjectCode: string;
    subjectNameAr: string;
    subjectNameEn: string;
    specialization?: string;
    weeklyHours: number;
    gradeLevel: number;
    textbookTitle?: string;
    totalMarks: number;
    passingMarks: number;
    creditHours: number;
    isCoreSubject: boolean;
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

export interface UpdateSubjectPayload {
    id?: number;
    subjectCode?: string;
    subjectNameAr?: string;
    subjectNameEn?: string;
    specialization?: string;
    weeklyHours?: number;
    gradeLevel?: number;
    textbookTitle?: string;
    totalMarks?: number;
    passingMarks?: number;
    creditHours?: number;
    isCoreSubject?: boolean;
}
