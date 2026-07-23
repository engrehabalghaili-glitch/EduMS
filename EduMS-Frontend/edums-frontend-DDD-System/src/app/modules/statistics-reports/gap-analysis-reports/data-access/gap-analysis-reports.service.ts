import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  GapAnalysisReport, 
  CreateGapAnalysisReportPayload, 
  UpdateGapAnalysisReportPayload 
} from '../../../../core/api/interfaces/M6_StatisticsReports/gapanalysisreport.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (GapAnalysisReports)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class GapAnalysisReportsService extends BaseApiService<
  GapAnalysisReport, 
  CreateGapAnalysisReportPayload, 
  UpdateGapAnalysisReportPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/GapAnalysisReports';
  }
}
