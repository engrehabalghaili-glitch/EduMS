import { TalentCategory, ProficiencyLevel } from './_types';

export interface StudentSkillAndTalentRecord {
  id: number;
  studentId: number;
  talentCategory: TalentCategory;
  talentTitleAr: string;
  proficiencyLevel: ProficiencyLevel;
  discoveredDate: string;
  mentorEmployeeId?: number;
  talentTitleEn?: string;
  developmentPlanDescription?: string;
  portfolioAttachmentUrl?: string;
  isEnrolledInGiftedProgram: boolean;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentSkillAndTalentRecord = Omit<StudentSkillAndTalentRecord, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStudentSkillAndTalentRecord = CreateStudentSkillAndTalentRecord & { id: number };
