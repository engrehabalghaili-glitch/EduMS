import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { pipe, tap, switchMap, catchError, of } from 'rxjs';
import { FieldInventoryLogService } from '../services/field-inventory-log.service';
import type {
  FieldInventoryLog,
  CreateFieldInventoryLogRequest,
  UpdateFieldInventoryLogRequest,
} from '../models/field-inventory-logs';

interface FieldInventoryLogState {
  fieldInventoryLogs: FieldInventoryLog[];
  isLoading: boolean;
  error: string | null;
}

const initialState: FieldInventoryLogState = {
  fieldInventoryLogs: [],
  isLoading: false,
  error: null,
};

export const FieldInventoryLogStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods(
    (store, fieldInventoryLogService = inject(FieldInventoryLogService)) => ({
      loadAll: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(() =>
            fieldInventoryLogService.getAll().pipe(
              tapResponse({
                next: (fieldInventoryLogs: FieldInventoryLog[]) =>
                  patchState(store, { fieldInventoryLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      loadByInventoryPlanId: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((inventoryPlanId) =>
            fieldInventoryLogService.getByInventoryPlanId(inventoryPlanId).pipe(
              tapResponse({
                next: (fieldInventoryLogs: FieldInventoryLog[]) =>
                  patchState(store, { fieldInventoryLogs, isLoading: false }),
                error: (err: Error) =>
                  patchState(store, { error: err.message, isLoading: false }),
              }),
              catchError(() => of(undefined)),
            ),
          ),
        ),
      ),

      addNewFieldInventoryLog: rxMethod<CreateFieldInventoryLogRequest>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((dto) =>
            fieldInventoryLogService.create(dto).pipe(
              tapResponse({
                next: (entity: FieldInventoryLog) =>
                  patchState(store, {
                    fieldInventoryLogs: [...store.fieldInventoryLogs(), entity],
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

      updateFieldInventoryLog: rxMethod<{
        id: number;
        dto: UpdateFieldInventoryLogRequest;
      }>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap(({ id, dto }) =>
            fieldInventoryLogService.update(id, dto).pipe(
              tapResponse({
                next: (updated: FieldInventoryLog) =>
                  patchState(store, {
                    fieldInventoryLogs: store
                      .fieldInventoryLogs()
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

      removeFieldInventoryLog: rxMethod<number>(
        pipe(
          tap(() => patchState(store, { isLoading: true, error: null })),
          switchMap((id) =>
            fieldInventoryLogService.delete(id).pipe(
              tapResponse({
                next: () =>
                  patchState(store, {
                    fieldInventoryLogs: store
                      .fieldInventoryLogs()
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
