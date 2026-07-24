import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  SchoolAsset, 
  CreateSchoolAssetPayload, 
  UpdateSchoolAssetPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/schoolasset.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolAssets)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolAssetsService extends BaseApiService<
  SchoolAsset, 
  CreateSchoolAssetPayload, 
  UpdateSchoolAssetPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolAssets';
  }
}
