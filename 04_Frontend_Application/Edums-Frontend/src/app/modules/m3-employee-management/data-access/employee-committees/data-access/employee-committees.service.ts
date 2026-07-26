import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  EmployeeCommittee, 
  CreateEmployeeCommittee, 
  UpdateEmployeeCommittee 
} from '@modules/m3-employee-management/interfaces/employee-committee.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeCommittees)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeCommitteesService extends BaseApiService<
  EmployeeCommittee, 
  CreateEmployeeCommittee, 
  UpdateEmployeeCommittee
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeCommittees';
  }
}
