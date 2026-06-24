import { Component, input, output, ChangeDetectionStrategy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { InputText } from 'primeng/inputtext';

@Component({
  selector: 'app-search-box',
  imports: [FormsModule, IconField, InputIcon, InputText],
  template: `
    <p-iconfield>
      <p-inputicon styleClass="pi pi-search" />
      <input
        pInputText
        type="text"
        [placeholder]="placeholder()"
        [ngModel]="value()"
        (ngModelChange)="valueChange.emit($event)"
        class="search-input"
        [style]="{'width': width()}"
      />
    </p-iconfield>
  `,
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchBoxComponent {
  readonly value = input('');
  readonly placeholder = input('بحث...');
  readonly width = input('320px');
  readonly valueChange = output<string>();
}
