import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolAcademicYear, 
  CreateSchoolAcademicYearDto, 
  UpdateSchoolAcademicYearDto 
} from '@modules/m1-school-office/interface/school-academic-year';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolAcademicYears)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolAcademicYearsService extends BaseApiService<
  SchoolAcademicYear, 
  CreateSchoolAcademicYearDto, 
  UpdateSchoolAcademicYearDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolAcademicYears';
  }
}
