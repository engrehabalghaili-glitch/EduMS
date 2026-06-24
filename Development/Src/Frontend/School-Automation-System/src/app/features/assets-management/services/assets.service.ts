import { Injectable, inject } from '@angular/core';
import { AssetDataSource } from '../data/assets.datasource';
import type { Asset, MaintenanceRequest, MaintenanceStatus, PreventiveMaintenance, InventoryItem, DepreciationInfo, AssetActivity } from '../models/assets.model';

@Injectable()
export class AssetService {
  private readonly dataSource = inject(AssetDataSource);

  async getAssets(): Promise<Asset[]> {
    return this.dataSource.getAssets();
  }

  async getAssetById(id: string): Promise<Asset | null> {
    return this.dataSource.getAssetById(id);
  }

  async createAsset(asset: Omit<Asset, 'id'>): Promise<Asset> {
    return this.dataSource.createAsset(asset);
  }

  async getMaintenanceRequests(): Promise<MaintenanceRequest[]> {
    return this.dataSource.getMaintenanceRequests();
  }

  async updateMaintenanceStatus(id: string, status: MaintenanceStatus): Promise<MaintenanceRequest> {
    return this.dataSource.updateMaintenanceStatus(id, status);
  }

  async getPreventiveMaintenance(): Promise<PreventiveMaintenance[]> {
    return this.dataSource.getPreventiveMaintenance();
  }

  async getInventory(): Promise<InventoryItem[]> {
    return this.dataSource.getInventory();
  }

  async getDepreciation(): Promise<DepreciationInfo[]> {
    return this.dataSource.getDepreciation();
  }

  async getExpiredAssets(): Promise<{ name: string; category: string; purchaseYear: number; replacementCost: number; reason: string }[]> {
    return this.dataSource.getExpiredAssets();
  }

  async getAssetActivities(assetId: string): Promise<AssetActivity[]> {
    return this.dataSource.getAssetActivities(assetId);
  }

  async getBureauReport(): Promise<{ localCount: number; bureauCount: number; extraAssets: string[]; missingAssets: string[]; lastSyncDate: string; status: string }> {
    return this.dataSource.getBureauReport();
  }
}
