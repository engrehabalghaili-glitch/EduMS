import { ChangeDetectionStrategy, Component, OnInit, computed, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AppCard } from '../../../../shared/components/card/card.component';
import { PermissionService } from '../../../../core/layout/services/permission.service';
import { LayoutStateService } from '../../../../core/layout/services/layout-state.service';
import { StatsCardComponent } from '../../../../shared/components/stats-card/stats-card.component';
import { DashboardStore } from '../../store/dashboard.store';
import { UserRole } from '../../../../core/layout/main-layout/main-layout.types';

interface QuickLink {
  label: string;
  route: string;
  icon: string;
  description: string;
  color: string;
}

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterLink, DatePipe, AppCard, StatsCardComponent],
  template: `
    <div class="dashboard-page">
      <div class="dashboard-header">
        <div class="header-text">
          <h1 class="greeting">مرحباً بك، {{ user()?.name || 'المستخدم' }}</h1>
          <p class="dashboard-title">{{ store.data().title }}</p>
        </div>
        <div class="header-date">
          <i class="pi pi-calendar"></i>
          <span>{{ today | date:'EEEE d MMMM yyyy' }}</span>
        </div>
      </div>

      <div class="dashboard-stats">
        @for (card of store.data().statsCards; track card.label) {
          <app-stats-card [config]="card" />
        }
      </div>

      <div class="dashboard-section">
        <h2 class="section-title">الوصول السريع</h2>
        <div class="quick-links">
          @for (link of quickLinks; track link.route) {
            <a [routerLink]="link.route" class="quick-link-card" [style.--card-color]="link.color">
              <div class="ql-icon">
                <i [class]="link.icon"></i>
              </div>
              <div class="ql-content">
                <span class="ql-label">{{ link.label }}</span>
                <span class="ql-desc">{{ link.description }}</span>
              </div>
              <i class="pi pi-chevron-left ql-arrow"></i>
            </a>
          }
        </div>
      </div>

      <div class="dashboard-section">
        <app-card header="معلومات سريعة" styleClass="info-card">
          <div class="info-grid">
            <div class="info-item">
              <i class="pi pi-user"></i>
              <div>
                <span class="info-label">الدور الحالي</span>
                <span class="info-value">{{ user()?.role || '—' }}</span>
              </div>
            </div>
            <div class="info-item">
              <i class="pi pi-box"></i>
              <div>
                <span class="info-label">الميزات المتاحة</span>
                <span class="info-value">{{ quickLinks.length }}</span>
              </div>
            </div>
            <div class="info-item">
              <i class="pi pi-clock"></i>
              <div>
                <span class="info-label">آخر دخول</span>
                <span class="info-value">{{ today | date:'hh:mm a' }}</span>
              </div>
            </div>
          </div>
        </app-card>
      </div>
    </div>
  `,
  styles: [`
    .dashboard-page { direction: rtl; }
    .dashboard-header {
      display: flex; justify-content: space-between; align-items: flex-start;
      margin-bottom: 1.5rem; flex-wrap: wrap; gap: 0.75rem;
    }
    .greeting {
      margin: 0; font-size: 1.5rem; font-weight: 700; color: var(--text-color);
    }
    .dashboard-title {
      margin: 0.25rem 0 0; font-size: 0.95rem; color: var(--text-color-secondary);
    }
    .header-date {
      display: flex; align-items: center; gap: 0.5rem;
      padding: 0.5rem 1rem; background: var(--surface-card);
      border-radius: 8px; font-size: 0.875rem; color: var(--text-color-secondary);
      border: 1px solid var(--surface-border);
    }
    .header-date i { font-size: 1rem; }
    .dashboard-stats {
      display: grid; grid-template-columns: repeat(auto-fill, minmax(240px, 1fr));
      gap: 1rem; margin-bottom: 1.5rem;
    }
    .dashboard-section { margin-bottom: 1.5rem; }
    .section-title { margin: 0 0 1rem; font-size: 1.1rem; font-weight: 600; color: var(--text-color); }
    .quick-links { display: grid; grid-template-columns: repeat(auto-fill, minmax(280px, 1fr)); gap: 0.75rem; }
    .quick-link-card {
      display: flex; align-items: center; gap: 0.75rem;
      padding: 1rem; background: var(--surface-card);
      border-radius: 10px; border: 1px solid var(--surface-border);
      text-decoration: none; transition: all 0.2s; cursor: pointer;
    }
    .quick-link-card:hover {
      border-color: var(--card-color, var(--primary-color));
      box-shadow: 0 2px 8px rgba(0,0,0,0.06);
      transform: translateY(-1px);
    }
    .ql-icon {
      width: 44px; height: 44px; border-radius: 10px;
      display: flex; align-items: center; justify-content: center;
      background: color-mix(in srgb, var(--card-color, var(--primary-color)) 12%, transparent);
      flex-shrink: 0;
    }
    .ql-icon i { font-size: 1.25rem; color: var(--card-color, var(--primary-color)); }
    .ql-content { flex: 1; display: flex; flex-direction: column; gap: 0.125rem; }
    .ql-label { font-weight: 600; font-size: 0.9rem; color: var(--text-color); }
    .ql-desc { font-size: 0.75rem; color: var(--text-color-secondary); }
    .ql-arrow { font-size: 0.8rem; color: var(--text-color-secondary); }
    .info-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(200px, 1fr)); gap: 1rem; }
    .info-item { display: flex; align-items: center; gap: 0.75rem; }
    .info-item i { font-size: 1.25rem; color: var(--primary-color); width: 2.5rem; text-align: center; }
    .info-label { display: block; font-size: 0.75rem; color: var(--text-color-secondary); }
    .info-value { display: block; font-size: 0.9rem; font-weight: 600; color: var(--text-color); }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardComponent implements OnInit {
  readonly store = inject(DashboardStore);
  readonly layoutState = inject(LayoutStateService);
  private readonly permissionService = inject(PermissionService);

  readonly today = new Date();
  readonly user = computed(() => this.layoutState.currentUser());

  quickLinks: QuickLink[] = [];

  ngOnInit(): void {
    this.store.loadDashboardData(this.permissionService.currentRole());
    this.quickLinks = this.getQuickLinks();
  }

  private getQuickLinks(): QuickLink[] {
    const role = this.permissionService.currentRole();
    const allLinks: QuickLink[] = [
      { label: 'الأصول', route: '/assets', icon: 'pi pi-box', description: 'إدارة الأصول والمخزون', color: 'var(--blue-500)' },
      { label: 'الطلاب', route: '/students', icon: 'pi pi-users', description: 'بيانات الطلاب', color: 'var(--green-500)' },
      { label: 'المعلمون', route: '/teachers', icon: 'pi pi-briefcase', description: 'بيانات المعلمين', color: 'var(--purple-500)' },
      { label: 'الفصول', route: '/classes', icon: 'pi pi-building', description: 'إدارة الفصول الدراسية', color: 'var(--orange-500)' },
      { label: 'المقررات', route: '/courses', icon: 'pi pi-book', description: 'المقررات الدراسية', color: 'var(--cyan-500)' },
      { label: 'المالية', route: '/finance', icon: 'pi pi-coin', description: 'الحسابات والميزانية', color: 'var(--green-600)' },
      { label: 'الموارد البشرية', route: '/hr', icon: 'pi pi-id-card', description: 'شؤون الموظفين', color: 'var(--pink-500)' },
      { label: 'التقارير', route: '/reports', icon: 'pi pi-chart-bar', description: 'التقارير والإحصائيات', color: 'var(--indigo-500)' },
      { label: 'الإعدادات', route: '/settings', icon: 'pi pi-cog', description: 'إعدادات النظام', color: 'var(--gray-500)' },
    ];

    const roleLinks: Partial<Record<UserRole, string[]>> = {
      [UserRole.SCHOOL_MANAGER]: ['assets', 'students', 'teachers', 'classes', 'courses', 'finance', 'hr', 'reports', 'settings'],
      [UserRole.TEACHER]: ['courses', 'students', 'classes', 'reports'],
      [UserRole.STUDENT]: ['courses'],
      [UserRole.ASSET_MANAGER]: ['assets', 'reports'],
      [UserRole.FINANCIAL_ACCOUNTANT]: ['finance', 'reports'],
      [UserRole.HR_MANAGER]: ['hr', 'reports'],
      [UserRole.STUDENT_AFFAIRS]: ['students', 'classes'],
      [UserRole.OFFICE_SUPERVISOR]: ['students', 'teachers', 'classes', 'reports'],
    };

    const allowedRoutes = (role ? roleLinks[role] : undefined) ?? ['assets', 'students', 'teachers', 'classes', 'courses', 'finance', 'hr', 'reports', 'settings'];
    const routeSet = new Set(allowedRoutes);

    return allLinks.filter(l => routeSet.has(l.route.replace('/', '')));
  }
}
