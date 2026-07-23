import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmployeeInventoryCustody, 
  CreateEmployeeInventoryCustodyPayload, 
  UpdateEmployeeInventoryCustodyPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/employeeinventorycustody.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeInventoryCustodies)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeInventoryCustodiesService extends BaseApiService<
  EmployeeInventoryCustody, 
  CreateEmployeeInventoryCustodyPayload, 
  UpdateEmployeeInventoryCustodyPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeInventoryCustodies';
  }
}
