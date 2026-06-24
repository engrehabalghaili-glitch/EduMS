import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface InvoiceRecord {
  id: string;
  studentName: string;
  fatherName: string;
  gradeLevel: string;
  totalAmount: number;
  paidAmount: number;
  remainingAmount: number;
  dueDate: string;
  status: 'fully_paid' | 'partially_paid' | 'unpaid';
}

export interface FinancialVoucher {
  id: string;
  type: 'receipt' | 'payment'; // سند قبض أو سند صرف
  title: string;
  amount: number;
  date: string;
  createdBy: string;
  accountCategory: string;
}

@Injectable({
  providedIn: 'root'
})
export class FinanceService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية المستقرة (Signals) للمراقبة المالية الآنية
  invoices = signal<InvoiceRecord[]>([]);
  vouchers = signal<FinancialVoucher[]>([]);

  /** جلب كشف الفواتير والرسوم الدراسية المستحقة على الطلاب */
  getStudentInvoices(): Observable<InvoiceRecord[]> {
    return this.http.get<InvoiceRecord[]>('/api/v1/finance/invoices').pipe(
      tap(data => this.invoices.set(data))
    );
  }

  /** جلب سجل سندات القبض والصرف الفوري للتدقيق */
  getRecentVouchers(): Observable<FinancialVoucher[]> {
    return this.http.get<FinancialVoucher[]>('/api/v1/finance/vouchers').pipe(
      tap(data => this.vouchers.set(data))
    );
  }
}
