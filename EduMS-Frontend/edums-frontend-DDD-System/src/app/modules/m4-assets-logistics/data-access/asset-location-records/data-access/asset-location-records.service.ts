import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetLocationRecord, 
  CreateAssetLocationRecordPayload, 
  UpdateAssetLocationRecordPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetlocationrecord.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetLocationRecords)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetLocationRecordsService extends BaseApiService<
  AssetLocationRecord, 
  CreateAssetLocationRecordPayload, 
  UpdateAssetLocationRecordPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetLocationRecords';
  }
}
