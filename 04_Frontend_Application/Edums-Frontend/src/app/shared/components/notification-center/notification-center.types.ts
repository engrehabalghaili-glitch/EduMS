export interface AppNotification {
  id: string | number;
  title: string;
  message: string;
  time: Date | string;
  read: boolean;
  type?: 'info' | 'success' | 'warning' | 'danger';
  avatar?: string;
  actionUrl?: string;
}
