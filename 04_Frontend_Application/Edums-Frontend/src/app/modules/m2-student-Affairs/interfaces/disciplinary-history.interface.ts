import { AppealStatus, DisciplinaryStatus } from './_types';

export interface StudentDisciplinaryHistory {
  id: number;
  studentId: number;
  behavioralLogId?: number;
  disciplinaryActionCode: string;
  actionTitleAr: string;
  executionDate: string;
  executedByEmployeeId?: number;
  penaltyDurationDays: number;
  guardianNotifiedDate?: string;
  appealStatus: AppealStatus;
  actionTitleEn?: string;
  appealNotes?: string;
  reinstatementCondition?: string;
  status: DisciplinaryStatus;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentDisciplinaryHistory = Omit<StudentDisciplinaryHistory, 'id' | 'createdAt' | 'modifiedAt' | 'appealStatus' | 'status'>;

export type UpdateStudentDisciplinaryHistory = CreateStudentDisciplinaryHistory & { id: number };
