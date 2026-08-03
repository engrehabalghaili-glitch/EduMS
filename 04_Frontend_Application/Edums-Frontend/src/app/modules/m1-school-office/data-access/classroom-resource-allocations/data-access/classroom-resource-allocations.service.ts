import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  ClassroomResourceAllocation, 
  CreateClassroomResourceAllocationDto, 
  UpdateClassroomResourceAllocationDto 
} from '@modules/m1-school-office/interface/classroom-resource-allocation';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (ClassroomResourceAllocations)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ClassroomResourceAllocationsService extends BaseApiService<
  ClassroomResourceAllocation, 
  CreateClassroomResourceAllocationDto, 
  UpdateClassroomResourceAllocationDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/ClassroomResourceAllocations';
  }
}
