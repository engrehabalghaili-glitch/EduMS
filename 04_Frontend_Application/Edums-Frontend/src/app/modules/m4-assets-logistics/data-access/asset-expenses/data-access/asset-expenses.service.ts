import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AssetExpense, 
  CreateAssetExpenseRequest, 
  UpdateAssetExpenseRequest 
} from '@modules/m4-assets-logistics/interfaces/asset-expenses';

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
  CreateAssetExpenseRequest, 
  UpdateAssetExpenseRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AssetExpenses';
  }
}
