import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetMovementHistory, 
  CreateAssetMovementHistoryPayload, 
  UpdateAssetMovementHistoryPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetmovementhistory.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetMovementHistories)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetMovementHistoriesService extends BaseApiService<
  AssetMovementHistory, 
  CreateAssetMovementHistoryPayload, 
  UpdateAssetMovementHistoryPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetMovementHistories';
  }
}
