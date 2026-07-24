export interface CurriculumTextbookDistribution {
  id: number;
  schoolId: number;
  subjectId: number;
  textbookCode: string;
  textbookTitleAr: string;
  textbookTitleEn: string;
  editionYear: number;
  quantityAllocated: number;
  quantityDistributed: number;
  distributionDate: string;
  targetGradeLevel: number;
  unitCost: number;
  totalValueAmount: number;
  warehouseLocationCode: string | null;
  isActive: boolean;
}

export type CreateCurriculumTextbookDistributionDto = Omit<CurriculumTextbookDistribution, 'id' | 'isActive'>;

export type UpdateCurriculumTextbookDistributionDto = Omit<CurriculumTextbookDistribution, 'schoolId' | 'isActive'>;
