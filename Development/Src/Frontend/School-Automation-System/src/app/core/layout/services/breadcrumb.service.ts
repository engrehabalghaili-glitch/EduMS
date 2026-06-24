import { Injectable, signal } from '@angular/core';
import type { BreadcrumbItem } from '../main-layout/main-layout.types';

@Injectable({ providedIn: 'root' })
export class BreadcrumbService {
  private readonly _items = signal<BreadcrumbItem[]>([]);
  readonly items = this._items.asReadonly();

  set(items: BreadcrumbItem[]): void {
    this._items.set(items);
  }

  clear(): void {
    this._items.set([]);
  }
}
