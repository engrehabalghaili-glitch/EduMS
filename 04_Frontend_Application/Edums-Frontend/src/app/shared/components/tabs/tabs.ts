import { ChangeDetectionStrategy, Component, input, output, signal, effect } from '@angular/core';

export type BadgeColor = 'primary' | 'success' | 'warning' | 'danger' | 'info';

export interface TabItem {
  key: string;
  label: string;
  icon?: string;
  badge?: number;
  badgeColor?: BadgeColor;
  disabled?: boolean;
}

@Component({
  selector: 'app-tabs',
  imports: [],
  templateUrl: './tabs.html',
  styleUrl: './tabs.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Tabs {
  readonly tabs = input.required<TabItem[]>();
  readonly activeTab = input<string>('');
  readonly activeTabChange = output<string>();

  readonly currentTab = signal('');

  constructor() {
    effect(() => {
      this.currentTab.set(this.activeTab());
    });
  }

  selectTab(key: string): void {
    if (this.currentTab() === key) return;
    this.currentTab.set(key);
    this.activeTabChange.emit(key);
  }
}
