import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { TableModule } from 'primeng/table';
import type { LazyLoadMeta, FilterMetadata, SortMeta } from 'primeng/api';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule],
  template: `
    <p-table
      [value]="value()"
      [loading]="loading()"
      [dataKey]="dataKey()"
      [selectionMode]="selectionMode()"
      [selection]="selection()"
      (selectionChange)="selectionChange.emit($event)"
      [paginator]="paginator()"
      [rows]="rows()"
      [first]="first()"
      (firstChange)="firstChange.emit($event)"
      (rowsChange)="rowsChange.emit($event)"
      [totalRecords]="totalRecords()"
      [lazy]="lazy()"
      (onLazyLoad)="onLazyLoad.emit($event)"
      [sortField]="sortField()"
      [sortOrder]="sortOrder()"
      (onSort)="onSort.emit($event)"
      [globalFilterFields]="globalFilterFields()"
      [filters]="filters()"
      (onFilter)="onFilter.emit($event)"
      [tableStyle]="tableStyle()"
      [class]="styleClass()">
      <ng-content />
    </p-table>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppTable {
  readonly value = input.required<any[]>();
  readonly loading = input(false);
  readonly dataKey = input<string>('');
  readonly selectionMode = input<'single' | 'multiple' | null>(null);
  readonly selection = input<any>([]);
  readonly selectionChange = output<any>();
  readonly paginator = input(false);
  readonly rows = input(0);
  readonly first = input(0);
  readonly firstChange = output<number>();
  readonly rowsChange = output<number>();
  readonly totalRecords = input<number>(0);
  readonly lazy = input(false);
  readonly onLazyLoad = output<LazyLoadMeta>();
  readonly sortField = input<string>('');
  readonly sortOrder = input(1);
  readonly onSort = output<SortMeta>();
  readonly globalFilterFields = input<string[]>([]);
  readonly filters = input<{ [s: string]: FilterMetadata | FilterMetadata[] }>({});
  readonly onFilter = output<any>();
  readonly styleClass = input<string>('');
  readonly tableStyle = input<Record<string, string>>({});
}
