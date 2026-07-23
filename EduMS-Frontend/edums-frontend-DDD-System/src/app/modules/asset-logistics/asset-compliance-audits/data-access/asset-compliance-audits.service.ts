import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetComplianceAudit, 
  CreateAssetComplianceAuditPayload, 
  UpdateAssetComplianceAuditPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetcomplianceaudit.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetComplianceAudits)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetComplianceAuditsService extends BaseApiService<
  AssetComplianceAudit, 
  CreateAssetComplianceAuditPayload, 
  UpdateAssetComplianceAuditPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetComplianceAudits';
  }
}
