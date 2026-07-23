export interface CreateStudentAdmissionApplicationPayload {
    guardianId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    requestedGradeLevelCode: string;
    submissionDate: string;
    birthCertificateAttachmentUrl?: string;
    personalPhotoAttachmentUrl?: string;
    previousSchoolName?: string;
    previousSchoolGradeLevel?: string;
    hasSpecialNeeds: boolean;
    specialNeedsDetails?: string;
    medicalNotes?: string;
    hasSiblingInSchool: boolean;
    siblingNames?: string;
    referralSource?: string;
    emergencyContactName?: string;
    emergencyContactPhone?: string;
    reviewedByEmployeeId?: number;
    reviewDate?: string;
    rejectionReason?: string;
    approvalDate?: string;
    convertedToStudentId?: number;
}

export interface StudentAdmissionApplication {
    id: number;
    guardianId: number;
    schoolId: number;
    schoolAcademicYearId?: number;
    requestedGradeLevelCode: string;
    submissionDate: string;
    requestStatus: number;
    birthCertificateAttachmentUrl?: string;
    personalPhotoAttachmentUrl?: string;
    previousSchoolName?: string;
    previousSchoolGradeLevel?: string;
    hasSpecialNeeds: boolean;
    specialNeedsDetails?: string;
    medicalNotes?: string;
    hasSiblingInSchool: boolean;
    siblingNames?: string;
    referralSource?: string;
    emergencyContactName?: string;
    emergencyContactPhone?: string;
    reviewedByEmployeeId?: number;
    reviewDate?: string;
    rejectionReason?: string;
    approvalDate?: string;
    convertedToStudentId?: number;
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

export interface UpdateStudentAdmissionApplicationPayload {
    id?: number;
    guardianId?: number;
    schoolAcademicYearId?: number;
    requestedGradeLevelCode?: string;
    submissionDate?: string;
    birthCertificateAttachmentUrl?: string;
    personalPhotoAttachmentUrl?: string;
    previousSchoolName?: string;
    previousSchoolGradeLevel?: string;
    hasSpecialNeeds?: boolean;
    specialNeedsDetails?: string;
    medicalNotes?: string;
    hasSiblingInSchool?: boolean;
    siblingNames?: string;
    referralSource?: string;
    emergencyContactName?: string;
    emergencyContactPhone?: string;
    reviewedByEmployeeId?: number;
    reviewDate?: string;
    rejectionReason?: string;
    approvalDate?: string;
    convertedToStudentId?: number;
}
