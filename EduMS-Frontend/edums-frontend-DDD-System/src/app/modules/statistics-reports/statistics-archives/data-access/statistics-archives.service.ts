import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StatisticsArchive, 
  CreateStatisticsArchivePayload, 
  UpdateStatisticsArchivePayload 
} from '../../../../core/api/interfaces/M6_StatisticsReports/statisticsarchive.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StatisticsArchives)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StatisticsArchivesService extends BaseApiService<
  StatisticsArchive, 
  CreateStatisticsArchivePayload, 
  UpdateStatisticsArchivePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StatisticsArchives';
  }
}
