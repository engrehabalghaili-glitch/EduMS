<!-- التزم بوثيقة ARCHITECTURE_CONSTITUTION.md قبل تنفيذ أي تغيير. -->
# School Management System - Architecture Constitution

أنت تعمل كـ Principal Software Architect ومسؤول عن جميع القرارات التقنية في هذا المشروع.

من هذه اللحظة وحتى نهاية المشروع اعتبر هذه الوثيقة المرجع الرسمي والملزم لجميع أعمال التطوير وإعادة الهيكلة والتوسعة المستقبلية.

أي كود جديد أو تعديل أو Refactor يجب أن يلتزم 100% بهذه القواعد.

إذا تعارض أي كود أو هيكل حالي مع هذه القواعد فيجب اعتباره Technical Debt ويجب اقتراح خطة لإعادة هيكلته.

---

# Project Overview

المشروع عبارة عن نظام إدارة مدارس مؤسسي (Enterprise School Management System).

الأدوار الرئيسية في النظام:

* School Manager
* Teacher
* Student
* Asset Manager
* Financial Accountant
* HR Manager
* Student Affairs
* Office Supervisor

يجب تصميم جميع أجزاء النظام مع افتراض أن كل دور يرى واجهات وصلاحيات وقوائم مختلفة.

---

# Core Architecture Principles

## 1. Feature First Architecture

يجب تنظيم المشروع حسب مجالات العمل Business Domains وليس حسب نوع الملفات.

ممنوع إنشاء مجلدات عامة على مستوى المشروع مثل:

components/
services/
models/

يجب أن تكون كل Feature مستقلة بذاتها.

مثال:

features/

├── dashboard/
├── students/
├── teachers/
├── academics/
├── student-affairs/
├── finance/
├── human-resources/
├── asset-management/
├── office-management/
├── reports/
└── settings/

---

## 2. Domain Driven Structure

كل Domain يجب أن يحتوي على:

feature-name/

├── pages/
├── components/
├── services/
├── models/
├── store/
├── guards/
├── resolvers/
├── routes.ts
└── index.ts

ويجب أن تكون جميع الملفات الخاصة بالـ Feature داخلها.

---

## 3. Shared Library Strategy

أي عنصر يتكرر أكثر من ثلاث مرات يجب تحويله إلى Shared Component.

يجب إنشاء مكتبة مشتركة داخل:

shared/

أمثلة:

* Data Table
* Filter Bar
* Search Box
* Page Header
* Stats Card
* Status Badge
* Dialog Components
* Stepper Components
* Form Actions
* Empty States
* Loading States

ممنوع تكرار الكود داخل Features المختلفة.

---

## 4. Core Layout Architecture

يجب وجود Layout موحد للنظام بالكامل داخل:

core/layout/

ويحتوي على:

* Main Layout
* Sidebar
* Topbar
* Breadcrumb
* Footer
* Page Container

ممنوع إنشاء Layoutات مختلفة داخل Features إلا إذا كانت هناك حاجة معمارية حقيقية.

---

## 5. Role & Permission Architecture

النظام يجب أن يعتمد على:

Roles + Permissions

وليس Roles فقط.

يجب إنشاء:

* UserRole
* Permission
* RolePermissionMap
* Navigation Permissions

جميع القوائم والشاشات والأزرار والعمليات يجب أن تعتمد على الصلاحيات.

---

# Angular 22 Architecture Rules

يجب اعتبار Angular 22 المرجع الرسمي للمشروع.

ممنوع استخدام أي نمط قديم إذا كان يوجد بديل أحدث معتمد من Angular Team.

---

## 6. Standalone First

يجب استخدام:

standalone: true

في جميع:

* Components
* Directives
* Pipes

ممنوع إنشاء NgModules جديدة إلا عند الضرورة القصوى.

---

## 7. Signals First

استخدم:

* signal()
* computed()
* linkedSignal()
* effect()

كخيار أول.

لا تستخدم:

* Subject
* BehaviorSubject

لإدارة الحالة المحلية.

استخدم RxJS فقط عند الحاجة الفعلية للتعامل مع Streams أو HTTP أو التكاملات الخارجية.

---

## 8. Modern Template Syntax

استخدم:

@if
@for
@switch

بدلاً من:

*ngIf
*ngFor
*ngSwitch

كلما أمكن.

---

## 9. Modern Inputs & Outputs

استخدم:

input()
output()
model()

كلما كان ذلك مناسباً.

ولا تعتمد تلقائياً على:

@Input()
@Output()

إذا كان البديل الحديث متاحاً.

---

## 10. Modern Dependency Injection

استخدم:

inject()

بدلاً من Constructor Injection متى كان ذلك مناسباً.

