import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentInventoryCustody, 
  CreateStudentInventoryCustody, 
  UpdateStudentInventoryCustody 
} from '@modules/m2-student-Affairs/interfaces/inventory-custody.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentInventoryCustodies)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentInventoryCustodiesService extends BaseApiService<
  StudentInventoryCustody, 
  CreateStudentInventoryCustody, 
  UpdateStudentInventoryCustody
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentInventoryCustodies';
  }
}
