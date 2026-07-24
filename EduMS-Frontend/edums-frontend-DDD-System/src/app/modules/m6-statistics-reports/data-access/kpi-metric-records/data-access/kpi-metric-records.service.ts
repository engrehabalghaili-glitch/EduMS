import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  KpiMetricRecord, 
  CreateKpiMetricRecord, 
  UpdateKpiMetricRecord 
} from '@modules/m6-statistics-reports/interfaces/kpi-metric-record.dto';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (KpiMetricRecords)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class KpiMetricRecordsService extends BaseApiService<
  KpiMetricRecord, 
  CreateKpiMetricRecord, 
  UpdateKpiMetricRecord
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/KpiMetricRecords';
  }
}
