import { ChangeDetectionStrategy, Component, effect, inject, Renderer2 } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { TopbarComponent } from '../topbar/topbar.component';
import { FooterComponent } from '../footer/footer.component';
import { PageContainerComponent } from '../page-container/page-container.component';
import { LayoutStateService } from '../services/layout-state.service';
import { NavigationService } from '../services/navigation.service';
import { PermissionService } from '../services/permission.service';
import type { ThemeMode, NotificationItem } from './main-layout.types';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [
    SidebarComponent,
    TopbarComponent,
    FooterComponent,
    PageContainerComponent,
  ],
  template: `
    <div
      class="main-layout"
      [class.main-layout-dark]="themeMode() === 'dark'"
      [class.main-layout-collapsed]="sidebarCollapsed()">

      <app-sidebar
        [items]="navService.filteredMenuItems()"
        [collapsed]="sidebarCollapsed()"
        [mobileOpen]="sidebarMobileOpen()"
        (toggle)="layoutState.toggleSidebar()"
        (closeMobile)="layoutState.setMobileSidebarOpen(false)"
        (itemClick)="onMenuItemClick($event)" />

      <div class="main-content">
        <app-topbar
          [user]="layoutState.currentUser()"
          [notifications]="notifications"
          [collapsed]="sidebarCollapsed()"
          [isDark]="themeMode() === 'dark'"
          (toggleMenu)="layoutState.toggleSidebar()"
          (toggleTheme)="layoutState.toggleTheme()"
          (logout)="onLogout()" />

        <main class="main-content-body">
          <app-page-container />
        </main>

        <app-footer />
      </div>
    </div>
  `,
  styles: [`
    .main-layout {
      display: flex;
      min-height: 100vh;
      direction: rtl;
      background: var(--surface-ground);
    }
    .main-content {
      display: flex;
      flex-direction: column;
      flex: 1;
      min-width: 0;
      transition: margin-inline-start 0.3s ease;
    }
    .main-content-body {
      flex: 1;
      display: flex;
      flex-direction: column;
    }
    .main-layout-dark {
      color-scheme: dark;
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MainLayoutComponent {
  private readonly renderer = inject(Renderer2);
  private readonly document = inject(DOCUMENT);
  protected readonly layoutState = inject(LayoutStateService);
  protected readonly navService = inject(NavigationService);
  private readonly permissionService = inject(PermissionService);
  private readonly router = inject(Router);

  protected readonly sidebarCollapsed = this.layoutState.sidebarCollapsed;
  protected readonly sidebarMobileOpen = this.layoutState.sidebarMobileOpen;
  protected readonly themeMode = this.layoutState.themeMode;

  readonly notifications: NotificationItem[] = [
    {
      id: '1',
      title: 'تحديث جديد',
      description: 'تم إضافة طالب جديد إلى النظام',
      icon: 'pi pi-user-plus',
      time: 'منذ 5 دقائق',
      read: false,
    },
    {
      id: '2',
      title: 'تقارير شهرية',
      description: 'التقارير الشهرية جاهزة للمراجعة',
      icon: 'pi pi-file',
      time: 'منذ ساعة',
      read: false,
    },
    {
      id: '3',
      title: 'صيانة',
      description: 'موعد صيانة للجهاز رقم 1023',
      icon: 'pi pi-wrench',
      time: 'منذ 3 ساعات',
      read: true,
    },
  ];

  constructor() {
    effect(() => {
      const mode = this.themeMode();
      this.applyTheme(mode);
    });
  }

  private applyTheme(mode: ThemeMode): void {
    const html = this.document.documentElement;
    this.renderer.setAttribute(html, 'data-theme-mode', mode);
    if (mode === 'dark') {
      this.renderer.addClass(html, 'p-dark');
    } else {
      this.renderer.removeClass(html, 'p-dark');
    }
  }

  onMenuItemClick(item: any): void {
    if (item?.route) {
      this.navService.navigate(item.route);
    }
    this.layoutState.setMobileSidebarOpen(false);
  }

  onLogout(): void {
    this.permissionService.clear();
    this.layoutState.setCurrentUser(null as any);
    this.router.navigateByUrl('/auth/login');
  }
}
