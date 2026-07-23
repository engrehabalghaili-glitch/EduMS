import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StudentFinancePermission, 
  CreateStudentFinancePermissionPayload, 
  UpdateStudentFinancePermissionPayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/studentfinancepermission.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentFinancePermissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentFinancePermissionsService extends BaseApiService<
  StudentFinancePermission, 
  CreateStudentFinancePermissionPayload, 
  UpdateStudentFinancePermissionPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentFinancePermissions';
  }
}
