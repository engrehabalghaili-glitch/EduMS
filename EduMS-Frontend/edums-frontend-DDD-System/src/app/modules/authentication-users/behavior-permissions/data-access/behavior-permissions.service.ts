import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  BehaviorPermission, 
  CreateBehaviorPermissionPayload, 
  UpdateBehaviorPermissionPayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/behaviorpermission.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (BehaviorPermissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class BehaviorPermissionsService extends BaseApiService<
  BehaviorPermission, 
  CreateBehaviorPermissionPayload, 
  UpdateBehaviorPermissionPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/BehaviorPermissions';
  }
}
