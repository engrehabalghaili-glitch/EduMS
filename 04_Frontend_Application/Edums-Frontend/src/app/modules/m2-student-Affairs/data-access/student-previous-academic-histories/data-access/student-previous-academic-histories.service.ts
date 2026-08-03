import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentPreviousAcademicHistory, 
  CreateStudentPreviousAcademicHistory, 
  UpdateStudentPreviousAcademicHistory 
} from '@modules/m2-student-Affairs/interfaces/previous-academic-history.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentPreviousAcademicHistories)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentPreviousAcademicHistoriesService extends BaseApiService<
  StudentPreviousAcademicHistory, 
  CreateStudentPreviousAcademicHistory, 
  UpdateStudentPreviousAcademicHistory
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentPreviousAcademicHistories';
  }
}
