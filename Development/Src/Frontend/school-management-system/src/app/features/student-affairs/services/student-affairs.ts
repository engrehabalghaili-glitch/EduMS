import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface AdmissionRequest {
  id: string;
  studentName: string;
  gradeLevel: string;
  submissionDate: string;
  documentStatus: 'complete' | 'missing_docs' | 'pending_review';
  documentStatusText: string;
  status: 'approved' | 'rejected' | 'under_review';
}

export interface StudentTransfer {
  id: string;
  studentName: string;
  direction: 'incoming' | 'outgoing';
  schoolName: string;
  currentStep: string;
  status: 'pending' | 'completed';
}

@Injectable({
  providedIn: 'root'
})
export class StudentAffairsService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية (Signals) لإدارة شؤون الطلاب لحظياً
  requests = signal<AdmissionRequest[]>([]);
  transfers = signal<StudentTransfer[]>([]);

  /** جلب طلبات القبول والتسجيل الجديدة */
  getAdmissionRequests(): Observable<AdmissionRequest[]> {
    return this.http.get<AdmissionRequest[]>('/api/v1/affairs/admissions').pipe(
      tap(data => this.requests.set(data))
    );
  }

  /** جلب معاملات تحويل الطلاب بين المدارس الفروع */
  getStudentTransfers(): Observable<StudentTransfer[]> {
    return this.http.get<StudentTransfer[]>('/api/v1/affairs/transfers').pipe(
      tap(data => this.transfers.set(data))
    );
  }
}
