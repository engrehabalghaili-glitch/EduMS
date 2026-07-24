import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  Person, 
  CreatePersonPayload, 
  UpdatePersonPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/person.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Persons)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class PersonsService extends BaseApiService<
  Person, 
  CreatePersonPayload, 
  UpdatePersonPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Persons';
  }
}
