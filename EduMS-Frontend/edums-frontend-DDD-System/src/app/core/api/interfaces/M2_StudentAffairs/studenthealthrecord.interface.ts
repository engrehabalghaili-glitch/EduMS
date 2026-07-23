export interface CreateStudentHealthRecordPayload {
    studentId: number;
    recordDate: string;
    examinationDetails?: string;
    diagnosis?: string;
    treatmentPlan?: string;
    referralHospital?: string;
    examinedByNurseName?: string;
    healthRecordCode?: string;
    physicalHeightCm: number;
    physicalWeightKg: number;
    visionCheckResult?: string;
    hearingCheckResult?: string;
    isFitForPhysicalEducation: boolean;
    nextCheckupDate?: string;
}

export interface StudentHealthRecord {
    id: number;
    studentId: number;
    recordDate: string;
    examinationDetails?: string;
    diagnosis?: string;
    treatmentPlan?: string;
    referralHospital?: string;
    examinedByNurseName?: string;
    healthStatus: number;
    healthRecordCode?: string;
    physicalHeightCm: number;
    physicalWeightKg: number;
    visionCheckResult?: string;
    hearingCheckResult?: string;
    isFitForPhysicalEducation: boolean;
    nextCheckupDate?: string;
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

export interface UpdateStudentHealthRecordPayload {
    id?: number;
    recordDate?: string;
    examinationDetails?: string;
    diagnosis?: string;
    treatmentPlan?: string;
    referralHospital?: string;
    examinedByNurseName?: string;
    healthRecordCode?: string;
    physicalHeightCm?: number;
    physicalWeightKg?: number;
    visionCheckResult?: string;
    hearingCheckResult?: string;
    isFitForPhysicalEducation?: boolean;
    nextCheckupDate?: string;
}
