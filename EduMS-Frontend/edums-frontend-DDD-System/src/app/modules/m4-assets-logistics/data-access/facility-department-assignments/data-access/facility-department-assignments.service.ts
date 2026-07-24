import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  FacilityDepartmentAssignment, 
  CreateFacilityDepartmentAssignmentRequest, 
  UpdateFacilityDepartmentAssignmentRequest 
} from '@modules/m4-assets-logistics/interfaces/facility-department-assignments';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (FacilityDepartmentAssignments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class FacilityDepartmentAssignmentsService extends BaseApiService<
  FacilityDepartmentAssignment, 
  CreateFacilityDepartmentAssignmentRequest, 
  UpdateFacilityDepartmentAssignmentRequest
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/FacilityDepartmentAssignments';
  }
}
