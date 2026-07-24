import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  BehavioralLog, 
  CreateBehavioralLog, 
  UpdateBehavioralLog 
} from '@modules/m2-student-Affairs/interfaces/behavioral-log.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (BehavioralLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class BehavioralLogsService extends BaseApiService<
  BehavioralLog, 
  CreateBehavioralLog, 
  UpdateBehavioralLog
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/BehavioralLogs';
  }
}
