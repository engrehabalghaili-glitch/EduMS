import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiConfigService {
  private readonly baseUrl = 'http://localhost:5169/api/v1';

  public getBaseUrl(): string {
    return this.baseUrl;
  }

  public getEndpoint(modulePath: string, useCasePath: string): string {
    return `${this.baseUrl}/${modulePath}/${useCasePath}`;
  }
}
