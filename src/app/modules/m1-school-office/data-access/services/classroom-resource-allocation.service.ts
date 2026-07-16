import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ClassroomResourceAllocation, CreateClassroomResourceAllocationDto, UpdateClassroomResourceAllocationDto } from '../models/classroom-resource-allocation';

@Injectable({ providedIn: 'root' })
export class ClassroomResourceAllocationService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/classroomResourceAllocations`;

  getAll(): Observable<ClassroomResourceAllocation[]> {
    return this.http.get<ClassroomResourceAllocation[]>(this.apiUrl);
  }

  getById(id: number): Observable<ClassroomResourceAllocation> {
    return this.http.get<ClassroomResourceAllocation>(`${this.apiUrl}/${id}`);
  }

  getByClassroomId(classroomId: number): Observable<ClassroomResourceAllocation[]> {
    return this.http.get<ClassroomResourceAllocation[]>(`${this.apiUrl}?classroomId=${classroomId}`);
  }

  getByResourceType(resourceType: string): Observable<ClassroomResourceAllocation[]> {
    return this.http.get<ClassroomResourceAllocation[]>(`${this.apiUrl}?resourceType=${resourceType}`);
  }

  create(dto: CreateClassroomResourceAllocationDto): Observable<ClassroomResourceAllocation> {
    return this.http.post<ClassroomResourceAllocation>(this.apiUrl, dto);
  }

  update(id: number, dto: UpdateClassroomResourceAllocationDto): Observable<ClassroomResourceAllocation> {
    return this.http.put<ClassroomResourceAllocation>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}


