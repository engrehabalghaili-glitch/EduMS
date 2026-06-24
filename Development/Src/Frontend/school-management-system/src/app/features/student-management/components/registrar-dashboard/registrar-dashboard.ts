import { Component, OnInit, inject, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { RegistrarService } from '../../services/registrar';

@Component({
  selector: 'app-registrar-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, ButtonModule, ChartModule, DialogModule, InputTextModule, SelectModule],
  templateUrl: './registrar-dashboard.html',
  styleUrls: ['./registrar-dashboard.scss']
})
export class RegistrarDashboardComponent implements OnInit {
  registrarService = inject(RegistrarService);

  isNewOrderDialogVisible = signal<boolean>(false);

  newStudentData = {
    name: '',
    grade: null as string | null,
    nationalId: ''
  };

  gradeOptions = [
    { label: 'الصف الأول الابتدائي', value: '1 ابتدائي' },
    { label: 'الصف الأول المتوسط', value: '1 متوسط' },
    { label: 'الصف الثاني المتوسط', value: '2 متوسط' },
    { label: 'الصف الثالث المتوسط', value: '3 متوسط (نقل)' },
    { label: 'الصف الأول الثانوي', value: '1 ثانوي' }
  ];

  applications = this.registrarService.applications;
  loading = signal(false);

  statCards = computed(() => {
    const s = this.registrarService.stats();
    if (!s) return [];
    return [
      { label: 'طلبات جديدة', value: String(s.newApplications), change: 'آخر 24 ساعة', type: 'primary' },
      { label: 'طلبات نشطة', value: String(s.activeStudents), change: 'إجمالي', type: 'success' },
      { label: 'طلبات نقل', value: String(s.pendingTransfers), change: 'تحت المعالجة', type: 'warning' },
      { label: 'مراجعة مستندات', value: String(s.documentsReview), change: 'بانتظار المراجعة', type: 'info' },
    ];
  });

  pieData: any = null;
  pieOptions: any = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
      legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 }, boxWidth: 12 } }
    }
  };

  ngOnInit(): void {
    this.loading.set(true);
    this.registrarService.getDashboardStats().subscribe({ complete: () => this.checkLoading() });
    this.registrarService.getPendingApplications().subscribe({ complete: () => this.checkLoading() });
    this.registrarService.getChartData().subscribe(data => {
      this.pieData = {
        labels: data.labels,
        datasets: [{
          data: data.data,
          backgroundColor: ['#10b981', '#f59e0b', '#ef4444', '#3b82f6'],
          hoverBackgroundColor: ['#059669', '#d97706', '#dc2626', '#2563eb']
        }]
      };
    });
  }

  private pending = 2;
  private checkLoading(): void {
    this.pending--;
    if (this.pending <= 0) { this.loading.set(false); this.pending = 2; }
  }

  openNewOrderDialog() {
    this.newStudentData = { name: '', grade: null, nationalId: '' };
    this.isNewOrderDialogVisible.set(true);
  }

  submitNewApplication() {
    if (!this.newStudentData.name || !this.newStudentData.grade) return;
    this.registrarService.submitApplication({
      name: this.newStudentData.name,
      grade: this.newStudentData.grade,
      nationalId: this.newStudentData.nationalId
    }).subscribe();
    this.isNewOrderDialogVisible.set(false);
  }

  onActionClick(action: string, appId: string) {
    console.log(`تم تنفيذ إجراء [${action}] على الطلب رقم: ${appId}`);
  }
}
