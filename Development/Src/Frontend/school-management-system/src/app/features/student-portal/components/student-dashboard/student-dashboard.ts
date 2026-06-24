import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { PortalDashboardService } from '../../services/portal';

@Component({
  selector: 'app-student-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './student-dashboard.html',
  styleUrls: ['./student-dashboard.scss']
})
export class StudentDashboardComponent implements OnInit {
  private portalService = inject(PortalDashboardService);

  stats = this.portalService.stats;
  homeworksList = this.portalService.homeworksList;
  charts = this.portalService.charts;
  loading = this.portalService.loading;

  ngOnInit(): void {
    this.portalService.loadAll();
  }
}
