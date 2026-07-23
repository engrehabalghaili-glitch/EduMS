import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  OfficePermission, 
  CreateOfficePermissionPayload, 
  UpdateOfficePermissionPayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/officepermission.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (OfficePermissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class OfficePermissionsService extends BaseApiService<
  OfficePermission, 
  CreateOfficePermissionPayload, 
  UpdateOfficePermissionPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/OfficePermissions';
  }
}
