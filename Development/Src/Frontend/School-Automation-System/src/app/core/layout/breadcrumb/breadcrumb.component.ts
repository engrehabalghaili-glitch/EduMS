import { ChangeDetectionStrategy, Component, computed, inject, ViewEncapsulation } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BreadcrumbModule } from 'primeng/breadcrumb';

import { NavigationService } from '../services/navigation.service';
import type { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-breadcrumb',
  standalone: true,
  imports: [BreadcrumbModule, RouterLink],
  template: `
    <p-breadcrumb
      [model]="primeCrumbs()"
      [home]="homeItem">
      <ng-template pTemplate="item" let-item>
        @if (item.route) {
          <a
            [routerLink]="item.route"
            class="breadcrumb-link">
            @if (item.icon) {
              <span [class]="item.icon"></span>
            }
            <span>{{ item.label }}</span>
          </a>
        } @else {
          <span class="breadcrumb-current">{{ item.label }}</span>
        }
      </ng-template>
    </p-breadcrumb>
  `,
  styleUrl: './breadcrumb.component.scss',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BreadcrumbComponent {
  readonly homeItem: MenuItem = {
    icon: 'pi pi-home',
    label: 'الرئيسية',
    routerLink: '/',
  };

  readonly primeCrumbs = computed(() => {
    const items = this.navService.breadcrumbItems();
    return items.slice(1).map(item => ({
      label: item.label,
      route: item.route,
      icon: undefined,
    } as MenuItem));
  });

  private readonly navService = inject(NavigationService);
}
