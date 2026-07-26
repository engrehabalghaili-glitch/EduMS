import { ChangeDetectionStrategy, Component, computed, inject, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
// import { AuthStore, UserRole } from '../../../core/auth';
export enum UserRole {
  OFFICE_SUPERVISOR = 'OFFICE_SUPERVISOR',
  SCHOOL_PRINCIPAL = 'SCHOOL_PRINCIPAL',
  ASSETS_MANAGER = 'ASSETS_MANAGER',
  STUDENT_AFFAIRS = 'STUDENT_AFFAIRS',
  HR_MANAGER = 'HR_MANAGER',
  TEACHER = 'TEACHER',
  PARENT = 'PARENT',
  STUDENT = 'STUDENT'
}
interface SubNavItem {
  label: string;
  route: string;
}

interface NavSection {
  key: string;
  label: string;
  iconClass: string;
  roles: UserRole[];
  children: SubNavItem[];
}

const navSections: NavSection[] = [
  {
    key: 'dashboard',
    label: 'لوحة التحكم الرئيسية',
    iconClass: 'pi pi-home',
    roles: [UserRole.OFFICE_SUPERVISOR, UserRole.SCHOOL_PRINCIPAL, UserRole.ASSETS_MANAGER, UserRole.STUDENT_AFFAIRS, UserRole.HR_MANAGER, UserRole.TEACHER, UserRole.PARENT, UserRole.STUDENT],
    children: [
      { label: 'النظرة العامة', route: '/dashboard' },
    ],
  },
  {
    key: 'school-office',
    label: 'الإدارة المدرسية والمكتب',
    iconClass: 'pi pi-building',
    roles: [UserRole.OFFICE_SUPERVISOR, UserRole.SCHOOL_PRINCIPAL],
    children: [
      { label: 'المدارس', route: '/dashboard/m1/schools' },
      { label: 'الإطار الأكاديمي', route: '/dashboard/m1/academic-framework' },
      { label: 'الهيكل التنظيمي', route: '/dashboard/m1/organizational' },
      { label: 'الاعتماد', route: '/dashboard/m1/accreditation' },
      { label: 'الإشراف', route: '/dashboard/m1/supervision' },
      { label: 'المرافق', route: '/dashboard/m1/facilities' },
      { label: 'السجلات', route: '/dashboard/m1/records' },
    ],
  },
  {
    key: 'student-affairs',
    label: 'شؤون الطلاب',
    iconClass: 'pi pi-users',
    roles: [UserRole.STUDENT_AFFAIRS, UserRole.SCHOOL_PRINCIPAL],
    children: [
      { label: 'إدارة الطلاب', route: '/dashboard/m2/students' },
      { label: 'أولياء الأمور', route: '/dashboard/m2/guardians' },
      { label: 'النقل المدرسي', route: '/dashboard/m2/transport-routes' },
      { label: 'الحصص الدراسية', route: '/dashboard/m2/class-sections' },
    ],
  },
  {
    key: 'academics',
    label: 'الشؤون الأكاديمية',
    iconClass: 'pi pi-book',
    roles: [UserRole.TEACHER, UserRole.SCHOOL_PRINCIPAL, UserRole.OFFICE_SUPERVISOR],
    children: [
      { label: 'الحضور والغياب', route: '/dashboard/m3/attendance-details' },
      { label: 'الدرجات', route: '/dashboard/m3/exam-grades' },
      { label: 'السجلات السلوكية', route: '/dashboard/m3/behavioral-logs' },
    ],
  },
  {
    key: 'assets',
    label: 'إدارة الأصول والمرافق',
    iconClass: 'pi pi-box',
    roles: [UserRole.ASSETS_MANAGER, UserRole.SCHOOL_PRINCIPAL],
    children: [
      { label: 'الأصول المدرسية', route: '/dashboard/m4/school-assets' },
      { label: 'المناقصات', route: '/dashboard/m4/bids' },
      { label: 'العقود', route: '/dashboard/m4/contracts' },
    ],
  },
  {
    key: 'finance',
    label: 'الإدارة المالية',
    iconClass: 'pi pi-wallet',
    roles: [UserRole.OFFICE_SUPERVISOR, UserRole.SCHOOL_PRINCIPAL],
    children: [
      { label: 'الحسابات', route: '/dashboard/m5/accounts' },
      { label: 'البنوك', route: '/dashboard/m5/banks' },
      { label: 'المصروفات', route: '/dashboard/m5/expenses' },
      { label: 'الإيرادات', route: '/dashboard/m5/revenues' },
    ],
  },
  {
    key: 'reports',
    label: 'التقارير الإحصائية',
    iconClass: 'pi pi-chart-bar',
    roles: [UserRole.OFFICE_SUPERVISOR, UserRole.SCHOOL_PRINCIPAL],
    children: [
      { label: 'التقارير النظامية', route: '/dashboard/m6/system-reports' },
      { label: 'التقارير المقارنة', route: '/dashboard/m6/comparative-reports' },
      { label: 'تحليل الفجوات', route: '/dashboard/m6/gap-analysis' },
      { label: 'تحليل الاتجاهات', route: '/dashboard/m6/trend-analysis' },
    ],
  },
];

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Sidebar {
  // private readonly authStore = inject(AuthStore);

  readonly openSection = signal<string | null>(null);

  readonly filteredSections = computed(() => {
    // const role = this.authStore.user()?.role;
    const role = UserRole.OFFICE_SUPERVISOR;
    return navSections.filter(section => section.roles.includes(role!));
  });

  toggleSection(key: string): void {
    this.openSection.update(current => current === key ? null : key);
  }

  isOpen(key: string): boolean {
    return this.openSection() === key;
  }
}
