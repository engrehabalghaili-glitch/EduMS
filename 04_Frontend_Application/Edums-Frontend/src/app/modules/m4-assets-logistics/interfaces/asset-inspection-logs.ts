export interface AssetInspectionLog {
  id: number;
  assetId: number;
  schoolId: number;
  relatedTransactionType: string;
  relatedTransactionId: number | null;
  inspectionType: number;
  inspectionDate: string;
  inspectorUserId: number;
  physicalCondition: number;
  damageDetails: string | null;
  damagePhotosJson: string | null;
  functionalStatus: number;
  missingPartsJson: string | null;
  inspectionResult: number;
  recommendedAction: string | null;
  estimatedRepairCost: number;
  notes: string | null;
}

export type CreateAssetInspectionLogRequest = Omit<AssetInspectionLog, 'id'>;
export type UpdateAssetInspectionLogRequest = AssetInspectionLog;
