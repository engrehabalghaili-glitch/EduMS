import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  Warehouse, 
  CreateWarehousePayload, 
  UpdateWarehousePayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/warehouse.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Warehouses)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class WarehousesService extends BaseApiService<
  Warehouse, 
  CreateWarehousePayload, 
  UpdateWarehousePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Warehouses';
  }
}
