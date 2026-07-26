import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../core/services/api-config.service';

export interface ApplyAcademicLockCommand {
  schoolId: number;
  lockType: number;
  startDate: string;
  endDate: string;
  reason?: string;
}

@Injectable({
  providedIn: 'root'
})
export class AcademicLockService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);

  public applyLock(command: ApplyAcademicLockCommand): Observable<number> {
    const url = this.apiConfig.getEndpoint('school-admin/academic-lock', 'apply');
    return this.http.post<number>(url, command);
  }

  public checkLock(schoolId: number, targetDate: string): Observable<boolean> {
    const url = this.apiConfig.getEndpoint('school-admin/academic-lock', 'check');
    const params = new HttpParams()
      .set('schoolId', schoolId.toString())
      .set('targetDate', targetDate);

    return this.http.get<boolean>(url, { params });
  }
}
