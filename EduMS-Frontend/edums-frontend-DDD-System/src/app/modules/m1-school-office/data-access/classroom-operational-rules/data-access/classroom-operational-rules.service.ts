import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  ClassroomOperationalRule, 
  CreateClassroomOperationalRuleDto, 
  UpdateClassroomOperationalRuleDto 
} from '@modules/m1-school-office/interface/classroom-operational-rule';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (ClassroomOperationalRules)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class ClassroomOperationalRulesService extends BaseApiService<
  ClassroomOperationalRule, 
  CreateClassroomOperationalRuleDto, 
  UpdateClassroomOperationalRuleDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/ClassroomOperationalRules';
  }
}
