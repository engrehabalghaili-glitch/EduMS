import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  Department, 
  CreateDepartmentDto, 
  UpdateDepartmentDto 
} from '@modules/m1-school-office/interface/department';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Departments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class DepartmentsService extends BaseApiService<
  Department, 
  CreateDepartmentDto, 
  UpdateDepartmentDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Departments';
  }
}
