export interface AssetSuspensionRequest {
  id: number;
  schoolId: number;
  requestNumber: number;
  assetId: number;
  requestedByUserId: number;
  requestDate: string;
  reason: string;
  reasonDetails: string | null;
  startDate: string;
  expectedEndDate: string | null;
  attachmentsJson: string | null;
  approvalStatus: string;
  approvedByUserId: number | null;
  approvalDate: string | null;
  approvalNotes: string | null;
  rejectionReason: string | null;
  isRevoked: boolean;
  revokeDate: string | null;
  revokeReason: string | null;
  revokedByUserId: number | null;
  actualEndDate: string | null;
  status: string;
  notes: string | null;
}

export type CreateAssetSuspensionRequest = Omit<AssetSuspensionRequest, 'id'>;
export type UpdateAssetSuspensionRequest = AssetSuspensionRequest;
