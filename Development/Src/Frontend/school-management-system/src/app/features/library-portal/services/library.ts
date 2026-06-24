import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface BookRecord {
  id: string;
  title: string;
  author: string;
  isbn: string;
  category: string;
  totalCopies: number;
  availableCopies: number;
  shelfLocation: string; // موقع الرف في المكتبة
}

export interface BorrowingLog {
  id: string;
  bookTitle: string;
  borrowerName: string;
  borrowerRole: 'student' | 'teacher';
  borrowDate: string;
  dueDate: string;
  status: 'active' | 'overdue' | 'returned';
}

@Injectable({
  providedIn: 'root'
})
export class LibraryService {
  private http = inject(HttpClient);

  // مخازن الحالة المركزية المستقرة (Signals) للمراقبة الآنية للمكتبة
  books = signal<BookRecord[]>([]);
  borrowingLogs = signal<BorrowingLog[]>([]);

  /** جلب تفاصيل الفهرس المركزي للكتب والمراجع */
  getBooksInventory(): Observable<BookRecord[]> {
    return this.http.get<BookRecord[]>('/api/v1/library/books').pipe(
      tap(data => this.books.set(data))
    );
  }

  /** جلب سجل عمليات الإعارة النشطة والمتأخرة للتدقيق اليومي */
  getBorrowingLogs(): Observable<BorrowingLog[]> {
    return this.http.get<BorrowingLog[]>('/api/v1/library/borrowings').pipe(
      tap(data => this.borrowingLogs.set(data))
    );
  }
}
