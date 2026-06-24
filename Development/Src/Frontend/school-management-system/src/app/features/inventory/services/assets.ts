import { HttpClient } from '@angular/common/http';
import { Injectable, signal, inject } from '@angular/core';
import { Observable, tap } from 'rxjs';

export interface AssetStats {
  totalAssets: number;
  maintenanceRequests: number;
  scrappedAssets: number;
  inventoryAccuracy: string;
}

export interface InventoryItem {
  id: string;
  name: string;
  category: string;
  quantity: number;
  location: string;
  status: 'good' | 'in_maintenance' | 'damaged';
  statusText: string;
}

@Injectable({
  providedIn: 'root'
})
export class AssetsService {
  private http = inject(HttpClient);

  stats = signal<AssetStats | null>(null);
  inventory = signal<InventoryItem[]>([]);

  /** جلب مؤشرات الجرد العام والأصول */
  getAssetStats(): Observable<AssetStats> {
    return this.http.get<AssetStats>('/api/v1/inventory/stats').pipe(
      tap(data => this.stats.set(data))
    );
  }

  /** جلب قائمة بآخر العهد والمواد المرصودة */
  getInventoryList(): Observable<InventoryItem[]> {
    return this.http.get<InventoryItem[]>('/api/v1/inventory/items').pipe(
      tap(data => this.inventory.set(data))
    );
  }
}
