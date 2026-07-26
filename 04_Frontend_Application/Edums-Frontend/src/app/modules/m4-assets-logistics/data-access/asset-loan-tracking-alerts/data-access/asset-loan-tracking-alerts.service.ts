import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetLoanTrackingAlert, 
  CreateAssetLoanTrackingAlertRequest, 
  UpdateAssetLoanTrackingAlertRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-loan-tracking-alerts';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetLoanTrackingAlerts)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetLoanTrackingAlertsService extends BaseApiService<
  AssetLoanTrackingAlert, 
  CreateAssetLoanTrackingAlertRequest, 
  UpdateAssetLoanTrackingAlertRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetLoanTrackingAlerts';
  }
}
