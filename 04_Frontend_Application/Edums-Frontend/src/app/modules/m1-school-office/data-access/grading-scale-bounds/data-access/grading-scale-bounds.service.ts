import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  GradingScaleBound, 
  CreateGradingScaleBoundDto, 
  UpdateGradingScaleBoundDto 
} from '@modules/m1-school-office/interface/grading-scale-bound';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (GradingScaleBounds)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class GradingScaleBoundsService extends BaseApiService<
  GradingScaleBound, 
  CreateGradingScaleBoundDto, 
  UpdateGradingScaleBoundDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/GradingScaleBounds';
  }
}
