import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  FeePayment, 
  CreateFeePaymentDto, 
  UpdateFeePaymentDto 
} from '@modules/m5-Financial-Management/interfaces/fee-payment.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FeePayments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FeePaymentsService extends BaseApiService<
  FeePayment, 
  CreateFeePaymentDto, 
  UpdateFeePaymentDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FeePayments';
  }
}
