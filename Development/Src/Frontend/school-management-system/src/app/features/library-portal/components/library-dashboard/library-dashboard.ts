import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { LibraryService, BookRecord, BorrowingLog } from '../../services/library';

@Component({
  selector: 'app-library-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './library-dashboard.html',
  styleUrls: ['./library-dashboard.scss']
})
export class LibraryDashboardComponent implements OnInit {
  libraryService = inject(LibraryService);

  // كروت المؤشرات الحيوية لعمليات المكتبة (Library KPI Cards)
  stats = signal([
    { label: 'إجمالي العناوين والمراجع المؤرشفة', value: '12,450 كتاباً', desc: '📚 ورقي وإلكتروني في شتى العلوم', type: 'primary' },
    { label: 'عمليات الإعارة النشطة حالياً', value: '342 إعارة', desc: '📖 منها 188 إعارة لطلاب المرحلة الثانوية', type: 'info' },
    { label: 'كتب متأخرة عن موعد الإرجاع', value: '24 كتاباً', desc: '⚠️ تم إرسال تنبيهات آلية لأولياء الأمور', type: 'danger' },
    { label: 'معدل الارتياد اليومي للمكتبة', value: '185 زائراً', desc: '✅ قفزة بنسبة 22% بفضل حصص القراءة الحرة', type: 'success' }
  ]);

  // قائمة جرد وتوفر المراجع والكتب على الرفوف
  booksInventoryList = signal<BookRecord[]>([
    { id: 'BK-9901', title: 'البداية والنهاية - الجزء الأول', author: 'ابن كثير', isbn: '978-3-16-148410-0', category: 'التاريخ الإسلامي', totalCopies: 5, availableCopies: 2, shelfLocation: 'رف A-04' },
    { id: 'BK-9902', title: 'مقدمة ابن خلدون التاريخية', author: 'ابن خلدون', isbn: '978-0-19-851961-4', category: 'علم الاجتماع', totalCopies: 3, availableCopies: 3, shelfLocation: 'رف B-12' },
    { id: 'BK-9903', title: 'الفيزياء المسلية والمفهومة', author: 'ياكوف بيريلمان', isbn: '978-1-40-289462-6', category: 'العلوم الطبيعية', totalCopies: 8, availableCopies: 0, shelfLocation: 'رف C-01' },
    { id: 'BK-9904', title: 'عبقريات العقاد الكاملة', author: 'عباس محمود العقاد', isbn: '978-9-77-021234-5', category: 'الأدب العربي', totalCopies: 4, availableCopies: 1, shelfLocation: 'رف A-09' }
  ]);

  // سجل عمليات الإعارة الفورية للمتابعة والتدقيق
  recentBorrowingsList = signal<BorrowingLog[]>([
    { id: 'LOG-7701', bookTitle: 'الفيزياء المسلية والمفهومة', borrowerName: 'سلطان بن عبد العزيز الدوسري', borrowerRole: 'student', borrowDate: '2026-06-01', dueDate: '2026-06-15', status: 'overdue' },
    { id: 'LOG-7702', bookTitle: 'مقدمة ابن خلدون التاريخية', borrowerName: 'أ. فهد بن سلطان السبيعي', borrowerRole: 'teacher', borrowDate: '2026-06-10', dueDate: '2026-06-24', status: 'active' },
    { id: 'LOG-7703', bookTitle: 'عبقريات العقاد الكاملة', borrowerName: 'خالد بن منصور الشمري', borrowerRole: 'student', borrowDate: '2026-06-14', dueDate: '2026-06-28', status: 'active' },
    { id: 'LOG-7704', bookTitle: 'البداية والنهاية - الجزء الأول', borrowerName: 'أحمد بن عبد الله العتيبي', borrowerRole: 'student', borrowDate: '2026-05-20', dueDate: '2026-06-03', status: 'returned' }
  ]);

  // كائنات ومخططات غرف المعرفة
  borrowingChartData: any;
  borrowingChartOptions: any;
  resourceDoughnutData: any;
  resourceDoughnutOptions: any;

  ngOnInit(): void {
    this.initLibraryCharts();
  }

  initLibraryCharts() {
    // 1. مخطط الأعمدة المتداخلة (Stacked Bar Chart) لمقارنة حركة الإعارة مقابل الاسترجاع أسبوعياً
    this.borrowingChartData = {
      labels: ['الأسبوع 1', 'الأسبوع 2', 'الأسبوع 3', 'الأسبوع 4', 'الأسبوع 5', 'الأسبوع 6'],
      datasets: [
        {
          type: 'bar',
          label: 'الكتب المستعارة',
          backgroundColor: '#b45309', // اللون الأمبر النحاسي الدافئ للمكتبات
          data: [120, 145, 160, 110, 175, 190],
          borderRadius: 4
        },
        {
          type: 'bar',
          label: 'الكتب المُرجعة بأمان',
          backgroundColor: '#d97706',
          data: [100, 130, 140, 105, 150, 165],
          borderRadius: 4
        }
      ]
    };

    this.borrowingChartOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 12 } } }
      },
      scales: {
        x: { stacked: true, grid: { display: false }, ticks: { font: { family: 'Cairo' } } },
        y: { stacked: true, grid: { color: '#f1f5f9' }, ticks: { font: { family: 'Cairo' } } }
      }
    };

    // 2. مخطط الدونات لتحليل توزيع الأوعية ومصادر المعرفة داخل المكتبة
    this.resourceDoughnutData = {
      labels: ['كتب ورقية', 'مراجع رقمية PDF', 'أبحاث ومجلات علمية', 'وسائط ووسائل تعليمية'],
      datasets: [
        {
          data: [55, 25, 12, 8],
          backgroundColor: ['#78350f', '#b45309', '#d97706', '#f59e0b'],
          borderWidth: 0
        }
      ]
    };

    this.resourceDoughnutOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 11 } } }
      },
      cutout: '72%'
    };
  }

  onLibraryAction(actionType: string, id: string) {
    console.log(`إجراء مكتبي معتمد: [${actionType}] على المستند أو السجل: [${id}]`);
  }
}
