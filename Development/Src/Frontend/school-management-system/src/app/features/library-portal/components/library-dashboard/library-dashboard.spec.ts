import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibraryDashboard } from './library-dashboard';

describe('LibraryDashboard', () => {
  let component: LibraryDashboard;
  let fixture: ComponentFixture<LibraryDashboard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LibraryDashboard],
    }).compileComponents();

    fixture = TestBed.createComponent(LibraryDashboard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
