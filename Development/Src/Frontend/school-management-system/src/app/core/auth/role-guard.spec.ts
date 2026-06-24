import { TestBed } from '@angular/core/testing';

import { roleGuard } from './role-guard';
import { AuthService } from './auth';

describe('RoleGuard', () => {
  let service: AuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(roleGuard);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
