export interface CreateStudentExemplaryRecognitionPayload {
    studentId: number;
    academicYear: string;
    semesterNumber: number;
    recognitionTitleAr: string;
    category: number;
    awardDate: string;
    certificateNumber?: string;
    recognitionTitleEn?: string;
    awardGrantedBy?: string;
    meritBonusPoints: number;
    isFeaturedInSchoolBoard: boolean;
}

export interface StudentExemplaryRecognition {
    id: number;
    studentId: number;
    academicYear: string;
    semesterNumber: number;
    recognitionTitleAr: string;
    category: number;
    awardDate: string;
    certificateNumber?: string;
    recognitionTitleEn?: string;
    awardGrantedBy?: string;
    meritBonusPoints: number;
    isFeaturedInSchoolBoard: boolean;
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

export interface UpdateStudentExemplaryRecognitionPayload {
    id?: number;
    academicYear?: string;
    semesterNumber?: number;
    recognitionTitleAr?: string;
    category?: number;
    awardDate?: string;
    certificateNumber?: string;
    recognitionTitleEn?: string;
    awardGrantedBy?: string;
    meritBonusPoints?: number;
    isFeaturedInSchoolBoard?: boolean;
}
