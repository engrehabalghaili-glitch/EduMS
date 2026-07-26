import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SystemPermission, 
  CreateSystemPermission, 
  UpdateSystemPermission 
} from '@modules/m8-authentication-users/interfaces/system-permission.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SystemPermissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SystemPermissionsService extends BaseApiService<
  SystemPermission, 
  CreateSystemPermission, 
  UpdateSystemPermission
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SystemPermissions';
  }
}
