import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { AuthService, User } from '../../core/auth/auth.service';
import { HasPermissionDirective } from '../../shared/directives/has-permission.directive';

interface MenuItem {
  id: string;
  type?: 'section' | 'item';
  label: string;
  icon?: string;
  route?: string;
  roles?: string[];
  badge?: number;
}

@Component({
  selector: 'app-master-shell',
  standalone: true,
  imports: [CommonModule, RouterModule, HasPermissionDirective],
  templateUrl: './master-shell.component.html',
  styleUrls: ['./master-shell.component.scss']
})
export class MasterShellComponent implements OnInit {
  sidebarCollapsed = signal(false);
  currentUser = signal<User | null>(null);
  menuItems = signal<MenuItem[]>([]);

  // Master menu - تحدد ما يراه كل دور
  private allMenuItems: MenuItem[] = [
    { id: 'dashboard', label: 'لوحة التحكم', icon: 'ph-house', route: '/dashboard', roles: ['*'] },

    // School Admin
    { id: 'school-section', type: 'section', label: 'الإدارة المدرسية', roles: ['principal', 'office_sup', 'sysadmin'] },
    { id: 'school-info', label: 'بيانات المدرسة', icon: 'ph-buildings', route: '/school/info', roles: ['principal', 'office_sup'] },
    { id: 'school-plans', label: 'الخطط السنوية', icon: 'ph-calendar-check', route: '/school/plans', roles: ['principal', 'office_sup'] },
    { id: 'school-circs', label: 'التعاميم', icon: 'ph-megaphone', route: '/school/circulars', roles: ['principal', 'office_sup', 'registrar'], badge: 12 },

    // Students
    { id: 'students-section', type: 'section', label: 'إدارة الطلاب', roles: ['principal', 'teacher', 'registrar'] },
    { id: 'students-list', label: 'قائمة الطلاب', icon: 'ph-graduation-cap', route: '/students/list', roles: ['principal', 'teacher', 'registrar'] },
    { id: 'students-enroll', label: 'تسجيل جديد', icon: 'ph-plus-circle', route: '/students/enroll', roles: ['principal', 'registrar'] },
    { id: 'students-attendance', label: 'الحضور والغياب', icon: 'ph-check-square', route: '/students/attendance', roles: ['principal', 'teacher'] },
    { id: 'students-grades', label: 'الدرجات', icon: 'ph-chart-bar', route: '/students/grades', roles: ['principal', 'teacher'] },

    // Employees
    { id: 'employees-section', type: 'section', label: 'الموارد البشرية', roles: ['principal', 'hr_mgr'] },
    { id: 'employees-list', label: 'قائمة الموظفين', icon: 'ph-users', route: '/employees/list', roles: ['principal', 'hr_mgr'] },
    { id: 'employees-leaves', label: 'الإجازات', icon: 'ph-airplane', route: '/employees/leaves', roles: ['principal', 'hr_mgr', 'teacher'], badge: 7 },
    { id: 'employees-payroll', label: 'الرواتب', icon: 'ph-currency-circle-dollar', route: '/employees/payroll', roles: ['principal', 'hr_mgr', 'accountant'] },

    // Assets
    { id: 'assets-section', type: 'section', label: 'الأصول والمرافق', roles: ['principal', 'assets_mgr'] },
    { id: 'assets-list', label: 'سجل الأصول', icon: 'ph-cube', route: '/assets/list', roles: ['principal', 'assets_mgr'] },
    { id: 'assets-maint', label: 'الصيانة', icon: 'ph-wrench', route: '/assets/maintenance', roles: ['principal', 'assets_mgr'], badge: 14 },

    // Finance
    { id: 'finance-section', type: 'section', label: 'الإدارة المالية', roles: ['principal', 'accountant', 'guardian'] },
    { id: 'finance-invoices', label: 'الفواتير', icon: 'ph-receipt', route: '/finance/invoices', roles: ['principal', 'accountant', 'guardian'] },

    // Auth
    { id: 'auth-section', type: 'section', label: 'الأمن والصلاحيات', roles: ['sysadmin'] },
    { id: 'auth-users', label: 'المستخدمون', icon: 'ph-user-circle', route: '/auth/users', roles: ['sysadmin'] },
    { id: 'auth-roles', label: 'الأدوار والصلاحيات', icon: 'ph-shield-check', route: '/auth/roles', roles: ['sysadmin'] },

    // Settings (everyone)
    { id: 'profile', label: 'ملفي الشخصي', icon: 'ph-user', route: '/profile', roles: ['*'] },
    { id: 'settings', label: 'الإعدادات', icon: 'ph-gear', route: '/settings', roles: ['*'] }
  ];

  constructor(public auth: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.auth.currentUser$.subscribe((user) => {
      this.currentUser.set(user);
      this.filterMenuItems();
    });
  }

  /** Filter menu items based on current user's roles */
  filterMenuItems(): void {
    const user = this.currentUser();
    if (!user) {
      this.menuItems.set([]);
      return;
    }
    const filtered = this.allMenuItems.filter((item) => {
      if (!item.roles) return true;
      if (item.roles.includes('*')) return true;
      return item.roles.some((r) => user.roles.includes(r));
    });
    this.menuItems.set(filtered);
  }

  toggleSidebar(): void {
    this.sidebarCollapsed.set(!this.sidebarCollapsed());
  }

  logout(): void {
    if (confirm('تأكيد تسجيل الخروج؟')) {
      this.auth.logout();
    }
  }
}
