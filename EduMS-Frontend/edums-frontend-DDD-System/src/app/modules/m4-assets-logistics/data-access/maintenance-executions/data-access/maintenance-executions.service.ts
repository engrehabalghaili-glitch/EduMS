import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  MaintenanceExecution, 
  CreateMaintenanceExecutionRequest, 
  UpdateMaintenanceExecutionRequest 
} from '@modules/m4-assets-logistics/interfaces/maintenance-executions';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (MaintenanceExecutions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class MaintenanceExecutionsService extends BaseApiService<
  MaintenanceExecution, 
  CreateMaintenanceExecutionRequest, 
  UpdateMaintenanceExecutionRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/MaintenanceExecutions';
  }
}
