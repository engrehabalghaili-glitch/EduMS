import { ChangeDetectionStrategy, Component } from '@angular/core';
import { PageHeaderComponent } from '../../../../core/layout/page-header/page-header.component';

@Component({
  standalone: true,
  imports: [PageHeaderComponent],
  template: `
    <app-page-header title="المعلمون" description="إدارة وعرض بيانات المعلمين" />
    <p style="color: var(--text-color-secondary); padding: 2rem 0;">قريباً...</p>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TeachersListComponent {}
