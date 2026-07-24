import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentPsychologicalCounselingLog, 
  CreateStudentPsychologicalCounselingLog, 
  UpdateStudentPsychologicalCounselingLog 
} from '@modules/m2-student-Affairs/interfaces/psychological-counseling.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentPsychologicalCounselingLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentPsychologicalCounselingLogsService extends BaseApiService<
  StudentPsychologicalCounselingLog, 
  CreateStudentPsychologicalCounselingLog, 
  UpdateStudentPsychologicalCounselingLog
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentPsychologicalCounselingLogs';
  }
}