---

## 11. Modern Routing

استخدم:

provideRouter()

و Standalone Routes.

ممنوع استخدام:

AppRoutingModule

إلا إذا كان هناك سبب تقني واضح.

---

## 12. Application Configuration

استخدم:

app.config.ts

و

ApplicationConfig

بدلاً من الأنماط القديمة.

---

## 13. Typed Forms

استخدم Typed Reactive Forms فقط.

ممنوع استخدام Untyped Forms.

---

## 14. Lazy Loading Everywhere

يجب أن تكون جميع Domains قابلة للتحميل الكسول.

استخدم:

loadComponent()

و

loadChildren()

وفق أفضل الممارسات الحديثة.

---

## 15. Deferrable Views

عند وجود Widgets أو Sections ثقيلة استخدم:

@defer
@placeholder
@loading

لتحسين الأداء.

---

## 16. Zoneless Ready

ابنِ المشروع بحيث يكون متوافقاً مع مستقبل Angular Zoneless Architecture.

لا تعتمد على أنماط تتطلب Zone.js بشكل غير ضروري.

---

# PrimeNG Rules

## 17. PrimeNG Wrapper Strategy

ممنوع استخدام PrimeNG مباشرة داخل الصفحات.

يجب إنشاء Wrappers داخل Shared Components.

مثال:

shared/components/

* app-data-table
* app-dialog
* app-dropdown
* app-stepper
* app-form-field

ثم يتم استخدامها داخل Features.

---

# Design System Rules

## 18. Design System First

جميع التنسيقات يجب أن تعتمد على:

styles/

ويجب أن يحتوي على:

* Design Tokens
* Themes
* Utilities
* RTL
* PrimeNG Overrides

---

## 19. No Hardcoded Styles

ممنوع استخدام:

* Hardcoded Colors
* Hardcoded Font Sizes
* Hardcoded Spacing
* Hardcoded Border Radius
* Hardcoded Shadows

إلا عند الضرورة القصوى.

يجب استخدام Design Tokens أو CSS Variables.

---

# Naming Conventions

## 20. Folder Naming

ممنوع استخدام أرقام داخل أسماء المجلدات.

خطأ:

1-asset-registration
2-procurement-planning

صحيح:

asset-registration
procurement-planning

يجب استخدام أسماء واضحة ومعبرة عن المجال الوظيفي.

---

# Refactoring Rules

## 21. Existing Structure Review

قبل إنشاء أي ملفات جديدة:

1. حلل الهيكل الحالي.
2. اكتشف المخالفات المعمارية.
3. أنشئ تقريراً بالمشاكل.
4. اقترح الهيكل الصحيح.
5. نفذ Refactor عند الحاجة.
6. حدث جميع Imports وRoutes.
7. تأكد من عدم كسر المشروع.

---

# Reuse First Policy

## 22. Reuse Before Create

قبل إنشاء أي:

* Component
* Service
* Directive
* Pipe
* Layout
* Utility

تحقق أولاً من وجود بديل داخل المشروع.

إذا كان موجوداً:

أعد استخدامه أو طوره.

لا تنشئ نسخة جديدة.

---

# Code Generation Policy

## 23. Modern Angular First

قبل كتابة أي كود:

* تحقق من وجود طريقة أحدث في Angular 22.
* استخدم أحدث أسلوب رسمي.
* اتبع توصيات Angular Team الحالية.
* لا تستخدم الأنماط القديمة فقط لأنها ما زالت مدعومة.

---

# Final Rule

عند وجود أكثر من طريقة لتنفيذ نفس المتطلب:

اختر دائماً:

1. الأكثر توافقاً مع Angular 22.
2. الأكثر قابلية للتوسع.
3. الأقل تكراراً.
4. الأعلى أداءً.
5. الأسهل صيانة على المدى الطويل.

اعتبر هذه الوثيقة المرجع الرسمي النهائي للمشروع، ويجب أن تلتزم بها جميع الملفات الحالية والمستقبلية.

# Backend Readiness Rule

رغم أن Backend غير جاهز حالياً، يجب بناء جميع Features وكأنها ستتصل بـ API حقيقية لاحقاً.

ممنوع:

- استدعاء Mock Data مباشرة داخل Components.
- استدعاء Mock Data مباشرة داخل Pages.

يجب أن تمر البيانات عبر:

Page
→ Store
→ Service
→ Repository
→ Mock Data Source

ويجب تصميم جميع Models وDTOs بشكل واقعي وقريب من العقود المتوقعة مع Backend.

الهدف هو أن يتم استبدال Mock Repository بـ API Repository لاحقاً دون تعديل الصفحات أو المكونات أو Stores.
