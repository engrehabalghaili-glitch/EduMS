import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  EmployeeTraining, 
  CreateEmployeeTrainingPayload, 
  UpdateEmployeeTrainingPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/employeetraining.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (EmployeeTrainings)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class EmployeeTrainingsService extends BaseApiService<
  EmployeeTraining, 
  CreateEmployeeTrainingPayload, 
  UpdateEmployeeTrainingPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/EmployeeTrainings';
  }
}
