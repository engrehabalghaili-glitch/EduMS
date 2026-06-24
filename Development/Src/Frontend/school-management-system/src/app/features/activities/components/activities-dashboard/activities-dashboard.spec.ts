import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivitiesDashboard } from './activities-dashboard';

describe('ActivitiesDashboard', () => {
  let component: ActivitiesDashboard;
  let fixture: ComponentFixture<ActivitiesDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActivitiesDashboard],
    }).compileComponents();

    fixture = TestBed.createComponent(ActivitiesDashboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
