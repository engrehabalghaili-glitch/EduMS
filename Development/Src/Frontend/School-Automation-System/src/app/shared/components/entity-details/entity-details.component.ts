import { Component, input, ChangeDetectionStrategy } from '@angular/core';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { StatusBadgeComponent } from '../status-badge/status-badge.component';
import type { EntityDetailSection } from '../../interfaces/shared.types';

@Component({
  selector: 'app-entity-details',
  imports: [DatePipe, CurrencyPipe, StatusBadgeComponent],
  template: `
    <div class="entity-details">
      @for (section of sections(); track section.title) {
        <div class="detail-section">
          <h3 class="detail-section-title">
            @if (section.icon) {
              <span [class]="section.icon" style="margin-inline-end: 6px;"></span>
            }
            {{ section.title }}
          </h3>
          <div class="detail-grid">
            @for (field of section.fields; track field.label) {
              <div class="detail-item" [class.detail-item-full]="field.colspan === 2">
                <span class="detail-label">{{ field.label }}</span>
                @switch (field.type) {
                  @case ('badge') {
                    @if (field.statusMap) {
                      <app-status-badge [value]="field.value ?? ''" [map]="field.statusMap" />
                    } @else {
                      <span class="detail-value">{{ field.value ?? '-' }}</span>
                    }
                  }
                  @case ('currency') {
                    <span class="detail-value">{{ field.value | currency:'SAR ':'symbol':'1.0-0' }}</span>
                  }
                  @case ('date') {
                    <span class="detail-value">{{ field.value | date }}</span>
                  }
                  @case ('status') {
                    @if (field.statusMap) {
                      <app-status-badge [value]="field.value ?? ''" [map]="field.statusMap" />
                    } @else {
                      <span class="detail-value">{{ field.value ?? '-' }}</span>
                    }
                  }
                  @default {
                    <span class="detail-value">{{ field.value ?? '-' }}</span>
                  }
                }
              </div>
            }
          </div>
        </div>
      }
    </div>
  `,
  styleUrl: './entity-details.component.scss',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EntityDetailsComponent {
  readonly sections = input.required<EntityDetailSection[]>();
}
