import { BaseAuditFields, FileFormat, GenerationMethod, ReportFrequency, ReportStatus } from './base.types';

export interface SystemReport extends BaseAuditFields {
  schoolId: number;
  reportType: string;
  reportSubType: string | null;
  reportTitle: string;
  reportFrequency: ReportFrequency;
  periodStart: string | null;
  periodEnd: string | null;
  generationDate: string;
  generationMethod: GenerationMethod;
  generatedByUserId: number | null;
  fileFormat: FileFormat | null;
  filePath: string | null;
  fileSizeBytes: number;
  reportStatus: ReportStatus;
  isPublished: boolean;
  publishedAt: string | null;
  publishedByUserId: number | null;
  viewCount: number;
  lastViewedAt: string | null;
  notes: string | null;
}

export type CreateSystemReport = Omit<SystemReport, 'id' | 'createdAt' | 'modifiedAt' | 'viewCount' | 'lastViewedAt'>;

export type UpdateSystemReport = Pick<SystemReport, 'id'> & Partial<Omit<SystemReport, 'id' | 'createdAt' | 'modifiedAt'>>;
