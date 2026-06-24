# Planning Protocol — النظام التعليمي لإدارة المدارس

**Date**: 2026-06-22  
**Role**: Staff Software Engineer / Tech Lead  
**Project**: نظام إدارة المدارس (خاصة + حكومية + رياض أطفال)

---

## البروتوكول 1: الوعي الزمني وموثوقية التبعيات

### التاريخ والزمن
- **Current Date**: 2026-06-22 17:40 UTC+3
- **Node**: 26.3.1
- **npm**: 11.13.0

### أحدث الإصدارات المستقرة (مُوثقة)

| الحزمة | الإصدار | حالة deprecation |
|-------|---------|-------------------|
| `@angular/core` | 22.0.2 | ✅ مستقر |
| `@angular/cli` | 22.0.3 | ✅ مستقر |
| `@angular/build` | 22.0.3 | ✅ مستقر |
| `@angular/cdk` | 22.0.2 | ✅ مستقر |
| `typescript` | 6.0.3 | ✅ مستقر |
| `primeng` | 21.1.9 | ✅ مستقر |
| `@primeuix/themes` | 2.0.3 | ✅ مستقر |
| `primeicons` | 7.0.0 | ✅ مستقر |
| `chart.js` | 4.5.1 | ✅ مستقر |
| `rxjs` | 7.8.2 | ✅ مستقر |
| `vitest` | 4.1.9 | ✅ مستقر |
| `jsdom` | 28.0.0 | ✅ مستقر |
| `jspdf` | 4.2.1 | ✅ مستقر |
| `xlsx` | 0.18.5 | ⚠️ لم يتم التثبيت بعد |
| `eslint` | 10.5.0 | ✅ غير مثبت (نستخدم Prettier) |

### ملاحظات التبعيات
- **PrimeNG 21.1.9** يتطلب Angular ^21.0.0 كـ peer dependency — تم التثبيت بـ `--legacy-peer-deps`، يعمل بسلاسة مع Angular 22.
- **chart.js 4.5.1** مطلوب من PrimeNG Chart component.
- **TypeScript 6.0.3** — Angular 22 يدعمه بشكل كامل.
- **Vitest 4.1.9** — Angular 22 يستخدمه كـ test runner افتراضي.
- **rxjs 7.8.2** — لا حاجة للترقية إلى 7.x أعلى.
- لا توجد حزم Deprecated في stack الحالي.

---

## البروتوكول 2: التدفق المنطقي ومنع زحف الميزات

### النطاق المطلوب (Scope)
نظام متكامل لإدارة المدارس يشمل:
1. **إدارة الطلاب** — تسجيل، حضور، درجات، سلوك، تقارير
2. **إدارة المعلمين** — تعيينات، جداول، تقييمات
3. **إدارة الفصول والجداول** — توزيع الطلاب، الجداول الدراسية
4. **إدارة الأصول والممتلكات** — ✅ تم تنفيذ Assets Dashboard
5. **المالية** — رسوم، رواتب، ميزانية
6. **المقررات والامتحانات** — خطط دراسية، جداول امتحانات، كشوف علامات
7. **التواصل** — إشعارات، إعلانات، اجتماعات أولياء الأمور
8. **النقل** — مسارات الحافلات

### رحلة المستخدم (User Journeys)

#### المسار 1: مدير المدرسة (Super Admin)
```
تسجيل دخول → لوحة التحكم الرئيسية (KPI عامة)
→ إدارة الطلاب (إضافة/تعديل/حذف)
→ إدارة المعلمين (تعيين، صلاحيات)
→ تقارير (إحصائية، مالية، درجات)
→ إدارة الأصول (لوحة الصيانة) ✅
```

#### المسار 2: المعلم
```
تسجيل دخول → لوحة المعلم (جدولي، صفي)
→ تسجيل درجات الطلاب
→ إدخال السلوك والحضور
→ طباعة كشوف علامات
```

#### المسار 3: الطالب / ولي الأمر
```
تسجيل دخول → عرض الدرجات
→ جدول الحصص الأسبوعي
→ الإشعارات والتواصل
→ سجل الحضور والغياب
```

