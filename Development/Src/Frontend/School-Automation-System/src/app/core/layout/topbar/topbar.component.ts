import { ChangeDetectionStrategy, Component, input, output, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { BadgeModule } from 'primeng/badge';
import { AvatarModule } from 'primeng/avatar';
import { PopoverModule } from 'primeng/popover';
import { TooltipModule } from 'primeng/tooltip';
import { LayoutStateService } from '../services/layout-state.service';
import type { UserInfo, NotificationItem } from '../main-layout/main-layout.types';

@Component({
  selector: 'app-topbar',
  standalone: true,
  imports: [
    ButtonModule, InputTextModule, BadgeModule, AvatarModule,
    PopoverModule, TooltipModule,
  ],
  template: `
    <header class="topbar">
      <div class="topbar-start">
        <p-button
          [icon]="collapsed() ? 'pi pi-chevron-left' : 'pi pi-chevron-right'"
          (onClick)="toggleMenu.emit()"
          [rounded]="true"
          [text]="true"
          severity="secondary"
          styleClass="topbar-toggle-btn">
        </p-button>
        <span class="topbar-system-name">{{ systemName() }}</span>
      </div>

      <div class="topbar-center">
        <span class="p-input-icon-left topbar-search">
          <!-- <i class="pi pi-search"></i> -->
          <input
            pInputText
            type="text"
            [placeholder]="'بحث...'"
            class="topbar-search-input"/>
        </span>
      </div>

      <div class="topbar-end">
        <p-button
          icon="pi pi-moon"
          (onClick)="toggleTheme.emit()"
          [rounded]="true"
          [text]="true"
          severity="secondary"
          styleClass="topbar-icon-btn"
          pTooltip="تغيير الثيم">
        </p-button>

        <div class="notification-trigger" (click)="notifPopover.toggle($event)">
          <p-button
            icon="pi pi-bell"
            [rounded]="true"
            [text]="true"
            severity="secondary"
            styleClass="topbar-icon-btn">
          </p-button>
          @if (unreadCount() > 0) {
            <span class="notification-badge">{{ unreadCount() }}</span>
          }
        </div>

        <p-popover #notifPopover>
          <div class="notification-panel">
            <h4 class="notification-title">الإشعارات</h4>
            <div class="notification-list">
              @for (notif of notifications(); track notif.id) {
                <div class="notification-item" [class.unread]="!notif.read">
                  <i [class]="notif.icon"></i>
                  <div class="notification-content">
                    <span class="notification-text">{{ notif.title }}</span>
                    <span class="notification-time">{{ notif.time }}</span>
                  </div>
                </div>
              }
            </div>
            <div class="notification-footer">
              <a class="notification-view-all">عرض الكل</a>
            </div>
          </div>
        </p-popover>

        <div class="topbar-user" (click)="userPopover.toggle($event)">
          <p-avatar
            [label]="user()?.initials || ''"
            [image]="user()?.avatar"
            shape="circle"
            size="normal"
            styleClass="topbar-avatar">
          </p-avatar>
          <div class="topbar-user-info">
            <span class="topbar-user-name">{{ user()?.name || 'مستخدم' }}</span>
            <span class="topbar-user-role">{{ user()?.role || '' }}</span>
          </div>
        </div>

        <p-popover #userPopover>
          <div class="user-menu-panel">
            <a class="user-menu-item">
              <i class="pi pi-user"></i>
              <span>الملف الشخصي</span>
            </a>
            <a class="user-menu-item">
              <i class="pi pi-cog"></i>
              <span>الإعدادات</span>
            </a>
            <a class="user-menu-item">
              <i class="pi pi-question-circle"></i>
              <span>مساعدة</span>
            </a>
            <hr class="user-menu-divider" />
            <a class="user-menu-item user-menu-logout" (click)="logout.emit()">
              <i class="pi pi-sign-out"></i>
              <span>تسجيل الخروج</span>
            </a>
          </div>
        </p-popover>
      </div>
    </header>
  `,
  styles: [`
    .topbar {
      direction: rtl;
      display: flex;
      align-items: center;
      justify-content: space-between;
      height: var(--topbar-height, 64px);
      padding: 0 1rem;
      background: var(--surface-card);
      border-bottom: 1px solid var(--surface-border);
      position: sticky;
      top: 0;
      z-index: 1000;
      gap: 1rem;
    }
    .topbar-start {
      display: flex;
      align-items: center;
      gap: 0.75rem;
    }
    .topbar-toggle-btn {
      width: 2.5rem;
      height: 2.5rem;
    }
    .topbar-system-name {
      font-size: 1.125rem;
      font-weight: 700;
      color: var(--primary-color);
      white-space: nowrap;
    }
    .topbar-center {
      flex: 1;
      max-width: 400px;
      margin: 0 1rem;
    }
    .topbar-search {
      width: 100%;
    }
    .topbar-search-input {
      width: 100%;
      padding-inline-start: 2.5rem;
    }
    .topbar-end {
      display: flex;
      align-items: center;
      gap: 0.5rem;
    }
    .topbar-icon-btn {
      position: relative;
    }
    .notification-trigger {
      position: relative;
      display: flex;
    }
    .notification-badge {
      position: absolute;
      top: 0;
      inset-inline-end: 0;
      background: var(--p-primary-color, #3b82f6);
      color: white;
      font-size: 0.625rem;
      width: 18px;
      height: 18px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-weight: 700;
      pointer-events: none;
    }
    .topbar-user {
      display: flex;
      align-items: center;
      gap: 0.5rem;
      cursor: pointer;
      padding: 0.25rem 0.5rem;
      border-radius: var(--border-radius);
      transition: background 0.2s;

    }
    .topbar-user:hover {
      background: var(--surface-hover);
    }
    .topbar-user-info {
      display: flex;
      flex-direction: column;
      // background-color: #3b82f6;
      line-height: 1.3;
    }
    .topbar-user-name {
      font-size: var(--font-size-sm, 0.875rem);
      font-weight: 600;
      color: var(--text-color);
    }
    .topbar-user-role {
      font-size: 0.75rem;
      color: var(--text-color-secondary);
    }
    .topbar-avatar {
      background: var(--primary-color);
      color: white;
    }
    .notification-panel {
      min-width: 280px;
      padding: 0.5rem 0;
    }
    .notification-title {
      margin: 0 0 0.5rem;
      padding: 0 1rem;
      font-size: 1rem;
      color: var(--text-color);
    }
    .notification-list {
      max-height: 300px;
      overflow-y: auto;
    }
    .notification-item {
      display: flex;
      gap: 0.75rem;
      padding: 0.75rem 1rem;
      cursor: pointer;
      transition: background 0.2s;
    }
    .notification-item:hover {
      background: var(--surface-hover);
    }
    .notification-item.unread {
      background: var(--surface-ground);
    }
    .notification-item i {
      margin-top: 0.125rem;
      color: var(--primary-color);
    }
    .notification-content {
      display: flex;
      flex-direction: column;
    }
    .notification-text {
      font-size: var(--font-size-sm, 0.875rem);
      color: var(--text-color);
    }
    .notification-time {
      font-size: 0.75rem;
      color: var(--text-color-secondary);
    }
    .notification-footer {
      padding: 0.5rem 1rem;
      border-top: 1px solid var(--surface-border);
      text-align: center;
    }
    .notification-view-all {
      color: var(--primary-color);
      cursor: pointer;
      font-size: var(--font-size-sm, 0.875rem);
    }
    .user-menu-panel {
      min-width: 200px;
      padding: 0.25rem 0;
    }
    .user-menu-item {
      display: flex;
      align-items: center;
      gap: 0.75rem;
      padding: 0.625rem 1rem;
      color: var(--text-color);
      cursor: pointer;
      transition: background 0.2s;
      font-size: var(--font-size-sm, 0.875rem);
    }
    .user-menu-item:hover {
      background: var(--surface-hover);
    }
    .user-menu-item i {
      width: 1.25rem;
      color: var(--text-color-secondary);
    }
    .user-menu-divider {
      border: none;
      border-top: 1px solid var(--surface-border);
      margin: 0.25rem 0;
    }
    .user-menu-logout {
      color: var(--p-danger-color, #ef4444) !important;
    }
    .user-menu-logout i {
      color: var(--p-danger-color, #ef4444) !important;
    }
    @media (max-width: 768px) {
      .topbar-center { display: none; }
      .topbar-user-info { display: none; }
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TopbarComponent {
  readonly systemName = input('نظام إدارة المدارس');
  readonly user = input<UserInfo | null>(null);
  readonly notifications = input<NotificationItem[]>([]);
  readonly collapsed = input(false);
  readonly isDark = input(false);

  readonly toggleMenu = output<void>();
  readonly toggleTheme = output<void>();
  readonly logout = output<void>();

  readonly unreadCount = () => this.notifications().filter(n => !n.read).length;
  public readonly layoutState = inject(LayoutStateService);
}
