import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Skeleton } from 'primeng/skeleton';

export type SkeletonType = 'card' | 'table' | 'form' | 'text' | 'circle' | 'custom';
export type SkeletonAnimation = 'wave' | 'none';

@Component({
  selector: 'app-loading-skeleton',
  imports: [Skeleton],
  templateUrl: './loading-skeleton.html',
  styleUrl: './loading-skeleton.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoadingSkeleton {
  readonly type = input<SkeletonType>('text');
  readonly rows = input(5);
  readonly columns = input(4);
  readonly cardsPerRow = input(3);
  readonly height = input('');
  readonly width = input('');
  readonly animation = input<SkeletonAnimation>('wave');

  skeletonAnimation(): 'wave' | '' {
    return this.animation() === 'none' ? '' : 'wave';
  }

  cardGridColumns(): string {
    return `repeat(${this.cardsPerRow()}, 1fr)`;
  }

  rowIndexes(): number[] {
    return Array.from({ length: this.rows() }, (_, i) => i);
  }

  colIndexes(): number[] {
    return Array.from({ length: this.columns() }, (_, i) => i);
  }
}
