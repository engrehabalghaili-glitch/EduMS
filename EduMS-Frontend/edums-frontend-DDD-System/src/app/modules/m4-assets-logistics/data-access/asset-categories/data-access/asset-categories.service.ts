import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetCategory, 
  CreateAssetCategoryPayload, 
  UpdateAssetCategoryPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetcategory.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetCategories)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetCategoriesService extends BaseApiService<
  AssetCategory, 
  CreateAssetCategoryPayload, 
  UpdateAssetCategoryPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetCategories';
  }
}
