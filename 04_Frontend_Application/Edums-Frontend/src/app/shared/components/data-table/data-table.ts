import { ChangeDetectionStrategy, Component, input, output, TemplateRef, contentChild, signal, viewChild } from '@angular/core';
import { NgTemplateOutlet } from '@angular/common';
import { Table, TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { Skeleton } from 'primeng/skeleton';
import { FormsModule } from '@angular/forms';
import type { TableRowSelectEvent, TableRowUnSelectEvent, TablePageEvent, TableFilterEvent, TableLazyLoadEvent } from 'primeng/table';

export interface DataTableColumn {
  field: string;
  header: string;
  sortable?: boolean;
  filterable?: boolean;
  width?: string;
  type?: 'text' | 'number' | 'date' | 'boolean' | 'currency';
}

export interface DataTableConfig {
  columns: DataTableColumn[];
}

export interface ActionConfig {
  label: string;
  icon?: string;
  severity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  visible?: (row: unknown) => boolean;
  disabled?: (row: unknown) => boolean;
  action: (row: unknown) => void;
}

export interface LazyLoadEvent {
  first: number;
  rows: number;
  sortField?: string;
  sortOrder?: -1 | 0 | 1;
  globalFilter?: string;
  filters?: Record<string, { value: string; matchMode: string }>;
}

export interface SortEvent {
  field: string;
  order: -1 | 0 | 1;
}

export interface PageEvent {
  first: number;
  rows: number;
  page: number;
  pageCount: number;
}

@Component({
  selector: 'app-data-table',
  imports: [TableModule, InputTextModule, SelectModule, ButtonModule, TooltipModule, FormsModule, NgTemplateOutlet, Skeleton],
  templateUrl: './data-table.html',
  styleUrl: './data-table.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataTable<T> {
  readonly data = input.required<T[]>();
  readonly config = input.required<DataTableConfig>();
  readonly totalRecords = input(0);
  readonly loading = input(false);
  readonly lazy = input(false);

  readonly paginator = input(true);
  readonly rows = input(15);
  readonly rowsPerPageOptions = input<number[]>([10, 15, 25, 50]);

  readonly globalFilterFields = input<string[]>([]);
  readonly showGlobalFilter = input(false);
  readonly globalFilterPlaceholder = input('بحث...');

  readonly selectionMode = input<'single' | 'multiple' | null>(null);
  readonly selectedItems = input<T[]>([]);
  readonly selectionChange = output<T[]>();

  readonly expandable = input(false);
  readonly expandTemplate = input<TemplateRef<{ $implicit: T }> | undefined>(undefined);

  readonly actions = input<ActionConfig[]>([]);
  readonly actionsPosition = input<'start' | 'end'>('end');

  readonly exportable = input(false);
  readonly exportFilename = input('export');

  readonly emptyMessage = input('لا توجد سجلات متوفرة');
  readonly stripedRows = input(false);
  readonly rowHover = input(false);

  readonly onLazyLoad = output<LazyLoadEvent>();
  readonly onRowSelect = output<T>();
  readonly onRowUnselect = output<T>();
  readonly onSort = output<SortEvent>();
  readonly onFilter = output<Record<string, { value: string; matchMode: string }>>();
  readonly onPage = output<PageEvent>();
  readonly onExport = output<void>();
  readonly onAction = output<{ action: ActionConfig; row: T }>();

  readonly actionTemplate = contentChild<TemplateRef<{ $implicit: T }>>('actions');

  private readonly dt = viewChild<Table>('dt');
  readonly searchValue = signal('');
  readonly skeletonRows = [0, 1, 2, 3, 4];

  hasActions(): boolean {
    return this.actions().length > 0 || !!this.actionTemplate();
  }

  onGlobalSearch(event: Event): void {
    const inputEl = event.target as HTMLInputElement;
    this.searchValue.set(inputEl.value);
    this.dt()?.filterGlobal(inputEl.value, 'contains');
  }

  onSelectionChange(value: T | T[]): void {
    this.selectionChange.emit(Array.isArray(value) ? value : value ? [value] : []);
  }

  onRowSelectEvent(event: TableRowSelectEvent<T>): void {
    const rowData = Array.isArray(event.data) ? event.data[0] : event.data;
    if (rowData) this.onRowSelect.emit(rowData);
  }

  onRowUnselectEvent(event: TableRowUnSelectEvent<T>): void {
    const rowData = Array.isArray(event.data) ? event.data[0] : event.data;
    if (rowData) this.onRowUnselect.emit(rowData);
  }

  onLazyLoadEvent(event: TableLazyLoadEvent): void {
    this.onLazyLoad.emit({
      first: event.first ?? 0,
      rows: event.rows ?? this.rows(),
      sortField: event.sortField as string | undefined,
      sortOrder: (event.sortOrder as -1 | 0 | 1 | undefined) ?? -1,
      globalFilter: event.globalFilter as string | undefined,
      filters: event.filters as Record<string, { value: string; matchMode: string }> | undefined,
    });
  }

  onSortEvent(event: { field: string; order: -1 | 0 | 1 }): void {
    this.onSort.emit(event);
  }

  onFilterEvent(event: TableFilterEvent): void {
    this.onFilter.emit(event.filters as Record<string, { value: string; matchMode: string }> ?? {});
  }

  onPageEvent(event: TablePageEvent): void {
    this.onPage.emit({
      first: event.first,
      rows: event.rows,
      page: Math.floor(event.first / event.rows),
      pageCount: Math.ceil(this.totalRecords() / event.rows),
    });
  }

  onExportClick(): void {
    this.onExport.emit();
    this.dt()?.exportCSV();
  }

  onActionClick(action: ActionConfig, row: T): void {
    this.onAction.emit({ action, row });
    action.action(row);
  }

  isActionVisible(action: ActionConfig, row: T): boolean {
    return !action.visible || action.visible(row);
  }

  isActionDisabled(action: ActionConfig, row: T): boolean {
    return !!action.disabled && action.disabled(row);
  }

  getVisibleActions(row: T): ActionConfig[] {
    return this.actions().filter(a => this.isActionVisible(a, row));
  }

  getColspan(columns: unknown[]): number {
    let span = columns.length;
    if (this.selectionMode()) { span++; }
    if (this.expandable()) { span++; }
    if (this.hasActions()) { span++; }
    return span;
  }
}
