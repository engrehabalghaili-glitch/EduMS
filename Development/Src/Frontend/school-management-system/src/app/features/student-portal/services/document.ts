import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface RequiredDocument {
  id: string;
  label: string;
  icon: string;
  description: string;
  accepted: boolean;
}

@Injectable({ providedIn: 'root' })
export class DocumentService {
  private http = inject(HttpClient);

  requiredDocs = signal<RequiredDocument[]>([]);

  getRequiredDocuments(): Observable<RequiredDocument[]> {
    return this.http.get<RequiredDocument[]>('/api/v1/documents/required').pipe(
      tap(data => this.requiredDocs.set(data))
    );
  }

  uploadFile(docId: string, file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`/api/v1/documents/upload/${docId}`, formData).pipe(
      tap(() => {
        this.requiredDocs.update(docs => docs.map(d => d.id === docId ? { ...d, accepted: true } : d));
      })
    );
  }

  removeFile(docId: string): Observable<any> {
    return this.http.delete(`/api/v1/documents/${docId}`).pipe(
      tap(() => {
        this.requiredDocs.update(docs => docs.map(d => d.id === docId ? { ...d, accepted: false } : d));
      })
    );
  }
}
