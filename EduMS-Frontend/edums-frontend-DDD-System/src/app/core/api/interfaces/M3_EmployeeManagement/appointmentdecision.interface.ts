export interface AppointmentDecision {
    id: number;
    employeeId: number;
    decisionNumber: string;
    decisionDate: string;
    decisionSource: number;
    decisionType: number;
    jobTitle: string;
    jobGrade?: string;
    departmentId?: number;
    employmentType: number;
    startDate: string;
    probationPeriodMonths: number;
    probationEndDate?: string;
    salaryAmount: number;
    allowanceDetailsJson?: string;
    otherBenefits?: string;
    attachmentUrl?: string;
    approvedByName?: string;
    approvedByTitle?: string;
    notes?: string;
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

export interface CreateAppointmentDecisionPayload {
    employeeId: number;
    decisionNumber: string;
    decisionDate: string;
    decisionSource: number;
    decisionType: number;
    jobTitle: string;
    jobGrade?: string;
    departmentId?: number;
    employmentType: number;
    startDate: string;
    probationPeriodMonths: number;
    probationEndDate?: string;
    salaryAmount: number;
    allowanceDetailsJson?: string;
    otherBenefits?: string;
    attachmentUrl?: string;
    approvedByName?: string;
    approvedByTitle?: string;
    notes?: string;
}

export interface UpdateAppointmentDecisionPayload {
    id?: number;
    employeeId?: number;
    decisionNumber?: string;
    decisionDate?: string;
    decisionSource?: number;
    decisionType?: number;
    jobTitle?: string;
    jobGrade?: string;
    departmentId?: number;
    employmentType?: number;
    startDate?: string;
    probationPeriodMonths?: number;
    probationEndDate?: string;
    salaryAmount?: number;
    allowanceDetailsJson?: string;
    otherBenefits?: string;
    attachmentUrl?: string;
    approvedByName?: string;
    approvedByTitle?: string;
    notes?: string;
}
