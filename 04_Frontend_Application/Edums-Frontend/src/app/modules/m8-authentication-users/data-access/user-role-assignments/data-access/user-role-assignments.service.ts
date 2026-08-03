import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  UserRoleAssignment, 
  CreateUserRoleAssignment, 
  UpdateUserRoleAssignment 
} from '@modules/m8-authentication-users/interfaces/user-role-assignment.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (UserRoleAssignments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class UserRoleAssignmentsService extends BaseApiService<
  UserRoleAssignment, 
  CreateUserRoleAssignment, 
  UpdateUserRoleAssignment
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/UserRoleAssignments';
  }
}
