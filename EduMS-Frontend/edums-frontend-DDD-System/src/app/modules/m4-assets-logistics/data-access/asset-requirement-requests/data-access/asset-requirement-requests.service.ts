import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetRequirementRequest, 
  CreateAssetRequirementRequestPayload, 
  UpdateAssetRequirementRequestPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetrequirementrequest.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetRequirementRequests)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetRequirementRequestsService extends BaseApiService<
  AssetRequirementRequest, 
  CreateAssetRequirementRequestPayload, 
  UpdateAssetRequirementRequestPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetRequirementRequests';
  }
}
