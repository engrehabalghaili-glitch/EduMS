import { Injectable } from '@angular/core';
import { environment } from '../../../environments';

@Injectable({
  providedIn: 'root',
})
export class ApiConfigService {
  private readonly baseUrl = environment.apiUrl;

  public getBaseUrl(): string {
    return this.baseUrl;
  }

  public getEndpoint(modulePath: string, useCasePath: string): string {
    return `${this.baseUrl}/${useCasePath}`;
  }
}
