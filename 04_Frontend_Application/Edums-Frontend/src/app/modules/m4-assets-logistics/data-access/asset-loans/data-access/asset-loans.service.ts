import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetLoan, 
  CreateAssetLoanRequest, 
  UpdateAssetLoanRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-loans';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetLoans)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetLoansService extends BaseApiService<
  AssetLoan, 
  CreateAssetLoanRequest, 
  UpdateAssetLoanRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetLoans';
  }
}
