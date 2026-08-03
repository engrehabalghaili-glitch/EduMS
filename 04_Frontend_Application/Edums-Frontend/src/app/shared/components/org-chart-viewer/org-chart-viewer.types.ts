export interface OrgChartNode {
  key: string;
  label: string;
  type: 'school' | 'department' | 'unit' | 'position';
  data: {
    title: string;
    name?: string;
    employeeCount?: number;
    status?: string;
    avatar?: string;
  };
  children?: OrgChartNode[];
  expanded?: boolean;
  styleClass?: string;
}
