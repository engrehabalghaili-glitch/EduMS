import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolSurplus, 
  CreateSchoolSurplus, 
  UpdateSchoolSurplus 
} from '@modules/m7-emergency-management/interfaces/school-surplus.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolSurpluses)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolSurplusesService extends BaseApiService<
  SchoolSurplus, 
  CreateSchoolSurplus, 
  UpdateSchoolSurplus
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolSurpluses';
  }
}
