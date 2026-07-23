import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmployeeTermination, 
  CreateEmployeeTerminationPayload, 
  UpdateEmployeeTerminationPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/employeetermination.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeTerminations)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeTerminationsService extends BaseApiService<
  EmployeeTermination, 
  CreateEmployeeTerminationPayload, 
  UpdateEmployeeTerminationPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeTerminations';
  }
}
