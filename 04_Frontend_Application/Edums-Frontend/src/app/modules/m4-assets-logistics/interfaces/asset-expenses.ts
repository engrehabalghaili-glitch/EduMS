export interface AssetExpense {
  id: number;
  assetId: number;
  schoolId: number;
  expenseType: number;
  expenseDate: string;
  amount: number;
  currency: string | null;
  description: string | null;
  relatedMaintenanceExecutionId: number | null;
  isCapitalized: boolean;
  capitalizationDate: string | null;
  accountedInFinancials: boolean;
  accountedInDepreciation: boolean;
  approvedByUserId: number | null;
  approvalDate: string | null;
  notes: string | null;
}

export type CreateAssetExpenseRequest = Omit<AssetExpense, 'id'>;
export type UpdateAssetExpenseRequest = AssetExpense;
