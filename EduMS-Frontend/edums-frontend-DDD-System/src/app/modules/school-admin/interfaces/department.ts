import type { DepartmentType } from './common';

export interface Department {
  id: number;
  schoolId: number;
  departmentCode: string;
  departmentNameAr: string;
  departmentNameEn: string;
  departmentType: DepartmentType;
  responsibilities: string | null;
  annualBudget: number;
  employeeCount: number;
  headOfDepartmentEmployeeId: number | null;
  workingHoursDescription: string | null;
  establishmentDate: string | null;
  isActive: boolean;
}

export type CreateDepartmentDto = Omit<Department, 'id' | 'isActive'>;

export type UpdateDepartmentDto = Omit<Department, 'schoolId' | 'isActive'>;
