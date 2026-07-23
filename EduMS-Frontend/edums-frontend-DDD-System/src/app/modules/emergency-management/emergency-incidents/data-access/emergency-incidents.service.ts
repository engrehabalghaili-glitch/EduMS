import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmergencyIncident, 
  CreateEmergencyIncidentPayload, 
  UpdateEmergencyIncidentPayload 
} from '../../../../core/api/interfaces/M7_EmergencyManagement/emergencyincident.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmergencyIncidents)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmergencyIncidentsService extends BaseApiService<
  EmergencyIncident, 
  CreateEmergencyIncidentPayload, 
  UpdateEmergencyIncidentPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmergencyIncidents';
  }
}
