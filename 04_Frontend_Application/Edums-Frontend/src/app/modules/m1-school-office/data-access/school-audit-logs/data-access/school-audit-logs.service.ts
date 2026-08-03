import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolAuditLog, 
  CreateSchoolAuditLogDto, 
  UpdateSchoolAuditLogDto 
} from '@modules/m1-school-office/interface/school-audit-log';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolAuditLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolAuditLogsService extends BaseApiService<
  SchoolAuditLog, 
  CreateSchoolAuditLogDto, 
  UpdateSchoolAuditLogDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolAuditLogs';
  }
}
