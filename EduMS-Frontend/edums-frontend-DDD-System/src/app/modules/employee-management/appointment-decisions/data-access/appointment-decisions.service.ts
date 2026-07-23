import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AppointmentDecision, 
  CreateAppointmentDecisionPayload, 
  UpdateAppointmentDecisionPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/appointmentdecision.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AppointmentDecisions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AppointmentDecisionsService extends BaseApiService<
  AppointmentDecision, 
  CreateAppointmentDecisionPayload, 
  UpdateAppointmentDecisionPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AppointmentDecisions';
  }
}
