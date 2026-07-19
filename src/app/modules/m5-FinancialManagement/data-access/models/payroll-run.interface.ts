import { PayrollStatus, AuditFields } from './common.types';

export interface PayrollRun extends AuditFields {
  id: number;
  runNumber: string;
  month: number;
  year: number;
  processDate: string;
  description: string;
  status: PayrollStatus;
}

export type CreatePayrollRunDto = Omit<PayrollRun, 'id' | 'createdAt'>;

export type UpdatePayrollRunDto = Omit<PayrollRun, 'createdAt'>;
