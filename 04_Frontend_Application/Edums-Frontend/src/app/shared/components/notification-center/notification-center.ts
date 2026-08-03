import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { PopoverModule } from 'primeng/popover';
import { BadgeModule } from 'primeng/badge';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { Skeleton } from 'primeng/skeleton';
import { NgClass } from '@angular/common';
import { AppNotification } from './notification-center.types';

export { type AppNotification } from './notification-center.types';

@Component({
  selector: 'app-notification-center',
  imports: [PopoverModule, BadgeModule, ScrollPanelModule, ButtonModule, TooltipModule, Skeleton, NgClass],
  templateUrl: './notification-center.html',
  styleUrl: './notification-center.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NotificationCenter {
  readonly notifications = input<AppNotification[]>([]);
  readonly unreadCount = input(0);
  readonly maxHeight = input('350px');
  readonly loading = input(false);

  readonly onNotificationClick = output<AppNotification>();
  readonly onMarkAllRead = output<void>();
  readonly onViewAll = output<void>();

  notificationClick(notif: AppNotification): void {
    this.onNotificationClick.emit(notif);
  }

  markAllRead(): void {
    this.onMarkAllRead.emit();
  }

  viewAll(): void {
    this.onViewAll.emit();
  }

  typeIcon(type?: string): string {
    switch (type) {
      case 'success': return 'pi pi-check-circle';
      case 'warning': return 'pi pi-exclamation-triangle';
      case 'danger': return 'pi pi-times-circle';
      default: return 'pi pi-info-circle';
    }
  }

  typeColor(type?: string): string {
    switch (type) {
      case 'success': return '#16a34a';
      case 'warning': return '#ca8a04';
      case 'danger': return '#dc2626';
      default: return '#006699';
    }
  }

  timeAgo(time: Date | string): string {
    const now = Date.now();
    const t = typeof time === 'string' ? new Date(time).getTime() : time.getTime();
    const diff = now - t;
    const mins = Math.floor(diff / 60000);
    if (mins < 1) return 'الآن';
    if (mins < 60) return `منذ ${mins} د`;
    const hours = Math.floor(mins / 60);
    if (hours < 24) return `منذ ${hours} س`;
    const days = Math.floor(hours / 24);
    if (days < 7) return `منذ ${days} ي`;
    return new Date(time).toLocaleDateString('ar-SA');
  }
}
