import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EducationalConsumableTracking, 
  CreateEducationalConsumableTrackingRequest, 
  UpdateEducationalConsumableTrackingRequest 
} from '@modules/m4-assets-logistics/interfaces/educational-consumable-trackings';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EducationalConsumableTrackings)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EducationalConsumableTrackingsService extends BaseApiService<
  EducationalConsumableTracking, 
  CreateEducationalConsumableTrackingRequest, 
  UpdateEducationalConsumableTrackingRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EducationalConsumableTrackings';
  }
}
