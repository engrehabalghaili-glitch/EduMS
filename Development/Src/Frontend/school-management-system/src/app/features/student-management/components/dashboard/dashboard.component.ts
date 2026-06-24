import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartModule } from 'primeng/chart';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { DashboardService } from '../../services/dashboard';

@Component({
  selector: 'app-management-dashboard',
  standalone: true,
  imports: [CommonModule, ChartModule, TableModule, TagModule, ButtonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  private dashboardService = inject(DashboardService);

  kpiCards = this.dashboardService.kpiCards;
  capacityAlerts = this.dashboardService.capacityAlerts;
  recentActivities = this.dashboardService.recentActivities;
  charts = this.dashboardService.charts;
  loading = this.dashboardService.loading;

  ngOnInit(): void {
    this.dashboardService.loadAll();
  }

  getCapacityColor(pct: number): string {
    if (pct >= 100) return 'danger';
    if (pct >= 96) return 'warn';
    return 'info';
  }

  getStatusIcon(status: string): string {
    switch (status) {
      case 'completed': return 'pi pi-check';
      case 'approved': return 'pi pi-check-circle';
      case 'rejected': return 'pi pi-times-circle';
      case 'pending': return 'pi pi-hourglass';
      default: return 'pi pi-info-circle';
    }
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'completed': return 'status-completed';
      case 'approved': return 'status-approved';
      case 'rejected': return 'status-rejected';
      case 'pending': return 'status-pending';
      default: return '';
    }
  }
}
