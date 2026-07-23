import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  Directorate, 
  CreateDirectoratePayload, 
  UpdateDirectoratePayload 
} from '../../../../core/api/interfaces/M1_SchoolAdmin/directorate.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Directorates)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class DirectoratesService extends BaseApiService<
  Directorate, 
  CreateDirectoratePayload, 
  UpdateDirectoratePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Directorates';
  }
}
