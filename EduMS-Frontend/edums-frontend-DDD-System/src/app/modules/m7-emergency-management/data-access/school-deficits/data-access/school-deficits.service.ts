import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolDeficit, 
  CreateSchoolDeficit, 
  UpdateSchoolDeficit 
} from '@modules/m7-emergency-management/interfaces/school-deficit.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolDeficits)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolDeficitsService extends BaseApiService<
  SchoolDeficit, 
  CreateSchoolDeficit, 
  UpdateSchoolDeficit
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolDeficits';
  }
}
