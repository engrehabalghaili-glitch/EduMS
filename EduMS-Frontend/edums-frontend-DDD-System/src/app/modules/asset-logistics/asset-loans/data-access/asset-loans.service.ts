import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetLoan, 
  CreateAssetLoanPayload, 
  UpdateAssetLoanPayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetloan.interface';

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
  CreateAssetLoanPayload, 
  UpdateAssetLoanPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetLoans';
  }
}
