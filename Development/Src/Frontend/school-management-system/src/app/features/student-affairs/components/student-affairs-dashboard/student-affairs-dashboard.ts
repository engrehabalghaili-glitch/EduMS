import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { StudentAffairsService, AdmissionRequest, StudentTransfer } from '../../services/student-affairs';

@Component({
  selector: 'app-student-affairs-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './student-affairs-dashboard.html',
  styleUrls: ['./student-affairs-dashboard.scss']
})
export class StudentAffairsDashboardComponent implements OnInit {
  affairsService = inject(StudentAffairsService);

  // كروت المراقبة اللحظية والعمليات الحيوية لشؤون الطلاب
  stats = signal([
    { label: 'إجمالي الطلاب المسجلين نشط', value: '1,840 طالب', desc: '🏫 طاقة استيعابية تشغيلية بنسبة 92%', type: 'primary' },
    { label: 'طلبات تسجيل جديدة هذا الأسبوع', value: '48 طلب', desc: '📥 منها 12 طلب بانتظار مراجعة الهوية', type: 'warning' },
    { label: 'معاملات نقل خارجي قيد الإجراء', value: '9 حالات', desc: '🔄 مرتبطة بنظام وزارة التعليم (نور)', type: 'info' },
    { label: 'شهادات وتقارير تم طباعتها اليوم', value: '85 وثيقة', desc: '✅ شهادات قيد، حسن سيرة وسلوك، مصدقة', type: 'success' }
  ]);

  // جدول طلبات القبول والتسجيل الفعلي
  admissionRequests = signal<AdmissionRequest[]>([
    { id: 'REG-2026-01', studentName: 'عبد الرحمن بن فهد السبيعي', gradeLevel: 'الأول الثانوي', submissionDate: '2026-06-15', documentStatus: 'complete', documentStatusText: 'مكتملة بالكامل', status: 'under_review' },
    { id: 'REG-2026-02', studentName: 'سلطان بن عبد الله الدوسري', gradeLevel: 'الثاني الثانوي', submissionDate: '2026-06-14', documentStatus: 'missing_docs', documentStatusText: 'نقص الهوية الوطنية للوالد', status: 'under_review' },
    { id: 'REG-2026-03', studentName: 'فيصل بن منصور الشمري', gradeLevel: 'الأول الثانوي', submissionDate: '2026-06-12', documentStatus: 'complete', documentStatusText: 'مكتملة بالكامل', status: 'approved' },
    { id: 'REG-2026-04', studentName: 'ماجد بن تركي العتيبي', gradeLevel: 'الثالث الثانوي', submissionDate: '2026-06-10', documentStatus: 'pending_review', documentStatusText: 'بانتظار فحص شهادة المرفقة', status: 'under_review' }
  ]);

  // جدول معاملات انتقال الطلاب (Incoming / Outgoing)
  studentTransfers = signal<StudentTransfer[]>([
    { id: 'TRF-881', studentName: 'خالد بن وليد الحربي', direction: 'incoming', schoolName: 'ثانوية الغد الأهلية', currentStep: 'بانتظار موافقة مدير المدرسة', status: 'pending' },
    { id: 'TRF-882', studentName: 'سعود بن محمد القحطاني', direction: 'outgoing', schoolName: 'مجمع الملك عبد الله التعليمي', currentStep: 'تم إصدار الملف والشهادات', status: 'completed' }
  ]);

  // كائنات المخططات البيانية
  doughnutData: any;
  doughnutOptions: any;
  stackedBarData: any;
  stackedBarOptions: any;

  ngOnInit(): void {
    this.initDashboardCharts();
  }

  initDashboardCharts() {
    // 1. مخطط Doughnut لتحليل توزيع الحالات الأكاديمية للطلاب
    this.doughnutData = {
      labels: ['طلاب مستجدين', 'طلاب منتظمين', 'منقولين إلينا', 'طي قيد / معلق'],
      datasets: [
        {
          data: [250, 1450, 110, 30],
          backgroundColor: ['#f97316', '#fb923c', '#fdba74', '#cbd5e1'],
          borderWidth: 0
        }
      ]
    };

    this.doughnutOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      cutout: '70%'
    };

    // 2. مخطط الأعمدة المتراكمة لمراقبة وثائق ومستمسكات القبول
    this.stackedBarData = {
      labels: ['الأول الثانوي', 'الثاني الثانوي', 'الثالث الثانوي'],
      datasets: [
        {
          type: 'bar',
          label: 'ملفات مكتملة',
          backgroundColor: '#ea580c',
          data: [120, 95, 140]
        },
        {
          type: 'bar',
          label: 'ملفات بها نواقص',
          backgroundColor: '#ffedd5',
          data: [15, 22, 8]
        }
      ]
    };

    this.stackedBarOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 11 } } }
      },
      scales: {
        x: { stacked: true, ticks: { font: { family: 'Cairo' } } },
        y: { stacked: true, grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } }
      }
    };
  }

  onActionTriggered(type: string, payload: string) {
    console.log(`إجراء شؤون طلاب: [${type}] للمعرف: [${payload}]`);
  }
}
