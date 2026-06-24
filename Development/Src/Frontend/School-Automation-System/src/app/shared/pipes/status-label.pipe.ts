import { Pipe, PipeTransform } from '@angular/core';
import type { StatusMap } from '../interfaces/shared.types';

@Pipe({ name: 'statusLabel', standalone: true })
export class StatusLabelPipe implements PipeTransform {
  transform(value: string, map: StatusMap): string {
    return map[value]?.label ?? value;
  }
}
