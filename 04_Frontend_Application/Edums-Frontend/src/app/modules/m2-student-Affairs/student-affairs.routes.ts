import { Routes } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  template: '<h2 style="padding: 20px;">صفحة شؤون الطلاب (قيد البرمجة)</h2>',
  standalone: true
})
export class DummyComponent {}

export const routes: Routes = [
  { path: '', component: DummyComponent }
];
