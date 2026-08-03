import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolEventCalendar, 
  CreateSchoolEventCalendarDto, 
  UpdateSchoolEventCalendarDto 
} from '@modules/m1-school-office/interface/school-event-calendar';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolEventCalendars)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolEventCalendarsService extends BaseApiService<
  SchoolEventCalendar, 
  CreateSchoolEventCalendarDto, 
  UpdateSchoolEventCalendarDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolEventCalendars';
  }
}
