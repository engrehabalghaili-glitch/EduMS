export interface InventoryReconciliation {
  id: number;
  inventoryPlanId: number;
  schoolId: number;
  assetId: number;
  discrepancyType: number;
  systemLocationId: number | null;
  actualLocationText: string | null;
  systemCondition: number;
  actualCondition: number;
  reasonForDiscrepancy: string | null;
  investigationNotes: string | null;
  correctiveAction: string | null;
  isResolved: boolean;
  resolutionDate: string | null;
  resolvedByUserId: number | null;
  resolutionNotes: string | null;
  approvedByUserId: number | null;
  approvalDate: string | null;
  reconciliationStatus: number;
  notes: string | null;
}

export type CreateInventoryReconciliationRequest = Omit<InventoryReconciliation, 'id'>;
export type UpdateInventoryReconciliationRequest = InventoryReconciliation;
