import { Component, inject, computed, signal } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ApplicationService } from '../../services/application';

@Component({
  selector: 'app-applications-list',
  standalone: true,
  imports: [CommonModule, FormsModule, TableModule, TagModule, ButtonModule, InputTextModule],
  templateUrl: './applications-list.component.html',
  styleUrls: ['./applications-list.component.scss']
})
export class ApplicationsListComponent {
  private router = inject(Router);
  private applicationService = inject(ApplicationService);

  applications = this.applicationService.applications;
  searchQuery = signal('');

  loading = signal(false);

  constructor() {
    this.loading.set(true);
    this.applicationService.getApplications().subscribe({ complete: () => this.loading.set(false) });
  }

  filteredApplications = computed(() => {
    const q = this.searchQuery().trim().toLowerCase();
    if (!q) return this.applications();
    return this.applications().filter(
      app => app.id.toLowerCase().includes(q) || app.studentName.includes(q)
    );
  });

  getStatusSeverity(status: string): 'warn' | 'success' | 'danger' {
    switch (status) {
      case 'pending': return 'warn';
      case 'approved': return 'success';
      case 'rejected': return 'danger';
      default: return 'warn';
    }
  }

  viewDetails(id: string): void {
    this.router.navigate(['/student/applications/details', id]);
  }
}
