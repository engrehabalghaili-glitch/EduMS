import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiConfigService } from '../../../../core/services/api-config.service';
import type { Department, CreateDepartmentDto, UpdateDepartmentDto } from '../models/department';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  private readonly http = inject(HttpClient);
  private readonly apiConfig = inject(ApiConfigService);
  private readonly baseUrl = this.apiConfig.getEndpoint('M1_SchoolAdmin', 'departments');

  getAll(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl);
  }

  getById(id: number): Observable<Department> {
    return this.http.get<Department>(`${this.baseUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.baseUrl}?schoolId=${schoolId}`);
  }

  getByType(departmentType: string): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.baseUrl}?departmentType=${departmentType}`);
  }

  create(dto: CreateDepartmentDto): Observable<Department> {
    return this.http.post<Department>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateDepartmentDto): Observable<Department> {
    return this.http.put<Department>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}





