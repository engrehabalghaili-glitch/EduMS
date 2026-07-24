import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SelfServicePortalRequest, 
  CreateSelfServicePortalRequest, 
  UpdateSelfServicePortalRequest 
} from '@modules/m3-employee-management/interfaces/self-service-portal-request.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SelfServicePortalRequests)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SelfServicePortalRequestsService extends BaseApiService<
  SelfServicePortalRequest, 
  CreateSelfServicePortalRequest, 
  UpdateSelfServicePortalRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SelfServicePortalRequests';
  }
}
