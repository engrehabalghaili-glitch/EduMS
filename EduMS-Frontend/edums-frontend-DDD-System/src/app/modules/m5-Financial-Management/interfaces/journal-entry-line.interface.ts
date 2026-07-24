import { AuditFields } from './common.types';

export interface JournalEntryLine extends AuditFields {
  id: number;
  journalEntryId: number;
  accountId: number;
  debitAmount: number;
  creditAmount: number;
  description: string;
}

export type CreateJournalEntryLineDto = Omit<JournalEntryLine, 'id' | 'createdAt'>;

export type UpdateJournalEntryLineDto = Omit<JournalEntryLine, 'createdAt'>;
