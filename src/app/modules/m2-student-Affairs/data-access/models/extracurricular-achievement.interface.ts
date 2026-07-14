import { CompetitionLevel, RankAchieved } from './_types';

export interface StudentExtracurricularAchievement {
  id: number;
  studentId: number;
  competitionTitleAr: string;
  competitionTitleEn?: string;
  competitionLevel: CompetitionLevel;
  organizingInstitutionName: string;
  achievementDate: string;
  rankOrMedalAchieved: RankAchieved;
  awardDescription?: string;
  monetaryPrizeAmount: number;
  supervisingCoachEmployeeId?: number;
  certificateOrMedalPhotoUrl?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentExtracurricularAchievement = Omit<StudentExtracurricularAchievement, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentExtracurricularAchievement = CreateStudentExtracurricularAchievement & { id: number };
