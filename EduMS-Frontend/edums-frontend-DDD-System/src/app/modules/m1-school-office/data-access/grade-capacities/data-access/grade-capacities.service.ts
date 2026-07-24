import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  GradeCapacity, 
  CreateGradeCapacityDto, 
  UpdateGradeCapacityDto 
} from '@modules/m1-school-office/interface/grade-capacity';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (GradeCapacities)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class GradeCapacitiesService extends BaseApiService<
  GradeCapacity, 
  CreateGradeCapacityDto, 
  UpdateGradeCapacityDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/GradeCapacities';
  }
}
