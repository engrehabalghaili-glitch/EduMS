import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { Department, CreateDepartmentDto, UpdateDepartmentDto } from '../models/department';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/departments`;

  getAll(): Observable<Department[]> {
    return this.http.get<Department[]>(this.apiUrl);
  }

  getById(id: number): Observable<Department> {
    return this.http.get<Department>(`${this.apiUrl}/${id}`);
  }

  getBySchoolId(schoolId: number): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.apiUrl}?schoolId=${schoolId}`);
  }

  getByType(departmentType: string): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.apiUrl}?departmentType=${departmentType}`);
  }

  create(dto: CreateDepartmentDto): Observable<Department> {
    return this.http.post<Department>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateDepartmentDto): Observable<Department> {
    return this.http.put<Department>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


