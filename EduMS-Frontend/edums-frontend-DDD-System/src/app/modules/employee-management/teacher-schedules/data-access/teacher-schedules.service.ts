import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  TeacherSchedule, 
  CreateTeacherSchedulePayload, 
  UpdateTeacherSchedulePayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/teacherschedule.interface';

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
  CreateTeacherSchedulePayload, 
  UpdateTeacherSchedulePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/TeacherSchedules';
  }
}
