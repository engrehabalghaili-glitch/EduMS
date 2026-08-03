import { JournalEntryStatus, AuditFields } from './common.types';

export interface JournalEntry extends AuditFields {
  id: number;
  schoolId: number;
  entryNumber: string;
  entryDate: string;
  description: string;
  status: JournalEntryStatus;
}

export type CreateJournalEntryDto = Omit<JournalEntry, 'id' | 'createdAt'>;

export type UpdateJournalEntryDto = Omit<JournalEntry, 'createdAt'>;
