import { TestBed } from '@angular/core/testing';
import { LayoutStateService } from './layout-state.service';
import { UserRole } from '../main-layout/main-layout.types';


describe('LayoutStateService', () => {
  let service: LayoutStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LayoutStateService);
  });

  it('should start with defaults', () => {
    expect(service.sidebarCollapsed()).toBe(false);
    expect(service.sidebarMobileOpen()).toBe(false);
    expect(service.themeMode()).toBe('light');
    expect(service.currentUser()).toBeNull();
    expect(service.pageTitle()).toBe('');
  });

  it('should toggle sidebar', () => {
    service.toggleSidebar();
    expect(service.sidebarCollapsed()).toBe(true);
    service.toggleSidebar();
    expect(service.sidebarCollapsed()).toBe(false);
  });

  it('should toggle mobile sidebar', () => {
    service.toggleMobileSidebar();
    expect(service.sidebarMobileOpen()).toBe(true);
  });

  it('should toggle theme', () => {
    service.toggleTheme();
    expect(service.themeMode()).toBe('dark');
    service.toggleTheme();
    expect(service.themeMode()).toBe('light');
  });

  it('should set current user', () => {
    const user = { name: 'Test', role: 'مدير', userRole: UserRole.SCHOOL_MANAGER, initials: 'ت' };
    service.setCurrentUser(user);
    expect(service.currentUser()).toEqual(user);
  });

  it('should set page title', () => {
    service.setPageTitle('لوحة التحكم');
    expect(service.pageTitle()).toBe('لوحة التحكم');
  });
});
