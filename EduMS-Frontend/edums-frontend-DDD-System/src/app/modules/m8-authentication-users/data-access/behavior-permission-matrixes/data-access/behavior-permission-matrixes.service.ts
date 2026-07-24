import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  BehaviorPermissionMatrix, 
  CreateBehaviorPermissionMatrix, 
  UpdateBehaviorPermissionMatrix 
} from '@modules/m8-authentication-users/interfaces/behavior-permission-matrix.models';

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
  CreateBehaviorPermissionMatrix, 
  UpdateBehaviorPermissionMatrix
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/BehaviorPermissionMatrixes';
  }
}
