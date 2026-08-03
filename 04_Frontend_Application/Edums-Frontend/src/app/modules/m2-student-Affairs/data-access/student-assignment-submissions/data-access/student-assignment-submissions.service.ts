import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentAssignmentSubmission, 
  CreateStudentAssignmentSubmission, 
  UpdateStudentAssignmentSubmission 
} from '@modules/m2-student-Affairs/interfaces/assignment-submission.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentAssignmentSubmissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentAssignmentSubmissionsService extends BaseApiService<
  StudentAssignmentSubmission, 
  CreateStudentAssignmentSubmission, 
  UpdateStudentAssignmentSubmission
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentAssignmentSubmissions';
  }
}
