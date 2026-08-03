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
  readAt: string | null;
  sentAt: string;
  deliveryMethod: number;
  notificationStatus: number;
}

export type CreateMaintenanceNotificationRequest = Omit<MaintenanceNotification, 'id'>;
export type UpdateMaintenanceNotificationRequest = MaintenanceNotification;
