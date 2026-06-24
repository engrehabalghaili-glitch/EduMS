import { Injectable, signal } from '@angular/core';

export interface SystemMessage {
  text: string;
  timestamp: string;
  type: 'success' | 'error' | 'info';
}

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  systemMessages = signal<SystemMessage[]>([]);

  addSystemMessage(text: string, type: 'success' | 'error' | 'info' = 'success'): void {
    this.systemMessages.update(msgs => [{
      text,
      timestamp: new Date().toLocaleString('ar-SA'),
      type,
    }, ...msgs]);
  }
}
