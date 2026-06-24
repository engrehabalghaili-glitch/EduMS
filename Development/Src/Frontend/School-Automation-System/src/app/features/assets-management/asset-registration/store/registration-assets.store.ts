import { Injectable, inject, signal, computed } from '@angular/core';
import { RegistrationService } from '../services/registration.service';
import type { AssetCategory, AssetStatus } from '../../../../shared/models/asset.types';
import type { AssetListItem, AssetListFilter } from '../models/registration.types';

@Injectable()
export class RegistrationAssetsStore {
  private readonly service = inject(RegistrationService);

  readonly assets = signal<AssetListItem[]>([]);
  readonly archivedAssets = signal<AssetListItem[]>([]);
  readonly loading = signal(false);
  readonly filter = signal<AssetListFilter>({ category: '', status: '', search: '' });
  readonly selectedIds = signal<string[]>([]);

  readonly filteredAssets = computed(() => {
    const list = this.assets();
    const f = this.filter();
    let result = list;

    if (f.search) {
      const q = f.search.toLowerCase();
      result = result.filter(a =>
        a.name.toLowerCase().includes(q) ||
        a.barcode.toLowerCase().includes(q) ||
        a.assignedTo.toLowerCase().includes(q)
      );
    }
    if (f.category) result = result.filter(a => a.category === f.category);
    if (f.status) result = result.filter(a => a.status === f.status);

    return result;
  });

  readonly allSelected = computed(() => {
    const filtered = this.filteredAssets();
    const selected = this.selectedIds();
    return filtered.length > 0 && filtered.every(a => selected.includes(a.id));
  });

  setFilter(update: Partial<AssetListFilter>): void {
    this.filter.update(f => ({ ...f, ...update }));
  }

  setSearch(query: string): void {
    this.setFilter({ search: query });
  }

  toggleSelection(id: string): void {
    this.selectedIds.update(s => {
      if (s.includes(id)) return s.filter(x => x !== id);
      return [...s, id];
    });
  }

  selectAll(): void {
    this.selectedIds.update(() => this.filteredAssets().map(a => a.id));
  }

  clearSelection(): void {
    this.selectedIds.set([]);
  }

  async loadAssets(): Promise<void> {
    if (this.loading()) return;
    this.loading.set(true);
    try {
      const list = await this.service.getAssets();
      this.assets.set(list);
    } finally {
      this.loading.set(false);
    }
  }

  async loadArchived(): Promise<void> {
    if (this.loading()) return;
    this.loading.set(true);
    try {
      const list = await this.service.getArchivedAssets();
      this.archivedAssets.set(list);
    } finally {
      this.loading.set(false);
    }
  }
}
