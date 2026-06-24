import { Component, ChangeDetectionStrategy } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-assets-management',
  imports: [RouterModule],
  template: `<router-outlet />`,
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssetsManagementComponent {}
