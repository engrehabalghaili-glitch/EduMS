import { ChangeDetectionStrategy, Component, inject, input, output, signal, HostListener } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { BadgeModule } from 'primeng/badge';
import { TooltipModule } from 'primeng/tooltip';
import type { MenuItem } from '../main-layout/main-layout.types';
import { LayoutStateService } from '../services/layout-state.service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    RouterLink, RouterLinkActive,
    ButtonModule, BadgeModule, TooltipModule,
  ],
  template: `
    <aside
      class="sidebar"
      [class.sidebar-collapsed]="collapsed()"
      [class.sidebar-mobile-open]="mobileOpen()"
      [class.sidebar-overlay]="isMobileView()">

      @if (collapsed() && !isMobileView()) {
        <div class="sidebar-logo-collapsed" pTooltip="إظهار القائمة" (click)="toggle.emit()">
          <span class="sidebar-logo-text">M</span>
        </div>
      } @else {
        <div class="sidebar-logo">
          <i class="pi pi-graduation-cap sidebar-logo-icon"></i>
          @if (!collapsed() || isMobileView()) {
            <span class="sidebar-logo-text">نظام المدارس</span>
          }
        </div>
      }

      <nav class="sidebar-nav">
        <ul class="sidebar-menu">
          @for (item of items(); track item.id) {
            <li class="sidebar-menu-item">
              @if (item.children && item.children.length > 0) {
                <div
                  class="sidebar-item sidebar-parent"
                  [class.sidebar-item-active]="isParentActive(item)"
                  [class.sidebar-item-expanded]="isExpanded(item.id)"
                  (click)="toggleExpand(item.id)">
                  <i [class]="item.icon" class="sidebar-item-icon"></i>
                  @if (!collapsed() || isMobileView()) {
                    <span class="sidebar-item-label">{{ item.label }}</span>
                  }
                  @if (!collapsed() || isMobileView()) {
                    <i class="pi pi-chevron-down sidebar-item-arrow"
                       [class.rotated]="isExpanded(item.id)"></i>
                  }
                  @if (item.badge) {
                    <p-badge [value]="item.badge" severity="danger" />
                  }
                </div>

                @if (isExpanded(item.id) && (!collapsed() || isMobileView())) {
                  <ul class="sidebar-submenu">
                    @for (child of item.children; track child.id) {
                      <li class="sidebar-submenu-item">
                        <a
                          [routerLink]="child.route"
                          routerLinkActive="sidebar-subitem-active"
                          class="sidebar-item sidebar-child"
                          (click)="itemClick.emit(child)">
                          <i [class]="child.icon" class="sidebar-item-icon sidebar-child-icon"></i>
                          <span class="sidebar-item-label">{{ child.label }}</span>
                          @if (child.badge) {
                            <p-badge [value]="child.badge" severity="danger" />
                          }
                        </a>
                      </li>
                    }
                  </ul>
                }
              } @else {
                <a
                  [routerLink]="item.route"
                  routerLinkActive="sidebar-item-active"
                  [routerLinkActiveOptions]="{ exact: true }"
                  class="sidebar-item"
                  (click)="itemClick.emit(item)"
                  [pTooltip]="collapsed() && !isMobileView() ? item.label : ''"
                  tooltipPosition="right">
                  <i [class]="item.icon" class="sidebar-item-icon"></i>
                  @if (!collapsed() || isMobileView()) {
                    <span class="sidebar-item-label">{{ item.label }}</span>
                  }
                  @if (item.badge) {
                    <p-badge [value]="item.badge" severity="danger" />
                  }
                </a>
              }
            </li>
          }
        </ul>
      </nav>

      @if (!collapsed() || isMobileView()) {
      <div class="sidebar-footer">
        <p-button
          [icon]="collapsed() ? 'pi pi-chevron-left' : 'pi pi-chevron-right'"
          (onClick)="toggle.emit()"
          [rounded]="true"
          [text]="true"
          severity="secondary"
          styleClass="sidebar-collapse-btn">
        </p-button>
      </div>
      }
    </aside>

    @if (mobileOpen() && isMobileView()) {
      <div class="sidebar-backdrop" (click)="closeMobile.emit()"></div>
    }
  `,
  styles: [`
    .sidebar {
      direction: rtl;
      display: flex;
      flex-direction: column;
      width: var(--sidebar-width, 260px);
      min-width: var(--sidebar-width, 260px);
      height: 100vh;
      background: var(--surface-card);
      border-left: 1px solid var(--surface-border);
      position: sticky;
      top: 0;
      z-index: 900;
      transition: width 0.3s ease, min-width 0.3s ease;
      overflow: hidden;
    }
    .sidebar-collapsed {
      width: var(--sidebar-collapsed-width, 64px);
      min-width: var(--sidebar-collapsed-width, 64px);
    }
    .sidebar-overlay {
      position: fixed;
      top: 0;
      inset-inline-start: 0;
      z-index: 1100;
      box-shadow: 0 0 20px rgba(0,0,0,0.15);
    }
    .sidebar-backdrop {
      position: fixed;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background: rgba(0,0,0,0.4);
      z-index: 1050;
    }

    .sidebar-logo,
    .sidebar-logo-collapsed {
      display: flex;
      align-items: center;
      gap: 0.5rem;
      padding: 1rem;
      border-bottom: 1px solid var(--surface-border);
      min-height: 64px;
      justify-content: center;
    }
    .sidebar-logo-icon {
      font-size: 1.75rem;
      color: var(--primary-color);
    }
    .sidebar-logo-text {
      font-size: 1.125rem;
      font-weight: 700;
      color: var(--primary-color);
      white-space: nowrap;
    }

    .sidebar-nav {
      flex: 1;
      overflow-y: auto;
      overflow-x: hidden;
      padding: 0.5rem 0;
    }
    .sidebar-nav::-webkit-scrollbar {
      width: 4px;
    }
    .sidebar-nav::-webkit-scrollbar-thumb {
      background: var(--surface-border);
      border-radius: 2px;
    }

    .sidebar-menu {
      list-style: none;
      margin: 0;
      padding: 0;
    }

    .sidebar-item {
      display: flex;
      align-items: center;
      gap: 0.75rem;
      padding: 0.75rem 1rem;
      cursor: pointer;
      color: var(--text-color);
      text-decoration: none;
      transition: all 0.2s;
      border-radius: 0;
      margin: 0 0.5rem;
      border-radius: var(--border-radius);
      font-size: var(--font-size-sm, 0.875rem);
      position: relative;
    }
    .sidebar-item:hover {
      background: var(--surface-hover);
    }
    .sidebar-item-active {
      background: var(--primary-50);
      color: var(--primary-color);
      font-weight: 600;
    }
    .sidebar-item-active i {
      color: var(--primary-color);
    }
    .sidebar-item-expanded > .sidebar-item {
      background: var(--surface-ground);
      font-weight: 600;
    }

    .sidebar-item-icon {
      font-size: 1.125rem;
      min-width: 1.25rem;
      text-align: center;
      color: var(--text-color-secondary);
      transition: color 0.2s;
    }
    .sidebar-item-active .sidebar-item-icon {
      color: var(--primary-color-text, #ffffff);
    }

    .sidebar-item-label {
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      flex: 1;
    }

    .sidebar-item-arrow {
      font-size: 0.75rem;
      transition: transform 0.3s;
      color: var(--text-color-secondary);
    }
    .sidebar-item-arrow.rotated {
      transform: rotate(180deg);
    }

    .sidebar-parent {
      justify-content: flex-start;
    }

    .sidebar-submenu {
      list-style: none;
      margin: 0;
      padding: 0;
    }
    .sidebar-submenu-item {
      margin: 0;
    }
    .sidebar-subitem-active {
      background: var(--primary-50);
      color: var(--primary-color);
      font-weight: 600;
    }
    .sidebar-subitem-active i {
      color: var(--primary-color);
    }
    .sidebar-child-icon {
      font-size: 0.75rem;
      min-width: 1rem;
    }

    .sidebar-footer {
      padding: 0.5rem;
      border-top: 1px solid var(--surface-border);
      display: flex;
      justify-content: center;
    }
    .sidebar-collapse-btn {
      width: 2.5rem;
      height: 2.5rem;
    }

    .sidebar-collapsed .sidebar-item {
      justify-content: center;
      padding: 0.75rem 0.5rem;
    }
    .sidebar-collapsed .sidebar-item-icon {
      font-size: 1.25rem;
      min-width: auto;
    }
    .sidebar-collapsed .sidebar-submenu {
      display: none;
    }

    @media (max-width: 768px) {
      .sidebar {
        position: fixed;
        top: 0;
        inset-inline-start: -100%;
        width: var(--sidebar-width, 260px);
        z-index: 1100;
        transition: inset-inline-start 0.3s ease;
      }
      .sidebar-mobile-open {
        inset-inline-start: 0;
      }
      .sidebar-collapsed {
        width: var(--sidebar-width, 260px);
        min-width: var(--sidebar-width, 260px);
      }
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidebarComponent {
  readonly items = input.required<MenuItem[]>();
  readonly collapsed = input(false);
  readonly mobileOpen = input(false);

  readonly toggle = output<void>();
  readonly closeMobile = output<void>();
  readonly itemClick = output<MenuItem>();

  private readonly router = inject(Router);
  private readonly expandedIds = new Set<string>();
  protected readonly layoutState = inject(LayoutStateService);
  protected readonly isMobileView = signal(typeof window !== 'undefined' && window.innerWidth <= 768);

  @HostListener('window:resize')
  onResize(): void {
    this.isMobileView.set(window.innerWidth <= 768);
  }

  isExpanded(id: string): boolean {
    return this.expandedIds.has(id);
  }

  toggleExpand(id: string): void {
    if (this.expandedIds.has(id)) {
      this.expandedIds.delete(id);
    } else {
      this.expandedIds.add(id);
    }
  }

  isParentActive(item: MenuItem): boolean {
    const url = this.router.url;
    return item.children?.some(c => c.route && url.startsWith(c.route)) ?? false;
  }


}
