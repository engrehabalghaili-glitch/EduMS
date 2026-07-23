import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmergencyPlan, 
  CreateEmergencyPlanPayload, 
  UpdateEmergencyPlanPayload 
} from '../../../../core/api/interfaces/M7_EmergencyManagement/emergencyplan.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmergencyPlans)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmergencyPlansService extends BaseApiService<
  EmergencyPlan, 
  CreateEmergencyPlanPayload, 
  UpdateEmergencyPlanPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmergencyPlans';
  }
}
