import type { RecordStatus, PenaltyType } from './common';

export interface ClassroomOperationalRule {
  id: number;
  classroomId: number;
  ruleCode: string;
  ruleTitleAr: string;
  ruleTitleEn: string;
  maxAllowedAbsencePercentage: number;
  requiresDailyAttendanceLog: boolean;
  allowLateArrivalMinutes: number;
  maxAllowedConsecutiveAbsenceDays: number;
  penaltyTypeForExceedingLimit: PenaltyType;
  effectiveStartDate: string | null;
  isActive: boolean;
}

export type CreateClassroomOperationalRuleDto = Omit<ClassroomOperationalRule, 'id' | 'isActive'>;

export type UpdateClassroomOperationalRuleDto = Omit<ClassroomOperationalRule, 'isActive'>;
