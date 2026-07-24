import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetFinancialAuditArchive, 
  CreateAssetFinancialAuditArchivePayload, 
  UpdateAssetFinancialAuditArchivePayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetfinancialauditarchive.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetFinancialAuditArchives)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetFinancialAuditArchivesService extends BaseApiService<
  AssetFinancialAuditArchive, 
  CreateAssetFinancialAuditArchivePayload, 
  UpdateAssetFinancialAuditArchivePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetFinancialAuditArchives';
  }
}
