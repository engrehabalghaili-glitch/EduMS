import { TestBed } from '@angular/core/testing';
import { PermissionService } from './permission.service';
import { UserRole } from '../main-layout/main-layout.types';

describe('PermissionService', () => {
  let service: PermissionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PermissionService);
  });

  it('should default to null role', () => {
    expect(service.currentRole()).toBeNull();
  });

  it('should set and get role', () => {
    service.setRole(UserRole.SCHOOL_MANAGER);
    expect(service.currentRole()).toBe(UserRole.SCHOOL_MANAGER);
  });

  it('hasAnyRole should return true for matching role', () => {
    service.setRole(UserRole.TEACHER);
    expect(service.hasAnyRole([UserRole.SCHOOL_MANAGER, UserRole.TEACHER])).toBe(true);
  });

  it('hasAnyRole should return false for non-matching role', () => {
    service.setRole(UserRole.STUDENT);
    expect(service.hasAnyRole([UserRole.SCHOOL_MANAGER, UserRole.TEACHER])).toBe(false);
  });
});
