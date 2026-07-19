import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FacilityDepartmentAssignmentService } from '../services/facility-department-assignment.service';
import type {
  FacilityDepartmentAssignment,
  CreateFacilityDepartmentAssignmentRequest,
  UpdateFacilityDepartmentAssignmentRequest,
} from '../models/facility-department-assignments';

interface FacilityDepartmentAssignmentState {
  facilityDepartmentAssignments: FacilityDepartmentAssignment[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FacilityDepartmentAssignmentState = {
  facilityDepartmentAssignments: [],
  isLoading: false,
  error: null,
};

export const FacilityDepartmentAssignmentStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, facilityDepartmentAssignmentService = inject(FacilityDepartmentAssignmentService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            facilityDepartmentAssignmentService.getAll().pipe(
              tapResponse({
                next: (facilityDepartmentAssignments: FacilityDepartmentAssignment[]) =>
                  patchState(store, { facilityDepartmentAssignments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadBySchoolId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((schoolId) =>
            facilityDepartmentAssignmentService.getBySchoolId(schoolId).pipe(
              tapResponse({
                next: (facilityDepartmentAssignments: FacilityDepartmentAssignment[]) =>
                  patchState(store, { facilityDepartmentAssignments, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFacilityDepartmentAssignment: rxMethod<CreateFacilityDepartmentAssignmentRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            facilityDepartmentAssignmentService.create(dto).pipe(
              tapResponse({
                next: (entity: FacilityDepartmentAssignment) =>
                  patchState(store, {
                    facilityDepartmentAssignments: [
                      ...store.facilityDepartmentAssignments(),
                      entity,
                    ],
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      updateFacilityDepartmentAssignment: rxMethod<{
        id: number;
        dto: UpdateFacilityDepartmentAssignmentRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            facilityDepartmentAssignmentService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FacilityDepartmentAssignment) =>
                  patchState(store, {
                    facilityDepartmentAssignments: store
                      .facilityDepartmentAssignments()
                      .map((e) => (e.id === id ? updated : e)),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      removeFacilityDepartmentAssignment: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            facilityDepartmentAssignmentService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    facilityDepartmentAssignments: store
                      .facilityDepartmentAssignments()
                      .filter((e) => e.id !== id),
                    isLoading: false,
                  }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),
    }),
  ),
);
