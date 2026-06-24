import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AcademicService {
  private http = inject(HttpClient);

  saveStudentData(data: any): Observable<any> {
    return this.http.post('/api/v1/students', data);
  }
}
