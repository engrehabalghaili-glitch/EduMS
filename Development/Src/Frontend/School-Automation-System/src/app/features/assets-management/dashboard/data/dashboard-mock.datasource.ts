import { Injectable } from '@angular/core';
import { DashboardDataSource } from './dashboard.datasource';
import {
  MOCK_ASSETS, MOCK_DEPRECIATION, MOCK_EXPIRED_ASSETS, MOCK_BUREAU_REPORT,
} from '../../data/mocks/assets.mock';
import { getChartColors } from '../../../../shared/utils/chart.utils';
import type { DashboardData } from '../models/dashboard.types';

@Injectable()
export class DashboardMockDataSource extends DashboardDataSource {
  async getDashboard(): Promise<DashboardData> {
    await new Promise(resolve => setTimeout(resolve, 300));
    const colors = getChartColors();
    const assets = [...MOCK_ASSETS];
    const depreciation = [...MOCK_DEPRECIATION];
    const expiredAssets = [...MOCK_EXPIRED_ASSETS];

    return {
      totalAssets: assets.length,
      brokenCount: assets.filter(a => a.status === 'broken').length,
      totalValue: assets.reduce((s, a) => s + a.currentValue, 0),
      annualDepreciation: depreciation.reduce((s, d) => s + d.annualDepreciation, 0),
      expiredCount: expiredAssets.length,

      categoryDistribution: {
        labels: ['أجهزة تقنية', 'أثاث', 'مركبات', 'مباني'],
        data: [
          assets.filter(a => a.category === 'technology').length,
          assets.filter(a => a.category === 'furniture').length,
          assets.filter(a => a.category === 'vehicle').length,
          assets.filter(a => a.category === 'building').length,
        ],
      },

      topAssets: [...assets]
        .sort((a, b) => b.purchaseCost - a.purchaseCost)
        .slice(0, 5)
        .map(a => ({
          id: a.id,
          name: a.name,
          barcode: a.barcode,
          category: a.category,
          status: a.status,
          purchaseCost: a.purchaseCost,
          currentValue: a.currentValue,
          location: a.location,
          assignedTo: a.assignedTo,
        })),

      depreciation: {
        labels: depreciation.map(d => d.category),
        bookValues: depreciation.map(d => d.bookValue),
        accumulatedDepreciation: depreciation.map(d => d.accumulatedDepreciation),
        annualDepreciationValues: depreciation.map(d => d.annualDepreciation),
        totalAnnualDepreciation: depreciation.reduce((s, d) => s + d.annualDepreciation, 0),
      },

      expiredAssets: expiredAssets.map(e => ({
        name: e.name,
        category: e.category,
        purchaseYear: e.purchaseYear,
        replacementCost: e.replacementCost,
        reason: e.reason,
      })),

      bureauReport: { ...MOCK_BUREAU_REPORT },
    };
  }
}
