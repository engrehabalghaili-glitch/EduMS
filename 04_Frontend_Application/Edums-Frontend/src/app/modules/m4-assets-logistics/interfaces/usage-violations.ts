export interface UsageViolation {
  id: number;
  schoolId: number;
  assetId: number;
  violationType: string;
  violationDate: string;
  reportedByUserId: number;
  reportedDate: string;
  violatingUserId: number;
  description: string;
  evidenceJson: string | null;
  penaltyAction: string | null;
  penaltyAmount: number;
  penaltyAmountCurrency: string | null;
  deductionFromSalary: boolean;
  approvedByUserId: number | null;
  approvalDate: string | null;
  status: string;
  closedAt: string | null;
  notes: string | null;
}

export type CreateUsageViolationRequest = Omit<UsageViolation, 'id'>;
export type UpdateUsageViolationRequest = UsageViolation;
