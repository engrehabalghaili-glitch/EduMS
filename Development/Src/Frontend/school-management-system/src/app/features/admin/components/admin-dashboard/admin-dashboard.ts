import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { AdminService, AuditLog, BranchStatus } from '../../services/admin';
// import { Chart, registerables } from 'chart.js';
@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './admin-dashboard.html',
  styleUrls: ['./admin-dashboard.scss']
})
export class AdminDashboardComponent implements OnInit {
  adminService = inject(AdminService);

  // كروت المراقبة والأداء عالي الحجم (Enterprise Infrastructure Cards)
  stats = signal([
    { label: 'إجمالي الحسابات النشطة بالمنظومة', value: '4,150 مستخدم', desc: '👥 طلاب، معلمين، إداريين، أولياء أمور', type: 'primary' },
    { label: 'متوسط استجابة خادم الـ API', value: '42ms', desc: '⚡ أداء فائق السرعة عبر خوادم موازية', type: 'success' },
    { label: 'حجم البيانات السحابية المستهلكة', value: '1.42 TB', desc: '💾 قواعد بيانات مستقرة + ملفات مرفقة', type: 'info' },
    { label: 'جاهزية النسخ الاحتياطي التلقائي', value: '100%', desc: '🛡️ تم الترحيل السحابي الآمن الفجر 4:00 ص', type: 'safe' }
  ]);

  // مصفوفة مراقبة الفروع والمنشآت التعليمية المرتبطة بالنظام المركزى
  branchesList = signal<BranchStatus[]>([
    { id: 'BR-01', name: 'مجمع الفتيان الرئيسي (الرياض)', databaseSize: '450 GB', licenseExpiry: '2027-01-01', activeUsers: 2400, status: 'active' },
    { id: 'BR-02', name: 'مجمع البنات الأكاديمي (جدة)', databaseSize: '380 GB', licenseExpiry: '2026-12-15', activeUsers: 1550, status: 'active' },
    { id: 'BR-03', name: 'فرع الروضة والطفولة المبكرة', databaseSize: '85 GB', licenseExpiry: '2026-08-30', activeUsers: 200, status: 'active' }
  ]);

  // سجل تدقيق العمليات الأمنية والحركية الدقيق (Audit Logs) لمنع الاختراقات وتتبع الأخطاء
  auditLogsList = signal<AuditLog[]>([
    { id: 'AUD-9921', timestamp: '12:00:15', operator: 'م. فهد القحطاني', role: 'مدير فني', action: 'تغيير صلاحيات جدار الحماية وتحديث شهادة الـ SSL', module: 'الأمن', ipAddress: '10.0.1.45', severity: 'info' },
    { id: 'AUD-9920', timestamp: '11:54:32', operator: 'أ. حمدان (م. عهدة)', role: 'مسؤول الأصول', action: 'تصدير الكشف الجردي الشامل لـ 48 جدول بصيغة Excel', module: 'المستودعات', ipAddress: '192.168.4.12', severity: 'info' },
    { id: 'AUD-9919', timestamp: '11:42:10', operator: 'نظام التنبيه الآلي', role: 'System', action: 'رصد محاولات تسجيل دخول خاطئة متكررة لحساب المعلم (EMP-401)', module: 'الهوية Auth', ipAddress: '185.22.41.9', severity: 'warning' },
    { id: 'AUD-9918', timestamp: '11:15:00', operator: 'م. فهد القحطاني', role: 'مدير فني', action: 'إيقاف تراخيص فرع تجريبي منتهي الصلاحية مسبقاً', module: 'التراخيص', ipAddress: '10.0.1.45', severity: 'info' },
    { id: 'AUD-9917', timestamp: '10:30:22', operator: 'أ. سارة (م. موارد)', role: 'مدير HR', action: 'تعديل الهيكل التنظيمي لرواتب القسم الثانوي والبدلات', module: 'الموارد HR', ipAddress: '192.168.2.55', severity: 'warning' }
  ]);

  // كائنات المخططات البيانية
  comboData: any;
  comboOptions: any;
  infraRadarData: any;
  infraRadarOptions: any;

  ngOnInit(): void {
    this.initCharts();
    // 2. أضف هذا السطر هنا لتسجيل المكونات قبل بناء المخططات
    // Chart.register(...registerables);
  }

  initCharts() {
    // 1. مخطط المزيج المتقدم (Combo Chart): الطلبات بالثانية وحمل المعالجة
    this.comboData = {
      labels: ['08:00 ص', '09:00 ص', '10:00 ص', '11:00 ص', '12:00 م', '01:00 م', '02:00 م'],
      datasets: [
        {
          type: 'line',
          label: 'زمن استجابة الشبكة (ms)',
          borderColor: '#f59e0b',
          borderWidth: 3,
          pointBackgroundColor: '#f59e0b',
          fill: false,
          data: [35, 52, 48, 62, 42, 58, 40]
        },
        {
          type: 'bar',
          label: 'حجم طلبات الـ Webhook والـ API (بالألوف)',
          backgroundColor: '#4f46e5',
          data: [28, 45, 60, 85, 92, 70, 40],
          borderRadius: 6
        }
      ]
    };

    this.comboOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      scales: {
        x: { grid: { display: false }, ticks: { font: { family: 'Cairo', size: 11 } } },
        y: { grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo', size: 11 } } }
      }
    };

    // 2. مخطط الرادار لتوزيع جاهزية البنية التحتية (Infrastructure Readiness Radar)
    this.infraRadarData = {
      labels: ['تأمين جدار الحماية', 'استقرار قواعد البيانات', 'معدل بقاء الخادم المتاح', 'تزامن الأبنية الفروع', 'سرعة استجابة المزامنة'],
      datasets: [
        {
          label: 'الوضع الفعلي الحالي للمنظومة',
          borderColor: '#06b6d4',
          backgroundColor: 'rgba(6, 182, 212, 0.15)',
          pointBackgroundColor: '#06b6d4',
          data: [98, 95, 99.9, 92, 96]
        }
      ]
    };

    this.infraRadarOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 11 } } }
      },
      scales: {
        r: {
          grid: { color: '#e2e8f0' },
          pointLabels: { font: { family: 'Cairo', size: 12, weight: '700' }, color: '#334155' },
          ticks: { display: false }
        }
      }
    };
  }

  triggerSystemAction(actionType: string) {
    console.log(`بدء تنفيذ عملية هندسية حرجة في النظام: [${actionType}]`);
  }
}
