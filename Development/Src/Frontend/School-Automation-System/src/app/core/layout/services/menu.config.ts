import type { MenuItem, UserRole } from '../main-layout/main-layout.types';

const ANY: UserRole[] = [];
const SM = 'school-manager' as UserRole;
const T = 'teacher' as UserRole;
const S = 'student' as UserRole;
const AM = 'asset-manager' as UserRole;
const FA = 'financial-accountant' as UserRole;
const HR = 'hr-manager' as UserRole;
const SA = 'student-affairs' as UserRole;
const OS = 'office-supervisor' as UserRole;

export const MENU_ITEMS: MenuItem[] = [
  {
    id: 'dashboard',
    label: 'لوحة التحكم',
    icon: 'pi pi-home',
    route: '/dashboard',
    roles: ANY,
  },
  {
    id: 'students',
    label: 'الطلاب',
    icon: 'pi pi-users',
    roles: [SM, T, SA, OS],
    children: [
      { id: 'students-list', label: 'قائمة الطلاب', icon: 'pi pi-list', route: '/students/list', roles: [SM, T, SA, OS] },
      { id: 'students-add', label: 'تسجيل طالب', icon: 'pi pi-user-plus', route: '/students/add', roles: [SM, SA] },
      { id: 'students-attendance', label: 'الحضور والغياب', icon: 'pi pi-calendar', route: '/students/attendance', roles: [SM, T, SA] },
      { id: 'students-grades', label: 'الدرجات', icon: 'pi pi-star', route: '/students/grades', roles: [SM, T, S] },
    ],
  },
  {
    id: 'teachers',
    label: 'المعلمون',
    icon: 'pi pi-briefcase',
    roles: [SM, HR],
    children: [
      { id: 'teachers-list', label: 'قائمة المعلمين', icon: 'pi pi-list', route: '/teachers/list', roles: [SM, HR] },
      { id: 'teachers-add', label: 'إضافة معلم', icon: 'pi pi-user-plus', route: '/teachers/add', roles: [SM, HR] },
      { id: 'teachers-schedule', label: 'الجدول الدراسي', icon: 'pi pi-calendar-clock', route: '/teachers/schedule', roles: [SM, T] },
    ],
  },
  {
    id: 'classes',
    label: 'الصفوف الدراسية',
    icon: 'pi pi-building',
    roles: [SM, T, SA],
    children: [
      { id: 'classes-list', label: 'قائمة الصفوف', icon: 'pi pi-list', route: '/classes/list', roles: [SM, T, SA] },
      { id: 'classes-schedule', label: 'الجداول', icon: 'pi pi-calendar', route: '/classes/schedule', roles: [SM, T] },
    ],
  },
  {
    id: 'courses',
    label: 'المواد الدراسية',
    icon: 'pi pi-book',
    roles: [SM, T, S, SA],
    children: [
      { id: 'courses-list', label: 'قائمة المواد', icon: 'pi pi-list', route: '/courses/list', roles: [SM, T, S, SA] },
      { id: 'courses-assignments', label: 'الواجبات', icon: 'pi pi-pen-to-square', route: '/courses/assignments', roles: [T, S] },
    ],
  },
  {
    id: 'finance',
    label: 'المالية',
    icon: 'pi pi-dollar',
    roles: [SM, FA],
    children: [
      { id: 'finance-fees', label: 'الرسوم الدراسية', icon: 'pi pi-credit-card', route: '/finance/fees', roles: [SM, FA] },
      { id: 'finance-expenses', label: 'المصروفات', icon: 'pi pi-money-bill', route: '/finance/expenses', roles: [SM, FA] },
      { id: 'finance-reports', label: 'التقارير المالية', icon: 'pi pi-chart-bar', route: '/finance/reports', roles: [SM, FA] },
    ],
  },
  {
    id: 'hr',
    label: 'الموارد البشرية',
    icon: 'pi pi-id-card',
    roles: [SM, HR],
    children: [
      { id: 'hr-employees', label: 'الموظفون', icon: 'pi pi-users', route: '/hr/employees', roles: [SM, HR] },
      { id: 'hr-salaries', label: 'الرواتب', icon: 'pi pi-wallet', route: '/hr/salaries', roles: [SM, HR] },
      { id: 'hr-attendance', label: 'الحضور', icon: 'pi pi-clock', route: '/hr/attendance', roles: [SM, HR] },
    ],
  },
  {
    id: 'assets',
    label: 'إدارة الأصول',
    icon: 'pi pi-box',
    roles: [SM, AM],
    children: [
      { id: 'assets-dashboard', label: 'لوحة الأصول', icon: 'pi pi-chart-pie', route: '/assets-management/dashboard', roles: [SM, AM] },
      { id: 'assets-registration', label: 'تسجيل الأصول', icon: 'pi pi-plus-circle', route: '/assets-management/registration', roles: [SM, AM] },
      { id: 'assets-procurement', label: 'المشتريات', icon: 'pi pi-shopping-cart', route: '/assets-management/procurement', roles: [SM, AM] },
      { id: 'assets-maintenance', label: 'الصيانة', icon: 'pi pi-wrench', route: '/assets-management/maintenance', roles: [SM, AM] },
    ],
  },
  {
    id: 'reports',
    label: 'التقارير',
    icon: 'pi pi-chart-bar',
    roles: [SM, AM, FA, HR, SA, OS],
    children: [
      { id: 'reports-academic', label: 'تقارير أكاديمية', icon: 'pi pi-chart-line', route: '/reports/academic', roles: [SM, SA] },
      { id: 'reports-financial', label: 'تقارير مالية', icon: 'pi pi-chart-bar', route: '/reports/financial', roles: [SM, FA] },
      { id: 'reports-assets', label: 'تقارير الأصول', icon: 'pi pi-chart-pie', route: '/reports/assets', roles: [SM, AM] },
    ],
  },
  {
    id: 'settings',
    label: 'الإعدادات',
    icon: 'pi pi-cog',
    roles: [SM, HR],
    children: [
      { id: 'settings-general', label: 'إعدادات عامة', icon: 'pi pi-sliders-h', route: '/settings/general', roles: [SM] },
      { id: 'settings-users', label: 'إدارة المستخدمين', icon: 'pi pi-user-gear', route: '/settings/users', roles: [SM, HR] },
      { id: 'settings-roles', label: 'الصلاحيات', icon: 'pi pi-shield', route: '/settings/roles', roles: [SM] },
    ],
  },
];
