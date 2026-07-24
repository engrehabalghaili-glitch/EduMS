import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetReceiving, 
  CreateAssetReceivingPayload, 
  UpdateAssetReceivingPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetreceiving.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetReceivings)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetReceivingsService extends BaseApiService<
  AssetReceiving, 
  CreateAssetReceivingPayload, 
  UpdateAssetReceivingPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetReceivings';
  }
}
