import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface SystemMetrics {
  cpuUsage: number;
  memoryUsage: number;
  activeSessions: number;
  apiRequestsPerMin: number;
  serverStatus: 'healthy' | 'warning' | 'critical';
}

export interface BranchStatus {
  id: string;
  name: string;
  databaseSize: string;
  licenseExpiry: string;
  activeUsers: number;
  status: 'active' | 'expired' | 'suspended';
}

export interface AuditLog {
  id: string;
  timestamp: string;
  operator: string;
  role: string;
  action: string;
  module: string;
  ipAddress: string;
  severity: 'info' | 'warning' | 'critical';
}

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private http = inject(HttpClient);

  // Signals لإدارة حالة البنية التحتية للنظام بالكامل
  metrics = signal<SystemMetrics | null>(null);
  branches = signal<BranchStatus[]>([]);
  auditLogs = signal<AuditLog[]>([]);

  /** جلب مؤشرات استهلاك الخوادم والـ API لحظياً */
  getSystemMetrics(): Observable<SystemMetrics> {
    return this.http.get<SystemMetrics>('/api/v1/admin/infrastructure/metrics').pipe(
      tap(data => this.metrics.set(data))
    );
  }

  /** جلب حالة الفروع والتراخيص المرتبطة بقاعدة البيانات المركزية */
  getBranchesStatus(): Observable<BranchStatus[]> {
    return this.http.get<BranchStatus[]>('/api/v1/admin/infrastructure/branches').pipe(
      tap(data => this.branches.set(data))
    );
  }

  /** جلب سجلات التدقيق الأمني الشاملة للعمليات الحساسة */
  getAuditLogs(): Observable<AuditLog[]> {
    return this.http.get<AuditLog[]>('/api/v1/admin/infrastructure/audit-logs').pipe(
      tap(data => this.auditLogs.set(data))
    );
  }
}
