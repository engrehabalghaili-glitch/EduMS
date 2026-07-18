import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { InventoryCustodyService } from '../services/inventory-custody.service';
import type { StudentInventoryCustody, CreateStudentInventoryCustody, UpdateStudentInventoryCustody } from '../models/inventory-custody.interface';

interface InventoryCustodyState {
  studentInventoryCustodies: StudentInventoryCustody[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InventoryCustodyState = {
  studentInventoryCustodies: [],
  isLoading: false,
  error: null,
};

export const InventoryCustodyStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(InventoryCustodyService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentInventoryCustodies: StudentInventoryCustody[]) =>
                  patchState(store, { studentInventoryCustodies, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadById: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.getById(id).pipe(
              tapResponse({
                next: (studentInventoryCustody: StudentInventoryCustody) =>
                  patchState(store, {
                    studentInventoryCustodies: [...store.studentInventoryCustodies(), studentInventoryCustody],
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

      loadByStudentId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((studentId) =>
            service.getByStudentId(studentId).pipe(
              tapResponse({
                next: (studentInventoryCustodies: StudentInventoryCustody[]) =>
                  patchState(store, { studentInventoryCustodies, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewInventoryCustody: rxMethod<CreateStudentInventoryCustody>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentInventoryCustody: StudentInventoryCustody) =>
                  patchState(store, {
                    studentInventoryCustodies: [...store.studentInventoryCustodies(), studentInventoryCustody],
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

      updateInventoryCustody: rxMethod<{ id: number; dto: UpdateStudentInventoryCustody }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentInventoryCustody) =>
                  patchState(store, {
                    studentInventoryCustodies: store
                      .studentInventoryCustodies()
                      .map((i) => (i.id === id ? updated : i)),
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

      removeInventoryCustody: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentInventoryCustodies: store
                      .studentInventoryCustodies()
                      .filter((i) => i.id !== id),
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
