# 🅰️ EduMS Enterprise — Angular Skeleton

هذا الهيكل البرمجي الجاهز لمشروع Angular يعكس بالضبط ما تم بناؤه في الـ HTML Master Shell. عند الانتقال للإنتاج، انسخ هذه الملفات إلى مشروع Angular جديد.

## 📁 البنية

```
src/app/
├── core/
│   ├── auth/
│   │   ├── auth.service.ts          # خدمة المصادقة
│   │   ├── auth.guard.ts            # حماية الصفحات
│   │   └── role.guard.ts            # تحقق من الأدوار
│   ├── services/
│   │   └── permission.service.ts    # خدمة الصلاحيات
│   └── interceptors/
│       └── auth.interceptor.ts      # حقن JWT في كل request
├── shared/
│   ├── components/
│   │   ├── button/
│   │   ├── data-table/
│   │   ├── modal/
│   │   └── ...
│   └── directives/
│       └── has-permission.directive.ts
├── layouts/
│   └── master-shell/
│       ├── master-shell.component.ts
│       ├── master-shell.component.html
│       └── master-shell.component.scss
└── features/
    ├── auth/
    │   └── login.component.ts
    └── dashboard/
        └── dashboard.component.ts
```

## 🚀 خطوات التشغيل (بعد الاعتماد)

```bash
# 1. إنشاء مشروع Angular جديد
ng new edums-frontend --routing --style=scss --standalone

# 2. نسخ ملفات هذا المجلد إلى src/app/
cp -r angular_skeleton/src/app/* ./edums-frontend/src/app/

# 3. تنصيب التبعيات
cd edums-frontend
npm install chart.js @phosphor-icons/web

# 4. التشغيل
ng serve
```

## 📦 الحزم المطلوبة (package.json)

```json
{
  "dependencies": {
    "@angular/animations": "^17.0.0",
    "@angular/common": "^17.0.0",
    "@angular/core": "^17.0.0",
    "@angular/forms": "^17.0.0",
    "@angular/router": "^17.0.0",
    "chart.js": "^4.4.0",
    "@phosphor-icons/web": "^2.0.3",
    "rxjs": "~7.8.0"
  }
}
```

## 🔐 ملاحظات أمنية

- JWT يُحفظ في `localStorage` (يمكن تحديثه إلى `httpOnly cookie` للأمان الأعلى)
- كل HTTP request يمر عبر `AuthInterceptor` لإضافة Bearer token
- الـ Guards تمنع الوصول غير المصرح
- توجيه `*hasPermission` يخفي/يُظهر العناصر حسب الصلاحيات
