import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentExitClearance, 
  CreateStudentExitClearance, 
  UpdateStudentExitClearance 
} from '@modules/m2-student-Affairs/interfaces/exit-clearance.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentExitClearances)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentExitClearancesService extends BaseApiService<
  StudentExitClearance, 
  CreateStudentExitClearance, 
  UpdateStudentExitClearance
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentExitClearances';
  }
}
