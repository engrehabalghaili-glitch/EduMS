import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StatisticsUpdateHistory, 
  CreateStatisticsUpdateHistory, 
  UpdateStatisticsUpdateHistory 
} from '@modules/m6-statistics-reports/interfaces/statistics-update-history.dto';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StatisticsUpdateHistories)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StatisticsUpdateHistoriesService extends BaseApiService<
  StatisticsUpdateHistory, 
  CreateStatisticsUpdateHistory, 
  UpdateStatisticsUpdateHistory
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StatisticsUpdateHistories';
  }
}
