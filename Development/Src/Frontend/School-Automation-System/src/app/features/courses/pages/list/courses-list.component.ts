import { ChangeDetectionStrategy, Component } from '@angular/core';
import { PageHeaderComponent } from '../../../../core/layout/page-header/page-header.component';

@Component({
  standalone: true,
  imports: [PageHeaderComponent],
  template: `
    <app-page-header title="المواد الدراسية" description="إدارة المواد والواجبات" />
    <p style="color: var(--text-color-secondary); padding: 2rem 0;">قريباً...</p>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CoursesListComponent {}
