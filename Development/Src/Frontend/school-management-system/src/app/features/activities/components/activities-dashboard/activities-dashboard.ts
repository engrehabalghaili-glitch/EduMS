import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ChartModule } from 'primeng/chart';
import { ActivitiesService, SchoolEvent } from '../../services/activities';

@Component({
  selector: 'app-activities-dashboard',
  standalone: true,
  imports: [CommonModule, ButtonModule, ChartModule],
  templateUrl: './activities-dashboard.html',
  styleUrls: ['./activities-dashboard.scss']
})
export class ActivitiesDashboardComponent implements OnInit {
  activitiesService = inject(ActivitiesService);

  // كروت الإحصاءات الأربعة من التصميم الأصلي لمشرف الأنشطة
  stats = signal([
    { label: 'الأندية الطلابية النشطة', value: '8 أندية', change: '🎨 فنون، علوم، رياضية، تطوع', type: 'primary' },
    { label: 'الطلاب المسجلين بالأنشطة', value: '420 طالب', change: '↗ 78% من إجمالي المدرسة', type: 'success' },
    { label: 'فعاليات ومسابقات قادمة', value: '5 فعاليات', change: '📅 خلال الفصل الحالي', type: 'warning' },
    { label: 'ميزانية الأنشطة المستهلكة', value: '45%', change: '✅ ضمن الحدود الآمنة الصرف', type: 'info' }
  ]);

  // جدول الفعاليات والمهرجانات الأخير من واقع ملف التصميم
  eventsList = signal<SchoolEvent[]>([
    { id: 'EVT-901', title: 'معرض الفنون التشكيلية السنوي', clubName: 'النادي الفني', eventDate: '22/06', targetAudience: 'جميع المراحل', status: 'ongoing', statusText: 'جاري التنفيذ' },
    { id: 'EVT-902', title: 'بطولة كرة القدم للمرحلة المتوسطة', clubName: 'النادي الرياضي', eventDate: '25/06', targetAudience: 'المتوسط', status: 'planned', statusText: 'مخطط له' },
    { id: 'EVT-903', title: 'مسابقة الروبوت والذكاء الاصطناعي', clubName: 'النادي العلمي', eventDate: '14/06', targetAudience: 'العام والمسارات', status: 'completed', statusText: 'مكتمل' },
    { id: 'EVT-904', title: 'الحملة التطوعية لتشجير محيط المدرسة', clubName: 'نادي العمل التطوعي', eventDate: '29/06', targetAudience: 'المتطوعين فقط', status: 'planned', statusText: 'مخطط له' },
    { id: 'EVT-905', title: 'الأمسية الشعرية والخطابة الكبرى', clubName: 'النادي الثقافي العربي', eventDate: '12/06', targetAudience: 'أولياء الأمور والطلاب', status: 'completed', statusText: 'مكتمل' }
  ]);

  // مخطط توزيع الطلاب بداخل الأندية (Doughnut Chart)
  doughnutData: any;
  doughnutOptions: any;

  ngOnInit(): void {
    this.initChart();
  }

  initChart() {
    this.doughnutData = {
      labels: ['النادي الرياضي', 'النادي العلمي', 'النادي الفني', 'النادي الثقافي', 'العمل التطوعي'],
      datasets: [
        {
          data: [150, 95, 65, 60, 50], // الأرقام الأصلية المتناسقة مع الـ 420 طالب
          backgroundColor: ['#ec4899', '#3b82f6', '#10b981', '#f59e0b', '#8b5cf6'],
          hoverBackgroundColor: ['#db2777', '#2563eb', '#059669', '#d97406', '#7c3aed']
        }
      ]
    };

    this.doughnutOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 11 }, boxWidth: 12 } }
      },
      cutout: '65%' // جعل الحافة الداخلية رشيقة ومفتوحة
    };
  }

  onEventAction(eventId: string) {
    console.log(`فتح لوحة التحكم والتنظيم التفصيلية للفعالية رقم: ${eventId}`);
  }
}
