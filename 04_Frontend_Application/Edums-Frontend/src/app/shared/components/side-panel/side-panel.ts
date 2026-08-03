import { ChangeDetectionStrategy, Component, input, model } from '@angular/core';
import { DrawerModule } from 'primeng/drawer';
import { Skeleton } from 'primeng/skeleton';

@Component({
  selector: 'app-side-panel',
  imports: [DrawerModule, Skeleton],
  templateUrl: './side-panel.html',
  styleUrl: './side-panel.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidePanel {
  readonly visible = model(false);
  readonly header = input('');
  readonly position = input<'left' | 'right' | 'bottom' | 'top' | 'full'>('right');
  readonly width = input('24rem');
  readonly modal = input(true);
  readonly closable = input(true);
  readonly dismissible = input(true);
  readonly closeOnEscape = input(true);
  readonly blockScroll = input(true);
  readonly styleClass = input('');
  readonly loading = input(false);

  readonly skeletonLines = [0, 1, 2, 3, 4];
}
