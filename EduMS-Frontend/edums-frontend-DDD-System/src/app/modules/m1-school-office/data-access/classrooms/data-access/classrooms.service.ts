import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  Classroom, 
  CreateClassroomDto, 
  UpdateClassroomDto 
} from '@modules/m1-school-office/interface/classroom';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Classrooms)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ClassroomsService extends BaseApiService<
  Classroom, 
  CreateClassroomDto, 
  UpdateClassroomDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Classrooms';
  }
}
