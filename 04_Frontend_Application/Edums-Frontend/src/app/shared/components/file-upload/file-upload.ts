import { ChangeDetectionStrategy, Component, forwardRef, input, output, signal } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormsModule } from '@angular/forms';
import { FileUploadModule } from 'primeng/fileupload';
import { ButtonModule } from 'primeng/button';
import { NgClass } from '@angular/common';

export interface UploadedFile {
  id?: string | number;
  name: string;
  size: number;
  url?: string;
  type?: string;
}

@Component({
  selector: 'app-file-upload',
  imports: [FileUploadModule, ButtonModule, FormsModule, NgClass],
  templateUrl: './file-upload.html',
  styleUrl: './file-upload.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => FileUploadComponent),
      multi: true,
    },
  ],
})
export class FileUploadComponent implements ControlValueAccessor {
  readonly url = input<string>('');
  readonly multiple = input(true);
  readonly accept = input<string>('');
  readonly maxFileSize = input<number>(10485760);
  readonly mode = input<'advanced' | 'basic'>('advanced');
  readonly auto = input(false);
  readonly disabled = input(false);
  readonly chooseLabel = input('اختر ملف');
  readonly uploadLabel = input('رفع');
  readonly cancelLabel = input('إلغاء');
  readonly chooseIcon = input('pi pi-fw pi-plus');
  readonly uploadIcon = input('pi pi-fw pi-upload');
  readonly cancelIcon = input('pi pi-fw pi-times');
  readonly showUploadButton = input(true);
  readonly showCancelButton = input(true);
  readonly customUpload = input(false);
  readonly fileLimit = input<number | undefined>(undefined);
  readonly invalidFileSizeMessageSummary = input('حجم الملف غير مسموح');
  readonly invalidFileSizeMessageDetail = input('الحد الأقصى لحجم الملف هو {0}');
  readonly invalidFileTypeMessageSummary = input('نوع الملف غير مسموح');
  readonly invalidFileTypeMessageDetail = input('النوع المسموح: {0}');
  readonly styleClass = input('');
  readonly existingFiles = input<UploadedFile[]>([]);

  readonly onRemoveExisting = output<UploadedFile>();

  files = signal<File[]>([]);
  disabledState = signal(false);

  private onChange: (_: unknown) => void = () => {};
  private onTouched: () => void = () => {};

  writeValue(obj: unknown): void {
    this.files.set(Array.isArray(obj) ? obj : []);
  }

  registerOnChange(fn: (_: unknown) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabledState.set(isDisabled);
  }

  onSelect(event: unknown): void {
    const evt = event as { files: File[] };
    const current = [...this.files()];
    const merged = [...current, ...evt.files];
    this.files.set(merged);
    this.onChange(merged);
  }

  onRemove(event: unknown): void {
    const evt = event as { file: File };
    const current = [...this.files()];
    const idx = current.findIndex(f => f.name === evt.file.name && f.size === evt.file.size);
    if (idx !== -1) current.splice(idx, 1);
    this.files.set(current);
    this.onChange(current);
  }

  onClear(): void {
    this.files.set([]);
    this.onChange([]);
  }

  onUpload(): void {
    this.onTouched();
  }

  onError(): void {
    this.onTouched();
  }

  hasFiles(): boolean {
    return this.files().length > 0;
  }

  formatSize(bytes: number): string {
    if (bytes < 1024) return `${bytes} B`;
    if (bytes < 1048576) return `${(bytes / 1024).toFixed(1)} KB`;
    return `${(bytes / 1048576).toFixed(1)} MB`;
  }

  removeExisting(file: UploadedFile): void {
    this.onRemoveExisting.emit(file);
  }
}
