import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  Vendor, 
  CreateVendorDto, 
  UpdateVendorDto 
} from '@modules/m5-Financial-Management/interfaces/vendor.interface';

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
  CreateVendorDto, 
  UpdateVendorDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Vendors';
  }
}
