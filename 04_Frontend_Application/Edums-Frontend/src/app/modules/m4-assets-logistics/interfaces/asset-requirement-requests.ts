export interface AssetRequirementRequest {
  id: number;
  schoolId: number;
  requestNumber: string;
  requestType: number;
  assetTypeDescription: string;
  assetCategoryId: number | null;
  quantityRequested: number;
  estimatedUnitCost: number;
  estimatedTotalCost: number;
  priority: number;
  urgencyReason: string | null;
  requestingDepartmentId: number | null;
  requestedByEmployeeId: number | null;
  requestDate: string;
  justification: string | null;
  initialSpecsText: string | null;
  requiredByDate: string | null;
  isReplacement: boolean;
  assetToReplaceId: number | null;
  replacementReason: string | null;
  approvalStatus: number;
  rejectionReason: string | null;
  approvedByUserId: number | null;
  approvalDate: string | null;
  convertedToPurchaseOrder: boolean;
  purchaseOrderId: number | null;
  notes: string | null;
}

export type CreateAssetRequirementRequest = Omit<AssetRequirementRequest, 'id'>;
export type UpdateAssetRequirementRequest = AssetRequirementRequest;
