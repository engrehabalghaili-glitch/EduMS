import { Injectable, inject, computed } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { NavigationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs';
import { MENU_ITEMS } from './menu.config';
import { PermissionService } from './permission.service';
import type { MenuItem, BreadcrumbItem } from '../main-layout/main-layout.types';

@Injectable({ providedIn: 'root' })
export class NavigationService {
  private readonly permissionService = inject(PermissionService);
  private readonly router = inject(Router);

  readonly currentRoute = toSignal(
    this.router.events.pipe(
      filter(e => e instanceof NavigationEnd),
      map(e => (e as NavigationEnd).urlAfterRedirects),
    ),
    { initialValue: '/' },
  );

  readonly filteredMenuItems = computed<MenuItem[]>(() => {
    const role = this.permissionService.currentRole();
    return this.filterByRole(MENU_ITEMS, role);
  });

  readonly breadcrumbItems = computed<BreadcrumbItem[]>(() => {
    const route = this.currentRoute();
    return this.buildBreadcrumb(route);
  });

  readonly activeMenuItemId = computed<string | null>(() => {
    const route = this.currentRoute();
    for (const item of this.filteredMenuItems()) {
      const found = this.findItemByRoute(item, route);
      if (found) return found.id;
    }
    return null;
  });

  navigate(route: string): void {
    this.router.navigateByUrl(route);
  }

  private filterByRole(items: MenuItem[], role: string | null): MenuItem[] {
    return items
      .filter(item => {
        if (item.roles.length === 0) return true;
        if (!role) return false;
        return item.roles.includes(role as any);
      })
      .map(item => ({
        ...item,
        children: item.children ? this.filterByRole(item.children, role) : undefined,
      }));
  }

  private findItemByRoute(item: MenuItem, route: string): MenuItem | null {
    if (item.route === route) return item;
    if (item.children) {
      for (const child of item.children) {
        const found = this.findItemByRoute(child, route);
        if (found) return found;
      }
    }
    return null;
  }

  private buildBreadcrumb(url: string): BreadcrumbItem[] {
    const parts = url.split('/').filter(Boolean);
    const crumbs: BreadcrumbItem[] = [{ label: 'الرئيسية', route: '/' }];
    let currentPath = '';
    for (const part of parts) {
      currentPath += `/${part}`;
      const label = this.findLabelForRoute(currentPath) ?? this.decodeSegment(part);
      crumbs.push({ label, route: currentPath });
    }
    return crumbs;
  }

  private findLabelForRoute(route: string): string | null {
    for (const item of MENU_ITEMS) {
      const found = this.findLabelRecursive(item, route);
      if (found) return found;
    }
    return null;
  }

  private findLabelRecursive(item: MenuItem, route: string): string | null {
    if (item.route === route) return item.label;
    if (item.children) {
      for (const child of item.children) {
        const found = this.findLabelRecursive(child, route);
        if (found) return found;
      }
    }
    return null;
  }

  private decodeSegment(segment: string): string {
    return decodeURIComponent(segment).replace(/-/g, ' ');
  }
}
