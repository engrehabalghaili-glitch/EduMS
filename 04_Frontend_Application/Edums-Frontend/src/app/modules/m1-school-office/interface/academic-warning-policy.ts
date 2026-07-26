import type { RecordStatus, WarningCategory, ActionRequired } from './common';

export interface AcademicWarningPolicy {
  id: number;
  schoolId: number;
  policyCode: string;
  policyTitleAr: string;
  warningCategory: WarningCategory;
  thresholdValue: number;
  actionRequired: ActionRequired;
  policyTitleEn: string | null;
  consecutiveOccurrenceLimit: number;
  autoTriggerNotification: boolean;
  escalationPolicyId: number | null;
  isActive: boolean;
}

export type CreateAcademicWarningPolicyDto = Omit<AcademicWarningPolicy, 'id' | 'isActive'>;

export type UpdateAcademicWarningPolicyDto = Omit<AcademicWarningPolicy, 'schoolId' | 'isActive'>;
