import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  PrivilegeRule, 
  CreatePrivilegeRule, 
  UpdatePrivilegeRule 
} from '@modules/m8-authentication-users/interfaces/privilege-rule.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (PrivilegeRules)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class PrivilegeRulesService extends BaseApiService<
  PrivilegeRule, 
  CreatePrivilegeRule, 
  UpdatePrivilegeRule
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/PrivilegeRules';
  }
}
