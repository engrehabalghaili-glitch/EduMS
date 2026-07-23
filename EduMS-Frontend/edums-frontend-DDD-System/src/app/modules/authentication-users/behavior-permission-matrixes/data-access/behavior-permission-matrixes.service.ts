import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  BehaviorPermissionMatrix, 
  CreateBehaviorPermissionMatrixPayload, 
  UpdateBehaviorPermissionMatrixPayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/behaviorpermissionmatrixe.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (BehaviorPermissionMatrixes)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class BehaviorPermissionMatrixesService extends BaseApiService<
  BehaviorPermissionMatrix, 
  CreateBehaviorPermissionMatrixPayload, 
  UpdateBehaviorPermissionMatrixPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/BehaviorPermissionMatrixes';
  }
}
