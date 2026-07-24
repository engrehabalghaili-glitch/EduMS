import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  StudentLibraryBorrowingLog, 
  CreateStudentLibraryBorrowingLog, 
  UpdateStudentLibraryBorrowingLog 
} from '@modules/m2-student-Affairs/interfaces/library-borrowing.interface';

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
  CreateStudentLibraryBorrowingLog, 
  UpdateStudentLibraryBorrowingLog
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/StudentLibraryBorrowingLogs';
  }
}
