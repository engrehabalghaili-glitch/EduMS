export interface AssetCategory {
  id: number;
  schoolId: number | null;
  parentCategoryId: number | null;
  categoryCode: string;
  categoryNameAr: string;
  categoryNameEn: string | null;
  categoryLevel: number;
  fullHierarchyPath: string | null;
  descriptionAr: string | null;
  defaultDepreciationRate: number;
  defaultDepreciationMethod: number;
  defaultUsefulLifeYears: number;
  isActive: boolean;
  isSystemCategory: boolean;
  sortOrder: number;
  notes: string | null;
}

export type CreateAssetCategoryRequest = Omit<AssetCategory, 'id'>;
export type UpdateAssetCategoryRequest = AssetCategory;
