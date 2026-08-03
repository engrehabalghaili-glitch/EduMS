import { AssessmentCategory } from './_types';

export interface StudentAssessment {
  id: number;
  studentId: number;
  subjectId: number;
  classroomId: number;
  assessmentTitle: string;
  assessmentCategory: AssessmentCategory;
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
  modifiedAt?: string;
}

export type CreateStudentAssessment = Omit<StudentAssessment, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentAssessment = CreateStudentAssessment & { id: number };
