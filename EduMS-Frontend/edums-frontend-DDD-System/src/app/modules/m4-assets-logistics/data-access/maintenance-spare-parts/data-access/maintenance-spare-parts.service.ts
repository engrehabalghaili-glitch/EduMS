import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  MaintenanceSparePart, 
  CreateMaintenanceSparePartPayload, 
  UpdateMaintenanceSparePartPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/maintenancesparepart.interface';

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
  CreateMaintenanceSparePartPayload, 
  UpdateMaintenanceSparePartPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/MaintenanceSpareParts';
  }
}
