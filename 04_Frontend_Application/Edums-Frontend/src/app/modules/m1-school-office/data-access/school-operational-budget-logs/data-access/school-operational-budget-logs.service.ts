import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolOperationalBudgetLog, 
  CreateSchoolOperationalBudgetLogDto, 
  UpdateSchoolOperationalBudgetLogDto 
} from '@modules/m1-school-office/interface/school-operational-budget-log';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolOperationalBudgetLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolOperationalBudgetLogsService extends BaseApiService<
  SchoolOperationalBudgetLog, 
  CreateSchoolOperationalBudgetLogDto, 
  UpdateSchoolOperationalBudgetLogDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolOperationalBudgetLogs';
  }
}
