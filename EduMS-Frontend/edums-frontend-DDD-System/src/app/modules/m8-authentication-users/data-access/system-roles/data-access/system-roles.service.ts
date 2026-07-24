import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  SystemRole, 
  CreateSystemRolePayload, 
  UpdateSystemRolePayload 
} from '../../../../core/api/interfaces/M8_AuthenticationUsers/systemrole.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (SystemRoles)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class SystemRolesService extends BaseApiService<
  SystemRole, 
  CreateSystemRolePayload, 
  UpdateSystemRolePayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/SystemRoles';
  }
}
