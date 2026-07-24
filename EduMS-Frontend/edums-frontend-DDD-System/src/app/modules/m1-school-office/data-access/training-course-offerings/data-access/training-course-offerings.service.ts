import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  TrainingCourseOffering, 
  CreateTrainingCourseOfferingDto, 
  UpdateTrainingCourseOfferingDto 
} from '@modules/m1-school-office/interface/training-course-offering';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (TrainingCourseOfferings)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class TrainingCourseOfferingsService extends BaseApiService<
  TrainingCourseOffering, 
  CreateTrainingCourseOfferingDto, 
  UpdateTrainingCourseOfferingDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/TrainingCourseOfferings';
  }
}
