export interface AssetTransferRequest {
  id: number;
  assetId: number;
  schoolId: number;
  requestNumber: string;
  fromEntityType: number;
  fromEntityId: number;
  toEntityType: number;
  toEntityId: number;
  transferType: number;
  requestReason: string | null;
  requestedByUserId: number | null;
  requestDate: string;
  approvalStatus: number;
  approvedByUserId: number | null;
  approvalDate: string | null;
  rejectionReason: string | null;
  transferExecutionDate: string | null;
  executedByUserId: number | null;
  requestStatus: number;
  notes: string | null;
}

export type CreateAssetTransferRequest = Omit<AssetTransferRequest, 'id'>;
export type UpdateAssetTransferRequest = AssetTransferRequest;
