import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { AssetMaintenanceTicket, CreateAssetMaintenanceTicketRequest, UpdateAssetMaintenanceTicketRequest } from '../models/asset-maintenance-tickets';

@Injectable({ providedIn: 'root' })
export class AssetMaintenanceTicketService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M4_AssetLogistics', 'assetMaintenanceTickets');

  getAll(): Observable<AssetMaintenanceTicket[]> {
    return this.http.get<AssetMaintenanceTicket[]>(this.baseUrl);
  }

  getById(id: number): Observable<AssetMaintenanceTicket> {
    return this.http.get<AssetMaintenanceTicket>(`${this.baseUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetMaintenanceTicket[]> {
    return this.http.get<AssetMaintenanceTicket[]>(`${this.baseUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetMaintenanceTicketRequest): Observable<AssetMaintenanceTicket> {
    return this.http.post<AssetMaintenanceTicket>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateAssetMaintenanceTicketRequest): Observable<AssetMaintenanceTicket> {
    return this.http.put<AssetMaintenanceTicket>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}


