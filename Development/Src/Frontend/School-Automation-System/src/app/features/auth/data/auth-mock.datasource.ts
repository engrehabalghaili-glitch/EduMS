import { Injectable } from '@angular/core';
import { AuthDataSource } from './auth.datasource';
import { UserInfo, UserRole } from '../../../core/layout/main-layout/main-layout.types';

@Injectable()
export class AuthMockDataSource extends AuthDataSource {
  async login(email: string, password: string): Promise<UserInfo> {
    await new Promise(resolve => setTimeout(resolve, 400));
    const normalized = email.toLowerCase().trim();
    const roleMap: Record<string, UserRole> = {
      'admin@school.com': UserRole.SCHOOL_MANAGER,
      'teacher@school.com': UserRole.TEACHER,
      'student@school.com': UserRole.STUDENT,
      'assets@school.com': UserRole.ASSET_MANAGER,
      'finance@school.com': UserRole.FINANCIAL_ACCOUNTANT,
      'hr@school.com': UserRole.HR_MANAGER,
      'affairs@school.com': UserRole.STUDENT_AFFAIRS,
      'supervisor@school.com': UserRole.OFFICE_SUPERVISOR,
    };
    const role = roleMap[normalized];
    if (!role) {
      throw new Error('بيانات الدخول غير صحيحة. تأكد من البريد الإلكتروني وكلمة المرور');
    }
    if (!password || password.length < 3) {
      throw new Error('كلمة المرور غير صحيحة');
    }
    return this.getUserInfo(role);
  }

  async loginAs(role: UserRole): Promise<UserInfo> {
    const mock = this.getUserInfo(role);
    await new Promise(resolve => setTimeout(resolve, 300));
    return mock;
  }

  async logout(): Promise<void> {
    await new Promise(resolve => setTimeout(resolve, 200));
  }

  private getUserInfo(role: UserRole): UserInfo {
    const map: Record<UserRole, UserInfo> = {
      [UserRole.SCHOOL_MANAGER]: { name: 'أ. محمد العلي', role: 'مدير المدرسة', userRole: UserRole.SCHOOL_MANAGER, initials: 'م.ع' },
      [UserRole.TEACHER]: { name: 'أ. سارة أحمد', role: 'معلم', userRole: UserRole.TEACHER, initials: 'س.أ' },
      [UserRole.STUDENT]: { name: 'عمر خالد', role: 'طالب', userRole: UserRole.STUDENT, initials: 'ع.خ' },
      [UserRole.ASSET_MANAGER]: { name: 'أ. فيصل الحربي', role: 'مدير أصول', userRole: UserRole.ASSET_MANAGER, initials: 'ف.ح' },
      [UserRole.FINANCIAL_ACCOUNTANT]: { name: 'أ. عبدالله السالم', role: 'محاسب', userRole: UserRole.FINANCIAL_ACCOUNTANT, initials: 'ع.س' },
      [UserRole.HR_MANAGER]: { name: 'أ. نورة العنزي', role: 'مدير موارد بشرية', userRole: UserRole.HR_MANAGER, initials: 'ن.ع' },
      [UserRole.STUDENT_AFFAIRS]: { name: 'أ. منى الشمري', role: 'شؤون الطلاب', userRole: UserRole.STUDENT_AFFAIRS, initials: 'م.ش' },
      [UserRole.OFFICE_SUPERVISOR]: { name: 'أ. عبدالرحمن القحطاني', role: 'مشرف', userRole: UserRole.OFFICE_SUPERVISOR, initials: 'ع.ق' },
    };
    return map[role];
  }
}
