import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetAuditFinalApproval, 
  CreateAssetAuditFinalApprovalRequest, 
  UpdateAssetAuditFinalApprovalRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-audit-final-approvals';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetAuditFinalApprovals)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetAuditFinalApprovalsService extends BaseApiService<
  AssetAuditFinalApproval, 
  CreateAssetAuditFinalApprovalRequest, 
  UpdateAssetAuditFinalApprovalRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetAuditFinalApprovals';
  }
}
