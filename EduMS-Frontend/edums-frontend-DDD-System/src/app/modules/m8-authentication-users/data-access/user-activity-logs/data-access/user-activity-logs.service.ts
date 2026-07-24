import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  UserActivityLog, 
  CreateUserActivityLogPayload, 
  UpdateUserActivityLogPayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/useractivitylog.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (UserActivityLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class UserActivityLogsService extends BaseApiService<
  UserActivityLog, 
  CreateUserActivityLogPayload, 
  UpdateUserActivityLogPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/UserActivityLogs';
  }
}
