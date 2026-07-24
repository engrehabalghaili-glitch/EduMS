import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  DirectorateStatisticalReport, 
  CreateDirectorateStatisticalReportDto, 
  UpdateDirectorateStatisticalReportDto 
} from '@modules/m1-school-office/interface/directorate-statistical-report';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (DirectorateStatisticalReports)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class DirectorateStatisticalReportsService extends BaseApiService<
  DirectorateStatisticalReport, 
  CreateDirectorateStatisticalReportDto, 
  UpdateDirectorateStatisticalReportDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/DirectorateStatisticalReports';
  }
}
