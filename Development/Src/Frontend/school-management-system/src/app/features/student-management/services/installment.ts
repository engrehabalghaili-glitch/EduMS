import { Injectable, signal, computed, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export type InstallmentStatus = 'paid' | 'scheduled' | 'pending';

export interface Installment {
  id: string;
  studentName: string;
  grade: string;
  amount: number;
  paidAmount: number;
  dueDate: string;
  paidDate?: string;
  status: InstallmentStatus;
  paymentMethod?: string;
  notes?: string;
}

@Injectable({ providedIn: 'root' })
export class InstallmentService {
  private http = inject(HttpClient);

  installments = signal<Installment[]>([]);
  loading = signal(false);
  isPrivateSchool = signal(true);

  totalAmount = computed(() => this.installments().reduce((sum, i) => sum + i.amount, 0));
  totalPaid = computed(() => this.installments().reduce((sum, i) => sum + i.paidAmount, 0));
  progressPercent = computed(() => Math.round((this.totalPaid() / this.totalAmount()) * 100));
  paidCount = computed(() => this.installments().filter(i => i.status === 'paid').length);
  scheduledCount = computed(() => this.installments().filter(i => i.status === 'scheduled').length);
  pendingCount = computed(() => this.installments().filter(i => i.status === 'pending').length);
  remainingAmount = computed(() => this.installments().reduce((sum, i) => {
    if (i.status === 'paid') return sum;
    return sum + (i.amount - i.paidAmount);
  }, 0));

  getInstallments(): Observable<Installment[]> {
    return this.http.get<Installment[]>('/api/v1/installments').pipe(
      tap(data => this.installments.set(data))
    );
  }

  saveInstallment(data: any): Observable<any> {
    return this.http.post('/api/v1/installments', data).pipe(
      tap(() => this.getInstallments().subscribe())
    );
  }
}
