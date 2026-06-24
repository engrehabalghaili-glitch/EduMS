import { Component, signal, computed, inject } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoadingService } from '../../../core/services/loading';
import { ProgressSpinner } from 'primeng/progressspinner';

// استيراد المكونات والأدوات المطلوبة من PrimeNG 21
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { RippleModule } from 'primeng/ripple';

// تعريف واجهة لعناصر القائمة الجانبية
interface MenuItem {
  label: string;
  icon: string;
  route: string;
  permission?: string;
}

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    ButtonModule,
    TooltipModule,
    RippleModule,
    ProgressSpinner
  ],
  templateUrl: './main-layout.html',
  styleUrls: ['./main-layout.scss']
})
export class MainLayoutComponent {

  // حقن خدمة التحميل للوصول للـ Signal في الـ HTML
  loadingService = inject(LoadingService);
  private router = inject(Router);

  // إدارة حالة انكماش وتمدد القائمة الجانبية
  isCollapsed = signal<boolean>(false);

  // حساب عرض القائمة الجانبية ديناميكياً بناءً على الحالة الحالية
  sidebarWidth = computed(() => this.isCollapsed() ? '80px' : '260px');

  // مصفوفة عناصر القائمة الجانبية لنظام المدرسة
  menuItems = signal<MenuItem[]>([
    { label: 'لوحة المدير', icon: 'pi pi-chart-bar', route: '/main-layout/admin/dashboard' },
    { label: 'لوحة المعلم', icon: 'pi pi-user-plus', route: '/main-layout/teacher/dashboard' },
    { label: 'شؤون الطلاب', icon: 'pi pi-users', route: '/main-layout/student-affairs/dashboard' },

    { label: 'الإدارة المالية', icon: 'pi pi-money-bill', route: '/main-layout/finance/dashboard' },
    { label: 'الأصول والمرافق', icon: 'pi pi-box', route: '/main-layout/asset-management/dashboard' },
    { label: 'الموارد البشرية', icon: 'pi pi-id-card', route: '/main-layout/hr/dashboard' },
    { label: 'قائد المدرسة', icon: 'pi pi-user', route: '/main-layout/principal/dashboard' },
    { label: 'الإشراف الأكاديمي', icon: 'pi pi-book', route: '/main-layout/supervision/dashboard' },
    { label: 'الأنشطة المدرسية', icon: 'pi pi-star', route: '/main-layout/activities/dashboard' },
    { label: 'بوابة ولي الأمر', icon: 'pi pi-heart', route: '/main-layout/parent/dashboard' },
    { label: 'بوابة الطالب', icon: 'pi pi-graduation-cap', route: '/student/dashboard' },
  ]);

  // دالة لقلب حالة القائمة الجانبية عند الضغط على زر الهامبرغر
  toggleSidebar(): void {
    this.isCollapsed.update(state => !state);
  }

  // تسجيل الخروج والعودة إلى شاشة الدخول
  logout(): void {
    this.router.navigate(['/auth/login']);
  }
}
