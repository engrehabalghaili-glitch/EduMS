import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmployeeAttendance, 
  CreateEmployeeAttendancePayload, 
  UpdateEmployeeAttendancePayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/employeeattendance.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeAttendances)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeAttendancesService extends BaseApiService<
  EmployeeAttendance, 
  CreateEmployeeAttendancePayload, 
  UpdateEmployeeAttendancePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeAttendances';
  }
}