#### المسار 4: مدير الصيانة والأصول
```
تسجيل دخول → لوحة إدارة الأصول (منفذة)
→ إدارة الصيانة
→ المخزون الاستهلاكي
→ تقارير الجرد
```

### المخرجات القابلة للتحقق (Verifiable Goals)

| الهدف | معيار النجاح |
|-------|-------------|
| **MVP (Milestone 1)** | 3 لوحات تحكم أساسية (مدير، معلم، ولي أمر) مع المصادقة |
| **Milestone 2** | إدارة الطلاب كاملة (CRUD + حضور + درجات) |
| **Milestone 3** | إدارة الجداول الدراسية والمقررات |
| **Milestone 4** | النظام المالي (رسوم + رواتب) |
| **Milestone 5** | تقارير شاملة وتكامل مع الأنظمة الخارجية |

---

## البروتوكول 3: المعمارية الذكية والتجريد الواقعي

### هيكل المشروع (Surgical Architecture)

```
src/
├── app/
│   ├── app.ts                          # Root component (standalone)
│   ├── app.config.ts                   # App config (PrimeNG, Router, HttpClient)
│   ├── app.routes.ts                   # Root routes
│   ├── app.html                        # <router-outlet />
│   │
│   ├── core/                           # SINGLETON — مرة واحدة فقط
│   │   ├── services/
│   │   │   ├── auth.service.ts         # مصادقة + JWT
│   │   │   ├── api.service.ts          # HttpClient wrapper
│   │   │   └── logger.service.ts       # Logging (Async)
│   │   ├── guards/
│   │   │   └── auth.guard.ts           # Route guard
│   │   ├── interceptors/
│   │   │   └── auth.interceptor.ts     # Token injection
│   │   └── models/                     # Interfaces مشتركة
│   │       ├── user.model.ts
│   │       ├── student.model.ts
│   │       └── teacher.model.ts
│   │
│   ├── shared/                         # أعد الاستخدام فقط لو تكرر
│   │   ├── components/
│   │   │   ├── data-table/             # جدول عام (PrimeNG Table wrapper)
│   │   │   └── page-header/            # Header موحد للصفحات
│   │   ├── directives/
│   │   │   └── has-role.directive.ts   # التحقق من الصلاحية
│   │   └── pipes/
│   │       └── arabic-date.pipe.ts     # تنسيق تواريخ عربية
│   │
│   ├── features/                       # DOMAIN-DRIVEN — كل ميزة في مجلد
│   │   ├── auth/                       # تسجيل الدخول
│   │   │   ├── auth.ts
│   │   │   ├── auth.html
│   │   │   └── auth.scss
│   │   │
│   │   ├── dashboard/                  # لوحة التحكم الرئيسية
│   │   │   ├── dashboard-main/         # لوحة المدير
│   │   │   ├── dashboard-teacher/      # لوحة المعلم
│   │   │   └── dashboard-student/      # لوحة الطالب
│   │   │
│   │   ├── students/                   # إدارة الطلاب
│   │   │   ├── students-list/
│   │   │   ├── student-form/
│   │   │   └── student-detail/
│   │   │
│   │   ├── teachers/                   # إدارة المعلمين
│   │   ├── classes/                    # الفصول والجداول
│   │   ├── grades/                     # الدرجات والتقييم
│   │   ├── schedule/                   # الجداول الدراسية
│   │   ├── exams/                      # الامتحانات
│   │   ├── finance/                    # المالية (رسوم - رواتب)
│   │   ├── transportation/             # النقل المدرسي
│   │   └── assets-dashboard/           # ✅ منفذ مسبقاً
│   │
│   └── layouts/                        # توزيعات الصفحات
│       ├── admin-layout/
│       ├── teacher-layout/
│       └── auth-layout/
```

### قواعد صارمة

1. **لا توجد NgModules** — كل المكونات Standalone.
2. **مجلد features فقط** — ممنوع إنشاء مجلدات services/ داخل كل feature.
3. **Shared/Core فقط عند التكرار الفعلي** — لا تجريد قبل 3 استخدامات.
4. **الموديلات في core/models** — أي interface يتكرر عبر feature.
5. **لا micro-files** — ملف 60 سطر أفضل من 4 ملفات.

