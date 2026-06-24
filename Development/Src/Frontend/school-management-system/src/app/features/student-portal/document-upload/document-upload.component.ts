import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule, FileUploadHandlerEvent } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { DocumentService } from '../services/document';

@Component({
  selector: 'app-document-upload',
  standalone: true,
  imports: [CommonModule, FileUploadModule, ToastModule],
  templateUrl: './document-upload.component.html',
  styleUrl: './document-upload.component.scss',
  providers: [MessageService],
})
export class DocumentUploadComponent implements OnInit {
  private documentService = inject(DocumentService);
  private messageService = inject(MessageService);

  requiredDocs = this.documentService.requiredDocs;
  uploading = signal(false);
  loading = signal(false);

  uploadedFiles: Record<string, File[]> = {};
  maxFileSize = 5 * 1024 * 1024;

  ngOnInit(): void {
    this.loading.set(true);
    this.documentService.getRequiredDocuments().subscribe({ complete: () => this.loading.set(false) });
  }

  onUpload(event: FileUploadHandlerEvent, docId: string): void {
    const files = event.files;
    if (files && files.length > 0) {
      this.uploading.set(true);
      this.documentService.uploadFile(docId, files[0]).subscribe({
        next: () => {
          this.uploadedFiles[docId] = files;
          this.messageService.add({
            severity: 'success', summary: 'تم الرفع بنجاح',
            detail: `تم رفع الملف "${files[0].name}" بنجاح`, life: 3000,
          });
        },
        complete: () => this.uploading.set(false)
      });
    }
  }

  onRemove(docId: string): void {
    this.documentService.removeFile(docId).subscribe();
    delete this.uploadedFiles[docId];
  }

  get acceptedCount(): number {
    return this.requiredDocs().filter(d => d.accepted).length;
  }

  get totalCount(): number {
    return this.requiredDocs().length;
  }
}
