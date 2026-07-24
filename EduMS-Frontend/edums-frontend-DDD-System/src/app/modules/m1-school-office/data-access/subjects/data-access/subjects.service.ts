import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  Subject, 
  CreateSubjectDto, 
  UpdateSubjectDto 
} from '@modules/m1-school-office/interface/subject';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Subjects)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SubjectsService extends BaseApiService<
  Subject, 
  CreateSubjectDto, 
  UpdateSubjectDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Subjects';
  }
}
