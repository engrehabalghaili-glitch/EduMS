import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { HrService, EmployeeRow } from '../../services/hr';

@Component({
  selector: 'app-hr-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './hr-dashboard.html',
  styleUrls: ['./hr-dashboard.scss']
})
export class HrDashboardComponent implements OnInit {
  hrService = inject(HrService);

  stats = signal([
    { label: 'إجمالي الموظفين الكلي', value: '124 موظف', change: '👥 كادر تعليمي وإداري', type: 'primary' },
    { label: 'نسبة الحضور اليوم', value: '94.8%', change: '✅ ضمن النطاق المستهدف', type: 'success' },
    { label: 'طلبات إجازة معلقة', value: '6 طلبات', change: '⏳ تنتظر الموافقة', type: 'warning' },
    { label: 'المستحقات والرواتب', value: 'محسوبة', change: '💳 تم ترحيلها للمصرف', type: 'info' }
  ]);

  employeesList = signal<EmployeeRow[]>([
    { id: 'EMP-401', name: 'أ. سامي بن أحمد الفهد', role: 'معلم فيزياء', department: 'القسم الثانوي', attendanceRate: 98, status: 'active', statusText: 'على رأس العمل' },
    { id: 'EMP-402', name: 'أ. نورة بنت عبد الله السديري', role: 'موظفة استقبال', department: 'شؤون الطلاب', attendanceRate: 95, status: 'active', statusText: 'على رأس العمل' },
    { id: 'EMP-403', name: 'أ. خالد بن محمد العيسى', role: 'محاسب مالي', department: 'الإدارة المالية', attendanceRate: 0, status: 'on_leave', statusText: 'إجازة مرضية' },
    { id: 'EMP-404', name: 'أ. منيرة بنت صالح الباز', role: 'معلمة كيمياء', department: 'القسم الثانوي', attendanceRate: 92, status: 'active', statusText: 'على رأس العمل' }
  ]);

  barData: any;
  barOptions: any;

  ngOnInit(): void {
    this.initChart();
  }

  initChart() {
    this.barData = {
      labels: ['القسم الثانوي', 'القسم المتوسط', 'الابتدائي', 'الإدارة', 'الصيانة'],
      datasets: [
        {
          label: 'أيام الغياب والإجازات هذا الشهر',
          backgroundColor: '#0d9488',
          data: [12, 18, 8, 4, 15]
        }
      ]
    };

    this.barOptions = {
      indexAxis: 'y', // قلب المخطط ليصبح أفقياً احترافياً
      responsive: true,
      maintainAspectRatio: false,
      plugins: { legend: { display: false } },
      scales: {
        x: { grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } },
        y: { ticks: { font: { family: 'Cairo' } } }
      }
    };
  }
}
