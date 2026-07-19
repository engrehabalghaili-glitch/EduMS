export interface AssetFinancials {
  id: number;
  assetId: number;
  schoolId: number;
  purchasePrice: number;
  shippingCosts: number;
  customsFees: number;
  installationCosts: number;
  otherCosts: number;
  totalInitialCost: number;
  currency: string | null;
  exchangeRateToSar: number;
  salvageValue: number;
  residualValueLastUpdate: string | null;
  fiscalYear: string | null;
}

export type CreateAssetFinancialsRequest = Omit<AssetFinancials, 'id'>;
export type UpdateAssetFinancialsRequest = AssetFinancials;
