import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentSkillAndTalentRecord, 
  CreateStudentSkillAndTalentRecord, 
  UpdateStudentSkillAndTalentRecord 
} from '@modules/m2-student-Affairs/interfaces/skill-talent.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentSkillAndTalentRecords)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentSkillAndTalentRecordsService extends BaseApiService<
  StudentSkillAndTalentRecord, 
  CreateStudentSkillAndTalentRecord, 
  UpdateStudentSkillAndTalentRecord
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentSkillAndTalentRecords';
  }
}
