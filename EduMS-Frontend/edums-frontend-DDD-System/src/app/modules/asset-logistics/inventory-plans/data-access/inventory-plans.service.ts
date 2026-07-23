import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  InventoryPlan, 
  CreateInventoryPlanPayload, 
  UpdateInventoryPlanPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/inventoryplan.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (InventoryPlans)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class InventoryPlansService extends BaseApiService<
  InventoryPlan, 
  CreateInventoryPlanPayload, 
  UpdateInventoryPlanPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/InventoryPlans';
  }
}
