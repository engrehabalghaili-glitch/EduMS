export enum UserRole {
  OFFICE_SUPERVISOR = 'OFFICE_SUPERVISOR',
  SCHOOL_PRINCIPAL = 'SCHOOL_PRINCIPAL',
  ASSETS_MANAGER = 'ASSETS_MANAGER',
  STUDENT_AFFAIRS = 'STUDENT_AFFAIRS',
  HR_MANAGER = 'HR_MANAGER',
  TEACHER = 'TEACHER',
  PARENT = 'PARENT',
  STUDENT = 'STUDENT'
}

export interface User {
  id: number;
  name: string;
  email: string;
  role: UserRole;
  token: string;
}
