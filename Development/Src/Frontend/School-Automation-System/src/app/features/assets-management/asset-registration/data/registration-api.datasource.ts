import { Injectable } from '@angular/core';
import { RegistrationDataSource } from './registration.datasource';
import type { Asset } from '../../../../shared/models/asset.types';
import type { AssetFormData, AssetListFilter, AssetListItem } from '../models/registration.types';

@Injectable()
export class RegistrationApiDataSource extends RegistrationDataSource {
  async createAsset(_data: AssetFormData): Promise<Asset> {
    throw new Error('API DataSource not yet implemented');
  }

  async getAssets(_filter?: AssetListFilter): Promise<AssetListItem[]> {
    throw new Error('API DataSource not yet implemented');
  }

  async getArchivedAssets(): Promise<AssetListItem[]> {
    throw new Error('API DataSource not yet implemented');
  }

  async getAssetById(_id: string): Promise<Asset | null> {
    throw new Error('API DataSource not yet implemented');
  }
}
