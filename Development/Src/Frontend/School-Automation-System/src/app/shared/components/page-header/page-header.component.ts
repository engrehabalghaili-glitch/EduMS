import { Component, input, output, ChangeDetectionStrategy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonDirective } from 'primeng/button';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { InputText } from 'primeng/inputtext';
import type { PageHeaderConfig } from '../../interfaces/shared.types';

@Component({
  selector: 'app-page-header',
  imports: [ButtonDirective, IconField, InputIcon, InputText, FormsModule],
  template: `
    <div class="page-header">
      <div class="page-header-title">
        <h1>{{ config().title }}</h1>
        @if (config().subtitle) {
          <span class="page-header-subtitle">{{ config().subtitle }}</span>
        }
      </div>
      <div class="page-header-actions">
        @if (config().showSearch) {
          <p-iconfield>
            <p-inputicon styleClass="pi pi-search" />
            <input
              pInputText
              type="text"
              [placeholder]="config().searchPlaceholder || 'بحث...'"
              [ngModel]="config().searchValue"
              (ngModelChange)="searchChange.emit($event)"
              class="page-header-search"
            />
          </p-iconfield>
        }
        @for (action of config().actions || []; track action.label) {
          <button
            pButton
            [label]="action.label"
            [icon]="action.icon"
            [class.p-button-outlined]="action.outlined"
            [class.p-button-raised]="action.raised"
            [disabled]="action.disabled"
            (click)="action.command()"
          ></button>
        }
      </div>
    </div>
  `,
  styleUrl: './page-header.component.scss',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageHeaderComponent {
  readonly config = input.required<PageHeaderConfig>();
  readonly searchChange = output<string>();
}
