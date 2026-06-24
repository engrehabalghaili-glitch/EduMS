import { Component, OnInit, Inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.html', // أو إذا كنت تستخدم التمبلت الداخلي: template: `<router-outlet></router-outlet>`
  styleUrl: './app.scss'
})
export class AppComponent implements OnInit {
  title = 'نظام إدارة التعليم الذكي';

  constructor(@Inject(DOCUMENT) private document: Document) {}

  ngOnInit(): void {
    // تفعيل البيئة العربية تلقائياً فور تشغيل التطبيق
    this.document.documentElement.dir = 'rtl';
    this.document.documentElement.lang = 'ar';
  }
}
