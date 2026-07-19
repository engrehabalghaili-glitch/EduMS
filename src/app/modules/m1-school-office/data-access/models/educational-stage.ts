export interface EducationalStage {
  id: number;
  stageCode: string;
  stageNameAr: string;
  stageNameEn: string;
  minAge: number;
  maxAge: number;
  defaultDurationYears: number;
  ministryCurriculumCode: string | null;
  requiresGraduationCertificate: boolean;
  displayOrder: number;
  isActive: boolean;
}

export type CreateEducationalStageDto = Omit<EducationalStage, 'id' | 'isActive'>;

export type UpdateEducationalStageDto = Omit<EducationalStage, 'isActive'>;
