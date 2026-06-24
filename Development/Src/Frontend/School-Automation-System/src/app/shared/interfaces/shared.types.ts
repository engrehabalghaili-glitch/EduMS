export interface SidebarItem {
  label: string;
  icon: string;
  route?: string;
  items?: SidebarItem[];
  badge?: number;
  disabled?: boolean;
}

export interface PageHeaderConfig {
  title: string;
  subtitle?: string;
  showSearch?: boolean;
  searchPlaceholder?: string;
  searchValue?: string;
  actions?: PageAction[];
}

export interface PageAction {
  label: string;
  icon: string;
  severity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  outlined?: boolean;
  raised?: boolean;
  disabled?: boolean;
  command: () => void;
}

export interface StatsCardConfig {
  value: string | number;
  label: string;
  icon: string;
  color: 'info' | 'success' | 'warn' | 'danger' | 'primary' | 'gray';
  trend?: { direction: 'up' | 'down'; value: string };
}

export interface TableColumn {
  field: string;
  header: string;
  sortable?: boolean;
  filterable?: boolean;
  width?: string;
  align?: 'left' | 'center' | 'right';
  type?: 'text' | 'number' | 'date' | 'status' | 'currency' | 'badge' | 'template';
  statusMap?: StatusMap;
  templateRef?: string;
  hidden?: boolean;
}

export interface TableAction {
  label: string;
  icon?: string;
  severity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  outlined?: boolean;
  command: (row: any) => void;
  visible?: (row: any) => boolean;
  disabled?: (row: any) => boolean;
}

export interface TableConfig {
  paginator?: boolean;
  rows?: number;
  rowsPerPageOptions?: number[];
  sortField?: string;
  sortOrder?: number;
  selectionMode?: 'single' | 'multiple' | null;
  exportEnabled?: boolean;
  exportFilename?: string;
  globalFilter?: boolean;
  showCurrentPageReport?: boolean;
  lazy?: boolean;
  loading?: boolean;
  totalRecords?: number;
}

export interface FilterField {
  field: string;
  header: string;
  type: 'text' | 'select' | 'date' | 'date-range' | 'multi-select';
  options?: { label: string; value: any }[];
  placeholder?: string;
}

export interface StatusMap {
  [key: string]: {
    label: string;
    severity: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  };
}

export interface FormActionConfig {
  submitLabel?: string;
  cancelLabel?: string;
  submitIcon?: string;
  cancelIcon?: string;
  submitDisabled?: boolean;
  submitLoading?: boolean;
  showCancel?: boolean;
  submitSeverity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  cancelSeverity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
}

export interface EntityDetailField {
  label: string;
  value: string | number | null | undefined;
  type?: 'text' | 'currency' | 'date' | 'badge' | 'status';
  statusMap?: StatusMap;
  copyable?: boolean;
  colspan?: 1 | 2;
}

export interface EntityDetailSection {
  title: string;
  fields: EntityDetailField[];
  icon?: string;
}

export interface ConfirmationConfig {
  title: string;
  message: string;
  icon?: string;
  acceptLabel?: string;
  rejectLabel?: string;
  acceptSeverity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
  rejectSeverity?: 'success' | 'info' | 'warn' | 'danger' | 'secondary' | 'contrast';
}

export interface EmptyStateConfig {
  title: string;
  message?: string;
  icon?: string;
  actionLabel?: string;
  actionIcon?: string;
  action?: () => void;
}
