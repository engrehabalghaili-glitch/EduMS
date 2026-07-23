import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  CurriculumTextbookDistribution, 
  CreateCurriculumTextbookDistributionPayload, 
  UpdateCurriculumTextbookDistributionPayload 
} from '../../../../core/api/interfaces/M1_SchoolAdmin/curriculumtextbookdistribution.interface';

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
  CreateCurriculumTextbookDistributionPayload, 
  UpdateCurriculumTextbookDistributionPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/CurriculumTextbookDistributions';
  }
}
