import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  AssetExpense, 
  CreateAssetExpensePayload, 
  UpdateAssetExpensePayload 
} from '../../../../core/api/interfaces/M4_AssetLogistics/assetexpense.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AssetExpenses)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AssetExpensesService extends BaseApiService<
  AssetExpense, 
  CreateAssetExpensePayload, 
  UpdateAssetExpensePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetExpenses';
  }
}
