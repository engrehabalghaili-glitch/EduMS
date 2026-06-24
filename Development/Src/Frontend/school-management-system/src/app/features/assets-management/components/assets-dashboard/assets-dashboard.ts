import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { AssetsService, AssetRecord, MaintenanceOrder } from '../../services/assets';

@Component({
  selector: 'app-assets-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './assets-dashboard.html',
  styleUrls: ['./assets-dashboard.scss']
})
export class AssetsDashboardComponent implements OnInit {
  assetsService = inject(AssetsService);

  // كروت المراقبة اللحظية للأصول والبنية التحتية
  stats = signal([
    { label: 'إجمالي الأصول المسجلة بالنظام', value: '3,420 أصل', desc: '🏢 تتركز في 4 مبانٍ رئيسية وفروعها', type: 'primary' },
    { label: 'طلبات صيانة طارئة نشطة', value: '14 طلباً', desc: '🛠️ منها 3 طلبات حرجة تحت التنفيذ الآن', type: 'danger' },
    { label: 'العهد الشخصية المستلمة', value: '1,120 عهدة', desc: '👤 عهد إلكترونية وأثاث طرف الكادر', type: 'info' },
    { label: 'نسبة سلامة وجاهزية الأصول', value: '94.2%', desc: '✅ كفاءة تشغيلية ممتازة للمنشأة', type: 'success' }
  ]);

  // جدول جرد الأصول الفعلي
  assetsInventory = signal<AssetRecord[]>([
    { id: 'AST-1022', name: 'أجهزة حاسب آلي iMac 24', category: 'أجهزة تقنية', location: 'مختبر الحاسب الرئيسي - مبنى أ', custodyOf: 'أ. عمر الشمري', purchaseDate: '2025-09-12', condition: 'excellent', conditionText: 'ممتازة' },
    { id: 'AST-1023', name: 'جهاز عرض ضوئي Projector 4K', category: 'أجهزة تقنية', location: 'قاعة الاجتماعات الكبرى - الإدارة', custodyOf: 'أ. أحمد الدوسري', purchaseDate: '2024-11-05', condition: 'needs_maintenance', conditionText: 'يحتاج صيانة عدسة' },
    { id: 'AST-2041', name: 'طاولات ومقاعد خشبية مزدوجة (دفعات)', category: 'أثاث ومكتبات', location: 'الفصول الدراسية - الصف الأول الثانوي', custodyOf: 'مستودع الأثاث المركزي', purchaseDate: '2025-01-20', condition: 'excellent', conditionText: 'ممتازة' },
    { id: 'AST-4009', name: 'جهاز ميكروسكوب إلكتروني متطور', category: 'أدوات مختبرية', location: 'مختبر الأحياء والفيزياء - مبنى ب', custodyOf: 'د. فهد القحطاني', purchaseDate: '2026-02-10', condition: 'excellent', conditionText: 'ممتازة' }
  ]);

  // جدول أوامر صيانة الأصول (Maintenance Orders)
  maintenanceOrders = signal<MaintenanceOrder[]>([
    { id: 'MNT-8801', assetId: 'AST-1023', assetName: 'جهاز عرض ضوئي Projector', issueDescription: 'وميض متقطع في الشاشة وتوقف مفاجئ للمروحة', priority: 'critical', scheduledDate: 'اليوم 02:00 م', status: 'in_progress' },
    { id: 'MNT-8802', assetId: 'AST-5021', assetName: 'مكيف سبليت 24 وحدة LG', issueDescription: 'ضعف التبريد مع صوت مرتفع في الوحدة الخارجية', priority: 'normal', scheduledDate: 'غداً 09:00 ص', status: 'pending' }
  ]);

  // كائنات المخططات البيانية
  groupedBarData: any;
  groupedBarOptions: any;
  categoryPieData: any;
  categoryPieOptions: any;

  ngOnInit(): void {
    this.initAssetsCharts();
  }

  initAssetsCharts() {
    // 1. مخطط الأعمدة للمقارنة بين الأصول النشطة وتلك التي تحت الصيانة في مباني المدرسة
    this.groupedBarData = {
      labels: ['مبنى أ (المركزي)', 'مبنى ب (الابتدائي)', 'مبنى ج (الثانوي)', 'المجمع الرياضي'],
      datasets: [
        {
          label: 'أصول جاهزة ونشطة',
          backgroundColor: '#475569', // رمادي داكن فخم
          data: [850, 620, 940, 310]
        },
        {
          label: 'أصول تحت الصيانة/معطلة',
          backgroundColor: '#f43f5e', // وردي محمر للتنبيه
          data: [15, 32, 12, 8]
        }
      ]
    };

    this.groupedBarOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      scales: {
        x: { ticks: { font: { family: 'Cairo' } } },
        y: { grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } }
      }
    };

    // 2. مخطط الدونات لتحليل توزيع فئات الأصول
    this.categoryPieData = {
      labels: ['أجهزة تقنية', 'أثاث ومكتبات', 'أدوات مختبرية', 'مركبات وحافلات'],
      datasets: [
        {
          data: [45, 30, 15, 10],
          backgroundColor: ['#334155', '#64748b', '#94a3b8', '#cbd5e1'],
          borderWidth: 0
        }
      ]
    };

    this.categoryPieOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      cutout: '70%'
    };
  }

  onAssetAction(type: string, id: string) {
    console.log(`إجراء إدارة الأصول: [${type}] للمعرف: [${id}]`);
  }
}
