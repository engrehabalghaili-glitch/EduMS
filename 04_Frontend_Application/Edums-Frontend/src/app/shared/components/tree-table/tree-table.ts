import { ChangeDetectionStrategy, Component, contentChild, input, output, TemplateRef } from '@angular/core';
import { NgTemplateOutlet } from '@angular/common';
import { TreeTableModule } from 'primeng/treetable';
import { TreeNode } from 'primeng/api';
import { Skeleton } from 'primeng/skeleton';

export interface TreeTableColumn {
  field: string;
  header: string;
  sortable?: boolean;
  width?: string;
  expander?: boolean;
}

export interface TreeTableLazyLoadEvent {
  first: number;
  rows: number;
  sortField: string;
  sortOrder: -1 | 0 | 1;
  globalFilter?: string;
}

interface TreeNodeEvent {
  node?: TreeNode;
  originalEvent?: Event;
}

@Component({
  selector: 'app-tree-table',
  imports: [TreeTableModule, NgTemplateOutlet, Skeleton],
  templateUrl: './tree-table.html',
  styleUrl: './tree-table.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TreeTable {
  readonly value = input.required<TreeNode[]>();
  readonly columns = input.required<TreeTableColumn[]>();
  readonly totalRecords = input(0);
  readonly loading = input(false);
  readonly lazy = input(false);
  readonly paginator = input(true);
  readonly rows = input(15);
  readonly first = input(0);
  readonly showCurrentPageReport = input(true);
  readonly currentPageReportTemplate = input('من {first} إلى {last} من أصل {totalRecords}');
  readonly rowsPerPageOptions = input<number[]>([10, 15, 25, 50]);
  readonly sortField = input<string>('');
  readonly sortOrder = input<-1 | 0 | 1>(-1);
  readonly selectionMode = input<'single' | 'multiple' | 'checkbox' | undefined>(undefined);
  readonly selection = input<TreeNode[]>([]);
  readonly selectionChange = output<TreeNode[]>();
  readonly dataKey = input<string>('key');
  readonly globalFilterFields = input<string[]>([]);
  readonly styleClass = input('compact-tree');
  readonly tableStyle = input<Record<string, string>>({ 'min-width': '50rem' });
  readonly emptyMessage = input('لا توجد بيانات متوفرة');
  readonly showGridlines = input(false);
  readonly lazyLoad = output<TreeTableLazyLoadEvent>();
  readonly nodeExpand = output<TreeNode>();
  readonly nodeCollapse = output<TreeNode>();
  readonly nodeSelect = output<TreeNode>();
  readonly nodeUnselect = output<TreeNode>();
  readonly rowAction = output<TreeNode>();

  readonly actionTemplate = contentChild<TemplateRef<{ $implicit: TreeNode }>>('actions');
  readonly bodyTemplate = contentChild<TemplateRef<{ $implicit: TreeNode }>>('body');

  readonly skeletonRows = [0, 1, 2, 3, 4];

  onLazyLoad(event: unknown): void {
    const evt = event as Record<string, unknown>;
    this.lazyLoad.emit({
      first: evt['first'] as number,
      rows: evt['rows'] as number,
      sortField: (evt['sortField'] as string) ?? '',
      sortOrder: (evt['sortOrder'] as -1 | 0 | 1) ?? -1,
      globalFilter: evt['globalFilter'] as string | undefined,
    });
  }

  onSelectionChange(value: unknown): void {
    const items = Array.isArray(value) ? value : value ? [value] : [];
    this.selectionChange.emit(items as TreeNode[]);
  }

  onNodeExpand(event: TreeNodeEvent): void {
    if (event.node) this.nodeExpand.emit(event.node);
  }

  onNodeCollapse(event: TreeNodeEvent): void {
    if (event.node) this.nodeCollapse.emit(event.node);
  }

  onNodeSelect(event: TreeNodeEvent): void {
    if (event.node) this.nodeSelect.emit(event.node);
  }

  onNodeUnselect(event: TreeNodeEvent): void {
    if (event.node) this.nodeUnselect.emit(event.node);
  }

  triggerAction(node: TreeNode): void {
    this.rowAction.emit(node);
  }
}
