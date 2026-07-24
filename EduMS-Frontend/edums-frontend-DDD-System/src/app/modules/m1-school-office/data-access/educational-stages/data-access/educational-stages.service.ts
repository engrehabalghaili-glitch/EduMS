import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EducationalStage, 
  CreateEducationalStageDto, 
  UpdateEducationalStageDto 
} from '@modules/m1-school-office/interface/educational-stage';

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
  CreateEducationalStageDto, 
  UpdateEducationalStageDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EducationalStages';
  }
}
