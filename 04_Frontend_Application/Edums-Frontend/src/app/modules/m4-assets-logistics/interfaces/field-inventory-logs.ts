export interface FieldInventoryLog {
  id: number;
  inventoryPlanId: number;
  schoolId: number;
  scannerUserId: number;
  scanTimestamp: string;
  scannedCode: string;
  assetId: number | null;
  physicalLocationText: string | null;
  actualCondition: number;
  conditionNotes: string | null;
  isFound: boolean;
  notFoundNotes: string | null;
  assetPhotoUrl: string | null;
  gpsLocation: string | null;
  isVerified: boolean;
  verifiedByUserId: number | null;
  verifiedAt: string | null;
  notes: string | null;
}

export type CreateFieldInventoryLogRequest = Omit<FieldInventoryLog, 'id'>;
export type UpdateFieldInventoryLogRequest = FieldInventoryLog;
