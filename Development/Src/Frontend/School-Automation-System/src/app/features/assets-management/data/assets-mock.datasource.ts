import { Injectable } from '@angular/core';
import { AssetDataSource } from './assets.datasource';
import {
  MOCK_ASSETS, MOCK_MAINTENANCE_REQUESTS, MOCK_PREVENTIVE_MAINTENANCE,
  MOCK_INVENTORY, MOCK_DEPRECIATION, MOCK_EXPIRED_ASSETS,
  MOCK_ASSET_ACTIVITIES, MOCK_BUREAU_REPORT,
} from './mocks/assets.mock';
import type { Asset, MaintenanceRequest, MaintenanceStatus } from '../models/assets.model';

@Injectable()
export class AssetMockDataSource extends AssetDataSource {
  private assets = [...MOCK_ASSETS];
  private maintenanceRequests = [...MOCK_MAINTENANCE_REQUESTS];

  async getAssets(): Promise<Asset[]> {
    return [...this.assets];
  }

  async getAssetById(id: string): Promise<Asset | null> {
    return this.assets.find(a => a.id === id) ?? null;
  }

  async createAsset(asset: Omit<Asset, 'id'>): Promise<Asset> {
    const id = `A${String(this.assets.length + 1).padStart(3, '0')}`;
    const newAsset = { ...asset, id } as Asset;
    this.assets = [newAsset, ...this.assets];
    return newAsset;
  }

  async getMaintenanceRequests(): Promise<MaintenanceRequest[]> {
    return [...this.maintenanceRequests];
  }

  async updateMaintenanceStatus(id: string, status: MaintenanceStatus): Promise<MaintenanceRequest> {
    this.maintenanceRequests = this.maintenanceRequests.map(r =>
      r.id === id ? { ...r, status } : r
    );
    return this.maintenanceRequests.find(r => r.id === id)!;
  }

  async getPreventiveMaintenance() {
    return [...MOCK_PREVENTIVE_MAINTENANCE];
  }

  async getInventory() {
    return [...MOCK_INVENTORY];
  }

  async getDepreciation() {
    return [...MOCK_DEPRECIATION];
  }

  async getExpiredAssets() {
    return [...MOCK_EXPIRED_ASSETS];
  }

  async getAssetActivities(assetId: string) {
    return [...(MOCK_ASSET_ACTIVITIES[assetId] || [])];
  }

  async getBureauReport() {
    return { ...MOCK_BUREAU_REPORT };
  }
}
