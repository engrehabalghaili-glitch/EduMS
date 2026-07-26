import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  PayrollDetail, 
  CreatePayrollDetailDto, 
  UpdatePayrollDetailDto 
} from '@modules/m5-Financial-Management/interfaces/payroll-detail.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (PayrollDetails)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class PayrollDetailsService extends BaseApiService<
  PayrollDetail, 
  CreatePayrollDetailDto, 
  UpdatePayrollDetailDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/PayrollDetails';
  }
}
