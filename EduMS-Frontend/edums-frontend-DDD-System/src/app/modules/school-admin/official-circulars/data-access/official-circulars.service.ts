import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  OfficialCircular, 
  CreateOfficialCircularPayload, 
  UpdateOfficialCircularPayload 
} from '../../../../core/api/interfaces/M1_SchoolAdmin/officialcircular.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (OfficialCirculars)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class OfficialCircularsService extends BaseApiService<
  OfficialCircular, 
  CreateOfficialCircularPayload, 
  UpdateOfficialCircularPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/OfficialCirculars';
  }
}
