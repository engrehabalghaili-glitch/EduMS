import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EmployeeExternalTransfer, 
  CreateEmployeeExternalTransfer, 
  UpdateEmployeeExternalTransfer 
} from '@modules/m3-employee-management/interfaces/employee-external-transfer.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeExternalTransfers)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeExternalTransfersService extends BaseApiService<
  EmployeeExternalTransfer, 
  CreateEmployeeExternalTransfer, 
  UpdateEmployeeExternalTransfer
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeExternalTransfers';
  }
}
