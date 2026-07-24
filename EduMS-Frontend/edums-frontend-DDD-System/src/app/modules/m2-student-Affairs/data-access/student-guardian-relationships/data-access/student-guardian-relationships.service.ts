import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentGuardianRelationship, 
  CreateStudentGuardianRelationship, 
  UpdateStudentGuardianRelationship 
} from '@modules/m2-student-Affairs/interfaces/guardian-relationship.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentGuardianRelationships)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentGuardianRelationshipsService extends BaseApiService<
  StudentGuardianRelationship, 
  CreateStudentGuardianRelationship, 
  UpdateStudentGuardianRelationship
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentGuardianRelationships';
  }
}
