import { Component, input, output, computed, ChangeDetectionStrategy, ViewEncapsulation } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonDirective } from 'primeng/button';
import { Tooltip } from 'primeng/tooltip';
import { DatePipe, DecimalPipe } from '@angular/common';
import type { TableColumn, TableAction, TableConfig } from '../../interfaces/shared.types';
import { StatusBadgeComponent } from '../status-badge/status-badge.component';

@Component({
  selector: 'app-data-table',
  imports: [TableModule, ButtonDirective, Tooltip, DatePipe, DecimalPipe, StatusBadgeComponent],
  template: `
    <p-table
      [value]="data()"
      [columns]="visibleColumns()"
      [paginator]="config().paginator !== false"
      [rows]="config().rows || 10"
      [rowsPerPageOptions]="config().rowsPerPageOptions || [5, 10, 25, 50]"
      [sortField]="config().sortField || ''"
      [sortOrder]="config().sortOrder || 1"
      [selectionMode]="config().selectionMode ?? null"
      [globalFilterFields]="globalFilterFields()"
      [loading]="config().loading || false"
      [totalRecords]="config().totalRecords || data().length"
      [lazy]="config().lazy || false"
      (onLazyLoad)="lazyLoad.emit($event)"
      styleClass="p-datatable-sm"
      [tableStyle]="{'min-width': '50rem'}"
    >
      <ng-template pTemplate="header" let-columns>
        <tr>
          @if (config().selectionMode) {
            <th style="width: 3rem"><p-tableHeaderCheckbox /></th>
          }
          @for (col of columns; track col.field) {
            <th
              [pSortableColumn]="col.sortable ? col.field : ''"
              [style]="col.width ? {'width': col.width} : {}"
              [class]="'text-' + (col.align || 'right')"
            >
              {{ col.header }}
              @if (col.sortable) {
                <p-sortIcon [field]="col.field" />
              }
            </th>
          }
          @if (actions().length > 0) {
            <th style="width: 8rem">الإجراءات</th>
          }
        </tr>
      </ng-template>
      <ng-template pTemplate="body" let-row let-columns="columns">
        <tr>
          @if (config().selectionMode) {
            <td><p-tableCheckbox [value]="row" /></td>
          }
          @for (col of columns; track col.field) {
            <td>
              @switch (col.type) {
                @case ('status') {
                  @if (col['statusMap']) {
                    <app-status-badge [value]="row[col.field]" [map]="col['statusMap']" />
                  } @else {
                    {{ row[col.field] }}
                  }
                }
                @case ('date') {
                  {{ row[col.field] | date }}
                }
                @case ('currency') {
                  {{ row[col.field] | number }}
                }
                @case ('badge') {
                  <span class="data-table-badge">{{ row[col.field] }}</span>
                }
                @default {
                  {{ row[col.field] }}
                }
              }
            </td>
          }
          @if (actions().length > 0) {
            <td>
              <div class="data-table-actions">
                @for (action of actions(); track action.label) {
                  @if (!action.visible || action.visible(row)) {
                    <button
                      pButton
                      [icon]="action.icon || 'pi pi-cog'"
                      [pTooltip]="action.label"
                      tooltipPosition="top"
                      [class.p-button-outlined]="action.outlined"
                      [class.p-button-rounded]="true"
                      [class.p-button-sm]="true"
                      [disabled]="action.disabled ? action.disabled(row) : false"
                      (click)="action.command(row)"
                    ></button>
                  }
                }
              </div>
            </td>
          }
        </tr>
      </ng-template>
      <ng-template pTemplate="emptymessage" let-columns="columns">
        <tr>
          <td [attr.colspan]="colspan()">
            <div class="data-table-empty">
              <span class="pi pi-inbox" style="font-size: 2rem; color: var(--gray-400);"></span>
              <p style="color: var(--gray-500); margin: 0;">لا توجد بيانات</p>
            </div>
          </td>
        </tr>
      </ng-template>
    </p-table>
  `,
  styleUrl: './data-table.component.scss',
  standalone: true,
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataTableComponent {
  readonly data = input.required<any[]>();
  readonly columns = input.required<TableColumn[]>();
  readonly actions = input<TableAction[]>([]);
  readonly config = input<TableConfig>({});
  readonly rowSelect = output<any>();
  readonly rowUnselect = output<any>();
  readonly lazyLoad = output<any>();

  readonly visibleColumns = computed(() => this.columns().filter(c => !c.hidden));
  readonly globalFilterFields = computed(() => this.columns().filter(c => c.filterable !== false).map(c => c.field));
  readonly colspan = computed(() => this.visibleColumns().length + (this.actions().length > 0 ? 1 : 0) + (this.config().selectionMode ? 1 : 0));
}
