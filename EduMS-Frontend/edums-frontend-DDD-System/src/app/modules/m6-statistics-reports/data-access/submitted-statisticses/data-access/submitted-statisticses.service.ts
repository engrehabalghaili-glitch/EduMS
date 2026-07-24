import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SubmittedStatistics, 
  CreateSubmittedStatistics, 
  UpdateSubmittedStatistics 
} from '@modules/m6-statistics-reports/interfaces/submitted-statistics.dto';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SubmittedStatisticses)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SubmittedStatisticsesService extends BaseApiService<
  SubmittedStatistics, 
  CreateSubmittedStatistics, 
  UpdateSubmittedStatistics
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SubmittedStatisticses';
  }
}
