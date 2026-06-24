import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface RegistrationRequest {
  id: number;
  requestNumber: string;
  studentName: string;
  grade: string;
  status: 'pending' | 'accepted' | 'rejected';
  parentName: string;
  parentPhone: string;
  parentEmail: string;
  studentId: string;
  birthDate: string;
  gender: string;
  nationality: string;
  address: string;
  phone: string;
  email: string;
  department: string;
  academicYear: string;
  bloodType: string;
  allergies: string;
  chronicDiseases: string;
  submittedAt: string;
  documents: { name: string; status: string }[];
}

@Injectable({ providedIn: 'root' })
export class RegistrationManagerService {
  private http = inject(HttpClient);

  applications = signal<RegistrationRequest[]>([]);

  getApplications(): Observable<RegistrationRequest[]> {
    return this.http.get<RegistrationRequest[]>('/api/v1/registration/applications').pipe(
      tap(data => this.applications.set(data))
    );
  }

  updateApplicationStatus(id: number, status: 'accepted' | 'rejected'): Observable<any> {
    return this.http.patch(`/api/v1/registration/applications/${id}/status`, { status }).pipe(
      tap(() => {
        this.applications.update(apps => apps.map(a => a.id === id ? { ...a, status } : a));
      })
    );
  }
}
