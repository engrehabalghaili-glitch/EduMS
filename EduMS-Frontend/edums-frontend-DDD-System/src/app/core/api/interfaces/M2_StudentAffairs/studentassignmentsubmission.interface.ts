export interface CreateStudentAssignmentSubmissionPayload {
    studentId: number;
    subjectId: number;
    classroomId: number;
    assignmentTitle: string;
    dueDate: string;
    submissionDate?: string;
    scoreObtained?: number;
    teacherFeedback?: string;
    attachmentFileUrl?: string;
    maxPossibleScore: number;
    submissionAttemptNumber: number;
    isGraded: boolean;
    gradedByEmployeeId?: number;
}

export interface StudentAssignmentSubmission {
    id: number;
    studentId: number;
    subjectId: number;
    classroomId: number;
    assignmentTitle: string;
    dueDate: string;
    submissionDate?: string;
    submissionStatus: number;
    scoreObtained?: number;
    teacherFeedback?: string;
    attachmentFileUrl?: string;
    maxPossibleScore: number;
    submissionAttemptNumber: number;
    isGraded: boolean;
    gradedByEmployeeId?: number;
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

export interface UpdateStudentAssignmentSubmissionPayload {
    id?: number;
    subjectId?: number;
    classroomId?: number;
    assignmentTitle?: string;
    dueDate?: string;
    submissionDate?: string;
    scoreObtained?: number;
    teacherFeedback?: string;
    attachmentFileUrl?: string;
    maxPossibleScore?: number;
    submissionAttemptNumber?: number;
    isGraded?: boolean;
    gradedByEmployeeId?: number;
}
