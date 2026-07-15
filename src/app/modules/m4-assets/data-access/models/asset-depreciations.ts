export interface AssetDepreciation {
  id: number;
  assetId: number;
  schoolId: number;
  methodType: number;
  usefulLifeYears: number;
  depreciationRate: number;
  currentBookValue: number;
  accumulatedDepreciation: number;
  netBookValue: number;
  depreciableAmount: number;
  lastDepreciationDate: string | null;
  lastDepreciationPeriod: string | null;
  isFullyDepreciated: boolean;
  notes: string | null;
}

export type CreateAssetDepreciationRequest = Omit<AssetDepreciation, 'id'>;
export type UpdateAssetDepreciationRequest = AssetDepreciation;
