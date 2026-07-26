import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentFinancialAidApplication, 
  CreateStudentFinancialAidApplication, 
  UpdateStudentFinancialAidApplication 
} from '@modules/m2-student-Affairs/interfaces/financial-aid-application.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentFinancialAidApplications)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentFinancialAidApplicationsService extends BaseApiService<
  StudentFinancialAidApplication, 
  CreateStudentFinancialAidApplication, 
  UpdateStudentFinancialAidApplication
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentFinancialAidApplications';
  }
}
