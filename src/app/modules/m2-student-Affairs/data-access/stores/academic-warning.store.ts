import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { AcademicWarningService } from '../services/academic-warning.service';
import type { DetailedAcademicWarningLog, CreateDetailedAcademicWarningLog, UpdateDetailedAcademicWarningLog } from '../models/academic-warning.interface';

interface AcademicWarningState {
  detailedAcademicWarningLogs: DetailedAcademicWarningLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: AcademicWarningState = {
  detailedAcademicWarningLogs: [],
  isLoading: false,
  error: null,
};

export const AcademicWarningStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, service = inject(AcademicWarningService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            service.getAll().pipe(
              tapResponse({
                next: (detailedAcademicWarningLogs: DetailedAcademicWarningLog[]) =>
                  patchState(store, { detailedAcademicWarningLogs, isLoading: false }),
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
                next: (detailedAcademicWarningLog: DetailedAcademicWarningLog) =>
                  patchState(store, {
                    detailedAcademicWarningLogs: [...store.detailedAcademicWarningLogs(), detailedAcademicWarningLog],
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
                next: (detailedAcademicWarningLogs: DetailedAcademicWarningLog[]) =>
                  patchState(store, { detailedAcademicWarningLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewAcademicWarning: rxMethod<CreateDetailedAcademicWarningLog>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            service.create(dto).pipe(
              tapResponse({
                next: (detailedAcademicWarningLog: DetailedAcademicWarningLog) =>
                  patchState(store, {
                    detailedAcademicWarningLogs: [...store.detailedAcademicWarningLogs(), detailedAcademicWarningLog],
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

      updateAcademicWarning: rxMethod<{ id: number; dto: UpdateDetailedAcademicWarningLog }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            service.update(id, dto).pipe(
              tapResponse({
                next: (updated: DetailedAcademicWarningLog) =>
                  patchState(store, {
                    detailedAcademicWarningLogs: store
                      .detailedAcademicWarningLogs()
                      .map((a) => (a.id === id ? updated : a)),
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

      removeAcademicWarning: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            service.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    detailedAcademicWarningLogs: store
                      .detailedAcademicWarningLogs()
                      .filter((a) => a.id !== id),
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
