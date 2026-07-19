export interface SchoolShift {
  id: number;
  schoolId: number;
  shiftNameAr: string;
  shiftNameEn: string;
  startTime: string;
  endTime: string;
  shiftCode: string | null;
  totalPeriodsCount: number;
  periodDurationMinutes: number;
  breakDurationMinutes: number;
  isActive: boolean;
}

export type CreateSchoolShiftDto = Omit<SchoolShift, 'id' | 'isActive'>;

export type UpdateSchoolShiftDto = Omit<SchoolShift, 'schoolId' | 'isActive'>;
