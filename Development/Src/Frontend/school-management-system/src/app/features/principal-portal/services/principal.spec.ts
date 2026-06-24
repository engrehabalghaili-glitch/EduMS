import { TestBed } from '@angular/core/testing';

import { Principal } from './principal';

describe('Principal', () => {
  let service: Principal;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Principal);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
