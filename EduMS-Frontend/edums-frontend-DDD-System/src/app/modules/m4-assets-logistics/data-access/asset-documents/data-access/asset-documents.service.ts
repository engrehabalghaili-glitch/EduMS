import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetDocument, 
  CreateAssetDocumentPayload, 
  UpdateAssetDocumentPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetdocument.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetDocuments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetDocumentsService extends BaseApiService<
  AssetDocument, 
  CreateAssetDocumentPayload, 
  UpdateAssetDocumentPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetDocuments';
  }
}
