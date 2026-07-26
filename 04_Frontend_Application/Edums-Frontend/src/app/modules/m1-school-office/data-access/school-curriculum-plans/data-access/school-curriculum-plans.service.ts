import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolCurriculumPlan, 
  CreateSchoolCurriculumPlanDto, 
  UpdateSchoolCurriculumPlanDto 
} from '@modules/m1-school-office/interface/school-curriculum-plan';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolCurriculumPlans)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolCurriculumPlansService extends BaseApiService<
  SchoolCurriculumPlan, 
  CreateSchoolCurriculumPlanDto, 
  UpdateSchoolCurriculumPlanDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolCurriculumPlans';
  }
}
