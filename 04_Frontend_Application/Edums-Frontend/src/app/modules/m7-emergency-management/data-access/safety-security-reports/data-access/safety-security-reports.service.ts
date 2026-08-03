import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SafetySecurityReport, 
  CreateSafetySecurityReport, 
  UpdateSafetySecurityReport 
} from '@modules/m7-emergency-management/interfaces/safety-security-report.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SafetySecurityReports)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SafetySecurityReportsService extends BaseApiService<
  SafetySecurityReport, 
  CreateSafetySecurityReport, 
  UpdateSafetySecurityReport
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SafetySecurityReports';
  }
}
