import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  // الـ Signal المركزي لحالة التحميل
  isLoading = signal<boolean>(false);

  // عداد لتتبع عدد طلبات الـ API المفتوحة في نفس الوقت
  private activeRequests = 0;

  show(): void {
    if (this.activeRequests === 0) {
      this.isLoading.set(true);
    }
    this.activeRequests++;
  }

  hide(): void {
    this.activeRequests--;
    if (this.activeRequests <= 0) {
      this.activeRequests = 0;
      this.isLoading.set(false);
    }
  }
}

// import { Service } from '@angular/core';

// @Service()
// export class Loading {}
