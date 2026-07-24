# التوليد الآلي لخدمات الفرونت إند (Frontend Services) من الباك إند

تفصل هذه الخطة عملية التوليد الآلي لملفات الخدمات `Services` الخاصة بقسم `M1_SchoolAdmin`. سنقوم بقراءة متحكمات C# (Controllers) وتوليد ملفات `Service` في Angular بما يتطابق تماماً مع معمارية التقسيم الرأسي (Vertical Slicing).

## مراجعة المستخدم مطلوبة

> [!IMPORTANT]
> يرجى مراجعة منطق الـ Script. سيقوم السكريبت بتوليد 39 ملف `.service.ts` في المسار `src/app/modules/school-admin/[feature]/data-access/`. **لن** يقوم بإنشاء ملفات `store` أو `view-model` كما اتفقنا.

## التغييرات المقترحة

سنقوم بإنشاء سكريبت Node.js باسم `scripts/generate-services.js` وسيقوم بالمهام التالية:
1. **المسح (Scanning):** قراءة المجلد `H:\EduMS\EduMS.Backend\src\EduMS.WebApi\Controllers\v1\M1_SchoolAdmin`.
2. **لكل ملف `.cs`:**
   - استخراج الرابط الأساسي (مثال: `/api/v1/Schools`).
   - استخراج اسم الكيان الأساسي من الـ DTOs (مثال: `SchoolDto` ⬅️ `School`).
   - تحديد ملف الـ Interface المطابق في الفرونت إند داخل `src/app/core/api/interfaces/M1_SchoolAdmin/`.
   - تحويل اسم الـ Controller إلى صيغة kebab-case (مثال: `SchoolsController` ⬅️ `schools`).
   - إنشاء المجلد الرأسي للعملية `src/app/modules/school-admin/[kebab-case]/data-access/`.
   - توليد وتعبئة ملف `[kebab-case].service.ts` بـ Class يرث من `BaseApiService<T, TCreate, TUpdate>`.

### الملفات البرمجية (Scripts)

#### [NEW] generate-services.js
هذا السكريبت سيتم تشغيله مرة واحدة لبناء الهيكل الأساسي للخدمات.

### مجلدات الفرونت إند

#### [NEW] 39 ملف Service في قسم school-admin
مثال: `src/app/modules/school-admin/schools/data-access/schools.service.ts`

## خطة الفحص والتحقق (Verification Plan)

### الفحص الآلي (Automated Tests)
- تشغيل أمر `npm run build` بعد انتهاء السكريبت للتأكد من أن جميع الخدمات المضافة خالية من الأخطاء وأن مسارات الاستيراد (Imports) صحيحة 100%.

### الفحص اليدوي (Manual Verification)
- الفحص العشوائي لبعض الخدمات المولدة للتأكد من أنها ترث من `BaseApiService` وأن الرابط `baseUrl` تم تمريره بشكل دقيق ومطابق للباك إند.
