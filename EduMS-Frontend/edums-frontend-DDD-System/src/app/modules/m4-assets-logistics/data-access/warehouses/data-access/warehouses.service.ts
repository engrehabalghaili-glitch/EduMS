import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  Warehouse, 
  CreateWarehouseRequest, 
  UpdateWarehouseRequest 
} from '@modules/m4-assets-logistics/interfaces/warehouses';

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
  CreateWarehouseRequest, 
  UpdateWarehouseRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Warehouses';
  }
}
