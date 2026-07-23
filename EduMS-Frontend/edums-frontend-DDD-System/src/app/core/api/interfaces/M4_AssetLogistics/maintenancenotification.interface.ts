export interface CreateMaintenanceNotificationPayload {
    schoolId: number;
    relatedEntityType: string;
    relatedEntityId: number;
    notificationType: number;
    title: string;
    messageContent: string;
    recipientUserId: number;
    priority: number;
    isRead: boolean;
    readAt?: string;
    sentAt: string;
    deliveryMethod: number;
    notificationStatus: number;
}

export interface MaintenanceNotification {
    id: number;
    schoolId: number;
    relatedEntityType: string;
    relatedEntityId: number;
    notificationType: number;
    title: string;
    messageContent: string;
    recipientUserId: number;
    priority: number;
    isRead: boolean;
    readAt?: string;
    sentAt: string;
    deliveryMethod: number;
    notificationStatus: number;
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

export interface UpdateMaintenanceNotificationPayload {
    id?: number;
    schoolId?: number;
    relatedEntityType?: string;
    relatedEntityId?: number;
    notificationType?: number;
    title?: string;
    messageContent?: string;
    recipientUserId?: number;
    priority?: number;
    isRead?: boolean;
    readAt?: string;
    sentAt?: string;
    deliveryMethod?: number;
    notificationStatus?: number;
}
