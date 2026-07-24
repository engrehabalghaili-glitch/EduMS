import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetRevaluationImpairment, 
  CreateAssetRevaluationImpairmentRequest, 
  UpdateAssetRevaluationImpairmentRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-revaluation-impairments';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetRevaluationImpairments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetRevaluationImpairmentsService extends BaseApiService<
  AssetRevaluationImpairment, 
  CreateAssetRevaluationImpairmentRequest, 
  UpdateAssetRevaluationImpairmentRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetRevaluationImpairments';
  }
}
