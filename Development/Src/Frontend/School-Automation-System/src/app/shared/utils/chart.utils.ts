export function cssVar(name: string, fallback = '#000000'): string {
  if (typeof document === 'undefined') return fallback;
  return getComputedStyle(document.documentElement).getPropertyValue(name).trim() || fallback;
}

export interface ChartColors {
  primary: string;
  info: string;
  warning: string;
  success: string;
  danger: string;
  surface: string;
}

export function getChartColors(): ChartColors {
  return {
    primary: cssVar('--p-primary-color', '#3b82f6'),
    info: cssVar('--p-info-color', '#8b5cf6'),
    warning: cssVar('--p-warning-color', '#f59e0b'),
    success: cssVar('--p-success-color', '#10b981'),
    danger: cssVar('--p-danger-color', '#ef4444'),
    surface: cssVar('--surface-border', '#f1f5f9'),
  };
}
