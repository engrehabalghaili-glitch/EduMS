import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  PermissionBaseModule, 
  CreatePermissionBaseModulePayload, 
  UpdatePermissionBaseModulePayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/permissionbasemodule.interface';

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
  CreatePermissionBaseModulePayload, 
  UpdatePermissionBaseModulePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/PermissionBaseModules';
  }
}
