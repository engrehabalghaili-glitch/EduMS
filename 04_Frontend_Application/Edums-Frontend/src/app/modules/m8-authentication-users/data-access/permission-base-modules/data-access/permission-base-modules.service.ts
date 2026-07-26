import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  PermissionBaseModule, 
  CreatePermissionBaseModule, 
  UpdatePermissionBaseModule 
} from '@modules/m8-authentication-users/interfaces/permission-base-module.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (PermissionBaseModules)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class PermissionBaseModulesService extends BaseApiService<
  PermissionBaseModule, 
  CreatePermissionBaseModule, 
  UpdatePermissionBaseModule
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/PermissionBaseModules';
  }
}
