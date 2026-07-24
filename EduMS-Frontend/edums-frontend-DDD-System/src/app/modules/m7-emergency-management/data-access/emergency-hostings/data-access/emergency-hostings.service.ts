import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmergencyHosting, 
  CreateEmergencyHostingPayload, 
  UpdateEmergencyHostingPayload 
} from '../../../../core/api/interfaces/M7_EmergencyManagement/emergencyhosting.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmergencyHostings)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmergencyHostingsService extends BaseApiService<
  EmergencyHosting, 
  CreateEmergencyHostingPayload, 
  UpdateEmergencyHostingPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmergencyHostings';
  }
}
