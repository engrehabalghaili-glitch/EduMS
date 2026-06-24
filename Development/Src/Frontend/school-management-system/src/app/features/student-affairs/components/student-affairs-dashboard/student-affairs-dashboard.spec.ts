import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentAffairsDashboard } from './student-affairs-dashboard';

describe('StudentAffairsDashboard', () => {
  let component: StudentAffairsDashboard;
  let fixture: ComponentFixture<StudentAffairsDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentAffairsDashboard],
    }).compileComponents();

    fixture = TestBed.createComponent(StudentAffairsDashboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
