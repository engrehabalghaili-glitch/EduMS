export interface AssetBudgetAllocation {
  id: number;
  schoolId: number;
  fiscalYear: string;
  budgetType: number;
  assetCategoryId: number | null;
  departmentId: number | null;
  allocatedAmount: number;
  spentAmount: number;
  remainingAmount: number;
  budgetLineCode: string | null;
  allocationStatus: number;
  notes: string | null;
}

export type CreateAssetBudgetAllocationRequest = Omit<AssetBudgetAllocation, 'id'>;
export type UpdateAssetBudgetAllocationRequest = AssetBudgetAllocation;
