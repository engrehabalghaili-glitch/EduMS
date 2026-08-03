import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolFacility, 
  CreateSchoolFacilityDto, 
  UpdateSchoolFacilityDto 
} from '@modules/m1-school-office/interface/school-facility';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolFacilities)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolFacilitiesService extends BaseApiService<
  SchoolFacility, 
  CreateSchoolFacilityDto, 
  UpdateSchoolFacilityDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolFacilities';
  }
}
