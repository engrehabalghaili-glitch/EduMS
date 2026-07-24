export interface MaintenanceSparePart {
  id: number;
  schoolId: number;
  partCode: string;
  partNameAr: string;
  partNameEn: string | null;
  partCategory: string | null;
  manufacturer: string | null;
  compatibleAssetsJson: string | null;
  unitOfMeasure: string;
  currentStockQuantity: number;
  minStockLevel: number;
  maxStockLevel: number;
  reorderQuantity: number;
  unitCost: number;
  supplierName: string | null;
  locationInWarehouse: string | null;
  isActive: boolean;
  stockStatus: number;
  lastRestockDate: string | null;
  totalConsumed: number;
  notes: string | null;
}

export type CreateMaintenanceSparePartRequest = Omit<MaintenanceSparePart, 'id'>;
export type UpdateMaintenanceSparePartRequest = MaintenanceSparePart;
