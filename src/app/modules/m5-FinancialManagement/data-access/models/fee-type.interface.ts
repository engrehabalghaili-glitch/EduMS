import { FeeCategory, BillingFrequency, Currency, RecurrenceType, AuditFields } from './common.types';

export interface FeeType extends AuditFields {
  id: number;
  schoolId: number;
  gradeCapacityId: number | null;
  feeCode: string;
  feeNameAr: string;
  feeNameEn: string | null;
  feeCategory: FeeCategory;
  amount: number;
  currency: Currency;
  billingFrequency: BillingFrequency;
  isTaxable: boolean;
  taxPercentage: number;
  isMandatory: boolean;
  isOptional: boolean;
  isDiscountable: boolean;
  discountPercentageAllowed: number | null;
  isRefundable: boolean;
  refundPercentage: number | null;
  refundCutoffDate: string | null;
  isRecurring: boolean;
  recurrenceType: RecurrenceType | null;
  appliesToGradesJson: string | null;
  appliesToNationalitiesJson: string | null;
  appliesToStudentTypesJson: string | null;
  isActive: boolean;
  validFrom: string | null;
  validTo: string | null;
  descriptionAr: string | null;
  notes: string | null;
}

export type CreateFeeTypeDto = Omit<FeeType, 'id' | 'createdAt'>;

export type UpdateFeeTypeDto = Omit<FeeType, 'createdAt'>;
