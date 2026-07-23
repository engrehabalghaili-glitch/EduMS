import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StudentAttachment, 
  CreateStudentAttachmentPayload, 
  UpdateStudentAttachmentPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/studentattachment.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentAttachments)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentAttachmentsService extends BaseApiService<
  StudentAttachment, 
  CreateStudentAttachmentPayload, 
  UpdateStudentAttachmentPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentAttachments';
  }
}
