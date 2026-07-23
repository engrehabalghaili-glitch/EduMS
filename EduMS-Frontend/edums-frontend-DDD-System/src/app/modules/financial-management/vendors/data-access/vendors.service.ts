import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  Vendor, 
  CreateVendorPayload, 
  UpdateVendorPayload 
} from '../../../../core/api/interfaces/M5_FinancialManagement/vendor.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Vendors)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class VendorsService extends BaseApiService<
  Vendor, 
  CreateVendorPayload, 
  UpdateVendorPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Vendors';
  }
}
