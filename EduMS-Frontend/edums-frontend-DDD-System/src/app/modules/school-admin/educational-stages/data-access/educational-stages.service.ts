import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EducationalStage, 
  CreateEducationalStagePayload, 
  UpdateEducationalStagePayload 
} from '../../../../core/api/interfaces/M1_SchoolAdmin/educationalstage.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EducationalStages)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EducationalStagesService extends BaseApiService<
  EducationalStage, 
  CreateEducationalStagePayload, 
  UpdateEducationalStagePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EducationalStages';
  }
}
