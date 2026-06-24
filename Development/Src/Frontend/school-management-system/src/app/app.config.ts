import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter, withComponentInputBinding, withViewTransitions } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeuix/themes/aura';

// استدعاء ميزات NgRx لإدارة الحالة المركزية للمشاريع الكبرى
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';

// استدعاء ملف المسارات الأساسي
import { routes } from './app.routes';

// استدعاء الـ Interceptors المركزية من مجلد core
import { authInterceptor } from './core/interceptors/auth-interceptor';
import { errorInterceptor } from './core/interceptors/error-interceptor';
import { loadingInterceptor } from './core/interceptors/loading-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    // 1. تحسين أداء دورت التحديث (Change Detection) لتتوافق بكفاءة مطلقة مع الـ Angular Signals
    // provideZoneChangeDetection({ eventCoalescing: true }),

    // 2. إعداد نظام التوجيه (Routing) مع ميزات متقدمة جداً
    provideRouter(
      routes,
      withComponentInputBinding(), // تمرير الـ Route Parameters (مثل id الطالب) كـ Inputs للمكون مباشرة
      withViewTransitions()        // تفعيل تأثيرات الانتقال السلسة والفاخرة بين الصفحات
    ),

    // 4. تفعيل الأنيميشن غير المتزامن لضمان عدم تأثر سرعة تشغيل التطبيق الأولية (Fast Bootstrap)
    provideAnimations(),

    // 5. تهيئة المخزن المركزي (NgRx Store) لإدارة العمليات المعقدة
    provideStore({}),

    // 6. تهيئة الـ Effects للعمليات الجانبية غير المتزامنة (Async Operations)
    provideEffects([]),

    // 7. تفعيل أدوات المطورين لـ NgRx لتتبع تدفق البيانات في بيئة التطوير فقط
    provideStoreDevtools({
      maxAge: 25, // الاحتفاظ بآخر 25 عملية فقط في الذاكرة لمنع تضخم المتصفح
      logOnly: !isDevMode(), // تفعيل التتبع الحركي في بيئة التطوير وتعطيله في الـ Production لأمان البيانات
      autoPause: true, // إيقاف التتبع مؤقتاً عند عدم فتح التبويب لتوفير موارد الجهاز
      trace: false, // تفعيل تتبع الـ Action Stack Trace (يمكن تفعيله عند تتبع خطأ برمي معقد)
      traceLimit: 75,
    }),

    // --- 👇 التعديل الجذري لمنع اللون الأسود 👇 ---
    // 5. تهيئة مكتبة PrimeNG 21 بالثيم الديناميكي المخصص لك (Aura)
    providePrimeNG({
      theme: {
        preset: Aura,
        options: {
          darkModeSelector: 'none' // إغلاق الوضع الداكن الإجباري من النظام تماماً
        }
      }
    }),
    // ------------------------------------------------

    // تسجيل الـ HttpClient وتمرير الـ Interceptors الحديثة التي قمنا ببنائها
    provideHttpClient(
      withInterceptors([authInterceptor, errorInterceptor, loadingInterceptor])
    ),
  ]
};