import type { AssetCategory, AssetStatus } from '../../../../shared/models/asset.types';

export type RegistrationStep = 'generalInfo' | 'locationTagging' | 'warrantyStatus' | 'verification';

export interface StepGeneralInfo {
  name: string;
  acquisitionDate: string;
  assetType: string;
  subCategory: string[];
  estimatedValue: number | null;
  notes: string;
}

export interface StepLocationTagging {
  floor: string;
  room: string;
  location: string;
  barcode: string;
}

export interface StepWarrantyStatus {
  purchaseDate: string;
  purchaseCost: number | null;
  invoiceNumber: string;
  warrantyEnd: string;
}

export interface AssetFormData {
  generalInfo: StepGeneralInfo;
  locationTagging: StepLocationTagging;
  warrantyStatus: StepWarrantyStatus;
}

export type StepValidationErrors<T> = Partial<Record<keyof T, string>>;

export interface ValidationErrors {
  generalInfo?: StepValidationErrors<StepGeneralInfo>;
  locationTagging?: StepValidationErrors<StepLocationTagging>;
  warrantyStatus?: StepValidationErrors<StepWarrantyStatus>;
  verification?: Record<string, never>;
}

export interface AssetListFilter {
  category: AssetCategory | '';
  status: AssetStatus | '';
  search: string;
}

export interface AssetListItem {
  id: string;
  barcode: string;
  name: string;
  category: AssetCategory;
  status: AssetStatus;
  location: string;
  purchaseDate: string;
  purchaseCost: number;
  assignedTo: string;
}

export const STEP_LABELS: Record<RegistrationStep, string> = {
  generalInfo: 'المعلومات العامة',
  locationTagging: 'الموقع والباركود',
  warrantyStatus: 'الضمان والشراء',
  verification: 'مراجعة وتأكيد',
};
