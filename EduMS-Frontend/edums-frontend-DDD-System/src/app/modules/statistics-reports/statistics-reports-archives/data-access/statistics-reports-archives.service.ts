import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StatisticsReportsArchive, 
  CreateStatisticsReportsArchivePayload, 
  UpdateStatisticsReportsArchivePayload 
} from '../../../../core/api/interfaces/M6_StatisticsReports/statisticsreportsarchive.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StatisticsReportsArchives)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StatisticsReportsArchivesService extends BaseApiService<
  StatisticsReportsArchive, 
  CreateStatisticsReportsArchivePayload, 
  UpdateStatisticsReportsArchivePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StatisticsReportsArchives';
  }
}
