# نظام الإدارة التعليمية الشامل (EduMS) 🎓

## نبذة عن المشروع
نظام **EduMS** (Educational Management System) هو منصة برمجية متكاملة وموحدة مصممة لإدارة كافة جوانب المؤسسات التعليمية. تم بناء النظام وفقاً لأفضل الممارسات الهندسية (Clean Architecture & Domain-Driven Design) لضمان قابلية التوسع، الصيانة، والأداء العالي.

---

## 🏗️ الهيكلية المعمارية (Clean Architecture)
يعتمد النظام على هيكلية **الطبقات النظيفة (Clean Architecture)**، والتي تقسم المشروع إلى 4 طبقات رئيسية لضمان فصل الاهتمامات (Separation of Concerns):

1. **الطبقة الأساسية (EduMS.Domain):**
   - تحتوي على الكيانات الأساسية (Entities)، القواعد (Constants)، والصلاحيات (Permissions).
   - لا تعتمد على أي طبقة أخرى (Zero Dependencies).
2. **طبقة التطبيق (EduMS.Application):**
   - تحتوي على واجهات الاستخدام (Interfaces)، كائنات نقل البيانات (DTOs)، ومنطق العمل (Business Logic / Use Cases).
3. **طبقة البنية التحتية (EduMS.Infrastructure):**
   - تتعامل مع قواعد البيانات (Oracle EF Core)، إعدادات الجداول (Configurations)، محرك الأمان والصلاحيات (RBAC Engine)، والخدمات الخارجية.
4. **طبقة العرض (EduMS.WebApi):**
   - واجهة برمجة التطبيقات (RESTful APIs).
   - منظمة بحسب الوحدات (Modules) لتسهيل الوصول والتطوير.

---

## 📁 توزيع المجلدات والوحدات (Project Structure)

تم تقسيم النظام إلى **8 وحدات رئيسية (Modules)** تغطي كافة المتطلبات الإدارية والتشغيلية:

- 🏫 **M1_SchoolAdmin:** إدارة المدرسة، الفصول، المقررات، القواعد التشغيلية.
- 👨‍🎓 **M2_StudentAffairs:** شؤون الطلاب، الغياب، السلوك، التقييمات، والأنشطة.
- 👥 **M3_EmployeeManagement:** إدارة الموظفين، الرواتب، الإجازات، واللجان.
- 📦 **M4_AssetLogistics:** إدارة الأصول، المخازن، العهد، والصيانة.
- 💰 **M5_FinancialManagement:** الإدارة المالية، الفواتير، الرسوم، وحسابات الطلاب.
- 📊 **M6_StatisticsReports:** الإحصائيات، مؤشرات الأداء (KPIs)، والتقارير التحليلية.
- 💬 **M7_CommunicationManagement:** إدارة الطوارئ، التواصل، الإشعارات، والرسائل.
- 🔐 **M8_AuthenticationUsers:** إدارة المستخدمين، المصادقة، وصلاحيات الوصول (RBAC).

---

## 🛡️ إنجازات مرحلة الحماية والأمان (Phase 2 - RBAC Rollout)

تم بناء نظام حماية متقدم جداً للتحكم في الوصول بناءً على الأدوار (Role-Based Access Control) ويتميز بالتالي:

1. **التغطية الشاملة:** تم حماية **أكثر من 200 كيان** و **143 Controller** في جميع الوحدات الثمانية.
2. **الـ Attributes المخصصة:** تم بناء `[HasPermission]` Attribute يضمن أن كل Endpoint لا يمكن الوصول إليه إلا بمن يمتلك الصلاحية الدقيقة (مثلاً: `Permissions.Students.View`).
3. **عزل البيانات (Multi-Tenancy):** تطبيق فلاتر تلقائية (Global Query Filters) تضمن أن كل مستخدم يرى فقط البيانات الخاصة بمدرسته (`SchoolId`) بشكل آمن.
4. **المغذي التلقائي (Dynamic Seeder):** تم بناء محرك ذكي يقوم بقراءة كافة الصلاحيات برمجياً (عبر Reflection) ويزرعها في قاعدة البيانات للمدير العام (Super Admin) عند أول تشغيل، لمنع سيناريو الانغلاق (Lockout).

---

## 🚀 كيفية التشغيل (Getting Started)

1. **قاعدة البيانات:** تأكد من إعداد اتصال قاعدة بيانات Oracle في ملف `appsettings.json`.
2. **تحديث قاعدة البيانات:**
   ```bash
   dotnet ef database update --project src\EduMS.Infrastructure --startup-project src\EduMS.Infrastructure
   ```
3. **تشغيل المشروع:**
   ```bash
   dotnet build
   dotnet run --project src\EduMS.WebApi
   ```

---
*تم بناء وتوثيق هذا النظام بعناية ليكون نواة صلبة لمستقبل التعليم الرقمي.*
