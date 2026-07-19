import { AccountType, AuditFields } from './common.types';

export interface Account extends AuditFields {
  id: number;
  schoolId: number | null;
  accountCode: string;
  accountNameAr: string;
  accountNameEn: string;
  parentAccountId: number | null;
  accountType: AccountType;
  levelNumber: number;
  currentBalance: number;
  isActive: boolean;
}

export type CreateAccountDto = Omit<Account, 'id' | 'createdAt'>;

export type UpdateAccountDto = Omit<Account, 'createdAt'>;
