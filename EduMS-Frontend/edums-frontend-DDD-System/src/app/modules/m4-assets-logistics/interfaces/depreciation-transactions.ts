export interface DepreciationTransaction {
  id: number;
  assetId: number;
  schoolId: number;
  depreciationPolicyId: number | null;
  periodStart: string;
  periodEnd: string;
  periodType: number;
  fiscalYear: string;
  periodNumber: number;
  depreciationAmount: number;
  accumulatedDepreciationAfter: number;
  netBookValueAfter: number;
  isPostedToLedger: boolean;
  ledgerEntryReference: string | null;
  postedToLedgerDate: string | null;
  calculatedByUserId: number | null;
  calculationDate: string | null;
  notes: string | null;
}

export type CreateDepreciationTransactionRequest = Omit<DepreciationTransaction, 'id'>;
export type UpdateDepreciationTransactionRequest = DepreciationTransaction;
