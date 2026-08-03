import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentAcademicPermission, 
  CreateStudentAcademicPermission, 
  UpdateStudentAcademicPermission 
} from '@modules/m8-authentication-users/interfaces/student-academic-permission.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentAcademicPermissions)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentAcademicPermissionsService extends BaseApiService<
  StudentAcademicPermission, 
  CreateStudentAcademicPermission, 
  UpdateStudentAcademicPermission
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentAcademicPermissions';
  }
}
