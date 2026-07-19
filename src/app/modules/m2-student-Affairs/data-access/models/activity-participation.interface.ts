import { CompetitionLevel } from './_types';

export interface StudentActivityParticipation {
  id: number;
  studentId: number;
  schoolId: number;
  activityNameAr: string;
  activityType: number;
  supervisorEmployeeId?: number;
  participationDate: string;
  achievementDetail?: string;
  scoreBonus: number;
  activityNameEn?: string;
  participationRole?: string;
  totalHoursLogged: number;
  awardLevel?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentActivityParticipation = Omit<StudentActivityParticipation, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentActivityParticipation = CreateStudentActivityParticipation & { id: number };
