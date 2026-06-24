import { Injectable } from '@angular/core';
import { AssetDataSource } from './assets.datasource';
import type { Asset, MaintenanceRequest, MaintenanceStatus, PreventiveMaintenance, InventoryItem, DepreciationInfo, AssetActivity } from '../models/assets.model';

@Injectable()
export class AssetApiDataSource extends AssetDataSource {
  private readonly apiBase = '/api/assets';

  async getAssets(): Promise<Asset[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getAssetById(id: string): Promise<Asset | null> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async createAsset(asset: Omit<Asset, 'id'>): Promise<Asset> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getMaintenanceRequests(): Promise<MaintenanceRequest[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async updateMaintenanceStatus(id: string, status: MaintenanceStatus): Promise<MaintenanceRequest> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getPreventiveMaintenance(): Promise<PreventiveMaintenance[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getInventory(): Promise<InventoryItem[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getDepreciation(): Promise<DepreciationInfo[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getExpiredAssets(): Promise<{ name: string; category: string; purchaseYear: number; replacementCost: number; reason: string }[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getAssetActivities(assetId: string): Promise<AssetActivity[]> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }

  async getBureauReport(): Promise<{ localCount: number; bureauCount: number; extraAssets: string[]; missingAssets: string[]; lastSyncDate: string; status: string }> {
    throw new Error('API DataSource not implemented. TODO: implement when backend is ready.');
  }
}
