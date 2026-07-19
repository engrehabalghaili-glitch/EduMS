import { signalStore, withState, withMethods, patchState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { tapResponse } from '@ngrx/operators';
import { inject } from '@angular/core';
import { pipe, switchMap, tap } from 'rxjs';
import type { MeetingAttendanceRecord, CreateMeetingAttendanceRecord, UpdateMeetingAttendanceRecord } from '../models/meeting-attendance-record.types';
import { MeetingAttendanceRecordService } from '../services/meeting-attendance-record.service';

interface MeetingAttendanceRecordState {
  meetingAttendanceRecords: MeetingAttendanceRecord[];
  isLoading: boolean;
  error: string | null;
}

const initialState: MeetingAttendanceRecordState = {
  meetingAttendanceRecords: [],
  isLoading: false,
  error: null,
};

export const MeetingAttendanceRecordStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store, meetingAttendanceRecordService = inject(MeetingAttendanceRecordService)) => ({
    loadAllMeetingAttendanceRecords: rxMethod<void>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(() =>
          meetingAttendanceRecordService.getAll().pipe(
            tapResponse({
              next: (meetingAttendanceRecords) => patchState(store, { meetingAttendanceRecords, isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    addNewMeetingAttendanceRecord: rxMethod<CreateMeetingAttendanceRecord>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((dto) =>
          meetingAttendanceRecordService.create(dto).pipe(
            tapResponse({
              next: (item) => patchState(store, { meetingAttendanceRecords: [...store.meetingAttendanceRecords(), item], isLoading: false }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    updateMeetingAttendanceRecord: rxMethod<{ id: number; dto: UpdateMeetingAttendanceRecord }>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap(({ id, dto }) =>
          meetingAttendanceRecordService.update(id, dto).pipe(
            tapResponse({
              next: (updated) => patchState(store, {
                meetingAttendanceRecords: store.meetingAttendanceRecords().map((e) => (e as { id: number }).id === id ? updated : e),
                isLoading: false,
              }),
              error: (err) => patchState(store, { error: err instanceof Error ? err.message : 'Unknown error', isLoading: false }),
            }),
          ),
        ),
      ),
    ),
    deleteMeetingAttendanceRecord: rxMethod<number>(
      pipe(
        tap(() => patchState(store, { isLoading: true, error: null })),
        switchMap((id) =>
          meetingAttendanceRecordService.delete(id).pipe(
            tapResponse({
              next: () => patchState(store, {
                meetingAttendanceRecords: store.meetingAttendanceRecords().filter((e) => (e as { id: number }).id !== id),
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
