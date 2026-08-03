import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  BehaviorPermissionRecord, 
  CreateBehaviorPermissionRecord, 
  UpdateBehaviorPermissionRecord 
} from '@modules/m8-authentication-users/interfaces/behavior-permission-record.models';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (BehaviorPermissionRecords)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class BehaviorPermissionRecordsService extends BaseApiService<
  BehaviorPermissionRecord, 
  CreateBehaviorPermissionRecord, 
  UpdateBehaviorPermissionRecord
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/BehaviorPermissionRecords';
  }
}
