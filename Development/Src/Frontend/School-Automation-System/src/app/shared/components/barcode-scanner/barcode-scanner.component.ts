import { ChangeDetectionStrategy, Component, input, model, output, signal } from '@angular/core';
import { AppDialog } from '../dialog/dialog.component';
import { AppInputText } from '../input-text/input-text.component';
import { AppButton } from '../button/button.component';
import type { Asset } from '../../models/asset.types';

@Component({
  selector: 'app-barcode-scanner',
  standalone: true,
  imports: [AppDialog, AppInputText, AppButton],
  template: `
    <app-dialog [(visible)]="visible" header="مسح الباركود" width="420px">
      <div class="scanner-content">
        <div class="scanner-preview">
          <span class="pi pi-camera scanner-icon"></span>
          <p>وجّه الكاميرا نحو الباركود أو أدخل الرقم يدوياً</p>
        </div>
        <div class="scanner-input">
          <app-input-text [(value)]="searchInput" placeholder="أدخل رقم الأصل أو الباركود" styleClass="scanner-field" />
        </div>
        @if (foundAsset(); as asset) {
          <div class="scanner-result" (click)="selectAsset(asset)">
            <span class="pi pi-check-circle result-icon"></span>
            <div>
              <strong>{{ asset.name }}</strong>
              <span>{{ asset.barcode }} · {{ asset.location }}</span>
            </div>
          </div>
        }
        <div class="scanner-actions">
          <app-button label="بحث" icon="pi pi-search" (click)="emitSearch()" />
        </div>
      </div>
    </app-dialog>
  `,
  styles: [`
    .scanner-content { display: flex; flex-direction: column; align-items: center; gap: 1rem; padding: 0.5rem 0; }
    .scanner-preview { display: flex; flex-direction: column; align-items: center; gap: 0.5rem; padding: 2rem; border: 2px dashed var(--gray-300); border-radius: 12px; width: 100%; }
    .scanner-icon { font-size: 3rem; color: var(--gray-400); }
    .scanner-preview p { font-size: var(--font-size-sm); color: var(--gray-500); text-align: center; margin: 0; }
    .scanner-input { width: 100%; }
    :host ::ng-deep .scanner-field { width: 100%; text-align: center; direction: ltr; padding: 0.6rem; }
    .scanner-result { display: flex; align-items: center; gap: 0.75rem; padding: 0.75rem; background: var(--success-100); border: 1px solid var(--success-300); border-radius: var(--border-radius-lg); width: 100%; cursor: pointer; }
    .result-icon { color: var(--success-500); font-size: 1.5rem; }
    .scanner-result div { display: flex; flex-direction: column; }
    .scanner-result strong { font-size: var(--font-size-sm); color: var(--success-800); }
    .scanner-result span { font-size: var(--font-size-xs); color: var(--success-700); }
    .scanner-actions { display: flex; gap: 0.5rem; }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BarcodeScanner {
  readonly visible = model(false);
  readonly foundAsset = input<Asset | null>(null);

  readonly searchChange = output<string>();
  readonly assetSelected = output<Asset>();

  readonly searchInput = signal('');

  emitSearch(): void {
    const input = this.searchInput();
    if (!input) return;
    this.searchChange.emit(input);
  }

  selectAsset(asset: Asset): void {
    this.visible.set(false);
    this.assetSelected.emit(asset);
  }
}
