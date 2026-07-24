import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  MaintenanceNotification, 
  CreateMaintenanceNotificationPayload, 
  UpdateMaintenanceNotificationPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/maintenancenotification.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (MaintenanceNotifications)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class MaintenanceNotificationsService extends BaseApiService<
  MaintenanceNotification, 
  CreateMaintenanceNotificationPayload, 
  UpdateMaintenanceNotificationPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/MaintenanceNotifications';
  }
}
