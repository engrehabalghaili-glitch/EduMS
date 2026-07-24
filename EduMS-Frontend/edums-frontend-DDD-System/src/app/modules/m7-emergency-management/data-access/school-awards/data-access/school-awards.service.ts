import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolAward, 
  CreateSchoolAward, 
  UpdateSchoolAward 
} from '@modules/m7-emergency-management/interfaces/school-award.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolAwards)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolAwardsService extends BaseApiService<
  SchoolAward, 
  CreateSchoolAward, 
  UpdateSchoolAward
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolAwards';
  }
}
