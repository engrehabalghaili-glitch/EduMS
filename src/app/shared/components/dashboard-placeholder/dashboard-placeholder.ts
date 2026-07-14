import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-dashboard-placeholder',
  template: `<h1 class="text-2xl font-semibold text-slate-900">Dashboard</h1>`,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardPlaceholder {

}
