import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { PrincipalService, SchoolIncident, TeacherPerformance } from '../../services/principal';

@Component({
  selector: 'app-principal-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './principal-dashboard.html',
  styleUrls: ['./principal-dashboard.scss']
})
export class PrincipalDashboardComponent implements OnInit {
  principalService = inject(PrincipalService);

  // كروت المؤشرات الاستراتيجية (Executive KPI Cards) لمدير المدرسة
  stats = signal([
    { label: 'نسبة الحضور العام اليوم (الطلاب)', value: '96.4%', desc: '✅ انضباط ممتاز (غياب 65 طالباً فقط)', type: 'success' },
    { label: 'نسبة حضور المعلمين والكادر', value: '98.1%', desc: '👨‍🏫 حالة واحدة غياب بعذر رسمي مصدق', type: 'primary' },
    { label: 'المعدل العام للتحصيل الدراسي', value: '88.5 / 100', desc: '📈 بارتفاع قدره 2.3% عن الفصل السابق', type: 'info' },
    { label: 'طلبات واعتمادات معلقة بانتظارك', value: '7 طلبات', desc: '⚠️ طلبات نقل، ميزانيات، وتعديل درجات وتظلمات', type: 'warning' }
  ]);

  // سجل البلاغات الإدارية والسلوكية التي تتطلب توقيع أو قرار المدير
  criticalIncidentsList = signal<SchoolIncident[]>([
    { id: 'INC-2026-01', type: 'behavioral', title: 'شجار وتخريب ممتلكات في ساحة الفسحة - طلاب الصف الثاني الثانوي', severity: 'high', reportedBy: 'أ. عبد الله (المشرف السلوكي)', date: '10:15 ص', status: 'pending_action' },
    { id: 'INC-2026-02', type: 'academic', title: 'طلب إعادة اختبار نهائي بديل للطالب فيصل الشمري لدواعي صحية', severity: 'medium', reportedBy: 'لجنة الاختبارات والكنترول', date: '09:30 ص', status: 'pending_action' },
    { id: 'INC-2026-03', type: 'administrative', title: 'عطل مفاجئ في وحدة التكييف المركزية بالمختبر رقم 3', severity: 'medium', reportedBy: 'مشرف الصيانة والسلامة', date: '08:00 ص', status: 'resolved' },
    { id: 'INC-2026-04', type: 'behavioral', title: 'حالة غياب جماعي غير مبرر لطلاب الفصل 3/أ (عدد 12 طالباً)', severity: 'high', reportedBy: 'نظام الحضور الذكي الآلي', date: 'أمس', status: 'pending_action' }
  ]);

  // جدول مراقبة وتقييم أداء المعلمين والتقدم في المناهج
  teachersPerformanceList = signal<TeacherPerformance[]>([
    { id: 'TCH-501', teacherName: 'أ. فهد بن سلطان السبيعي', subject: 'الرياضيات المتقدمة', attendanceRate: 100, syllabusProgress: 88, evaluationScore: 94 },
    { id: 'TCH-502', teacherName: 'أ. محمد بن علي القحطاني', subject: 'الفيزياء الكونية', attendanceRate: 95, syllabusProgress: 82, evaluationScore: 89 },
    { id: 'TCH-503', teacherName: 'أ. عمر بن عبد العزيز الشمري', subject: 'اللغة الإنجليزية (Mega Goal)', attendanceRate: 98, syllabusProgress: 91, evaluationScore: 96 }
  ]);

  // كائنات المخططات البيانية القيادية
  attendanceLineData: any;
  attendanceLineOptions: any;
  academicBarData: any;
  academicBarOptions: any;

  ngOnInit(): void {
    this.initPrincipalCharts();
  }

  initPrincipalCharts() {
    // 1. مخطط خطي متقدم لمراقبة الغياب والالتزام على مدار الأسابيع الستة الماضية
    this.attendanceLineData = {
      labels: ['الأسبوع 1', 'الأسبوع 2', 'الأسبوع 3', 'الأسبوع 4', 'الأسبوع 5', 'الأسبوع 6'],
      datasets: [
        {
          label: 'نسبة حضور الطلاب %',
          data: [94, 95.5, 96.1, 93.8, 95.9, 96.4],
          fill: true,
          borderColor: '#4f46e5', // النيلي القيادي
          backgroundColor: 'rgba(79, 70, 229, 0.05)',
          tension: 0.4,
          borderWidth: 3
        },
        {
          label: 'نسبة حضور المعلمين %',
          data: [98, 97.5, 99, 98.2, 97.8, 98.1],
          fill: false,
          borderColor: '#06b6d4',
          tension: 0.3,
          borderWidth: 2
        }
      ]
    };

    this.attendanceLineOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      scales: {
        x: { grid: { display: false }, ticks: { font: { family: 'Cairo' } } },
        y: { min: 90, max: 100, grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } }
      }
    };

    // 2. مخطط أعمدة أفقي لمقارنة معدلات نجاح وتحصيل الصفوف الدراسية
    this.academicBarData = {
      labels: ['الأول الثانوي', 'الثاني الثانوي - علمي', 'الثاني الثانوي - أدبي', 'الثالث الثانوي - عام'],
      datasets: [
        {
          label: 'معدل التحصيل الدراسي الحالي %',
          backgroundColor: '#312e81', // الأزرق الداكن الفخم
          data: [84, 89, 81, 92],
          borderRadius: 4
        }
      ]
    };

    this.academicBarOptions = {
      indexAxis: 'y', // قلب المخطط ليصبح أفقياً لمنع التداخل البصري
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { display: false }
      },
      scales: {
        x: { min: 0, max: 100, grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } },
        y: { ticks: { font: { family: 'Cairo', size: 11 } } }
      }
    };
  }

  executePrincipalAction(actionType: string, payload: string) {
    console.log(`قرار إداري من المدير: [${actionType}] على المعرف: [${payload}]`);
  }
}
