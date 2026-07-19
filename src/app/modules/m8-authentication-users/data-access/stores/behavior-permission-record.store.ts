import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { BehaviorPermissionRecord, CreateBehaviorPermissionRecord, UpdateBehaviorPermissionRecord } from '../models/behavior-permission-record.models';
import { BehaviorPermissionRecordService } from '../services/behavior-permission-record.service';

interface BehaviorPermissionRecordState {
  behaviorPermissionRecords: BehaviorPermissionRecord[];
  isLoading: boolean;
  error: string | null;
}

const initialState: BehaviorPermissionRecordState = {
  behaviorPermissionRecords: [],
  isLoading: false,
  error: null,
};

export const BehaviorPermissionRecordStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, behaviorPermissionRecordService = inject(BehaviorPermissionRecordService)) => ({
    loadAllBehaviorPermissionRecords: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          behaviorPermissionRecordService.getAll().pipe(
            tapResponse({
              next: (behaviorPermissionRecords) => patchState(store, { behaviorPermissionRecords, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewBehaviorPermissionRecord: rxMethod<CreateBehaviorPermissionRecord>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          behaviorPermissionRecordService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { behaviorPermissionRecords: [...store.behaviorPermissionRecords(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateBehaviorPermissionRecord: rxMethod<{ id: number; dto: UpdateBehaviorPermissionRecord }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          behaviorPermissionRecordService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                behaviorPermissionRecords: store.behaviorPermissionRecords().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteBehaviorPermissionRecord: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          behaviorPermissionRecordService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                behaviorPermissionRecords: store.behaviorPermissionRecords().filter((e) => (e as { id: number }).id !== id),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);