export interface AssetAllocation {
  id: number;
  inventoryItemId: number;
  schoolId: number;
  classroomId: number | null;
  assignedToEmployeeId: number | null;
  allocatedQuantity: number;
  allocationDate: string;
  status: string;
}

export type CreateAssetAllocationRequest = Omit<AssetAllocation, 'id'>;
export type UpdateAssetAllocationRequest = AssetAllocation;
