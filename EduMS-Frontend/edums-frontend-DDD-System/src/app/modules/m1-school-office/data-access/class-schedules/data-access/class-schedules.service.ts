import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  ClassSchedule, 
  CreateClassScheduleDto, 
  UpdateClassScheduleDto 
} from '@modules/m1-school-office/interface/class-schedule';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (ClassSchedules)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ClassSchedulesService extends BaseApiService<
  ClassSchedule, 
  CreateClassScheduleDto, 
  UpdateClassScheduleDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/ClassSchedules';
  }
}
