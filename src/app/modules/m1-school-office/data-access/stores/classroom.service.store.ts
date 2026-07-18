import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { Classroom, CreateClassroomDto, UpdateClassroomDto } from '../models/classroom';
import { ClassroomService } from '../services/classroom.service';

interface ClassroomState {
  classrooms: Classroom[];
  isLoading: boolean;
  error: string | null;
}

const initialState: ClassroomState = {
  classrooms: [],
  isLoading: false,
  error: null,
};

export const ClassroomStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, classroomService = inject(ClassroomService)) => ({
    loadAllClassrooms: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          classroomService.getAll().pipe(
            tapResponse({
              next: (data) => patchState(store, { classrooms: data, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewClassroom: rxMethod<CreateClassroomDto>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          classroomService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { classrooms: [...store.classrooms(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
  })),
);
