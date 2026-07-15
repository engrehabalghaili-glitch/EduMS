import { BaseAuditFields, ChangeCategory, ChangeType } from './base.types';

export interface StatisticsUpdateHistory extends BaseAuditFields {
  statisticsDraftId: number | null;
  submittedStatisticsId: number | null;
  schoolId: number;
  changeType: ChangeType;
  changeCategory: ChangeCategory;
  oldValue: string | null;
  newValue: string | null;
  changeDate: string;
  updateReason: string | null;
  supportingDocumentUrl: string | null;
  changedByUserId: number | null;
  isApproved: boolean;
  approvedByUserId: number | null;
  approvalDate: string | null;
  notes: string | null;
}

export type CreateStatisticsUpdateHistory = Omit<StatisticsUpdateHistory, 'id' | 'createdAt' | 'modifiedAt'>;

export type UpdateStatisticsUpdateHistory = Pick<StatisticsUpdateHistory, 'id'> & Partial<Omit<StatisticsUpdateHistory, 'id' | 'createdAt' | 'modifiedAt'>>;
