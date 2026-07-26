import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  TeacherSchedule, 
  CreateTeacherSchedule, 
  UpdateTeacherSchedule 
} from '@modules/m3-employee-management/interfaces/teacher-schedule.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (TeacherSchedules)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class TeacherSchedulesService extends BaseApiService<
  TeacherSchedule, 
  CreateTeacherSchedule, 
  UpdateTeacherSchedule
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/TeacherSchedules';
  }
}
