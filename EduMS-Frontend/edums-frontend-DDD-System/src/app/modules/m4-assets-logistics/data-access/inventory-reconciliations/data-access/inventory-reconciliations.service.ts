import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  InventoryReconciliation, 
  CreateInventoryReconciliationRequest, 
  UpdateInventoryReconciliationRequest 
} from '@modules/m4-assets-logistics/interfaces/inventory-reconciliations';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (InventoryReconciliations)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class InventoryReconciliationsService extends BaseApiService<
  InventoryReconciliation, 
  CreateInventoryReconciliationRequest, 
  UpdateInventoryReconciliationRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/InventoryReconciliations';
  }
}
