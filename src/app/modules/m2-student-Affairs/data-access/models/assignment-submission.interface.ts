import { SubmissionStatus } from './_types';

export interface StudentAssignmentSubmission {
  id: number;
  studentId: number;
  subjectId: number;
  classroomId: number;
  assignmentTitle: string;
  dueDate: string;
  submissionDate?: string;
  submissionStatus: SubmissionStatus;
  scoreObtained?: number;
  teacherFeedback?: string;
  attachmentFileUrl?: string;
  maxPossibleScore: number;
  submissionAttemptNumber: number;
  isGraded: boolean;
  gradedByEmployeeId?: number;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentAssignmentSubmission = Omit<StudentAssignmentSubmission, 'id' | 'createdAt' | 'modifiedAt' | 'submissionStatus' | 'isGraded' | 'gradedByEmployeeId'>;

export type UpdateStudentAssignmentSubmission = CreateStudentAssignmentSubmission & { id: number };
