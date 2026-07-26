import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  OrganizationalSector, 
  CreateOrganizationalSector, 
  UpdateOrganizationalSector 
} from '@modules/m3-employee-management/interfaces/organizational-sector.types';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (OrganizationalSectors)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class OrganizationalSectorsService extends BaseApiService<
  OrganizationalSector, 
  CreateOrganizationalSector, 
  UpdateOrganizationalSector
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/OrganizationalSectors';
  }
}
