export interface SchoolAsset {
  id: number;
  schoolId: number;
  assetUniqueCode: string;
  assetNameAr: string;
  assetNameEn: string | null;
  assetTag: string | null;
  serialNumber: string | null;
  modelNumber: string | null;
  manufacturer: string | null;
  brand: string | null;
  assetCategoryId: number | null;
  assetStatusId: number | null;
  assetLocationId: number | null;
  condition: number;
  acquisitionType: number;
  acquisitionDate: string;
  acquisitionCost: number;
  supplierName: string | null;
  purchaseOrderReference: string | null;
  warrantyContractId: number | null;
  isInsured: boolean;
  insurancePolicyNumber: string | null;
  insuranceExpiryDate: string | null;
  usefulLifeYears: number;
  salvageValue: number;
  currentBookValue: number;
  barcode: string | null;
  qrCode: string | null;
  rfidTag: string | null;
  hasPhysicalTag: boolean;
  physicalTagDate: string | null;
  currency: string | null;
  isActive: boolean;
  notes: string | null;
}

export type CreateSchoolAssetRequest = Omit<SchoolAsset, 'id'>;
export type UpdateSchoolAssetRequest = SchoolAsset;
