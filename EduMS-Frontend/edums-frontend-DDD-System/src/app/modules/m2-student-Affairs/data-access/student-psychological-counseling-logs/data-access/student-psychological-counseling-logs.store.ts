import { inject } from '@angular/core';
import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { pipe, switchMap, tap } from 'rxjs';
import { StudentPsychologicalCounselingLogsService } from './student-psychological-counseling-logs.service';
import { StudentPsychologicalCounselingLog, CreateStudentPsychologicalCounselingLogPayload, UpdateStudentPsychologicalCounselingLogPayload } from '../../../../core/api/interfaces/M2_StudentAffairs/studentpsychologicalcounselinglog.interface';

type StudentPsychologicalCounselingLogsStoreState = {
  items: StudentPsychologicalCounselingLog[];
  selectedItem: StudentPsychologicalCounselingLog | null;
  isLoading: boolean;
  error: string | null;
};

const initialState: StudentPsychologicalCounselingLogsStoreState = {
  items: [],
  selectedItem: null,
  isLoading: false,
  error: null,
};

export const StudentPsychologicalCounselingLogsStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, service = inject(StudentPsychologicalCounselingLogsService)) => ({
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
    create: rxMethod<CreateStudentPsychologicalCounselingLogPayload>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((payload) => service.create(payload).pipe(
          tap({
            next: (response) => {
              if (response) {
                patchState(store, { items: [...store.items(), response as StudentPsychologicalCounselingLog] });
              }
              patchState(store, { isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error creating item', isLoading: false })
          })
        ))
      )
    ),
    update: rxMethod<{id: number | string, payload: UpdateStudentPsychologicalCounselingLogPayload}>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({id, payload}) => service.update(id, payload).pipe(
          tap({
            next: () => {
              const updatedItems = store.items().map(item => (item as any).id === id ? { ...item, ...payload } : item);
              patchState(store, { items: updatedItems as StudentPsychologicalCounselingLog[] });
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
              patchState(store, { items: updatedItems as StudentPsychologicalCounselingLog[], isLoading: false });
            },
            error: (err) => patchState(store, { error: err.message || 'Error deleting item', isLoading: false })
          })
        ))
      )
    )
  }))
);
