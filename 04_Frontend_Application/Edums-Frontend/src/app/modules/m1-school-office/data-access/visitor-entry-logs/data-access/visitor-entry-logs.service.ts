import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  VisitorEntryLog, 
  CreateVisitorEntryLogDto, 
  UpdateVisitorEntryLogDto 
} from '@modules/m1-school-office/interface/visitor-entry-log';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (VisitorEntryLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class VisitorEntryLogsService extends BaseApiService<
  VisitorEntryLog, 
  CreateVisitorEntryLogDto, 
  UpdateVisitorEntryLogDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/VisitorEntryLogs';
  }
}
