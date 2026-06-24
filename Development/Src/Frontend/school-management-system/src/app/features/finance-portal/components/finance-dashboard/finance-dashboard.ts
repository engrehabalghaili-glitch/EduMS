import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { FinanceService, InvoiceRecord, FinancialVoucher } from '../../services/finance';

@Component({
  selector: 'app-finance-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './finance-dashboard.html',
  styleUrls: ['./finance-dashboard.scss']
})
export class FinanceDashboardComponent implements OnInit {
  financeService = inject(FinanceService);

  // كروت المؤشرات المالية الحيوية عالية الحجم (Financial KPI Cards)
  stats = signal([
    { label: 'إجمالي الإيرادات المحصلة (الدورة الحالية)', value: '4,250,000 ر.ي', desc: '💰 رسوم دراسية + حافلات مأهولة', type: 'success' },
    { label: 'المصروفات والالتزامات التشغيلية', value: '3,100,000 ر.ي', desc: '📉 رواتب كادر، عقود صيانة، تشغيل فروع', type: 'info' },
    { label: 'الذمم المدينة المتأخرة (المتبقي)', value: '650,000 ر.ي', desc: '⏳ فواتير مجدولة بانتظار التحصيل الدورية', type: 'warning' },
    { label: 'صافي التدفق النقدي المتوفر (الربح)', value: '1,150,000 ر.ي', desc: '📈 نمو مالي مستقر بنسبة 14% عن العام السابق', type: 'primary' }
  ]);

  // كشف الفواتير والرسوم الدراسية المربوطة بحسابات أولياء الأمور
  studentInvoicesList = signal<InvoiceRecord[]>([
    { id: 'INV-2026-801', studentName: 'محمد بن سلطان الدوسري', fatherName: 'سلطان الدوسري', gradeLevel: 'الأول الثانوي', totalAmount: 15000, paidAmount: 15000, remainingAmount: 0, dueDate: '2026-06-01', status: 'fully_paid' },
    { id: 'INV-2026-802', studentName: 'أحمد بن عبد الله العتيبي', fatherName: 'عبد الله العتيبي', gradeLevel: 'الثاني الثانوي', totalAmount: 15000, paidAmount: 10000, remainingAmount: 5000, dueDate: '2026-06-15', status: 'partially_paid' },
    { id: 'INV-2026-803', studentName: 'ياسر بن فهد القحطاني', fatherName: 'فهد القحطاني', gradeLevel: 'الأول الثانوي', totalAmount: 15000, paidAmount: 0, remainingAmount: 15000, dueDate: '2026-05-20', status: 'unpaid' },
    { id: 'INV-2026-804', studentName: 'خالد بن منصور الشمري', fatherName: 'منصور الشمري', gradeLevel: 'الثالث الثانوي', totalAmount: 18000, paidAmount: 18000, remainingAmount: 0, dueDate: '2026-06-10', status: 'fully_paid' }
  ]);

  // سجل القيود والسندات اليومية الفورية (قيد المراجعة)
  recentVouchersList = signal<FinancialVoucher[]>([
    { id: 'VCH-9941', type: 'receipt', title: 'تحصيل دفعة رسوم دراسية - كاش', amount: 5000, date: '11:45 ص', createdBy: 'أ. خالد (المحاسب الرئيسي)', accountCategory: 'الرسوم الدراسية' },
    { id: 'VCH-9940', type: 'payment', title: 'سداد فاتورة شركة الاتصالات والصيانة الدورية', amount: 3450, date: '10:30 ص', createdBy: 'أ. خالد (المحاسب الرئيسي)', accountCategory: 'المصروفات الإدارية' },
    { id: 'VCH-9939', type: 'receipt', title: 'تحصيل رسوم نقل مدرسي حافلة رقم 12 - سداد إلكتروني', amount: 2500, date: '09:15 ص', createdBy: 'بوابة الدفع الآلية', accountCategory: 'خدمات النقل' },
    { id: 'VCH-9938', type: 'payment', title: 'شراء أدوات مخبرية ومستهلكات قسم الفيزياء', amount: 1200, date: 'أمس', createdBy: 'أ. خالد (المحاسب الرئيسي)', accountCategory: 'المصروفات الأكاديمية' }
  ]);

  // كائنات ومخططات الميزانية
  cashFlowData: any;
  cashFlowOptions: any;
  expensePieData: any;
  expensePieOptions: any;

  ngOnInit(): void {
    this.initFinancialCharts();
  }

  initFinancialCharts() {
    // 1. مخطط المزيج للتدفق النقدي الشامل (Combo Chart): الإيرادات والمصروفات مقابل صافي الربح الخطّي
    this.cashFlowData = {
      labels: ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو', 'يونيو'],
      datasets: [
        {
          type: 'line',
          label: 'صافي الربح التراكمي المستهدف',
          borderColor: '#10b981',
          borderWidth: 3,
          pointBackgroundColor: '#10b981',
          fill: false,
          data: [900, 1000, 1090, 940, 1200, 1150]
        },
        {
          type: 'bar',
          label: 'الإيرادات والمقبوضات (بالآف ر.ي)',
          backgroundColor: '#059669',
          data: [3800, 3950, 4100, 3920, 4250, 4200],
          borderRadius: 6
        },
        {
          type: 'bar',
          label: 'المصروفات التشغيلية (بالآف ر.ي)',
          backgroundColor: '#f43f5e',
          data: [2900, 2950, 3010, 2980, 3050, 3100],
          borderRadius: 6
        }
      ]
    };

    this.cashFlowOptions = {
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

    // 2. مخطط توزيع المصروفات التشغيلية للمنشأة (Doughnut Chart)
    this.expensePieData = {
      labels: ['رواتب وأجور', 'إيجارات وصيانة وعقود', 'مستهلكات وكتب ومختبرات', 'أصول ومركبات وحافلات'],
      datasets: [
        {
          data: [65, 15, 12, 8],
          backgroundColor: ['#047857', '#10b981', '#34d399', '#a7f3d0'],
          borderWidth: 0
        }
      ]
    };

    this.expensePieOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      cutout: '70%'
    };
  }

  onFinancialAction(actionType: string, id: string) {
    console.log(`إجراء مالي معتمد: [${actionType}] على المستند المالي: [${id}]`);
  }
}
