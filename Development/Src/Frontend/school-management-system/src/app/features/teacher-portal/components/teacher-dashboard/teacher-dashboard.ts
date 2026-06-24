import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { TeacherService, TeacherClass, TeacherAssignment } from '../../services/teacher';

@Component({
  selector: 'app-teacher-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './teacher-dashboard.html',
  styleUrls: ['./teacher-dashboard.scss']
})
export class TeacherDashboardComponent implements OnInit {
  teacherService = inject(TeacherService);

  // كروت المراقبة اللحظية الشاملة لأداء المعلم
  stats = signal([
    { label: 'إجمالي الطلاب المقيدين بفصولك', value: '145 طالب', desc: '📚 موزعين على 4 فصول دراسية', type: 'primary' },
    { label: 'متوسط الأداء الأكاديمي العام', value: '88.4%', desc: '↗ مرتفع بنسبة 2.1% عن الشهر الماضي', type: 'success' },
    { label: 'واجبات ومهام أدائية معلقة', value: '12 واجب', desc: '⏳ تنتظر التصحيح ورصد الدرجات', type: 'warning' },
    { label: 'الحصص المنجزة هذا الأسبوع', value: '16 حامس', desc: '✅ متبقي 4 حصص في الجدول الدراسي', type: 'info' }
  ]);

  // جدول الفصول الدراسية المسندة من واقع جداول النظام التعليمي
  assignedClasses = signal<TeacherClass[]>([
    { id: 'CLS-101', name: 'الصف الأول الثانوي - أ', subject: 'الفيزياء العامة', totalStudents: 36, averageGrade: 91.2, nextLessonTime: '08:00 ص - الحصة الأولى' },
    { id: 'CLS-102', name: 'الصف الأول الثانوي - ب', subject: 'الفيزياء العامة', totalStudents: 35, averageGrade: 86.5, nextLessonTime: '09:45 ص - الحصة الثالثة' },
    { id: 'CLS-201', name: 'الصف الثاني الثانوي - مسارات أ', subject: 'الفيزياء المتقدمة', totalStudents: 38, averageGrade: 89.0, nextLessonTime: 'غداً - الحصة الثانية' },
    { id: 'CLS-202', name: 'الصف الثاني الثانوي - مسارات ب', subject: 'الفيزياء المتقدمة', totalStudents: 36, averageGrade: 87.1, nextLessonTime: 'غداً - الحصة الرابعة' }
  ]);

  // مصفوفة إدارة الواجبات والاختبارات القصيرة التفاعلية
  assignmentsList = signal<TeacherAssignment[]>(
    [
      { id: 'ASM-401', title: 'واجب منزلي: قوانين نيوتن للحركة الدائرية', targetClass: 'الأول الثانوي - أ', submittedCount: 32, totalCount: 36, dueDate: 'اليوم 11:00 م', status: 'active' },
      { id: 'ASM-402', title: 'تقرير معملي: تجربة قياس تسارع الجاذبية', targetClass: 'الثاني الثانوي - مسارات أ', submittedCount: 38, totalCount: 38, dueDate: 'أمس', status: 'grading_completed' },
      { id: 'ASM-403', title: 'اختبار قصير دوري: الديناميكا الحرارية', targetClass: 'الأول الثانوي - ب', submittedCount: 15, totalCount: 35, dueDate: '19 يونيو', status: 'pending' }
    ]
  );

  // كائنات المخططات البيانية لمراقبة الطلاب
  radarData: any;
  radarOptions: any;
  attendanceLineData: any;
  attendanceLineOptions: any;

  ngOnInit(): void {
    this.initDashboardCharts();
  }

  initDashboardCharts() {
    // 1. مخطط رادار لتحليل مهارات مخرجات التعلم للفصول (Learning Outcomes)
    this.radarData = {
      labels: ['الفهم والاستيعاب', 'التفكير النقدي', 'التطبيقات الحسابية', 'التجارب المعملية', 'الالتزام بالمهام'],
      datasets: [
        {
          label: 'الأول الثانوي (عام)',
          borderColor: '#8b5cf6',
          backgroundColor: 'rgba(139, 92, 246, 0.1)',
          pointBackgroundColor: '#8b5cf6',
          data: [90, 82, 85, 88, 92]
        },
        {
          label: 'الثاني الثانوي (مسارات)',
          borderColor: '#ec4899',
          backgroundColor: 'rgba(236, 72, 153, 0.1)',
          pointBackgroundColor: '#ec4899',
          data: [85, 88, 90, 82, 86]
        }
      ]
    };

    this.radarOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      scales: {
        r: {
          grid: { color: '#e2e8f0' },
          pointLabels: { font: { family: 'Cairo', size: 12, weight: '700' }, color: '#334155' },
          ticks: { display: false }
        }
      }
    };

    // 2. مخطط خطي لمراقبة التزام الطلاب بالحضور والغياب الأسبوعي
    this.attendanceLineData = {
      labels: ['الأسبوع 1', 'الأسبوع 2', 'الأسبوع 3', 'الأسبوع 4', 'الأسبوع 5'],
      datasets: [
        {
          label: 'نسبة انضباط الحضور (%)',
          data: [96.2, 98.0, 95.1, 97.4, 98.8],
          borderColor: '#6366f1',
          backgroundColor: 'rgba(99, 102, 241, 0.1)',
          tension: 0.3,
          fill: true
        }
      ]
    };

    this.attendanceLineOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { display: false }
      },
      scales: {
        x: { grid: { display: false }, ticks: { font: { family: 'Cairo', size: 11 } } },
        y: { min: 90, max: 100, grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo', size: 11 } } }
      }
    };
  }

  onActionTriggered(type: string, payload: string) {
    console.log(`تنفيذ إجراء المعلم الكفء: [${type}] على المعرف: [${payload}]`);
  }
}
