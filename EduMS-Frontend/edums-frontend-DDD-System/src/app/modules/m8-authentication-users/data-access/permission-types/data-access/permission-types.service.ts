import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  PermissionType, 
  CreatePermissionType, 
  UpdatePermissionType 
} from '@modules/m8-authentication-users/interfaces/permission-type.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (PermissionTypes)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class PermissionTypesService extends BaseApiService<
  PermissionType, 
  CreatePermissionType, 
  UpdatePermissionType
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/PermissionTypes';
  }
}
