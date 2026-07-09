# 📦 EduMS Enterprise — Foundation Package (Batch 1)

> الدفعة الأولى من مشروع تصميم واجهات نظام EduMS Enterprise
> النظام: 205 جدولاً • 8 وحدات • 423 شاشة مخططة • مُنفّذ منها في هذه الدفعة 40+ شاشة أساس

---

## 🚀 كيفية التشغيل

### الطريقة الأسرع (بدون أي إعداد):
1. افتح ملف **`index.html`** مباشرةً في المتصفح (Chrome / Edge / Firefox).
2. تنقّل بين جميع الواجهات من البطاقات.
3. جميع الملفات HTML/CSS/Vanilla JS — **لا يلزم Angular ولا npm**.

### عبر خادم محلي (موصى به لتجنّب مشاكل CORS):
```bash
cd EduMS_UI_System
python3 -m http.server 8000
# ثم افتح: http://localhost:8000
```

---

## 📁 هيكل المشروع

```
EduMS_UI_System/
├── index.html                          # ← ابدأ من هنا (الفهرس)
│
├── 00_Core/                            # حزمة الأساس
│   ├── design-system.html              # نظام التصميم (ألوان، خطوط، spacing)
│   ├── components-library.html         # مكتبة 30+ مكوّن قابل لإعادة الاستخدام
│   ├── master-shell.html               # SPA Shell الرئيسي (Sidebar + Topbar)
│   │
│   ├── dashboards/
│   │   └── dashboards.html             # ⭐ 8 لوحات تحكم ديناميكية
│   │
│   └── auth/
│       ├── login.html                  # تسجيل الدخول
│       ├── forgot-password.html        # نسيت كلمة المرور
│       └── reset-password.html         # تعيين كلمة سر جديدة
│
├── assets/
│   ├── css/
│   │   └── edums-design-system.css     # نظام التصميم الكامل (CSS)
│   └── js/
│       ├── edums-core.js               # وظائف SPA الأساسية
│       └── edums-mock-data.js          # بيانات وهمية واقعية
│
├── angular_skeleton/                   # ملفات Angular جاهزة للنسخ
│   ├── README.md
│   └── src/app/
│       ├── core/auth/
│       │   ├── auth.guard.ts
│       │   ├── auth.service.ts
│       │   └── role.guard.ts
│       ├── core/interceptors/
│       │   └── auth.interceptor.ts
│       ├── layouts/master-shell/
│       │   ├── master-shell.component.html
│       │   └── master-shell.component.ts
│       └── shared/directives/
│           └── has-permission.directive.ts
│
└── docs/
    └── UX_Documentation.html           # وثيقة UX التقنية الكاملة
```

---

## 🎨 الهوية البصرية

| العنصر | القيمة |
|--------|--------|
| الأزرق الأساسي | `#1E3A8A` (Primary Blue) |
| الذهبي المميّز | `#D4AF37` (Accent Gold) |
| الأخضر النجاح | `#10B981` |
| الأحمر الخطر | `#DC2626` |
| البرتقالي تحذير | `#F97316` |
| خط عربي | Cairo / Tajawal |
| خط لاتيني | Inter |
| خط الكود | Fira Code |
| الزاوية المستديرة | 12px (بطاقات) / 8px (أزرار) |

---

## 👥 الأدوار المدعومة (10 أدوار)

| الدور | المعرف | لون |
|-------|--------|-----|
| 🏛️ مدير المدرسة | `principal` | أزرق |
| 👨‍🏫 معلم | `teacher` | أخضر |
| 👨‍👩‍👧 ولي أمر | `guardian` | ذهبي |
| 🎓 طالب | `student` | بنفسجي |
| 📋 شؤون الطلاب | `registrar` | فيروزي |
| 💰 محاسب | `accountant` | أحمر |
| 📦 إدارة الأصول | `assets_mgr` | برتقالي |
| 🏫 مشرف المكتب | `office_sup` | بنفسجي غامق |
| 👥 الموارد البشرية | `hr_mgr` | وردي |
| 🔐 مدير النظام | `sysadmin` | رمادي |

---

## 📊 لوحات التحكم المُنفّذة (8 لوحات)

كل لوحة تحتوي على:
- **KPI Cards** خاصة بالدور (4-6 بطاقات)
- **رسوم بيانية تفاعلية** (Chart.js): Line, Bar, Doughnut, Polar Area
- **Quick Actions** (إجراءات سريعة - أقل من 3 نقرات)
- **Activity Feed** (آخر الأنشطة)
- **Smart Alerts** (تنبيهات ذكية ملوّنة حسب الأولوية)

🎭 **بدّل بين اللوحات** عبر شريط الأدوار العلوي في `dashboards.html`.

---

## 🧩 المكونات الجاهزة (30+ مكوّن)

