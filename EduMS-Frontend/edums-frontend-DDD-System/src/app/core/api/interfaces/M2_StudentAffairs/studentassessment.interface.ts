export interface CreateStudentAssessmentPayload {
    studentId: number;
    subjectId: number;
    classroomId: number;
    assessmentTitle: string;
    assessmentCategory: number;
    maxScore: number;
    obtainedScore: number;
    assessmentDate: string;
    evaluatedByEmployeeId?: number;
    passingScore: number;
    letterCodeResult?: string;
    gradePointResult: number;
    remarks?: string;
    isRetakeExam: boolean;
    originalAssessmentId?: number;
}

export interface StudentAssessment {
    id: number;
    studentId: number;
    subjectId: number;
    classroomId: number;
    assessmentTitle: string;
    assessmentCategory: number;
    maxScore: number;
    obtainedScore: number;
    assessmentDate: string;
    evaluatedByEmployeeId?: number;
    passingScore: number;
    letterCodeResult?: string;
    gradePointResult: number;
    remarks?: string;
    isRetakeExam: boolean;
    originalAssessmentId?: number;
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

export interface UpdateStudentAssessmentPayload {
    id?: number;
    subjectId?: number;
    classroomId?: number;
    assessmentTitle?: string;
    assessmentCategory?: number;
    maxScore?: number;
    obtainedScore?: number;
    assessmentDate?: string;
    evaluatedByEmployeeId?: number;
    passingScore?: number;
    letterCodeResult?: string;
    gradePointResult?: number;
    remarks?: string;
    isRetakeExam?: boolean;
    originalAssessmentId?: number;
}
