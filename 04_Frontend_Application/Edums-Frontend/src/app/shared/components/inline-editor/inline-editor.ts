import { ChangeDetectionStrategy, Component, computed, effect, input, output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectModule } from 'primeng/select';
import { ButtonModule } from 'primeng/button';
import { NgClass } from '@angular/common';

export type InlineEditorType = 'text' | 'number' | 'textarea' | 'dropdown';

export interface InlineEditorOption {
  label: string;
  value: unknown;
}

@Component({
  selector: 'app-inline-editor',
  imports: [FormsModule, InputTextModule, InputNumberModule, SelectModule, ButtonModule, NgClass],
  templateUrl: './inline-editor.html',
  styleUrl: './inline-editor.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class InlineEditor {
  readonly value = input.required<unknown>();
  readonly type = input<InlineEditorType>('text');
  readonly placeholder = input('انقر للتعديل');
  readonly label = input('');
  readonly required = input(false);
  readonly maxlength = input<number | undefined>(undefined);
  readonly size = input<'small' | 'normal' | 'large'>('normal');
  readonly options = input<InlineEditorOption[]>([]);
  readonly optionLabel = input('label');
  readonly optionValue = input('value');
  readonly disabled = input(false);
  readonly styleClass = input('');

  readonly save = output<unknown>();
  readonly cancel = output<void>();

  editing = signal(false);
  editValue = signal<unknown>('');

  readonly maxlengthOrNull = computed(() => this.maxlength() ?? null);

  private readonly isEditing = effect(() => {
    if (this.editing()) {
      this.editValue.set(this.value());
    }
  });

  startEditing(): void {
    if (this.disabled()) return;
    this.editValue.set(this.value());
    this.editing.set(true);
  }

  onSave(): void {
    this.save.emit(this.editValue());
    this.editing.set(false);
  }

  onCancel(): void {
    this.cancel.emit();
    this.editing.set(false);
  }

  onKeydown(event: KeyboardEvent): void {
    if (event.key === 'Enter' && this.type() !== 'textarea') {
      this.onSave();
    }
    if (event.key === 'Escape') {
      this.onCancel();
    }
  }
}
