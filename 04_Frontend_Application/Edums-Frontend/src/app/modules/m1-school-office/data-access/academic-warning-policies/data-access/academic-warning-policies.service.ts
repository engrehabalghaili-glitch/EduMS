import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AcademicWarningPolicy, 
  CreateAcademicWarningPolicyDto, 
  UpdateAcademicWarningPolicyDto 
} from '@modules/m1-school-office/interface/academic-warning-policy';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AcademicWarningPolicies)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AcademicWarningPoliciesService extends BaseApiService<
  AcademicWarningPolicy, 
  CreateAcademicWarningPolicyDto, 
  UpdateAcademicWarningPolicyDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AcademicWarningPolicies';
  }
}
