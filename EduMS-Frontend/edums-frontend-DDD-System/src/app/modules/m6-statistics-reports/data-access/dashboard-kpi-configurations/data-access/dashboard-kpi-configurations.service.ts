import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  DashboardKpiConfiguration, 
  CreateDashboardKpiConfigurationPayload, 
  UpdateDashboardKpiConfigurationPayload 
} from '../../../../core/api/interfaces/M6_StatisticsReports/dashboardkpiconfiguration.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (DashboardKpiConfigurations)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class DashboardKpiConfigurationsService extends BaseApiService<
  DashboardKpiConfiguration, 
  CreateDashboardKpiConfigurationPayload, 
  UpdateDashboardKpiConfigurationPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/DashboardKpiConfigurations';
  }
}
