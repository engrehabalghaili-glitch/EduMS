import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { TabsModule } from 'primeng/tabs';
import { TableModule } from 'primeng/table';
import { TooltipModule } from 'primeng/tooltip';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AuthService } from '../../../../core/auth/auth';
import { NotificationService } from '../../../../core/services/notification';
import { ApplicationService } from '../../services/application';

@Component({
  selector: 'app-application-details',
  standalone: true,
  imports: [CommonModule, CardModule, TagModule, ButtonModule, TabsModule, TableModule, TooltipModule, ConfirmDialogModule, ToastModule],
  providers: [ConfirmationService, MessageService],
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.scss']
})
export class ApplicationDetailsComponent {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private confirmationService = inject(ConfirmationService);
  private authService = inject(AuthService);
  private notificationService = inject(NotificationService);
  private messageService = inject(MessageService);
  private applicationService = inject(ApplicationService);

  activeTab = signal('0');
  app = this.applicationService.currentApp;
  activityLog = this.applicationService.activityLog;
  systemMessages = this.notificationService.systemMessages;
  loading = signal(false);

  constructor() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loading.set(true);
      this.applicationService.getApplicationById(id).subscribe({ complete: () => this.loading.set(false) });
      this.applicationService.getActivityLog(id).subscribe();
    }
  }

  private addLogToHistory(action: string, actor: string, details: string): void {
    const date = new Date().toLocaleString('ar-SA');
    this.activityLog.update(log => [{ action, user: actor, date, notes: details }, ...log]);
  }

  getStatusSeverity(status: string): 'warn' | 'success' | 'danger' {
    switch (status) {
      case 'pending': return 'warn';
      case 'approved': return 'success';
      case 'rejected': return 'danger';
      default: return 'warn';
    }
  }

  getDocSeverity(status: string): 'success' | 'warn' | 'danger' {
    switch (status) {
      case 'مكتمل': return 'success';
      case 'ناقص': return 'warn';
      case 'غير مرفوع': return 'danger';
      default: return 'warn';
    }
  }

  goBack(): void {
    this.router.navigate(['/student/applications']);
  }

  private get actor(): string {
    return this.authService.currentUser()?.name || 'مسؤول النظام';
  }

  confirmAccept(): void {
    const a = this.actor;
    const name = this.app()?.studentName || '';
    this.confirmationService.confirm({
      message: 'هل أنت متأكد من قبول هذا الطلب؟',
      header: 'تأكيد القبول',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'نعم، قبول',
      rejectLabel: 'إلغاء',
      accept: () => {
        const id = this.app()?.id;
        if (id) this.applicationService.updateApplicationStatus(id, 'approved', 'معتمد').subscribe();
        this.addLogToHistory('قبول الطلب', a, `تم قبول الطلب بواسطة ${a} - تم التحقق من جميع المستندات`);
        this.messageService.add({ severity: 'success', summary: 'تم اعتماد الطلب', detail: `تم اعتماد طلب الطالب ${name} بنجاح، وسيتم إرسال إشعار لولي الأمر`, life: 5000 });
        this.notificationService.addSystemMessage(`تم إرسال رسالة SMS لولي أمر الطالب ${name}: تم قبول طلب ${name} - مرحباً به في مدرستنا`);
      },
    });
  }

  confirmReject(): void {
    const a = this.actor;
    const name = this.app()?.studentName || '';
    this.confirmationService.confirm({
      message: 'هل أنت متأكد من رفض هذا الطلب؟ سيتم إشعار ولي الأمر عبر البريد الإلكتروني.',
      header: 'تأكيد الرفض',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'نعم، رفض',
      rejectLabel: 'إلغاء',
      accept: () => {
        const id = this.app()?.id;
        if (id) this.applicationService.updateApplicationStatus(id, 'rejected', 'مرفوض').subscribe();
        this.addLogToHistory('رفض الطلب', a, `تم رفض الطلب بواسطة ${a} - نقص في المستندات المرفوعة`);
        this.messageService.add({ severity: 'error', summary: 'تم رفض الطلب', detail: `تم رفض طلب الطالب ${name}، سيتم إشعار ولي الأمر بالسبب`, life: 5000 });
        this.notificationService.addSystemMessage(`تم إرسال رسالة SMS لولي أمر الطالب ${name}: تم رفض طلب ${name} - يرجى مراجعة المستندات المطلوبة`, 'error');
      },
    });
  }

  confirmRevise(): void {
    const a = this.actor;
    const name = this.app()?.studentName || '';
    this.confirmationService.confirm({
      message: 'هل تريد إعادة الطلب إلى حالة "قيد المراجعة"؟ سيتم إلغاء القرار السابق.',
      header: 'تعديل القرار',
      icon: 'pi pi-refresh',
      acceptLabel: 'نعم، تعديل',
      rejectLabel: 'إلغاء',
      accept: () => {
        const id = this.app()?.id;
        if (id) this.applicationService.updateApplicationStatus(id, 'pending', 'قيد المراجعة').subscribe();
        this.addLogToHistory('تعديل القرار', a, `تم إعادة الطلب للمراجعة بواسطة ${a} - إلغاء القرار السابق وإعادة الفتح`);
        this.messageService.add({ severity: 'info', summary: 'تم تعديل القرار', detail: `تم إعادة فتح طلب الطالب ${name} للمراجعة`, life: 5000 });
        this.notificationService.addSystemMessage(`تم إرسال إشعار لولي أمر الطالب ${name}: تم تحديث حالة الطلب إلى قيد المراجعة`, 'info');
      },
    });
  }
}
