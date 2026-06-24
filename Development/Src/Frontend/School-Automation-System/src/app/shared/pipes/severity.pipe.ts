import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'severity', standalone: true })
export class SeverityPipe implements PipeTransform {
  transform(value: string, severityMap: Record<string, string>): string {
    return severityMap[value] ?? 'info';
  }
}
