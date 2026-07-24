import { Injectable } from '@angular/core';
import { BaseApiService } from '../../../../core/api/services/base-api.service';
import { 
  StudentLibraryBorrowingLog, 
  CreateStudentLibraryBorrowingLogPayload, 
  UpdateStudentLibraryBorrowingLogPayload 
} from '../../../../core/api/interfaces/M2_StudentAffairs/studentlibraryborrowinglog.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (StudentLibraryBorrowingLogs)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class StudentLibraryBorrowingLogsService extends BaseApiService<
  StudentLibraryBorrowingLog, 
  CreateStudentLibraryBorrowingLogPayload, 
  UpdateStudentLibraryBorrowingLogPayload
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentLibraryBorrowingLogs';
  }
}
