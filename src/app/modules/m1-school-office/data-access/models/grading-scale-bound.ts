export interface GradingScaleBound {
  id: number;
  schoolId: number;
  scaleName: string;
  letterCode: string;
  minPercentage: number;
  maxPercentage: number;
  gradePointValue: number;
  descriptionAr: string | null;
  descriptionEn: string | null;
  scaleCode: string | null;
  isPassingGrade: boolean;
  displayOrder: number;
  isActive: boolean;
}

export type CreateGradingScaleBoundDto = Omit<GradingScaleBound, 'id' | 'isActive'>;

export type UpdateGradingScaleBoundDto = Omit<GradingScaleBound, 'schoolId' | 'isActive'>;
