import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolLibraryItem, 
  CreateSchoolLibraryItemDto, 
  UpdateSchoolLibraryItemDto 
} from '@modules/m1-school-office/interface/school-library-item';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolLibraryItems)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolLibraryItemsService extends BaseApiService<
  SchoolLibraryItem, 
  CreateSchoolLibraryItemDto, 
  UpdateSchoolLibraryItemDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolLibraryItems';
  }
}
