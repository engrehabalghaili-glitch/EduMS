export type AssetCategory = 'technology' | 'furniture' | 'vehicle' | 'building';
export type AssetStatus = 'active' | 'maintenance' | 'broken' | 'retired' | 'stored';
export type MaintenancePriority = 'urgent' | 'medium' | 'routine';
export type MaintenanceStatus = 'pending' | 'in-progress' | 'completed';
export type InventoryCategory = 'stationery' | 'ink' | 'spare-parts';

export interface Asset {
  id: string;
  barcode: string;
  name: string;
  category: AssetCategory;
  location: string;
  status: AssetStatus;
  purchaseDate: string;
  purchaseCost: number;
  currentValue: number;
  supplier: string;
  invoiceNumber: string;
  warrantyEnd: string;
  warrantyStatus: 'valid' | 'expired';
  assignedTo: string;
  floor: string;
  room: string;
  description: string;
}

export interface MaintenanceRequest {
  id: string;
  assetId: string;
  assetName: string;
  assetBarcode: string;
  reportedDate: string;
  priority: MaintenancePriority;
  status: MaintenanceStatus;
  technician: string;
  description: string;
}

export interface PreventiveMaintenance {
  id: string;
  assetId: string;
  assetName: string;
  scheduledDate: string;
  remainingDays: number;
  type: string;
  assignedTo: string;
}

export interface InventoryItem {
  id: string;
  name: string;
  category: InventoryCategory;
  currentQuantity: number;
  minThreshold: number;
  unit: string;
}

export interface DepreciationInfo {
  category: string;
  bookValue: number;
  accumulatedDepreciation: number;
  annualDepreciation: number;
  assetCount: number;
}

export interface AssetActivity {
  date: string;
  event: string;
  type: 'purchase' | 'distribution' | 'maintenance' | 'warranty' | 'retirement';
}
