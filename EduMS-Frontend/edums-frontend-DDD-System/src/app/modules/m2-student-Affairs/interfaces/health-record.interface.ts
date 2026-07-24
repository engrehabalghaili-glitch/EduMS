import { HealthStatus } from './_types';

export interface StudentHealthRecord {
  id: number;
  studentId: number;
  recordDate: string;
  examinationDetails?: string;
  diagnosis?: string;
  treatmentPlan?: string;
  referralHospital?: string;
  examinedByNurseName?: string;
  healthStatus: HealthStatus;
  healthRecordCode?: string;
  physicalHeightCm: number;
  physicalWeightKg: number;
  visionCheckResult?: string;
  hearingCheckResult?: string;
  isFitForPhysicalEducation: boolean;
  nextCheckupDate?: string;
  createdAt: string;
  modifiedAt?: string;
}

export type CreateStudentHealthRecord = Omit<StudentHealthRecord, 'id' | 'createdAt' | 'modifiedAt' | 'healthStatus'>;

export type UpdateStudentHealthRecord = CreateStudentHealthRecord & { id: number };
