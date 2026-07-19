export interface AssetUsageLog {
  id: number;
  assetId: number;
  schoolId: number;
  usageType: number;
  startDateTime: string;
  endDateTime: string | null;
  durationMinutes: number;
  usagePurpose: number;
  purposeDetails: string | null;
  usedByUserId: number | null;
  userType: number;
  locationId: number | null;
  usageStatus: number;
  notes: string | null;
}

export type CreateAssetUsageLogRequest = Omit<AssetUsageLog, 'id'>;
export type UpdateAssetUsageLogRequest = AssetUsageLog;
