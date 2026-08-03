import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  CurriculumTextbookDistribution, 
  CreateCurriculumTextbookDistributionDto, 
  UpdateCurriculumTextbookDistributionDto 
} from '@modules/m1-school-office/interface/curriculum-textbook-distribution';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (CurriculumTextbookDistributions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class CurriculumTextbookDistributionsService extends BaseApiService<
  CurriculumTextbookDistribution, 
  CreateCurriculumTextbookDistributionDto, 
  UpdateCurriculumTextbookDistributionDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/CurriculumTextbookDistributions';
  }
}
