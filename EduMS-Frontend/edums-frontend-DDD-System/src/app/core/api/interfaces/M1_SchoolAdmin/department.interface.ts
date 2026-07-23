export interface CreateDepartmentPayload {
    schoolId: number;
    departmentCode: string;
    departmentNameAr: string;
    departmentNameEn: string;
    departmentType: number;
    responsibilities?: string;
    annualBudget: number;
    employeeCount: number;
    headOfDepartmentEmployeeId?: number;
    workingHoursDescription?: string;
    establishmentDate?: string;
}

export interface Department {
    id: number;
    schoolId: number;
    departmentCode: string;
    departmentNameAr: string;
    departmentNameEn: string;
    departmentType: number;
    responsibilities?: string;
    annualBudget: number;
    employeeCount: number;
    headOfDepartmentEmployeeId?: number;
    workingHoursDescription?: string;
    establishmentDate?: string;
    isActive: boolean;
    createdAt: string;
    createdByUserId: number;
    modifiedAt?: string;
    modifiedByUserId?: number;
    isDeleted: boolean;
    deletedAt?: string;
    deletedByUserId?: number;
    versionToken: string;
    lastSyncedAt?: string;
    syncStatus: string;
}

export interface UpdateDepartmentPayload {
    id?: number;
    departmentCode?: string;
    departmentNameAr?: string;
    departmentNameEn?: string;
    departmentType?: number;
    responsibilities?: string;
    annualBudget?: number;
    employeeCount?: number;
    headOfDepartmentEmployeeId?: number;
    workingHoursDescription?: string;
    establishmentDate?: string;
}
