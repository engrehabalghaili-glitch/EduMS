import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EmployeePayroll, 
  CreateEmployeePayroll, 
  UpdateEmployeePayroll 
} from '@modules/m3-employee-management/interfaces/employee-payroll.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeePayrolls)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeePayrollsService extends BaseApiService<
  EmployeePayroll, 
  CreateEmployeePayroll, 
  UpdateEmployeePayroll
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeePayrolls';
  }
}
