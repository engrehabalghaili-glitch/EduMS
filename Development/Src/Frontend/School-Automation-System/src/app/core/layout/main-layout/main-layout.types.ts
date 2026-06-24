export enum UserRole {
  SCHOOL_MANAGER = 'school-manager',
  TEACHER = 'teacher',
  STUDENT = 'student',
  ASSET_MANAGER = 'asset-manager',
  FINANCIAL_ACCOUNTANT = 'financial-accountant',
  HR_MANAGER = 'hr-manager',
  STUDENT_AFFAIRS = 'student-affairs',
  OFFICE_SUPERVISOR = 'office-supervisor',
}

export interface MenuItem {
  id: string;
  label: string;
  icon: string;
  route?: string;
  roles: UserRole[];
  permissions?: string[];
  children?: MenuItem[];
  badge?: number;
  disabled?: boolean;
  data?: Record<string, unknown>;
}

export type ThemeMode = 'light' | 'dark';

export interface BreadcrumbItem {
  label: string;
  route?: string;
}

export interface PageHeaderConfig {
  title: string;
  description?: string;
  breadcrumb?: BreadcrumbItem[];
  actions?: PageAction[];
}

export interface PageAction {
  label: string;
  icon: string;
  severity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  outlined?: boolean;
  disabled?: boolean;
  command: () => void;
}

export interface NotificationItem {
  id: string;
  title: string;
  description: string;
  icon: string;
  time: string;
  read: boolean;
}

export interface UserInfo {
  name: string;
  role: string;
  userRole: UserRole;
  avatar?: string;
  initials: string;
}

export const SIDEBAR_WIDTH = 260;
export const SIDEBAR_COLLAPSED_WIDTH = 64;
