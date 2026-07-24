import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StaffCustodySummary, 
  CreateStaffCustodySummaryPayload, 
  UpdateStaffCustodySummaryPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/staffcustodysummary.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StaffCustodySummaries)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StaffCustodySummariesService extends BaseApiService<
  StaffCustodySummary, 
  CreateStaffCustodySummaryPayload, 
  UpdateStaffCustodySummaryPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StaffCustodySummaries';
  }
}
