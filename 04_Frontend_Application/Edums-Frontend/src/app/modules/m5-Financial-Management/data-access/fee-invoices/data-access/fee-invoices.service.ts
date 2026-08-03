import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  FeeInvoice, 
  CreateFeeInvoiceDto, 
  UpdateFeeInvoiceDto 
} from '@modules/m5-Financial-Management/interfaces/fee-invoice.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FeeInvoices)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FeeInvoicesService extends BaseApiService<
  FeeInvoice, 
  CreateFeeInvoiceDto, 
  UpdateFeeInvoiceDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FeeInvoices';
  }
}
