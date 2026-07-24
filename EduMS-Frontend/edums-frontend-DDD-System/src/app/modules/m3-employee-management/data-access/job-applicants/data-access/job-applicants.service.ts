import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  JobApplicant, 
  CreateJobApplicantPayload, 
  UpdateJobApplicantPayload 
} from '../../../../core/api/interfaces/M3_EmployeeManagement/jobapplicant.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (JobApplicants)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class JobApplicantsService extends BaseApiService<
  JobApplicant, 
  CreateJobApplicantPayload, 
  UpdateJobApplicantPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/JobApplicants';
  }
}
