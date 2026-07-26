import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  RemediationPlan, 
  CreateRemediationPlan, 
  UpdateRemediationPlan 
} from '@modules/m7-emergency-management/interfaces/remediation-plan.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (RemediationPlans)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class RemediationPlansService extends BaseApiService<
  RemediationPlan, 
  CreateRemediationPlan, 
  UpdateRemediationPlan
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/RemediationPlans';
  }
}
