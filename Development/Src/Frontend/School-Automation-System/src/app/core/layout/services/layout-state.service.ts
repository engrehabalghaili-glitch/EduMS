import { Injectable, signal } from '@angular/core';
import type { ThemeMode, UserInfo } from '../main-layout/main-layout.types';

export interface LayoutState {
  sidebarCollapsed: boolean;
  sidebarMobileOpen: boolean;
  themeMode: ThemeMode;
  currentUser: UserInfo | null;
}

const initialState: LayoutState = {
  sidebarCollapsed: false,
  sidebarMobileOpen: false,
  themeMode: 'light',
  currentUser: null,
};

@Injectable({ providedIn: 'root' })
export class LayoutStateService {
  private readonly _state = signal<LayoutState>(initialState);
  readonly state = this._state.asReadonly();

  readonly sidebarCollapsed = signal(false);
  readonly sidebarMobileOpen = signal(false);
  readonly themeMode = signal<ThemeMode>('light');
  readonly currentUser = signal<UserInfo | null>(null);
  readonly pageTitle = signal<string>('');

  toggleSidebar(): void {
    this.sidebarCollapsed.update(v => !v);
  }

  setSidebarCollapsed(value: boolean): void {
    this.sidebarCollapsed.set(value);
  }

  toggleMobileSidebar(): void {
    this.sidebarMobileOpen.update(v => !v);
  }

  setMobileSidebarOpen(value: boolean): void {
    this.sidebarMobileOpen.set(value);
  }

  toggleTheme(): void {
    this.themeMode.update(mode => (mode === 'light' ? 'dark' : 'light'));
  }

  setThemeMode(mode: ThemeMode): void {
    this.themeMode.set(mode);
  }

  setCurrentUser(user: UserInfo): void {
    this.currentUser.set(user);
  }

  setPageTitle(title: string): void {
    this.pageTitle.set(title);
  }
}
