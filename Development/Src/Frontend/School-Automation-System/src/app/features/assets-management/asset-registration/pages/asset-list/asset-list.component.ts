import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { DataTableComponent } from '../../../../../shared/components/data-table/data-table.component';
import { AppInputText } from '../../../../../shared/components/input-text/input-text.component';
import { AppSelect } from '../../../../../shared/components/select/select.component';
import { AppButton } from '../../../../../shared/components/button/button.component';
import { AppCard } from '../../../../../shared/components/card/card.component';
import { RegistrationAssetsStore } from '../../store/registration-assets.store';
import { CATEGORY_OPTIONS, STATUS_OPTIONS } from '../../models/registration.constants';
import type { TableColumn, TableConfig, StatusMap } from '../../../../../shared/interfaces/shared.types';

const ASSET_STATUS_MAP: StatusMap = {
  active: { label: 'نشط', severity: 'success' },
  maintenance: { label: 'قيد الصيانة', severity: 'warn' },
  broken: { label: 'عاطل', severity: 'danger' },
  retired: { label: 'مستبعد', severity: 'secondary' },
  stored: { label: 'مخزّن', severity: 'info' },
};

@Component({
  selector: 'app-asset-list',
  standalone: true,
  imports: [
    RouterLink, FormsModule,
    DataTableComponent,
    AppInputText, AppSelect, AppButton, AppCard,
  ],
  templateUrl: './asset-list.html',
  styleUrl: './asset-list.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssetListComponent implements OnInit {
  readonly store = inject(RegistrationAssetsStore);

  readonly categoryOptions = CATEGORY_OPTIONS;
  readonly statusOptions = STATUS_OPTIONS;

  readonly columns: TableColumn[] = [
    { field: 'barcode', header: 'الباركود', sortable: true },
    { field: 'name', header: 'الاسم', sortable: true },
    { field: 'category', header: 'الفئة', sortable: true },
    { field: 'status', header: 'الحالة', sortable: true, type: 'status', statusMap: ASSET_STATUS_MAP },
    { field: 'location', header: 'الموقع', sortable: true },
    { field: 'purchaseCost', header: 'التكلفة', sortable: true, type: 'currency' },
    { field: 'assignedTo', header: 'المسؤول', sortable: true },
  ];

  readonly tableConfig: TableConfig = {
    selectionMode: 'multiple',
    paginator: true,
    rows: 20,
  };

  ngOnInit(): void {
    void this.store.loadAssets();
  }

  onSearch(query: string): void {
    this.store.setSearch(query);
  }

  onCategoryChange(cat: string): void {
    this.store.setFilter({ category: cat as any });
  }

  onStatusChange(status: string): void {
    this.store.setFilter({ status: status as any });
  }


}
