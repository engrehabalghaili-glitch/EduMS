import { Injectable } from '@angular/core';
import { BaseApiService } from '@base-api';
import { 
  Account, 
  CreateAccountDto, 
  UpdateAccountDto 
} from '@modules/m5-Financial-Management/interfaces/account.interface';

/**
 * خدمة (Service) متخصصة لإدارة عمليات (Accounts)
 * تم توليد هذه الخدمة آلياً لترث كافة العمليات الأساسية (CRUD) من الكلاس المركزي BaseApiService.
 * 
 * @extends BaseApiService
 * @description هذه الخدمة تعمل كـ "العقل" لمعالجة البيانات وتتصل مباشرة برابط الباك إند المخصص.
 */
@Injectable({ providedIn: 'root' })
export class AccountsService extends BaseApiService<
  Account, 
  CreateAccountDto, 
  UpdateAccountDto
> {
  /**
   * الرابط الأساسي للـ API المستخرج من الـ Controller في الباك إند
   */
  protected override get baseUrl(): string {
    return '/api/v1/Accounts';
  }
}
