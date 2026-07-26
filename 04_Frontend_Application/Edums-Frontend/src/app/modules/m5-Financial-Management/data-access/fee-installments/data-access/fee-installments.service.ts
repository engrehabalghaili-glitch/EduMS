import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  FeeInstallment, 
  CreateFeeInstallmentDto, 
  UpdateFeeInstallmentDto 
} from '@modules/m5-Financial-Management/interfaces/fee-installment.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FeeInstallments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FeeInstallmentsService extends BaseApiService<
  FeeInstallment, 
  CreateFeeInstallmentDto, 
  UpdateFeeInstallmentDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FeeInstallments';
  }
}
