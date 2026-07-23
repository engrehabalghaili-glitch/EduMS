import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StudentComplaintLog, 
  CreateStudentComplaintLogPayload, 
  UpdateStudentComplaintLogPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/studentcomplaintlog.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentComplaintLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentComplaintLogsService extends BaseApiService<
  StudentComplaintLog, 
  CreateStudentComplaintLogPayload, 
  UpdateStudentComplaintLogPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentComplaintLogs';
  }
}
