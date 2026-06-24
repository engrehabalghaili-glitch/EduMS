import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule, FileUploadHandlerEvent } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { RegistrationService, UploadedDoc } from '../registration.service';
import { DocumentService } from '../../../student-portal/services/document';

@Component({
  selector: 'app-docs-step',
  standalone: true,
  imports: [CommonModule, FileUploadModule, ToastModule],
  template: `
    <div class="step-content">
      <div class="step-title"><i class="pi pi-folder-open"></i><span>رفع الوثائق والمستندات</span></div>

      <div class="alert-note"><i class="pi pi-info-circle"></i><span>PDF أو JPG فقط — حد أقصى 5MB للملف</span></div>

      <div class="docs-grid">
        @for (doc of requiredDocs(); track doc.id) {
          <div class="doc-item" [class.done]="doc.accepted">
            <div class="doc-icon"><i [class]="'pi ' + doc.icon"></i></div>
            <div class="doc-info">
              <span class="doc-label">{{ doc.label }}</span>
              <span class="doc-desc">{{ doc.description }}</span>
            </div>
            @if (doc.accepted) {
              <div class="doc-badge ok"><i class="pi pi-check"></i></div>
            } @else {
              <div class="doc-badge no"><i class="pi pi-upload"></i></div>
            }
          </div>
        }
      </div>

      <div class="upload-area">
        <p-toast position="top-left" key="tl"></p-toast>
        <p-fileUpload mode="advanced" [multiple]="false" accept=".pdf,.jpg,.jpeg,.png" [maxFileSize]="maxSize" [auto]="false" [customUpload]="true" (uploadHandler)="onUpload($event)" chooseLabel="اختر ملف" uploadLabel="رفع" cancelLabel="إلغاء" styleClass="custom-fu">
          <ng-template pTemplate="empty">
            <div class="drop-inner">
              <i class="pi pi-cloud-upload drop-icon"></i>
              <p>اسحب وأفلت الملفات هنا</p>
              <span>PDF, JPG, PNG — حد أقصى 5MB</span>
            </div>
          </ng-template>
        </p-fileUpload>
      </div>

      <div class="tips-grid">
        <div class="tip"><i class="pi pi-file-pdf"></i><span>ملفات PDF أو JPG فقط</span></div>
        <div class="tip"><i class="pi pi-database"></i><span>حجم الملف ≤ 5 ميجابايت</span></div>
        <div class="tip"><i class="pi pi-image"></i><span>الصور واضحة ومضاءة جيداً</span></div>
        <div class="tip"><i class="pi pi-shield"></i><span>جميع المستندات مشفرة</span></div>
      </div>
    </div>
  `,
  styles: [`
    .step-title { display: flex; align-items: center; gap: 0.65rem; font-size: 1.05rem; font-weight: 800; color: #0f172a; margin-bottom: 1rem; }
    .step-title i { color: #06b6d4; font-size: 1.15rem; }
    .alert-note { display: flex; align-items: center; gap: 0.5rem; padding: 0.6rem 1rem; background: linear-gradient(135deg,#fef9c3,#fef08a); border: 1px solid #fde047; border-radius: 0.65rem; font-size: 0.8rem; font-weight: 600; color: #a16207; margin-bottom: 1.25rem; }
    .alert-note i { font-size: 0.9rem; color: #ca8a04; }
    .docs-grid { display: grid; grid-template-columns: repeat(auto-fill,minmax(250px,1fr)); gap: 0.75rem; margin-bottom: 1.5rem; }
    .doc-item { display: flex; align-items: center; gap: 0.75rem; padding: 0.75rem 1rem; background: #fff; border: 1.5px solid #e2e8f0; border-radius: 0.75rem; transition: all 0.25s ease; }
    .doc-item.done { border-color: #86efac; background: linear-gradient(135deg,#f0fdf4,#dcfce7); }
    .doc-icon { width: 38px; height: 38px; background: linear-gradient(135deg,#f0f9ff,#e0f2fe); border-radius: 9px; display: flex; align-items: center; justify-content: center; font-size: 1.1rem; color: #06b6d4; flex-shrink: 0; }
    .doc-item.done .doc-icon { background: linear-gradient(135deg,#dcfce7,#bbf7d0); color: #22c55e; }
    .doc-info { flex: 1; display: flex; flex-direction: column; gap: 1px; }
    .doc-label { font-size: 0.83rem; font-weight: 700; color: #374151; }
    .doc-desc { font-size: 0.7rem; color: #6b7280; font-weight: 500; }
    .doc-badge { width: 26px; height: 26px; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 0.75rem; flex-shrink: 0; }
    .doc-badge.no { background: #f1f5f9; color: #94a3b8; }
    .doc-badge.ok { background: #22c55e; color: #fff; }
    .upload-area { margin-bottom: 1.25rem; }
    ::v-deep .custom-fu { border: 2px dashed #cbd5e1; border-radius: 0.85rem; background: #fff; transition: all 0.25s ease; }
    ::v-deep .custom-fu:hover { border-color: #06b6d4; background: #f8fafc; }
    ::v-deep .custom-fu .p-fileupload-buttonbar { background: transparent; border: none; padding: 0.65rem; }
    ::v-deep .custom-fu .p-fileupload-content { background: transparent; border: none; padding: 0.75rem; }
    .drop-inner { display: flex; flex-direction: column; align-items: center; padding: 1.5rem; color: #374151; }
    .drop-icon { font-size: 2.5rem; color: #94a3b8; margin-bottom: 0.5rem; transition: all 0.3s ease; }
    .custom-fu:hover .drop-icon { color: #06b6d4; transform: translateY(-4px); }
    .drop-inner p { font-size: 0.9rem; font-weight: 700; margin: 0 0 0.25rem; color: #374151; }
    .drop-inner span { font-size: 0.75rem; color: #94a3b8; font-weight: 500; }
    .tips-grid { display: grid; grid-template-columns: repeat(auto-fill,minmax(200px,1fr)); gap: 0.65rem; }
    .tip { display: flex; align-items: center; gap: 0.5rem; padding: 0.55rem 0.85rem; background: #fff; border: 1px solid #e2e8f0; border-radius: 0.65rem; font-size: 0.78rem; font-weight: 600; color: #374151; }
    .tip i { font-size: 0.85rem; color: #06b6d4; flex-shrink: 0; }
  `],
  providers: [MessageService],
})
export class DocsStepComponent implements OnInit {
  private documentService = inject(DocumentService);
  requiredDocs = this.documentService.requiredDocs;

  maxSize = 5 * 1024 * 1024;

  constructor(public svc: RegistrationService, private msg: MessageService) {}

  ngOnInit(): void {
    this.documentService.getRequiredDocuments().subscribe();
  }

  onUpload(event: FileUploadHandlerEvent): void {
    const files = event.files;
    if (files?.length) {
      const docId = files[0].name;
      this.svc.addDocument({ id: docId, label: files[0].name, files, accepted: true });
      this.msg.add({ severity: 'success', summary: 'تم الرفع', detail: `"${files[0].name}" رفع بنجاح`, life: 3000 });
    }
  }
}
