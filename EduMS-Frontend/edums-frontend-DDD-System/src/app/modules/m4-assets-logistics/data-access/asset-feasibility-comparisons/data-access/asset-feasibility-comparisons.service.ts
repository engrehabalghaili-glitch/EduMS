import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetFeasibilityComparison, 
  CreateAssetFeasibilityComparisonPayload, 
  UpdateAssetFeasibilityComparisonPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetfeasibilitycomparison.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetFeasibilityComparisons)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetFeasibilityComparisonsService extends BaseApiService<
  AssetFeasibilityComparison, 
  CreateAssetFeasibilityComparisonPayload, 
  UpdateAssetFeasibilityComparisonPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetFeasibilityComparisons';
  }
}
