export interface Directorate {
  id: number;
  directorateCode: string;
  directorateNameAr: string;
  directorateNameEn: string;
  address: string | null;
  contactPhone: string | null;
  contactEmail: string | null;
  directorName: string | null;
  governorate: string | null;
  establishmentDate: string | null;
  regionCode: string | null;
  supervisoryScopeDescription: string | null;
  annualBudgetLimit: number;
  employeeCount: number;
  isActive: boolean;
}

export type CreateDirectorateDto = Omit<Directorate, 'id' | 'isActive'>;

export type UpdateDirectorateDto = Omit<Directorate, 'isActive'>;
