import type { TargetAudience, Priority } from './common';

export interface SchoolAnnouncementLog {
  id: number;
  schoolId: number;
  titleAr: string;
  titleEn: string;
  announcementContent: string;
  publishDate: string;
  expireDate: string | null;
  targetAudience: TargetAudience;
  isPinned: boolean;
  announcementPriority: Priority;
  attachmentFileUrl: string | null;
  viewCount: number;
  publishedByEmployeeId: number | null;
  isActive: boolean;
}

export type CreateSchoolAnnouncementLogDto = Omit<SchoolAnnouncementLog, 'id' | 'viewCount' | 'isActive'>;

export type UpdateSchoolAnnouncementLogDto = Omit<SchoolAnnouncementLog, 'schoolId' | 'viewCount' | 'isActive'>;
