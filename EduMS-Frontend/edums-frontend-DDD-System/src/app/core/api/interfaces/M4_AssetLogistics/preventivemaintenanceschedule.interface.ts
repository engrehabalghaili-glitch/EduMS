export interface CreatePreventiveMaintenanceSchedulePayload {
    schoolId: number;
    scheduleCode: string;
    assetId?: number;
    assetCategoryId?: number;
    taskNameAr: string;
    taskNameEn?: string;
    maintenanceType: number;
    frequencyUnit: number;
    frequencyValue: number;
    nextDueDate?: string;
    lastServiceDate?: string;
    estimatedDurationMinutes: number;
    assignedToTeamText?: string;
    instructionsText?: string;
    checklistJson?: string;
    estimatedCost: number;
    maintenanceContractId?: number;
    isReminderActive: boolean;
    reminderDaysBefore: number;
    scheduleStatus: number;
    notes?: string;
}

export interface PreventiveMaintenanceSchedule {
    id: number;
    schoolId: number;
    scheduleCode: string;
    assetId?: number;
    assetCategoryId?: number;
    taskNameAr: string;
    taskNameEn?: string;
    maintenanceType: number;
    frequencyUnit: number;
    frequencyValue: number;
    nextDueDate?: string;
    lastServiceDate?: string;
    estimatedDurationMinutes: number;
    assignedToTeamText?: string;
    instructionsText?: string;
    checklistJson?: string;
    estimatedCost: number;
    maintenanceContractId?: number;
    isReminderActive: boolean;
    reminderDaysBefore: number;
    scheduleStatus: number;
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

export interface UpdatePreventiveMaintenanceSchedulePayload {
    id?: number;
    schoolId?: number;
    scheduleCode?: string;
    assetId?: number;
    assetCategoryId?: number;
    taskNameAr?: string;
    taskNameEn?: string;
    maintenanceType?: number;
    frequencyUnit?: number;
    frequencyValue?: number;
    nextDueDate?: string;
    lastServiceDate?: string;
    estimatedDurationMinutes?: number;
    assignedToTeamText?: string;
    instructionsText?: string;
    checklistJson?: string;
    estimatedCost?: number;
    maintenanceContractId?: number;
    isReminderActive?: boolean;
    reminderDaysBefore?: number;
    scheduleStatus?: number;
    notes?: string;
}
