import { SessionCategory, ReferralSourceType, RiskLevel, StatusNumeric } from './_types';

export interface StudentPsychologicalCounselingLog {
  id: number;
  studentId: number;
  counselorEmployeeId: number;
  sessionDate: string;
  sessionCategory: SessionCategory;
  sessionNotes?: string;
  recommendedIntervention?: string;
  isConfidential: boolean;
  followUpDate?: string;
  referralSource: ReferralSourceType;
  riskAssessmentLevel: RiskLevel;
  isParentInvolved: boolean;
  caseStatus: StatusNumeric;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentPsychologicalCounselingLog = Omit<StudentPsychologicalCounselingLog, 'id' | 'createdAt' | 'modifiedAt' | 'caseStatus'>;

export type UpdateStudentPsychologicalCounselingLog = CreateStudentPsychologicalCounselingLog & { id: number };
