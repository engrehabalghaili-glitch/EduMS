import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { AuthStore } from '../../../core/auth';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Header {
  protected readonly authStore = inject(AuthStore);
}
