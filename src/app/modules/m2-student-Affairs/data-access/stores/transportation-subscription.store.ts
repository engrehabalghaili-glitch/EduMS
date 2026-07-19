import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { TransportationSubscriptionService } from '../services/transportation-subscription.service';
import type { StudentTransportationSubscription, CreateStudentTransportationSubscription, UpdateStudentTransportationSubscription } from '../models/transportation-subscription.interface';

interface TransportationSubscriptionState {
  studentTransportationSubscriptions: StudentTransportationSubscription[];
  isLoading: boolean;
  error: string | null;
}

const initialState: TransportationSubscriptionState = {
  studentTransportationSubscriptions: [],
  isLoading: false,
  error: null,
};

export const TransportationSubscriptionStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(TransportationSubscriptionService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (studentTransportationSubscriptions: StudentTransportationSubscription[]) =>
                  patchState(store, { studentTransportationSubscriptions, isLoading: false }),
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
                next: (studentTransportationSubscription: StudentTransportationSubscription) =>
                  patchState(store, {
                    studentTransportationSubscriptions: [...store.studentTransportationSubscriptions(), studentTransportationSubscription],
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
                next: (studentTransportationSubscriptions: StudentTransportationSubscription[]) =>
                  patchState(store, { studentTransportationSubscriptions, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewTransportationSubscription: rxMethod<CreateStudentTransportationSubscription>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (studentTransportationSubscription: StudentTransportationSubscription) =>
                  patchState(store, {
                    studentTransportationSubscriptions: [...store.studentTransportationSubscriptions(), studentTransportationSubscription],
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

      updateTransportationSubscription: rxMethod<{ id: number; dto: UpdateStudentTransportationSubscription }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: StudentTransportationSubscription) =>
                  patchState(store, {
                    studentTransportationSubscriptions: store
                      .studentTransportationSubscriptions()
                      .map((t) => (t.id === id ? updated : t)),
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

      removeTransportationSubscription: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    studentTransportationSubscriptions: store
                      .studentTransportationSubscriptions()
                      .filter((t) => t.id !== id),
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
