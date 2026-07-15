export interface AssetLoan {
  id: number;
  assetId: number;
  schoolId: number;
  borrowerType: number;
  borrowerId: number;
  borrowerName: string;
  borrowerContact: string | null;
  loanDate: string;
  expectedReturnDate: string | null;
  actualReturnDate: string | null;
  loanPurpose: string | null;
  issuerUserId: number | null;
  conditionAtLoan: number;
  conditionAtReturn: number;
  isOverdue: boolean;
  overdueDays: number;
  fineAmount: number;
  isFinePaid: boolean;
  finePaidDate: string | null;
  loanStatus: number;
  notes: string | null;
}

export type CreateAssetLoanRequest = Omit<AssetLoan, 'id'>;
export type UpdateAssetLoanRequest = AssetLoan;
