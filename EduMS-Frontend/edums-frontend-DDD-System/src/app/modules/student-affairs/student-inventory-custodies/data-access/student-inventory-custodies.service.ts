import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StudentInventoryCustody, 
  CreateStudentInventoryCustodyPayload, 
  UpdateStudentInventoryCustodyPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/studentinventorycustody.interface';

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
  CreateStudentInventoryCustodyPayload, 
  UpdateStudentInventoryCustodyPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentInventoryCustodies';
  }
}
