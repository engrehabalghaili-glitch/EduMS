import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../core/services/api-config.service';

export interface CreatePersonCommand {
  fullNameAr: string;
  fullNameEn?: string;
  nationalId: string;
  gender: number;
  contactNumber?: string;
  medicalInfo?: string;
}

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);

  public createPerson(command: CreatePersonCommand): Observable<number> {
    const url = `${this.apiConfig.getBaseUrl()}/student-affairs/persons`;
    return this.http.post<number>(url, command);
  }
}
