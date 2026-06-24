import { Injectable } from '@angular/core';
import type { Asset } from '../../../../shared/models/asset.types';
import type { AssetFormData, AssetListFilter, AssetListItem } from '../models/registration.types';

@Injectable()
export abstract class RegistrationDataSource {
  abstract createAsset(data: AssetFormData): Promise<Asset>;
  abstract getAssets(filter?: AssetListFilter): Promise<AssetListItem[]>;
  abstract getArchivedAssets(): Promise<AssetListItem[]>;
  abstract getAssetById(id: string): Promise<Asset | null>;
}
