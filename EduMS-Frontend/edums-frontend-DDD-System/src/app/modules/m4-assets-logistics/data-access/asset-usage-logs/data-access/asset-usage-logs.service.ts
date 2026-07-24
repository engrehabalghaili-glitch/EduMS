import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetUsageLog, 
  CreateAssetUsageLogPayload, 
  UpdateAssetUsageLogPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetusagelog.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetUsageLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetUsageLogsService extends BaseApiService<
  AssetUsageLog, 
  CreateAssetUsageLogPayload, 
  UpdateAssetUsageLogPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetUsageLogs';
  }
}
