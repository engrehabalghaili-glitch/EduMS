import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { TableModule } from 'primeng/table';

export interface TableColumn {
  field: string;
  header: string;
  sortable?: boolean;
  width?: string;
}

@Component({
  selector: 'app-data-table',
  imports: [TableModule],
  templateUrl: './data-table.html',
  styleUrl: './data-table.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DataTable<T extends Record<string, unknown>> {
  readonly value = input.required<T[]>();
  readonly columns = input.required<TableColumn[]>();
  readonly loading = input(false);
  readonly paginator = input(true);
  readonly rows = input(10);
  readonly showCurrentPageReport = input(true);
  readonly currentPageReportTemplate = input('Showing {first} to {last} of {totalRecords} entries');
}
