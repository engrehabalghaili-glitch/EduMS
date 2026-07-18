import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { CanteenPurchaseService } from '../services/canteen-purchase.service';
import type { StudentCanteenPurchaseLog, CreateStudentCanteenPurchaseLog, UpdateStudentCanteenPurchaseLog } from '../models/canteen-purchase.interface';

interface CanteenPurchaseState {
  studentCanteenPurchaseLogs: StudentCanteenPurchaseLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: CanteenPurchaseState = {
  studentCanteenPurchaseLogs: [],
  isLoading: false,
  error: null,
};

export const CanteenPurchaseStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(CanteenPurchaseService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentCanteenPurchaseLogs: StudentCanteenPurchaseLog[]) =>
                  patchState(store, { studentCanteenPurchaseLogs, isLoading: false }),
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
                next: (studentCanteenPurchaseLog: StudentCanteenPurchaseLog) =>
                  patchState(store, {
                    studentCanteenPurchaseLogs: [...store.studentCanteenPurchaseLogs(), studentCanteenPurchaseLog],
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
                next: (studentCanteenPurchaseLogs: StudentCanteenPurchaseLog[]) =>
                  patchState(store, { studentCanteenPurchaseLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewCanteenPurchase: rxMethod<CreateStudentCanteenPurchaseLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentCanteenPurchaseLog: StudentCanteenPurchaseLog) =>
                  patchState(store, {
                    studentCanteenPurchaseLogs: [...store.studentCanteenPurchaseLogs(), studentCanteenPurchaseLog],
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

      updateCanteenPurchase: rxMethod<{ id: number; dto: UpdateStudentCanteenPurchaseLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentCanteenPurchaseLog) =>
                  patchState(store, {
                    studentCanteenPurchaseLogs: store
                      .studentCanteenPurchaseLogs()
                      .map((c) => (c.id === id ? updated : c)),
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

      removeCanteenPurchase: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentCanteenPurchaseLogs: store
                      .studentCanteenPurchaseLogs()
                      .filter((c) => c.id !== id),
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
