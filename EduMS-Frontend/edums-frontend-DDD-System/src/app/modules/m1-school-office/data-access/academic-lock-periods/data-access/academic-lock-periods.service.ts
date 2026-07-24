import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AcademicLockPeriod, 
  CreateAcademicLockPeriodDto, 
  UpdateAcademicLockPeriodDto 
} from '@modules/m1-school-office/interface/academic-lock-period';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AcademicLockPeriods)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AcademicLockPeriodsService extends BaseApiService<
  AcademicLockPeriod, 
  CreateAcademicLockPeriodDto, 
  UpdateAcademicLockPeriodDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AcademicLockPeriods';
  }
}
