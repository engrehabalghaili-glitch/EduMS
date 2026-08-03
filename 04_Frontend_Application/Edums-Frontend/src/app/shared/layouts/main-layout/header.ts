import { ChangeDetectionStrategy, Component, inject, signal, computed, OnInit } from '@angular/core';
import { Router, RouterLink, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs';
// import { AuthStore } from '../../../core/auth';

interface Breadcrumb {
  label: string;
  route: string;
}

const routeLabels: Record<string, string> = {
  'dashboard': 'لوحة التحكم',
  'm1': 'المكتب المدرسي',
  'schools': 'المدارس',
  'academic-framework': 'الإطار الأكاديمي',
  'organizational': 'الهيكل التنظيمي',
  'accreditation': 'الاعتماد',
  'supervision': 'الإشراف',
  'facilities': 'المرافق',
  'records': 'السجلات',
  'm2': 'شؤون الطلاب',
  'm3': 'الشؤون الأكاديمية',
  'm4': 'إدارة الأصول',
  'm5': 'الإدارة المالية',
  'm6': 'التقارير الإحصائية',
  'm7': 'الطوارئ',
  'm8': 'المستخدمون',
  'auth': 'تسجيل الدخول',
  'unauthorized': 'غير مصرح',
};

@Component({
  selector: 'app-header',
  imports: [RouterLink],
  templateUrl: './header.html',
  styleUrl: './header.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Header implements OnInit {
  // protected readonly authStore = inject(AuthStore);
  private readonly router = inject(Router);

  readonly searchQuery = signal('');
  readonly breadcrumbs = signal<Breadcrumb[]>([]);
  readonly showSearch = signal(false);

  readonly userInitial = computed(() => {
    const name = 'Admin';
    return name ? name.charAt(0) : 'م';
  });

  readonly userName = computed(() => 'مستخدم');

  readonly userRole = computed(() => {
    const role = 'OFFICE_SUPERVISOR';
    const roleMap: Record<string, string> = {
      'OFFICE_SUPERVISOR': 'مشرف المكتب',
      'SCHOOL_PRINCIPAL': 'مدير المدرسة',
      'ASSETS_MANAGER': 'مدير الأصول',
      'STUDENT_AFFAIRS': 'شؤون الطلاب',
      'HR_MANAGER': 'الموارد البشرية',
      'TEACHER': 'معلم',
      'PARENT': 'ولي أمر',
      'STUDENT': 'طالب',
    };
    return roleMap[role ?? ''] ?? role ?? '—';
  });

  ngOnInit(): void {
    this.buildBreadcrumbs(this.router.url);
    this.router.events.pipe(
      filter((event): event is NavigationEnd => event instanceof NavigationEnd)
    ).subscribe(event => {
      this.buildBreadcrumbs(event.urlAfterRedirects || event.url);
    });
  }

  toggleSearch(): void {
    this.showSearch.update(v => !v);
    if (!this.showSearch()) {
      this.searchQuery.set('');
    }
  }

  onSearchInput(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.searchQuery.set(value);
  }

  logout(): void {
    // this.authStore.logout();
    this.router.navigate(['/auth/login']);
  }

  private buildBreadcrumbs(url: string): void {
    const segments = url.split('/').filter(Boolean);
    const crumbs: Breadcrumb[] = [];
    let path = '';

    for (const segment of segments) {
      path += `/${segment}`;
      const label = routeLabels[segment];
      if (label) {
        crumbs.push({ label, route: path });
      }
    }

    this.breadcrumbs.set(crumbs);
  }
}
