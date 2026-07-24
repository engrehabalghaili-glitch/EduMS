import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  AcademicBranchConfigLog, 
  CreateAcademicBranchConfigLogDto, 
  UpdateAcademicBranchConfigLogDto 
} from '@modules/m1-school-office/interface/academic-branch-config-log';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (AcademicBranchConfigLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AcademicBranchConfigLogsService extends BaseApiService<
  AcademicBranchConfigLog, 
  CreateAcademicBranchConfigLogDto, 
  UpdateAcademicBranchConfigLogDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/AcademicBranchConfigLogs';
  }
}
