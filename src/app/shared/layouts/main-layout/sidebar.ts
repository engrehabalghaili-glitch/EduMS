import { ChangeDetectionStrategy, Component, computed, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthStore, UserRole } from '../../../core/auth';

interface NavItem {
  label: string;
  route: string;
  svg: string;
  roles: UserRole[];
}

const navItems: NavItem[] = [
  {
    label: 'لوحة التحكم',
    route: '/dashboard',
    svg: '<path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/><polyline points="9 22 9 12 15 12 15 22"/>',
    roles: [UserRole.OFFICE_SUPERVISOR, UserRole.SCHOOL_PRINCIPAL, UserRole.ASSETS_MANAGER, UserRole.STUDENT_AFFAIRS, UserRole.HR_MANAGER, UserRole.TEACHER, UserRole.PARENT, UserRole.STUDENT]
  },
  {
    label: 'إحصائيات المدارس',
    route: '/dashboard/school-stats',
    svg: '<path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z"/><path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z"/>',
    roles: [UserRole.OFFICE_SUPERVISOR]
  },
  {
    label: 'إدارة المدرسة',
    route: '/dashboard/school',
    svg: '<path d="M12 2L2 7l10 5 10-5-10-5z"/><path d="M2 17l10 5 10-5"/><path d="M2 12l10 5 10-5"/>',
    roles: [UserRole.SCHOOL_PRINCIPAL]
  },
  {
    label: 'إدارة الأصول',
    route: '/dashboard/assets',
    svg: '<rect x="3" y="3" width="7" height="7"/><rect x="14" y="3" width="7" height="7"/><rect x="14" y="14" width="7" height="7"/><rect x="3" y="14" width="7" height="7"/>',
    roles: [UserRole.ASSETS_MANAGER]
  },
  {
    label: 'شؤون الطلاب',
    route: '/dashboard/students',
    svg: '<path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M23 21v-2a4 4 0 0 0-3-3.87"/><path d="M16 3.13a4 4 0 0 1 0 7.75"/>',
    roles: [UserRole.STUDENT_AFFAIRS]
  },
  {
    label: 'الموارد البشرية',
    route: '/dashboard/hr',
    svg: '<path d="M16 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="8.5" cy="7" r="4"/><polyline points="17 11 19 13 23 9"/>',
    roles: [UserRole.HR_MANAGER]
  },
  {
    label: 'الجدول الدراسي',
    route: '/dashboard/schedule',
    svg: '<rect x="3" y="4" width="18" height="18" rx="2" ry="2"/><line x1="16" y1="2" x2="16" y2="6"/><line x1="8" y1="2" x2="8" y2="6"/><line x1="3" y1="10" x2="21" y2="10"/>',
    roles: [UserRole.TEACHER]
  },
  {
    label: 'متابعة الطالب',
    route: '/dashboard/my-student',
    svg: '<path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/>',
    roles: [UserRole.PARENT]
  },
  {
    label: 'جدولي الدراسي',
    route: '/dashboard/my-schedule',
    svg: '<path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><polyline points="14 2 14 8 20 8"/><line x1="16" y1="13" x2="8" y2="13"/><line x1="16" y1="17" x2="8" y2="17"/><polyline points="10 9 9 9 8 9"/>',
    roles: [UserRole.STUDENT]
  }
];

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Sidebar {
  private readonly authStore = inject(AuthStore);

  readonly filteredNav = computed(() => {
    const role = this.authStore.user()?.role;
    return navItems.filter(item => item.roles.includes(role!));
  });
}
