import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { AssetMaintenanceTicket, CreateAssetMaintenanceTicketRequest, UpdateAssetMaintenanceTicketRequest } from '../models/asset-maintenance-tickets';

@Injectable({ providedIn: 'root' })
export class AssetMaintenanceTicketService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/assetMaintenanceTickets`;

  getAll(): Observable<AssetMaintenanceTicket[]> {
    return this.http.get<AssetMaintenanceTicket[]>(this.apiUrl);
  }

  getById(id: number): Observable<AssetMaintenanceTicket> {
    return this.http.get<AssetMaintenanceTicket>(`${this.apiUrl}/${id}`);
  }

  getByAssetId(assetId: number): Observable<AssetMaintenanceTicket[]> {
    return this.http.get<AssetMaintenanceTicket[]>(`${this.apiUrl}?assetId=${assetId}`);
  }

  create(dto: CreateAssetMaintenanceTicketRequest): Observable<AssetMaintenanceTicket> {
    return this.http.post<AssetMaintenanceTicket>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateAssetMaintenanceTicketRequest): Observable<AssetMaintenanceTicket> {
    return this.http.put<AssetMaintenanceTicket>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

