import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ProgressBarModule } from 'primeng/progressbar';
import { TooltipModule } from 'primeng/tooltip';
import { ToastModule } from 'primeng/toast';
import { DialogService } from 'primeng/dynamicdialog';
import { MessageService } from 'primeng/api';
import { InstallmentService, Installment, InstallmentStatus } from '../../services/installment';
import { InstallmentFormDialogComponent } from './installment-form-dialog.component';

@Component({
  selector: 'app-financial-installments',
  standalone: true,
  imports: [CommonModule, TableModule, TagModule, ProgressBarModule, TooltipModule, ToastModule],
  providers: [DialogService, MessageService],
  templateUrl: './financial-installments.component.html',
  styleUrls: ['./financial-installments.component.scss']
})
export class FinancialInstallmentsComponent implements OnInit {
  private installmentService = inject(InstallmentService);
  private dialogService = inject(DialogService);
  private msg = inject(MessageService);

  installments = this.installmentService.installments;
  totalAmount = this.installmentService.totalAmount;
  totalPaid = this.installmentService.totalPaid;
  progressPercent = this.installmentService.progressPercent;
  paidCount = this.installmentService.paidCount;
  remainingAmount = this.installmentService.remainingAmount;
  scheduledCount = this.installmentService.scheduledCount;
  pendingCount = this.installmentService.pendingCount;
  isPrivateSchool = this.installmentService.isPrivateSchool;
  loading = this.installmentService.loading;
  saving = signal(false);

  ngOnInit(): void {
    this.installmentService.getInstallments().subscribe();
  }

  openAddDialog(): void {
    const ref = this.dialogService.open(InstallmentFormDialogComponent, {
      header: 'إضافة قسط جديد',
      width: '420px',
      dismissableMask: true,
    });

    ref!.onClose.subscribe((result: any) => {
      if (!result) return;
      this.saving.set(true);
      this.installmentService.saveInstallment(result).subscribe({
        next: () => {
          this.msg.add({ severity: 'success', summary: 'نجاح', detail: 'تم الحفظ بنجاح', life: 3000 });
          this.saving.set(false);
        },
        error: () => {
          this.msg.add({ severity: 'error', summary: 'خطأ', detail: 'حدث خطأ، يرجى المحاولة لاحقاً', life: 3000 });
          this.saving.set(false);
        },
      });
    });
  }

  getStudentProgress(inst: Installment): number {
    return Math.round((inst.paidAmount / inst.amount) * 100);
  }

  getProgressColor(pct: number): string {
    if (pct >= 100) return '#10b981';
    if (pct >= 50) return '#3b82f6';
    return '#f59e0b';
  }

  getStatusLabel(status: InstallmentStatus): string {
    switch (status) {
      case 'paid': return 'تم الدفع';
      case 'scheduled': return 'مجدول';
      case 'pending': return 'قيد الانتظار';
    }
  }

  getStatusClass(status: InstallmentStatus): string {
    switch (status) {
      case 'paid': return 'status-paid';
      case 'scheduled': return 'status-scheduled';
      case 'pending': return 'status-pending';
    }
  }

  getStatusIcon(status: InstallmentStatus): string {
    switch (status) {
      case 'paid': return 'pi pi-check-circle';
      case 'scheduled': return 'pi pi-calendar';
      case 'pending': return 'pi pi-hourglass';
    }
  }
}