---

## البروتوكول 4: استراتيجية التتبع (Safe Logging)

```typescript
// core/services/logger.service.ts
export type LogLevel = 'debug' | 'info' | 'warn' | 'error';

export class LoggerService {
  private log(level: LogLevel, message: string, data?: unknown): void {
    // في وضع production → أرسل إلى API خارجي (اختياري)
    // في وضع development → console فقط
    if (typeof window !== 'undefined') {
      const entry = { level, message, data, timestamp: new Date().toISOString() };
      if (level === 'error') console.error(entry);
      else if (level === 'warn') console.warn(entry);
      else console.log(entry);
    }
  }

  debug(msg: string, data?: unknown) { this.log('debug', msg, data); }
  info(msg: string, data?: unknown) { this.log('info', msg, data); }
  warn(msg: string, data?: unknown) { this.log('warn', msg, data); }
  error(msg: string, data?: unknown) { this.log('error', msg, data); }
}
```

- **غير حظري** (Async-ready) — يمكن تحويله إلى HTTP call لاحقاً.
- **4 مستويات فقط** — لا تعقيد.
- **لا يخزن sensitive data** — بدون tokens أو user secrets.

---

## البروتوكول 5: خطة العمل (Milestones)

### Milestone 1 — MVP (الأسبوع 1-2)
| الهدف | المخرجات الملموسة |
|-------|-------------------|
| 1.1 مصادقة المستخدمين | صفحة login + JWT guard + interceptor |
| 1.2 لوحة المدير | KPI cards + جدول سريع للطلاب والمعلمين |
| 1.3 إدارة الأصول | ✅ تم |
| 1.4 اختبارات | 80% تغطية للمكونات الجديدة |

### Milestone 2 — الطلاب والمعلمين (الأسبوع 3-4)
| الهدف | المخرجات الملموسة |
|-------|-------------------|
| 2.1 CRUD الطلاب | قائمة + إضافة/تعديل + بحث |
| 2.2 CRUD المعلمين | قائمة + إضافة/تعديل + صلاحيات |
| 2.3 الحضور | تسجيل حضور + تقارير غياب |
| 2.4 الدرجات | إدخال درجات + كشف علامات |

### Milestone 3 — الجداول والمقررات (الأسبوع 5-6)
| الهدف | المخرجات الملموسة |
|-------|-------------------|
| 3.1 إدارة الفصول | توزيع الطلاب على الفصول |
| 3.2 الجدول الدراسي | جدول تفاعلي (Drag & Drop) |
| 3.3 المقررات | إضافة مقررات + ربط بالمعلمين |
| 3.4 الامتحانات | جدول امتحانات + نتائج |

### Milestone 4 — المالية (الأسبوع 7-8)
| الهدف | المخرجات الملموسة |
|-------|-------------------|
| 4.1 الرسوم الدراسية | فواتير + تحصيل + تقارير |
| 4.2 الرواتب | صرف رواتب المعلمين |
| 4.3 الميزانية | ربط مع مشتريات الأصول |

### Milestone 5 — التقارير والتكامل (الأسبوع 9-10)
| الهدف | المخرجات الملموسة |
|-------|-------------------|
| 5.1 تقارير جاهزة | PDF/Excel للدرجات، الحضور، المالية |
| 5.2 التواصل | إشعارات + بريد إلكتروني |
| 5.3 لوحة الطالب وولي الأمر | عرض البيانات للطالب |
| 5.4 التكامل مع مكتب التربية | تصدير البيانات بالصيغة المعتمدة |

---

### ORPHANS & PENDING
- [x] Assets Dashboard — منفذ.
- [ ] Auth Service + JWT — pending.
- [ ] API Service + Base URL config — pending.
- [ ] Shared DataTable component — pending.
- [ ] Arabic date pipe — pending.
- [ ] E2E testing (Playwright/Cypress) — pending.
- [ ] i18n (ترجمة واجهة) — pending.
- [x] Chart.js + PrimeNG Charts — مثبت.
- [x] PrimeNG 21 + PrimeIcons + Theme Aura — مثبت.
