import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetCategory, 
  CreateAssetCategoryRequest, 
  UpdateAssetCategoryRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-categories';

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
  CreateAssetCategoryRequest, 
  UpdateAssetCategoryRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetCategories';
  }
}
