import { ChangeDetectionStrategy, Component, input, model } from '@angular/core';
import { DialogModule } from 'primeng/dialog';

@Component({
  selector: 'app-modal-shell',
  imports: [DialogModule],
  templateUrl: './modal-shell.html',
  styleUrl: './modal-shell.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ModalShell {
  readonly visible = model(false);
  readonly header = input('');
  readonly width = input('32rem');
  readonly modal = input(true);
  readonly closable = input(true);
  readonly showHeader = input(true);
  readonly draggable = input(false);
  readonly resizable = input(false);
  readonly blockScroll = input(true);
  readonly dismissableMask = input(false);
  readonly closeOnEscape = input(true);
  readonly breakpoints = input<Record<string, string>>({ '960px': '90vw', '640px': '95vw' });
  readonly position = input<'center' | 'top' | 'bottom' | 'left' | 'right' | 'topleft' | 'topright' | 'bottomleft' | 'bottomright'>('center');
  readonly styleClass = input('');
}
