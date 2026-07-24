import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentPermissionAuditLog, 
  CreateStudentPermissionAuditLog, 
  UpdateStudentPermissionAuditLog 
} from '@modules/m8-authentication-users/interfaces/student-permission-audit-log.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentPermissionAuditLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentPermissionAuditLogsService extends BaseApiService<
  StudentPermissionAuditLog, 
  CreateStudentPermissionAuditLog, 
  UpdateStudentPermissionAuditLog
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentPermissionAuditLogs';
  }
}
