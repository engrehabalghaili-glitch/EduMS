import { TestBed } from '@angular/core/testing';

import { authGuard } from './auth-guard';
import { AuthService } from './auth';

describe('AuthGuard', () => {
  let service: AuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(authGuard);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
