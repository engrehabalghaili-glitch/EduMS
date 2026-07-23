import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetFeasibilityRiskAnalysis, 
  CreateAssetFeasibilityRiskAnalysisPayload, 
  UpdateAssetFeasibilityRiskAnalysisPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetfeasibilityriskanalysise.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetFeasibilityRiskAnalysises)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetFeasibilityRiskAnalysisesService extends BaseApiService<
  AssetFeasibilityRiskAnalysis, 
  CreateAssetFeasibilityRiskAnalysisPayload, 
  UpdateAssetFeasibilityRiskAnalysisPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetFeasibilityRiskAnalysises';
  }
}
