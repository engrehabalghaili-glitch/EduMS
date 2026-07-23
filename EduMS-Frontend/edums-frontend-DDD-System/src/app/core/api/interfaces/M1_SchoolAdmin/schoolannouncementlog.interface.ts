export interface CreateSchoolAnnouncementLogPayload {
    schoolId: number;
    titleAr: string;
    titleEn: string;
    announcementContent: string;
    publishDate: string;
    expireDate?: string;
    targetAudience: number;
    isPinned: boolean;
    announcementPriority: number;
    attachmentFileUrl?: string;
    viewCount: number;
    publishedByEmployeeId?: number;
}

export interface SchoolAnnouncementLog {
    id: number;
    schoolId: number;
    titleAr: string;
    titleEn: string;
    announcementContent: string;
    publishDate: string;
    expireDate?: string;
    targetAudience: number;
    isPinned: boolean;
    announcementPriority: number;
    attachmentFileUrl?: string;
    viewCount: number;
    publishedByEmployeeId?: number;
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

export interface UpdateSchoolAnnouncementLogPayload {
    id?: number;
    titleAr?: string;
    titleEn?: string;
    announcementContent?: string;
    publishDate?: string;
    expireDate?: string;
    targetAudience?: number;
    isPinned?: boolean;
    announcementPriority?: number;
    attachmentFileUrl?: string;
    viewCount?: number;
    publishedByEmployeeId?: number;
}
