import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  ExternalParticipation, 
  CreateExternalParticipation, 
  UpdateExternalParticipation 
} from '@modules/m7-emergency-management/interfaces/external-participation.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (ExternalParticipations)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ExternalParticipationsService extends BaseApiService<
  ExternalParticipation, 
  CreateExternalParticipation, 
  UpdateExternalParticipation
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/ExternalParticipations';
  }
}
