export interface InventoryPlan {
  id: number;
  schoolId: number;
  planNumber: string;
  planNameAr: string;
  inventoryType: number;
  scopeType: number;
  scopeValueId: number | null;
  startDate: string;
  targetEndDate: string | null;
  actualEndDate: string | null;
  teamLeaderEmployeeId: number | null;
  assignedTeamMembersJson: string | null;
  instructions: string | null;
  planStatus: number;
  completionPercentage: number;
  notes: string | null;
}

export type CreateInventoryPlanRequest = Omit<InventoryPlan, 'id'>;
export type UpdateInventoryPlanRequest = InventoryPlan;
