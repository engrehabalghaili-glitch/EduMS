import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolAsset, 
  CreateSchoolAssetRequest, 
  UpdateSchoolAssetRequest 
} from '@modules/m4-assets-logistics/interfaces/school-assets';

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
  CreateSchoolAssetRequest, 
  UpdateSchoolAssetRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolAssets';
  }
}
