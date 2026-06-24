import { Injectable } from '@angular/core';
import { RegistrationDataSource } from './registration.datasource';
import { MOCK_ASSETS } from '../../data/mocks/assets.mock';
import type { Asset, AssetCategory, AssetStatus } from '../../../../shared/models/asset.types';
import type { AssetFormData, AssetListFilter, AssetListItem } from '../models/registration.types';

let nextIdCounter = MOCK_ASSETS.length + 1;

@Injectable()
export class RegistrationMockDataSource extends RegistrationDataSource {
  private assets: Asset[] = [...MOCK_ASSETS];
  private archived: Asset[] = this.assets.filter(a => a.status === 'retired' || a.status === 'stored');

  async createAsset(data: AssetFormData): Promise<Asset> {
    await new Promise(r => setTimeout(r, 500));
    const id = `A${String(nextIdCounter++).padStart(3, '0')}`;
    const today = new Date().toISOString().split('T')[0];
    const warrantyEnd = data.warrantyStatus.warrantyEnd;
    const purchaseCost = data.warrantyStatus.purchaseCost ?? 0;

    const assetTypeMap: Record<string, string> = {
      computers: 'technology', books: 'building', furniture: 'furniture',
      equipment: 'technology', labs: 'building',
    };

    const asset: Asset = {
      id,
      barcode: data.locationTagging.barcode || `BRC-${new Date().getFullYear()}-${String(nextIdCounter).padStart(3, '0')}`,
      name: data.generalInfo.name,
      category: (assetTypeMap[data.generalInfo.assetType] || 'technology') as AssetCategory,
      location: data.locationTagging.location,
      status: 'active',
      purchaseDate: data.generalInfo.acquisitionDate || today,
      purchaseCost: data.generalInfo.estimatedValue ?? 0,
      currentValue: data.generalInfo.estimatedValue ?? 0,
      supplier: data.generalInfo.subCategory.join(', '),
      invoiceNumber: data.warrantyStatus.invoiceNumber,
      warrantyEnd,
      warrantyStatus: warrantyEnd && warrantyEnd > today ? 'valid' : 'expired',
      assignedTo: '',
      floor: data.locationTagging.floor,
      room: data.locationTagging.room,
      description: data.generalInfo.notes || '',
    };

    this.assets.unshift(asset);
    return asset;
  }

  async getAssets(filter?: AssetListFilter): Promise<AssetListItem[]> {
    await new Promise(r => setTimeout(r, 200));
    let result = this.assets.filter(a => a.status !== 'retired');

    if (filter) {
      if (filter.search) {
        const q = filter.search.toLowerCase();
        result = result.filter(a =>
          a.name.toLowerCase().includes(q) ||
          a.barcode.toLowerCase().includes(q) ||
          a.assignedTo.toLowerCase().includes(q)
        );
      }
      if (filter.category) {
        result = result.filter(a => a.category === filter.category);
      }
      if (filter.status) {
        result = result.filter(a => a.status === filter.status);
      }
    }

    return result.map(this.toListItem);
  }

  async getArchivedAssets(): Promise<AssetListItem[]> {
    await new Promise(r => setTimeout(r, 200));
    return this.archived.map(this.toListItem);
  }

  async getAssetById(id: string): Promise<Asset | null> {
    await new Promise(r => setTimeout(r, 150));
    return this.assets.find(a => a.id === id) ?? null;
  }

  private toListItem(a: Asset): AssetListItem {
    return {
      id: a.id,
      barcode: a.barcode,
      name: a.name,
      category: a.category,
      status: a.status,
      location: a.location,
      purchaseDate: a.purchaseDate,
      purchaseCost: a.purchaseCost,
      assignedTo: a.assignedTo,
    };
  }
}
