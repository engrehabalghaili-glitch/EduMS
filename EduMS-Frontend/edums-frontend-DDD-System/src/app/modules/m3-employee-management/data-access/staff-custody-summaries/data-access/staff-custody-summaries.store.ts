import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { pipe, switchMap, tap } from 'rxjs';
import { StaffCustodySummariesService } from './staff-custody-summaries.service';
import { StaffCustodySummary, CreateStaffCustodySummary, UpdateStaffCustodySummary } from '@modules/m3-employee-management/interfaces/staff-custody-summary.types';

type StaffCustodySummariesStoreState = {
  items: StaffCustodySummary[];
  selectedItem: StaffCustodySummary | null;
  isLoading: boolean;
  error: string | null;
};

const initialState: StaffCustodySummariesStoreState = {
  items: [],
  selectedItem: null,
  isLoading: false,
  error: null,
};

export const StaffCustodySummariesStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, service = inject(StaffCustodySummariesService)) => ({
    loadAll: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() => service.getAll().pipe(
          tap({
            next: (response) => patchState(store, { items: response || [], isLoading: false }),
            error: (err) => patchState(store, { error: err.message || 'Error loading data', isLoading: false })
          })
        ))
      )
    ),
    loadById: rxMethod<number | string>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) => service.getById(id).pipe(
          tap({
            next: (response) => patchState(store, { selectedItem: response, isLoading: false }),
            error: (err) => patchState(store, { error: err.message || 'Error loading data', isLoading: false })
          })
        ))
      )
    ),
    create: rxMethod<CreateStaffCustodySummary>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((payload) => service.create(payload).pipe(
          tap({
            next: (response) => {
              if (response) {
                patchState(store, { items: [...store.items(), response as StaffCustodySummary] });
              }
              patchState(store, { isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error creating item', isLoading: false })
          })
        ))
      )
    ),
    update: rxMethod<{id: number | string, payload: UpdateStaffCustodySummary}>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({id, payload}) => service.update(id, payload).pipe(
          tap({
            next: () => {
              const updatedItems = store.items().map(item => (item as any).id === id ? { ...item, ...payload } : item);
              patchState(store, { items: updatedItems as StaffCustodySummary[] });
              patchState(store, { isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error updating item', isLoading: false })
          })
        ))
      )
    ),
    delete: rxMethod<number | string>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) => service.delete(id).pipe(
          tap({
            next: () => {
              const updatedItems = store.items().filter(item => (item as any).id !== id);
              patchState(store, { items: updatedItems as StaffCustodySummary[], isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error deleting item', isLoading: false })
          })
        ))
      )
    )
  }))
);
