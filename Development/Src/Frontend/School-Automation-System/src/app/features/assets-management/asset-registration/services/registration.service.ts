import { Injectable, inject } from '@angular/core';
import { RegistrationDataSource } from '../data/registration.datasource';
import type { Asset } from '../../../../shared/models/asset.types';
import type { AssetFormData, AssetListFilter, AssetListItem } from '../models/registration.types';

@Injectable()
export class RegistrationService {
  private readonly dataSource = inject(RegistrationDataSource);

  createAsset(data: AssetFormData): Promise<Asset> {
    return this.dataSource.createAsset(data);
  }

  getAssets(filter?: AssetListFilter): Promise<AssetListItem[]> {
    return this.dataSource.getAssets(filter);
  }

  getArchivedAssets(): Promise<AssetListItem[]> {
    return this.dataSource.getArchivedAssets();
  }

  getAssetById(id: string): Promise<Asset | null> {
    return this.dataSource.getAssetById(id);
  }
}
