import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { SupervisorService, TeacherPerformance } from '../../services/supervisor';

@Component({
  selector: 'app-supervisor-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './supervisor-dashboard.html',
  styleUrls: ['./supervisor-dashboard.scss']
})
export class SupervisorDashboardComponent implements OnInit {
  supervisorService = inject(SupervisorService);

  // كروت الإحصاءات الأربعة للمشرف الأكاديمي
  stats = signal([
    { label: 'كادر هيئة التدريس', value: '48 معلم', change: '✅ مكتمل النصاب', type: 'primary' },
    { label: 'نسبة الحضور العام اليوم', value: '96.4%', change: '↗ أعلى من الأسبوع الماضي', type: 'success' },
    { label: 'زيارات صفية مكتملة', value: '18 زيارة', change: '🎯 المستهدف المستمر', type: 'info' },
    { label: 'تقارير معلقة للمراجعة', value: '7 تقارير', change: '⚠️ تطلب اعتمادك', type: 'warning' }
  ]);

  // جدول متابعة المعلمين المستمد من لغة البيانات الأصلية في نظامك
  teachers = signal<TeacherPerformance[]>([
    { id: 'TCH-091', name: 'أ. عبد العزيز الشمري', subject: 'الرياضيات', attendanceRate: 98, progressRate: 85, status: 'excellent', statusText: 'ممتاز' },
    { id: 'TCH-092', name: 'أ. مها بنت عبد الرحمن', subject: 'اللغة الإنجليزية', attendanceRate: 95, progressRate: 90, status: 'excellent', statusText: 'ممتاز' },
    { id: 'TCH-093', name: 'أ. فهد بن خالد العتيبي', subject: 'الفيزياء', attendanceRate: 92, progressRate: 72, status: 'good', statusText: 'جيد جدًا' },
    { id: 'TCH-094', name: 'أ. سارة بنت محمد القحطاني', subject: 'الكيمياء', attendanceRate: 88, progressRate: 60, status: 'attention', statusText: 'يحتاج متابعة' },
    { id: 'TCH-095', name: 'أ. سلطان بن علي العنزي', subject: 'اللغة العربية', attendanceRate: 96, progressRate: 88, status: 'excellent', statusText: 'ممتاز' }
  ]);

  // مخطط الحضور الحركي عبر الساعات واليوم (Line Chart)
  lineData: any;
  lineOptions: any;

  ngOnInit(): void {
    this.initChart();
  }

  initChart() {
    this.lineData = {
      labels: ['الأحد', 'الإثنين', 'الثلاثاء', 'الأربعاء', 'الخميس'],
      datasets: [
        {
          label: 'نسبة انضباط الطلاب (%)',
          data: [95.2, 96.4, 94.8, 97.1, 96.4],
          borderColor: '#7c3aed', // اللون البنفسجي المعتمد
          backgroundColor: 'rgba(124, 58, 237, 0.1)',
          fill: true,
          tension: 0.4,
          borderWidth: 3
        }
      ]
    };

    this.lineOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { display: false } // نكتفي بالعنوان العلوي للكارت
      },
      scales: {
        x: { grid: { display: false }, ticks: { font: { family: 'Cairo' } } },
        y: { min: 90, max: 100, grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } }
      }
    };
  }

  onInspectClick(teacherId: string) {
    console.log(`بدء تقييم أو زيارة صفية للمعلم صاحب الرقم: ${teacherId}`);
  }
}
