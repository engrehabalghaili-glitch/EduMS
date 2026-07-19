export interface AssetStatusRecord {
  id: number;
  schoolId: number | null;
  statusCode: string;
  statusNameAr: string;
  statusNameEn: string | null;
  statusType: number;
  isOperational: boolean;
  isAvailableForAssignment: boolean;
  requiresApprovalToEnter: boolean;
  colorCode: string | null;
  isActive: boolean;
  isSystemStatus: boolean;
  sortOrder: number;
  descriptionAr: string | null;
}

export type CreateAssetStatusRecordRequest = Omit<AssetStatusRecord, 'id'>;
export type UpdateAssetStatusRecordRequest = AssetStatusRecord;
