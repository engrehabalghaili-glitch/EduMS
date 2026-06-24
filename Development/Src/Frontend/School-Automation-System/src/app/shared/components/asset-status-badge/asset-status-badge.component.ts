import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { AppTag } from '../tag/tag.component';

const ASSET_MAP: Record<string, { label: string; severity: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast' }> = {
  active:       { label: 'نشط',       severity: 'success' },
  maintenance:  { label: 'قيد الصيانة', severity: 'warn' },
  broken:       { label: 'عاطل',      severity: 'danger' },
  retired:      { label: 'مستبعد',    severity: 'secondary' },
  stored:       { label: 'مخزّن',     severity: 'info' },
};

const PRIORITY_MAP: Record<string, { label: string; severity: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast' }> = {
  urgent:  { label: 'عاجل',    severity: 'danger' },
  medium:  { label: 'متوسط',   severity: 'warn' },
  routine: { label: 'روتيني',  severity: 'info' },
};

const MAINTENANCE_MAP: Record<string, { label: string; severity: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast' }> = {
  pending:      { label: 'قيد الانتظار', severity: 'warn' },
  'in-progress': { label: 'قيد الإصلاح',  severity: 'info' },
  completed:    { label: 'تم الإصلاح',   severity: 'success' },
};

const BUILTIN_MAPS: Record<string, Record<string, { label: string; severity: any }>> = {
  asset: ASSET_MAP,
  priority: PRIORITY_MAP,
  maintenance: MAINTENANCE_MAP,
};

@Component({
  selector: 'app-asset-status-badge',
  standalone: true,
  imports: [AppTag],
  template: `
    <app-tag [value]="mapped().label" [severity]="mapped().severity" />
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssetStatusBadge {
  readonly value = input.required<string>();
  readonly mapType = input<'asset' | 'priority' | 'maintenance'>('asset');
  readonly customMap = input<Record<string, { label: string; severity: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast' }>>();

  readonly mapped = computed(() => {
    const override = this.customMap();
    if (override) {
      return override[this.value()] ?? { label: this.value(), severity: 'info' };
    }
    const map = BUILTIN_MAPS[this.mapType()];
    return map[this.value()] ?? { label: this.value(), severity: 'info' };
  });
}
