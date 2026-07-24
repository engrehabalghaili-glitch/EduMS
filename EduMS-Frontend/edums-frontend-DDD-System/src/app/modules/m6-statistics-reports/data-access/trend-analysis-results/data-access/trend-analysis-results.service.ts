import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  TrendAnalysisResult, 
  CreateTrendAnalysisResult, 
  UpdateTrendAnalysisResult 
} from '@modules/m6-statistics-reports/interfaces/trend-analysis-result.dto';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (TrendAnalysisResults)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class TrendAnalysisResultsService extends BaseApiService<
  TrendAnalysisResult, 
  CreateTrendAnalysisResult, 
  UpdateTrendAnalysisResult
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/TrendAnalysisResults';
  }
}
