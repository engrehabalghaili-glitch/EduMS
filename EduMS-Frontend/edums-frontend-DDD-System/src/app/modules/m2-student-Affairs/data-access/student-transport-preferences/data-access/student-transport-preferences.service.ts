import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentTransportPreference, 
  CreateStudentTransportPreference, 
  UpdateStudentTransportPreference 
} from '@modules/m2-student-Affairs/interfaces/transport-preference.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentTransportPreferences)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentTransportPreferencesService extends BaseApiService<
  StudentTransportPreference, 
  CreateStudentTransportPreference, 
  UpdateStudentTransportPreference
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentTransportPreferences';
  }
}
