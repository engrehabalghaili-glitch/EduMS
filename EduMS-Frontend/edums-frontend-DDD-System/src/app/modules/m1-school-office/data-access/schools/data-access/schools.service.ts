import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  School, 
  CreateSchoolDto, 
  UpdateSchoolDto 
} from '@modules/m1-school-office/interface/school';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Schools)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolsService extends BaseApiService<
  School, 
  CreateSchoolDto, 
  UpdateSchoolDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Schools';
  }
}
