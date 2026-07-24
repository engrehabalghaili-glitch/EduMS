import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  ExamDistributionTimetable, 
  CreateExamDistributionTimetableDto, 
  UpdateExamDistributionTimetableDto 
} from '@modules/m1-school-office/interface/exam-distribution-timetable';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (ExamDistributionTimetables)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ExamDistributionTimetablesService extends BaseApiService<
  ExamDistributionTimetable, 
  CreateExamDistributionTimetableDto, 
  UpdateExamDistributionTimetableDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/ExamDistributionTimetables';
  }
}
