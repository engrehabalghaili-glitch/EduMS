import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  Guardian, 
  CreateGuardianPayload, 
  UpdateGuardianPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/guardian.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Guardians)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class GuardiansService extends BaseApiService<
  Guardian, 
  CreateGuardianPayload, 
  UpdateGuardianPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Guardians';
  }
}
