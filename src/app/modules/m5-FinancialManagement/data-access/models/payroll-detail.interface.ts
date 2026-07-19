import { PayrollStatus, AuditFields } from './common.types';

export interface PayrollDetail extends AuditFields {
  id: number;
  payrollRunId: number;
  employeeId: number;
  baseSalary: number;
  totalAllowances: number;
  totalDeductions: number;
  netSalary: number;
  status: PayrollStatus;
}

export type CreatePayrollDetailDto = Omit<PayrollDetail, 'id' | 'createdAt'>;

export type UpdatePayrollDetailDto = Omit<PayrollDetail, 'createdAt'>;
