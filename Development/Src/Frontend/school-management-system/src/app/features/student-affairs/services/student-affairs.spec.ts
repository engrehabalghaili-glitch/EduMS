import { TestBed } from '@angular/core/testing';

import { StudentAffairs } from './student-affairs';

describe('StudentAffairs', () => {
  let service: StudentAffairs;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentAffairs);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
