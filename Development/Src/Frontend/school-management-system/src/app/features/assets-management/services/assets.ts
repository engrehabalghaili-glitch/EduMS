import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface AssetRecord {
  id: string;
  name: string;
  category: string;
  location: string;
  custodyOf: string; // العهدة طرف من
  purchaseDate: string;
  condition: 'excellent' | 'needs_maintenance' | 'depreciated';
  conditionText: string;
}

export interface MaintenanceOrder {
  id: string;
  assetId: string;
  assetName: string;
  issueDescription: string;
  priority: 'critical' | 'normal';
  scheduledDate: string;
  status: 'pending' | 'in_progress' | 'completed';
}

@Injectable({
  providedIn: 'root'
})
export class AssetsService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية (Signals) للمراقبة الفورية للأصول
  assets = signal<AssetRecord[]>([]);
  maintenanceOrders = signal<MaintenanceOrder[]>([]);

  /** جلب سجل الأصول الثابتة والمنقولة والعهد */
  getAssetsInventory(): Observable<AssetRecord[]> {
    return this.http.get<AssetRecord[]>('/api/v1/assets/inventory').pipe(
      tap(data => this.assets.set(data))
    );
  }

  /** جلب أوامر الصيانة الدورية والطارئة للأصول */
  getMaintenanceOrders(): Observable<MaintenanceOrder[]> {
    return this.http.get<MaintenanceOrder[]>('/api/v1/assets/maintenance').pipe(
      tap(data => this.maintenanceOrders.set(data))
    );
  }
}
