import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AccessPolicy, 
  CreateAccessPolicy, 
  UpdateAccessPolicy 
} from '@modules/m8-authentication-users/interfaces/access-policy.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AccessPolicies)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AccessPoliciesService extends BaseApiService<
  AccessPolicy, 
  CreateAccessPolicy, 
  UpdateAccessPolicy
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AccessPolicies';
  }
}
