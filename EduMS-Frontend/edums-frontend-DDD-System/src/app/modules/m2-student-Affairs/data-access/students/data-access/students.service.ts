import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  Student, 
  CreateStudentPayload, 
  UpdateStudentPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/student.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Students)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentsService extends BaseApiService<
  Student, 
  CreateStudentPayload, 
  UpdateStudentPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Students';
  }
}
