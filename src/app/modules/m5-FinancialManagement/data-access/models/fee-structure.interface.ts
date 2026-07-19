import { AuditFields } from './common.types';

export interface FeeStructure extends AuditFields {
  id: number;
  schoolId: number;
  feeCode: string;
  feeNameAr: string;
  feeNameEn: string;
  gradeLevel: number;
  amount: number;
  academicYear: string;
}

export type CreateFeeStructureDto = Omit<FeeStructure, 'id' | 'createdAt'>;

export type UpdateFeeStructureDto = Omit<FeeStructure, 'createdAt'>;
