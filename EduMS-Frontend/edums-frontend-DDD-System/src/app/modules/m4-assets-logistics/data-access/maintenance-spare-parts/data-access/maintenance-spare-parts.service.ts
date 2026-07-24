import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  MaintenanceSparePart, 
  CreateMaintenanceSparePartRequest, 
  UpdateMaintenanceSparePartRequest 
} from '@modules/m4-assets-logistics/interfaces/maintenance-spare-parts';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (MaintenanceSpareParts)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class MaintenanceSparePartsService extends BaseApiService<
  MaintenanceSparePart, 
  CreateMaintenanceSparePartRequest, 
  UpdateMaintenanceSparePartRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/MaintenanceSpareParts';
  }
}
