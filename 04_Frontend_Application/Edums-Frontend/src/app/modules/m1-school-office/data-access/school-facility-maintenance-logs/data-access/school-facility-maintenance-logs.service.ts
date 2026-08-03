import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  SchoolFacilityMaintenanceLog, 
  CreateSchoolFacilityMaintenanceLogDto, 
  UpdateSchoolFacilityMaintenanceLogDto 
} from '@modules/m1-school-office/interface/school-facility-maintenance-log';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SchoolFacilityMaintenanceLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SchoolFacilityMaintenanceLogsService extends BaseApiService<
  SchoolFacilityMaintenanceLog, 
  CreateSchoolFacilityMaintenanceLogDto, 
  UpdateSchoolFacilityMaintenanceLogDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SchoolFacilityMaintenanceLogs';
  }
}
