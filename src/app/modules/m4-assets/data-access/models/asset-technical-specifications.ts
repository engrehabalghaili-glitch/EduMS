export interface AssetTechnicalSpecification {
  id: number;
  schoolId: number | null;
  specCode: string;
  specNameAr: string;
  specNameEn: string | null;
  assetCategoryId: number | null;
  assetTypeDescription: string | null;
  technicalDetailsJson: string | null;
  requiredCertifications: string | null;
  acceptanceCriteria: string | null;
  qualityStandards: string | null;
  warrantyRequirements: string | null;
  safetyRequirements: string | null;
  isActive: boolean;
  validFrom: string | null;
  validTo: string | null;
  specVersion: string;
  attachmentsJson: string | null;
  notes: string | null;
}

export type CreateAssetTechnicalSpecificationRequest = Omit<AssetTechnicalSpecification, 'id'>;
export type UpdateAssetTechnicalSpecificationRequest = AssetTechnicalSpecification;
