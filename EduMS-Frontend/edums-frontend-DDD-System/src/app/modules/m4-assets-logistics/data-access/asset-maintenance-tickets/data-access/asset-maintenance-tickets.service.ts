import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetMaintenanceTicket, 
  CreateAssetMaintenanceTicketRequest, 
  UpdateAssetMaintenanceTicketRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-maintenance-tickets';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetMaintenanceTickets)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetMaintenanceTicketsService extends BaseApiService<
  AssetMaintenanceTicket, 
  CreateAssetMaintenanceTicketRequest, 
  UpdateAssetMaintenanceTicketRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetMaintenanceTickets';
  }
}
