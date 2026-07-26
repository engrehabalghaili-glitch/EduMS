import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { Skeleton } from 'primeng/skeleton';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { NgClass } from '@angular/common';
import { OrgChartNode } from './org-chart-viewer.types';

export { type OrgChartNode } from './org-chart-viewer.types';

@Component({
  selector: 'app-org-chart-viewer',
  imports: [OrganizationChartModule, Skeleton, DialogModule, ButtonModule, TooltipModule, NgClass],
  templateUrl: './org-chart-viewer.html',
  styleUrl: './org-chart-viewer.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class OrgChartViewer {
  readonly data = input<OrgChartNode[]>([]);
  readonly loading = input(false);
  readonly selectionMode = input<'single' | 'multiple' | null>('single');
  readonly collapsible = input(true);
  readonly showNodeDetails = input(true);
  readonly emptyMessage = input('لا يوجد هيكل تنظيمي لعلامة التبويب الحالية');

  readonly onNodeSelect = output<OrgChartNode>();
  readonly onNodeExpand = output<OrgChartNode>();
  readonly onNodeCollapse = output<OrgChartNode>();

  selectedNode: OrgChartNode | null = null;
  detailVisible = false;

  nodeSelect(event: unknown): void {
    const evt = event as { node: OrgChartNode };
    this.selectedNode = evt.node;
    this.onNodeSelect.emit(evt.node);
    if (this.showNodeDetails()) {
      this.detailVisible = true;
    }
  }

  nodeExpand(event: unknown): void {
    const evt = event as { node: OrgChartNode };
    this.onNodeExpand.emit(evt.node);
  }

  nodeCollapse(event: unknown): void {
    const evt = event as { node: OrgChartNode };
    this.onNodeCollapse.emit(evt.node);
  }

  statusColor(status?: string): string {
    switch (status) {
      case 'active': return '#16a34a';
      case 'inactive': return '#a1a1aa';
      case 'pending': return '#ca8a04';
      default: return '#006699';
    }
  }

  statusLabel(status?: string): string {
    switch (status) {
      case 'active': return 'نشط';
      case 'inactive': return 'غير نشط';
      case 'pending': return 'قيد الانتظار';
      default: return status ?? '—';
    }
  }

  typeLabel(type: string): string {
    switch (type) {
      case 'school': return 'مدرسة';
      case 'department': return 'إدارة';
      case 'unit': return 'قسم';
      case 'position': return 'وظيفة';
      default: return type;
    }
  }

  typeIcon(type: string): string {
    switch (type) {
      case 'school': return 'pi pi-building';
      case 'department': return 'pi pi-sitemap';
      case 'unit': return 'pi pi-folder';
      case 'position': return 'pi pi-user';
      default: return 'pi pi-circle';
    }
  }
}
