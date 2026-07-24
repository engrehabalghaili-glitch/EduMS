export interface AssetMovementHistory {
  id: number;
  assetId: number;
  schoolId: number;
  actionType: string;
  actionDescription: string;
  oldValueJson: string | null;
  newValueJson: string | null;
  relatedEntityType: string | null;
  relatedEntityId: number | null;
  actionDate: string;
  performedByUserId: number;
  notes: string | null;
}

export type CreateAssetMovementHistoryRequest = Omit<AssetMovementHistory, 'id'>;
export type UpdateAssetMovementHistoryRequest = AssetMovementHistory;
