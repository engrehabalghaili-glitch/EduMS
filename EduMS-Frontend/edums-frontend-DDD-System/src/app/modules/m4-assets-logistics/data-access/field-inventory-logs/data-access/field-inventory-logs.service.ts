import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  FieldInventoryLog, 
  CreateFieldInventoryLogRequest, 
  UpdateFieldInventoryLogRequest 
} from '@modules/m4-assets-logistics/interfaces/field-inventory-logs';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FieldInventoryLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FieldInventoryLogsService extends BaseApiService<
  FieldInventoryLog, 
  CreateFieldInventoryLogRequest, 
  UpdateFieldInventoryLogRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FieldInventoryLogs';
  }
}
