import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { ClassroomResourceAllocation, CreateClassroomResourceAllocationDto, UpdateClassroomResourceAllocationDto } from '../models/classroom-resource-allocation';

@Injectable({ providedIn: 'root' })
export class ClassroomResourceAllocationService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/classroomResourceAllocations`;

  getAll(): Observable<ClassroomResourceAllocation[]> {
    return this.http.get<ClassroomResourceAllocation[]>(this.baseUrl);
  }

  getById(id: number): Observable<ClassroomResourceAllocation> {
    return this.http.get<ClassroomResourceAllocation>(`${this.baseUrl}/${id}`);
  }

  getByClassroomId(classroomId: number): Observable<ClassroomResourceAllocation[]> {
    return this.http.get<ClassroomResourceAllocation[]>(`${this.baseUrl}?classroomId=${classroomId}`);
  }

  getByResourceType(resourceType: string): Observable<ClassroomResourceAllocation[]> {
    return this.http.get<ClassroomResourceAllocation[]>(`${this.baseUrl}?resourceType=${resourceType}`);
  }

  create(dto: CreateClassroomResourceAllocationDto): Observable<ClassroomResourceAllocation> {
    return this.http.post<ClassroomResourceAllocation>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateClassroomResourceAllocationDto): Observable<ClassroomResourceAllocation> {
    return this.http.put<ClassroomResourceAllocation>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
