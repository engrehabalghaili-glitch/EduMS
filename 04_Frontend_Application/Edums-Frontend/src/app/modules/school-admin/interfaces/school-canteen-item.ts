import type { NutritionalCategory } from './common';

export interface SchoolCanteenItem {
  id: number;
  schoolId: number;
  facilityId: number | null;
  itemCode: string;
  itemNameAr: string;
  unitPrice: number;
  stockQuantity: number;
  nutritionalCategory: NutritionalCategory;
  isApprovedByHealthOfficer: boolean;
  itemNameEn: string | null;
  costPrice: number;
  reorderThresholdQuantity: number;
  barcodeNumber: string | null;
  dailySalesLimitPerStudent: number;
  isAvailable: boolean;
}

export type CreateSchoolCanteenItemDto = Omit<SchoolCanteenItem, 'id'>;

export type UpdateSchoolCanteenItemDto = Omit<SchoolCanteenItem, 'schoolId'>;
