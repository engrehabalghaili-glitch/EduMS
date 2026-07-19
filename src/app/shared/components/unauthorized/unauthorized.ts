import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-unauthorized',
  imports: [RouterLink],
  template: `
    <div class="min-h-screen bg-slate-50 flex items-center justify-center p-4">
      <div class="text-center">
        <h1 class="text-6xl font-bold text-slate-300">403</h1>
        <p class="mt-2 text-lg text-slate-600">Access denied</p>
        <p class="mt-1 text-sm text-slate-400">You don't have permission to access this page.</p>
        <a routerLink="/auth/login" class="mt-6 inline-block rounded-lg bg-blue-600 px-4 py-2 text-sm font-semibold text-white hover:bg-blue-500">Back to sign in</a>
      </div>
    </div>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Unauthorized {

}
