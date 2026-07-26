import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EducationalSupervisionVisit, 
  CreateEducationalSupervisionVisitDto, 
  UpdateEducationalSupervisionVisitDto 
} from '@modules/m1-school-office/interface/educational-supervision-visit';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EducationalSupervisionVisits)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EducationalSupervisionVisitsService extends BaseApiService<
  EducationalSupervisionVisit, 
  CreateEducationalSupervisionVisitDto, 
  UpdateEducationalSupervisionVisitDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EducationalSupervisionVisits';
  }
}
