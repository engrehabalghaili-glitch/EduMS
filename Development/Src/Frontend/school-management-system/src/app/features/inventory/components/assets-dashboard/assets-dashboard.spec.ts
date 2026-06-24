import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetsDashboard } from './assets-dashboard';

describe('AssetsDashboard', () => {
  let component: AssetsDashboard;
  let fixture: ComponentFixture<AssetsDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssetsDashboard],
    }).compileComponents();

    fixture = TestBed.createComponent(AssetsDashboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
