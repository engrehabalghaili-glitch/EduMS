import { ChangeDetectionStrategy, Component } from '@angular/core';
import { PageHeaderComponent } from '../../../../core/layout/page-header/page-header.component';

@Component({
  standalone: true,
  imports: [PageHeaderComponent],
  template: `
    <app-page-header title="الصفوف الدراسية" description="إدارة الصفوف والشعب" />
    <p style="color: var(--text-color-secondary); padding: 2rem 0;">قريباً...</p>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ClassesListComponent {}
