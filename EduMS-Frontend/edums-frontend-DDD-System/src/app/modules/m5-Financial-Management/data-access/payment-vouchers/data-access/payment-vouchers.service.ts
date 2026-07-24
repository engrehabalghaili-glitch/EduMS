import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  PaymentVoucher, 
  CreatePaymentVoucherDto, 
  UpdatePaymentVoucherDto 
} from '@modules/m5-Financial-Management/interfaces/payment-voucher.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (PaymentVouchers)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class PaymentVouchersService extends BaseApiService<
  PaymentVoucher, 
  CreatePaymentVoucherDto, 
  UpdatePaymentVoucherDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/PaymentVouchers';
  }
}
