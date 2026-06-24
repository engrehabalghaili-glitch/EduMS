import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { AssetsService, InventoryItem } from '../../services/assets';

@Component({
  selector: 'app-assets-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './assets-dashboard.html',
  styleUrls: ['./assets-dashboard.scss']
})
export class AssetsDashboardComponent implements OnInit {
  assetsService = inject(AssetsService);

  // كروت الإحصاءات الأربعة لإدارة الأصول والمرافق
  stats = signal([
    { label: 'إجمالي الأصول المسجلة', value: '1,420 أصل', change: '📦 جرد إلكتروني نشط', type: 'primary' },
    { label: 'طلبات صيانة مفتوحة', value: '14 طلب', change: '⚠️ 3 طلبات عاجلة', type: 'warning' },
    { label: 'أصول تم إهلاكها', value: '38 قطعة', change: '✅ معتمدة من اللجنة', type: 'danger' },
    { label: 'دقة المطابقة الجردية', value: '99.2%', change: '↗ تحديث فوري', type: 'success' }
  ]);

  // جدول العهد والمواد الفعلي من ملف الكود الأصلي الخاص بك
  assetsList = signal<InventoryItem[]>([
    { id: 'AST-2026-091', name: 'شاشة تفاعلية ذكية 75 بوصة', category: 'أجهزة حاسوب', quantity: 12, location: 'مختبرات الحاسب', status: 'good', statusText: 'سليم' },
    { id: 'AST-2026-092', name: 'مكاتب خشبية إدارية فاخرة', category: 'أثاث', quantity: 45, location: 'المبنى الإداري', status: 'good', statusText: 'سليم' },
    { id: 'AST-2026-093', name: 'مجهر ضوئي أحادي العين', category: 'مختبرات', quantity: 8, location: 'مختبر العلوم', status: 'in_maintenance', statusText: 'تحت الصيانة' },
    { id: 'AST-2026-094', name: 'أجهزة حاسوب مكتبية Core i7', category: 'أجهزة حاسوب', quantity: 25, location: 'المعمل الرئيسي', status: 'good', statusText: 'سليم' },
    { id: 'AST-2026-095', name: 'مقاعد طلابية مبطنة عازلة', category: 'أثاث', quantity: 120, location: 'الفصول الدراسية', status: 'damaged', statusText: 'تالف جزئي' }
  ]);

  // بيانات مخطط توزيع العهد القطبي (Polar Area Chart) المعتمد في الملف الأصلي
  polarData: any;
  polarOptions: any;

  ngOnInit(): void {
    this.initChart();
  }

  initChart() {
    this.polarData = {
      labels: ['أجهزة حاسوب', 'أثاث', 'مختبرات', 'كتب', 'مركبات', 'أخرى'],
      datasets: [{
        data: [85, 120, 47, 35, 8, 47], // الأرقام الأصلية الدقيقة من ملفك
        backgroundColor: [
          '#3b82f6', // أزرق
          '#f59e0b', // ذهبي
          '#10b981', // أخضر
          '#8b5cf6', // بنفسجي
          '#ef4444', // أحمر
          '#06b6d4'  // سيان
        ]
      }]
    };

    this.polarOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: {
          position: 'bottom',
          labels: { font: { family: 'Cairo', size: 12 }, boxWidth: 10 }
        }
      },
      scales: {
        r: {
          grid: { color: '#f1f5f9' },
          ticks: { backdropColor: 'transparent', font: { family: 'Cairo', size: 10 } }
        }
      }
    };
  }

  onActionClick(assetId: string) {
    console.log(`فتح سجل الجرد والتتبع التفصيلي للأصل رقم: ${assetId}`);
  }
}
