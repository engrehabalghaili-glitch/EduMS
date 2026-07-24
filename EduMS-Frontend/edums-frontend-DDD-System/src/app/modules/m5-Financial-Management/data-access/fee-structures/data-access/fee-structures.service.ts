import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  FeeStructure, 
  CreateFeeStructurePayload, 
  UpdateFeeStructurePayload 
} from '../../../../core/api/interfaces/M5_FinancialManagement/feestructure.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FeeStructures)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FeeStructuresService extends BaseApiService<
  FeeStructure, 
  CreateFeeStructurePayload, 
  UpdateFeeStructurePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FeeStructures';
  }
}
