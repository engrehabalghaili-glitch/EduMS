import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { BehavioralLogService } from '../services/behavioral-log.service';
import type { BehavioralLog, CreateBehavioralLog, UpdateBehavioralLog } from '../models/behavioral-log.interface';

interface BehavioralLogState {
  behavioralLogs: BehavioralLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: BehavioralLogState = {
  behavioralLogs: [],
  isLoading: false,
  error: null,
};

export const BehavioralLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(BehavioralLogService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (behavioralLogs: BehavioralLog[]) =>
                  patchState(store, { behavioralLogs, isLoading: false }),
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
                next: (behavioralLog: BehavioralLog) =>
                  patchState(store, {
                    behavioralLogs: [...store.behavioralLogs(), behavioralLog],
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
                next: (behavioralLogs: BehavioralLog[]) =>
                  patchState(store, { behavioralLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewBehavioralLog: rxMethod<CreateBehavioralLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (behavioralLog: BehavioralLog) =>
                  patchState(store, {
                    behavioralLogs: [...store.behavioralLogs(), behavioralLog],
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

      updateBehavioralLog: rxMethod<{ id: number; dto: UpdateBehavioralLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: BehavioralLog) =>
                  patchState(store, {
                    behavioralLogs: store
                      .behavioralLogs()
                      .map((b) => (b.id === id ? updated : b)),
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

      removeBehavioralLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    behavioralLogs: store
                      .behavioralLogs()
                      .filter((b) => b.id !== id),
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
