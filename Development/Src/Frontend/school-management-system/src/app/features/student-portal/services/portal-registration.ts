import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PortalRegistrationService {
  private http = inject(HttpClient);

  submitRegistration(data: any): Observable<any> {
    return this.http.post('/api/v1/portal/register', data);
  }
}
