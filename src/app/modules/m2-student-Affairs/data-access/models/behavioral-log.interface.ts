import { BehaviorCategory, BehaviorStatus } from './_types';

export interface BehavioralLog {
  id: number;
  studentId: number;
  incidentDate: string;
  behaviorCategory: BehaviorCategory;
  incidentTitleAr: string;
  description: string;
  actionTaken?: string;
  recordedByEmployeeId?: number;
  status: BehaviorStatus;
  incidentTitleEn?: string;
  demeritOrMeritPoints: number;
  incidentLocation?: string;
  parentNotificationStatus: number;
  investigationNotes?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateBehavioralLog = Omit<BehavioralLog, 'id' | 'createdAt' | 'modifiedAt' | 'status' | 'parentNotificationStatus' | 'recordedByEmployeeId'>;

export type UpdateBehavioralLog = CreateBehavioralLog & { id: number };
