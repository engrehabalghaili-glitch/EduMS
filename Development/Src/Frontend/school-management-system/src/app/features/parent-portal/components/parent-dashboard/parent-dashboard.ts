import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { ParentService, ChildSummary, ParentAlert } from '../../services/parent';

@Component({
  selector: 'app-parent-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './parent-dashboard.html',
  styleUrls: ['./parent-dashboard.scss']
})
export class ParentDashboardComponent implements OnInit {
  parentService = inject(ParentService);

  // كروت المؤشرات السريعة لحالة العائلة المدرسية
  stats = signal([
    { label: 'عدد الأبناء المسجلين', value: '2 طلاب', change: '🏫 مدرسة التربية الأهلية', type: 'primary' },
    { label: 'متوسط مواظبة الأبناء', value: '98.2%', change: '✅ انضباط ممتاز هذا الأسبوع', type: 'success' },
    { label: 'المستحقات المالية القادمة', value: '1,500 ر.ي', change: '⏳ تاريخ الاستحقاق: 01/07', type: 'warning' },
    { label: 'الرسائل والتعاميم الجديدة', value: '3 رسائل', change: '🔔 تتطلب الاطلاع', type: 'info' }
  ]);

  // مصفوفة الأبناء مع بياناتهم الحركية المختصرة
  childrenList = signal<ChildSummary[]>([
    { id: 'STD-1012', name: 'عبد الرحمن خالد الشمري', grade: 'الصف الأول المتوسط', avatar: '👦', attendanceRate: 99, latestGrade: '94.5%', behaviorScore: 'ممتاز' },
    { id: 'STD-2045', name: 'سارة خالد الشمري', grade: 'الصف الرابع الابتدائي', avatar: '👧', attendanceRate: 97, latestGrade: '96.8%', behaviorScore: 'ممتاز' }
  ]);

  // جدول التنبيهات والإجراءات المطلوبة من ولي الأمر
  alertsList = signal<ParentAlert[]>([
    { id: 'ALT-441', childName: 'عبد الرحمن', type: 'academic', title: 'إصدار تقرير منتصف الفصل الدراسي الثاني', date: '16/06', resolved: false },
    { id: 'ALT-440', childName: 'سارة', type: 'attendance', title: 'تأخر عن الطابور الصباحي (الـ 7:20 ص)', date: '14/06', resolved: true },
    { id: 'ALT-439', childName: 'العائلة', type: 'invoice', title: 'إصدار فاتورة باص النقل المدرسي للفصل القادم', date: '10/06', resolved: false }
  ]);

  // مخطط الرادار الشامل لتقييم أبعاد الطالب (Radar Chart)
  radarData: any;
  radarOptions: any;

  ngOnInit(): void {
    this.initChart();
  }

  initChart() {
    this.radarData = {
      labels: ['التحصيل الأكاديمي', 'السلوك والمواظبة', 'المشاركة والأنشطة', 'حل الواجبات', 'الاختبارات القصيرة'],
      datasets: [
        {
          label: 'عبد الرحمن',
          borderColor: '#0ea5e9', // اللون السماوي الأساسي لولي الأمر
          backgroundColor: 'rgba(14, 165, 233, 0.2)',
          pointBackgroundColor: '#0ea5e9',
          pointBorderColor: '#fff',
          pointHoverBackgroundColor: '#fff',
          pointHoverBorderColor: '#0ea5e9',
          data: [92, 98, 85, 95, 90] // الأرقام من تصاميمك
        },
        {
          label: 'سارة',
          borderColor: '#ec4899', // وردي مخصص للابنة لتفريق الأداء بصرياً
          backgroundColor: 'rgba(236, 72, 153, 0.2)',
          pointBackgroundColor: '#ec4899',
          pointBorderColor: '#fff',
          pointHoverBackgroundColor: '#fff',
          pointHoverBorderColor: '#ec4899',
          data: [96, 95, 92, 98, 94]
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
          angleLines: { color: '#e2e8f0' },
          pointLabels: { font: { family: 'Cairo', size: 12, weight: '700' }, color: '#334155' },
          ticks: { display: false } // إخفاء الأرقام الداخلية للمحافظة على نظافة التصميم
        }
      }
    };
  }

  onActionClick(actionType: string, childId: string) {
    console.log(`فتح نافذة الإجراء [${actionType}] للطالب صاحب الرقم: ${childId}`);
  }
}
