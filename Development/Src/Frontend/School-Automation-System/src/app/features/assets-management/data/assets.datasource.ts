import { Injectable } from '@angular/core';
import type {
  Asset, MaintenanceRequest, PreventiveMaintenance, InventoryItem,
  DepreciationInfo, AssetActivity, MaintenanceStatus,
} from '../models/assets.model';

@Injectable()
export abstract class AssetDataSource {
  abstract getAssets(): Promise<Asset[]>;
  abstract getAssetById(id: string): Promise<Asset | null>;
  abstract createAsset(asset: Omit<Asset, 'id'>): Promise<Asset>;
  abstract getMaintenanceRequests(): Promise<MaintenanceRequest[]>;
  abstract updateMaintenanceStatus(id: string, status: MaintenanceStatus): Promise<MaintenanceRequest>;
  abstract getPreventiveMaintenance(): Promise<PreventiveMaintenance[]>;
  abstract getInventory(): Promise<InventoryItem[]>;
  abstract getDepreciation(): Promise<DepreciationInfo[]>;
  abstract getExpiredAssets(): Promise<{ name: string; category: string; purchaseYear: number; replacementCost: number; reason: string }[]>;
  abstract getAssetActivities(assetId: string): Promise<AssetActivity[]>;
  abstract getBureauReport(): Promise<{ localCount: number; bureauCount: number; extraAssets: string[]; missingAssets: string[]; lastSyncDate: string; status: string }>;
}
