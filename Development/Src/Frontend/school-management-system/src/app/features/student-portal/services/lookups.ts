import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { GENDER_OPTIONS } from '../../../app.constants';

export interface LookupOption {
  label: string;
  value: string;
}

@Injectable({ providedIn: 'root' })
export class LookupService {
  private http = inject(HttpClient);

  genders = GENDER_OPTIONS;
  nationalities = signal<LookupOption[]>([]);
  grades = signal<LookupOption[]>([]);
  gradesLoading = signal(false);
  departments = signal<LookupOption[]>([]);
  academicYears = signal<LookupOption[]>([]);
  bloodTypes = signal<LookupOption[]>([]);
  relations = signal<LookupOption[]>([]);

  getNationalities(): Observable<LookupOption[]> {
    return this.http.get<LookupOption[]>('/api/v1/lookups/nationalities').pipe(
      tap(data => this.nationalities.set(data))
    );
  }

  getGrades(): Observable<LookupOption[]> {
    this.gradesLoading.set(true);
    return this.http.get<LookupOption[]>('/api/v1/lookups/grades').pipe(
      tap(data => {
        this.grades.set(data);
        this.gradesLoading.set(false);
      })
    );
  }

  getDepartments(): Observable<LookupOption[]> {
    return this.http.get<LookupOption[]>('/api/v1/lookups/departments').pipe(
      tap(data => this.departments.set(data))
    );
  }

  getAcademicYears(): Observable<LookupOption[]> {
    return this.http.get<LookupOption[]>('/api/v1/lookups/academic-years').pipe(
      tap(data => this.academicYears.set(data))
    );
  }

  getBloodTypes(): Observable<LookupOption[]> {
    return this.http.get<LookupOption[]>('/api/v1/lookups/blood-types').pipe(
      tap(data => this.bloodTypes.set(data))
    );
  }

  getRelations(): Observable<LookupOption[]> {
    return this.http.get<LookupOption[]>('/api/v1/lookups/relations').pipe(
      tap(data => this.relations.set(data))
    );
  }

  secondaryDepartments: LookupOption[] = [
    { label: 'العلوم الطبيعية', value: 'science' },
    { label: 'العلوم الإنسانية', value: 'humanities' },
    { label: 'المسار العام', value: 'general' },
  ];
}
