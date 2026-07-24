import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EmergencyHosting, 
  CreateEmergencyHosting, 
  UpdateEmergencyHosting 
} from '@modules/m7-emergency-management/interfaces/emergency-hosting.types';

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
  CreateEmergencyHosting, 
  UpdateEmergencyHosting
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmergencyHostings';
  }
}
