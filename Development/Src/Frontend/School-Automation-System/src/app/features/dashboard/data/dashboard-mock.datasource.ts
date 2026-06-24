import { Injectable } from '@angular/core';
import { UserRole } from '../../../core/layout/main-layout/main-layout.types';
import type { DashboardData } from '../models/dashboard.model';
import { DashboardDataSource } from './dashboard.datasource';


const dashboardDataMap: Partial<Record<UserRole, DashboardData>> & { default: DashboardData } = {
  [UserRole.SCHOOL_MANAGER]: {
    title: 'لوحة تحكم مدير المدرسة',
    statsCards: [
      { value: '1,250', label: 'الطلاب المسجلون', icon: 'pi pi-users', color: 'primary' },
      { value: '85', label: 'المعلمون', icon: 'pi pi-briefcase', color: 'info' },
      { value: '32', label: 'الفصول الدراسية', icon: 'pi pi-building', color: 'warn' },
      { value: '₿450K', label: 'الميزانية', icon: 'pi pi-coin', color: 'success' },
    ],
  },
  [UserRole.TEACHER]: {
    title: 'لوحة تحكم المعلم',
    statsCards: [
      { value: '150', label: 'الطلاب', icon: 'pi pi-users', color: 'primary' },
      { value: '6', label: 'الحصص اليوم', icon: 'pi pi-calendar', color: 'info' },
      { value: '3', label: 'الواجبات', icon: 'pi pi-pen-to-square', color: 'warn' },
    ],
  },
  [UserRole.STUDENT]: {
    title: 'لوحة تحكم الطالب',
    statsCards: [
      { value: '12', label: 'المواد المسجلة', icon: 'pi pi-book', color: 'primary' },
      { value: '92%', label: 'معدل الحضور', icon: 'pi pi-check-circle', color: 'success' },
      { value: '85%', label: 'المعدل التراكمي', icon: 'pi pi-star', color: 'info' },
    ],
  },
  [UserRole.ASSET_MANAGER]: {
    title: 'لوحة تحكم إدارة الأصول',
    statsCards: [
      { value: '2,450', label: 'الأصول المسجلة', icon: 'pi pi-box', color: 'primary' },
      { value: '28', label: 'قيد الصيانة', icon: 'pi pi-wrench', color: 'warn' },
      { value: '₿1.2M', label: 'قيمة الأصول', icon: 'pi pi-coin', color: 'success' },
    ],
  },
  default: {
    title: 'لوحة التحكم',
    statsCards: [
      { value: '0', label: 'مرحباً بك', icon: 'pi pi-check', color: 'primary' },
    ],
  },
};

@Injectable()
export class DashboardMockDataSource extends DashboardDataSource {
  async getDashboardData(role: UserRole | null): Promise<DashboardData> {
    const key = role ?? 'default';
    return dashboardDataMap[key as UserRole] ?? dashboardDataMap.default;
  }
}
