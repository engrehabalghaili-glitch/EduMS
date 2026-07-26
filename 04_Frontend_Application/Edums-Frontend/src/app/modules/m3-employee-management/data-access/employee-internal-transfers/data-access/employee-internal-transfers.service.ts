import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EmployeeInternalTransfer, 
  CreateEmployeeInternalTransfer, 
  UpdateEmployeeInternalTransfer 
} from '@modules/m3-employee-management/interfaces/employee-internal-transfer.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeInternalTransfers)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeInternalTransfersService extends BaseApiService<
  EmployeeInternalTransfer, 
  CreateEmployeeInternalTransfer, 
  UpdateEmployeeInternalTransfer
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeInternalTransfers';
  }
}
