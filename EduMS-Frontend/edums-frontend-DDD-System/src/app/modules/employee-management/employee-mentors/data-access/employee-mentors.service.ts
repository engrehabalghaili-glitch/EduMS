import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmployeeMentor, 
  CreateEmployeeMentorPayload, 
  UpdateEmployeeMentorPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/employeementor.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeMentors)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeMentorsService extends BaseApiService<
  EmployeeMentor, 
  CreateEmployeeMentorPayload, 
  UpdateEmployeeMentorPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeMentors';
  }
}
