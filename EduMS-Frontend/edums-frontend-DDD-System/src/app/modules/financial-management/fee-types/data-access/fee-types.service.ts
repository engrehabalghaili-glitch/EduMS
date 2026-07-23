import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  FeeType, 
  CreateFeeTypePayload, 
  UpdateFeeTypePayload 
} from '../../../../core/api/interfaces/M5_FinancialManagement/feetype.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FeeTypes)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FeeTypesService extends BaseApiService<
  FeeType, 
  CreateFeeTypePayload, 
  UpdateFeeTypePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FeeTypes';
  }
}
