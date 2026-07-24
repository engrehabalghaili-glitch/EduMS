import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { pipe, switchMap, tap } from 'rxjs';
import { StudentParentConferenceReservationsService } from './student-parent-conference-reservations.service';
import { StudentParentConferenceReservation, CreateStudentParentConferenceReservation, UpdateStudentParentConferenceReservation } from '@modules/m2-student-Affairs/interfaces/parent-conference.interface';

type StudentParentConferenceReservationsStoreState = {
  items: StudentParentConferenceReservation[];
  selectedItem: StudentParentConferenceReservation | null;
  isLoading: boolean;
  error: string | null;
};

const initialState: StudentParentConferenceReservationsStoreState = {
  items: [],
  selectedItem: null,
  isLoading: false,
  error: null,
};

export const StudentParentConferenceReservationsStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, service = inject(StudentParentConferenceReservationsService)) => ({
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
    create: rxMethod<CreateStudentParentConferenceReservation>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((payload) => service.create(payload).pipe(
          tap({
            next: (response) => {
              if (response) {
                patchState(store, { items: [...store.items(), response as StudentParentConferenceReservation] });
              }
              patchState(store, { isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error creating item', isLoading: false })
          })
        ))
      )
    ),
    update: rxMethod<{id: number | string, payload: UpdateStudentParentConferenceReservation}>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({id, payload}) => service.update(id, payload).pipe(
          tap({
            next: () => {
              const updatedItems = store.items().map(item => (item as any).id === id ? { ...item, ...payload } : item);
              patchState(store, { items: updatedItems as StudentParentConferenceReservation[] });
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
              patchState(store, { items: updatedItems as StudentParentConferenceReservation[], isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error deleting item', isLoading: false })
          })
        ))
      )
    )
  }))
);
