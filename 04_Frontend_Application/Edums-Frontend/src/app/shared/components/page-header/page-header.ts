import { ChangeDetectionStrategy, Component, contentChild, input, output, TemplateRef } from '@angular/core';
import { NgTemplateOutlet } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { ToolbarModule } from 'primeng/toolbar';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
import { SplitButtonModule } from 'primeng/splitbutton';
import { TooltipModule } from 'primeng/tooltip';

export interface HeaderAction {
  label: string;
  icon?: string;
  severity?: 'primary' | 'secondary' | 'success' | 'info' | 'warning' | 'danger';
  disabled?: boolean;
  command: () => void;
  items?: HeaderAction[];
}

type PrimeSeverity = 'success' | 'info' | 'warn' | 'danger' | 'help' | 'primary' | 'secondary' | 'contrast' | null | undefined;

const severityMap: Record<string, PrimeSeverity> = {
  primary: 'primary',
  secondary: 'secondary',
  success: 'success',
  info: 'info',
  warning: 'warn',
  danger: 'danger',
};

@Component({
  selector: 'app-page-header',
  imports: [ToolbarModule, BreadcrumbModule, ButtonModule, SplitButtonModule, TooltipModule, NgTemplateOutlet],
  templateUrl: './page-header.html',
  styleUrl: './page-header.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageHeader {
  readonly title = input.required<string>();
  readonly subtitle = input('');
  readonly icon = input('');
  readonly actions = input<HeaderAction[]>([]);
  readonly breadcrumbItems = input<MenuItem[]>([]);
  readonly backButton = input(false);
  readonly backUrl = input('');
  readonly loading = input(false);
  readonly sticky = input(false);

  readonly onBack = output<void>();

  readonly actionsSlot = contentChild<TemplateRef<unknown>>('actions');

  handleBack(): void {
    this.onBack.emit();
  }

  trackAction(_index: number, action: HeaderAction): string {
    return action.label;
  }

  mapSeverity(severity: string | undefined): PrimeSeverity {
    return severityMap[severity ?? 'primary'] ?? 'primary';
  }

  convertToMenuItems(items: HeaderAction[] | undefined): MenuItem[] {
    return (items ?? []).map(item => ({
      label: item.label,
      icon: item.icon,
      command: () => item.command(),
    }));
  }
}