- **الأزرار**: Primary, Gold, Success, Danger, Outline, Ghost, Loading, Icon, Sizes
- **النماذج**: Input, Textarea, Select, Checkbox, Radio, Switch, Input Group
- **التحقق**: Valid, Invalid states + Help text + Error messages
- **الجداول**: Sortable, Responsive, Sticky header, Empty state
- **البطاقات**: Card, Card with Header/Footer, Stat Card (5 variants)
- **الشارات**: Badge (8 variants), Badge with dot
- **التنبيهات**: Alert (Success/Warning/Danger/Info) مع أيقونات
- **الحالات**: Loading Skeleton, Empty State, Error State

---

## ⚡ ملفات Angular الجاهزة

ملفات `.ts` قابلة للنسخ المباشر إلى مشروع Angular 17+ حقيقي:

| الملف | الغرض |
|-------|------|
| `auth.guard.ts` | يحمي المسارات من غير المسجلين |
| `role.guard.ts` | يفرض الوصول حسب الدور |
| `auth.service.ts` | إدارة JWT، تسجيل دخول/خروج، RxJS state |
| `auth.interceptor.ts` | إضافة Bearer Token تلقائياً لكل طلب |
| `has-permission.directive.ts` | إخفاء/إظهار عناصر HTML حسب الصلاحية |
| `master-shell.component.*` | الواجهة الرئيسية مع Router-Outlet |

### مثال استخدام `*hasPermission`:
```html
<button *hasPermission="'students.create'" class="btn btn-primary">
  + تسجيل طالب جديد
</button>
```

---

## 📋 قاعدة "أقل من 3 نقرات"

تم تطبيقها على جميع الوظائف الأساسية:
- **Quick Actions** على كل لوحة تحكم → نقرة واحدة
- **Global Search** في الـ Topbar → نقرتان للوصول لأي كيان
- **Breadcrumbs** للعودة السريعة → نقرة واحدة
- **Recent Items** في Sidebar → نقرتان

---

## 🌐 RTL / LTR

- جميع الواجهات **RTL-First** (الاتجاه من اليمين لليسار).
- جميع المكوّنات مُصمّمة باستخدام `margin-inline-start/end` و`logical properties`.
- جاهزة لإضافة `dir="ltr"` toggler في الدفعات القادمة.

---

## 📱 Responsive Breakpoints

| الجهاز | العرض |
|--------|------|
| Mobile | < 640px |
| Tablet | 640px - 1024px |
| Desktop | 1024px - 1280px |
| Large Desktop | > 1280px |

---

## 🚦 الخطوة التالية (في انتظار اعتمادكم)

### Batch 2 — وحدة الطلاب (≈142 شاشة)
- G1 التسجيل والقيد (16 شاشة): تقديم, مراجعة, اعتماد, ربط ولي الأمر...
- G2 الشؤون الأكاديمية (14): التسكين, الترقية, الجداول, الدرجات
- G3 المكتبة (12): استعارة, إعادة, جرد, غرامات
- G4 الأنشطة (5) • G5 الإجازات (4) • G6 السلوك (7)
- G7 الشكاوى (7) • G8 الإرشاد (4) • G9 التواصل الأسري (6)
- G10 الطوارئ والصحة (5)

### الدفعات اللاحقة:
- **Batch 3**: الموظفين (≈38 شاشة)
- **Batch 4**: الأصول (≈136 شاشة)
- **Batch 5**: إدارة المدرسة (≈30 شاشة)
- **Batch 6**: المالية + الإحصاء + الأمن + الطوارئ (≈52 شاشة)

**إجمالي الخطة الكاملة: ≈423 شاشة**

---

## 📝 ملاحظات للمراجعة

1. **افتح `index.html` أولاً** — يحوي روابط لكل ما تم إنجازه.
2. **جرّب لوحات التحكم** (`dashboards.html`) — بدّل بين الأدوار من الأعلى.
3. **افحص نظام التصميم** (`design-system.html`) — اعتمد الألوان والخطوط.
4. **افحص مكتبة المكوّنات** (`components-library.html`) — اعتمد المكوّنات قبل البدء في Batch 2.
5. **اقرأ وثيقة UX** (`docs/UX_Documentation.html`) — لفهم استراتيجية التنقّل والـ IA.

---

## ✅ معايير الاعتماد قبل الانتقال لـ Batch 2

- [ ] اعتماد الهوية البصرية (Blue + Gold)
- [ ] اعتماد نظام التصميم والمكوّنات
- [ ] اعتماد تخطيط Master Shell (Sidebar + Topbar)
- [ ] اعتماد لوحات التحكم الـ 8
- [ ] اعتماد ملفات Angular الأساسية
- [ ] الموافقة على بدء Batch 2 (وحدة الطلاب)

---

**EduMS Enterprise © 2026** • Foundation Package v1.0
