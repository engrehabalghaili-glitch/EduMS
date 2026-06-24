export interface TopAssetItem {
  id: string;
  name: string;
  barcode: string;
  category: string;
  status: string;
  purchaseCost: number;
  currentValue: number;
  location: string;
  assignedTo: string;
}

export interface DepreciationSummary {
  labels: string[];
  bookValues: number[];
  accumulatedDepreciation: number[];
  annualDepreciationValues: number[];
  totalAnnualDepreciation: number;
}

export interface ExpiredAssetItem {
  name: string;
  category: string;
  purchaseYear: number;
  replacementCost: number;
  reason: string;
}

export interface BureauReportItem {
  localCount: number;
  bureauCount: number;
  extraAssets: string[];
  missingAssets: string[];
  lastSyncDate: string;
  status: string;
}

export interface CategoryDistribution {
  labels: string[];
  data: number[];
}

export interface DashboardData {
  totalAssets: number;
  brokenCount: number;
  totalValue: number;
  annualDepreciation: number;
  expiredCount: number;
  categoryDistribution: CategoryDistribution;
  topAssets: TopAssetItem[];
  depreciation: DepreciationSummary;
  expiredAssets: ExpiredAssetItem[];
  bureauReport: BureauReportItem;
}
