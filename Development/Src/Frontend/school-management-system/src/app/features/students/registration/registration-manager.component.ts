import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { CardModule } from 'primeng/card';
import { SplitterModule } from 'primeng/splitter';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { RegistrationManagerService, RegistrationRequest } from '../services/registration-manager';

@Component({
  selector: 'app-registration-manager',
  standalone: true,
  imports: [CommonModule, FormsModule, TableModule, TagModule, CardModule, SplitterModule, ButtonModule, ToastModule],
  providers: [MessageService],
  templateUrl: './registration-manager.component.html',
  styleUrls: ['./registration-manager.component.scss']
})
export class RegistrationManagerComponent implements OnInit {
  private registrationService = inject(RegistrationManagerService);
  private messageService = inject(MessageService);

  selectedStatus: string = 'all';
  selectedRequest: RegistrationRequest | null = null;
  loading = false;

  applications = this.registrationService.applications;

  ngOnInit(): void {
    this.loading = true;
    this.registrationService.getApplications().subscribe({ complete: () => this.loading = false });
  }

  get filteredApplications(): RegistrationRequest[] {
    const all = this.applications();
    if (this.selectedStatus === 'all') return all;
    return all.filter(app => app.status === this.selectedStatus);
  }

  get statusCounts() {
    const all = this.applications();
    return {
      all: all.length,
      pending: all.filter(a => a.status === 'pending').length,
      accepted: all.filter(a => a.status === 'accepted').length,
      rejected: all.filter(a => a.status === 'rejected').length,
    };
  }

  getStatusSeverity(status: string): 'warn' | 'success' | 'danger' {
    switch (status) {
      case 'pending': return 'warn';
      case 'accepted': return 'success';
      case 'rejected': return 'danger';
      default: return 'warn';
    }
  }

  getStatusLabel(status: string): string {
    switch (status) {
      case 'pending': return 'بانتظار الاعتماد';
      case 'accepted': return 'مقبول';
      case 'rejected': return 'مرفوض';
      default: return '';
    }
  }

  getDocSeverity(status: string): 'success' | 'warn' | 'danger' {
    switch (status) {
      case 'مكتمل': return 'success';
      case 'ناقص': return 'warn';
      case 'غير مرفوع': return 'danger';
      default: return 'warn';
    }
  }

  setFilter(status: string): void {
    this.selectedStatus = status;
    this.selectedRequest = null;
  }

  onRowSelect(event: any): void {
    this.selectedRequest = event.data;
  }

  acceptRequest(request: RegistrationRequest): void {
    this.registrationService.updateApplicationStatus(request.id, 'accepted').subscribe();
  }

  rejectRequest(request: RegistrationRequest): void {
    this.registrationService.updateApplicationStatus(request.id, 'rejected').subscribe();
  }
}
