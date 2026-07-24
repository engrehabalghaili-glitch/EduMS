import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  UserDirectPermission, 
  CreateUserDirectPermission, 
  UpdateUserDirectPermission 
} from '@modules/m8-authentication-users/interfaces/user-direct-permission.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (UserDirectPermissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class UserDirectPermissionsService extends BaseApiService<
  UserDirectPermission, 
  CreateUserDirectPermission, 
  UpdateUserDirectPermission
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/UserDirectPermissions';
  }
}
