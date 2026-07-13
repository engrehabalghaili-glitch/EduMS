# تقرير الهندسة المعمارية والتدقيق العكسي الشامل: البناء الأساسي للمرحلة الأولى للقسمين السابع والثامن (M7 & M8)

**تاريخ الإصدار:** 13 يوليو 2026  
**المشروع:** EduMS (Enterprise Educational Management System)  
**النطاق المعماري:** إدارة الطوارئ والتميز والمجتمع (Module 7 - Emergency Management & Community Resilience) ونظام الصلاحيات والمستخدمين والتدقيق الأمني (Module 8 - Authentication, RBAC & Identity Auditing)  
**مرجع الحقيقة الأساسي:** الأرشيف البرمجي المضغوط (`اخر واهم ملفات مشروع التخرج.zip` - المخططات المصدرية `faild_053908.txt`, `ERD_M8_Emergency.html`, `ERD_M7_Auth.html`)  

---

## 1. المقدمة والهدف الاستراتيجي (Executive Summary & Strategic Mandate)

امتثالاً للتوجيه المعماري الصارم والمحكم بإنجاز البناء الأساسي للمرحلة الأولى (**Phase-1 Scaffolding**) للقسمين الختاميين في النظام البيئي: القسم السابع (**إدارة الطوارئ والتميز - Emergency Management**) والقسم الثامن (**نظام الصلاحيات والمستخدمين - Authentication & Users**)، مع التجميد التام والتحفظ المطلق على الأقسام السابقة (M1 إلى M6) وعدم إقحام أي روابط علاقاتية متداخلة (`Relational Cross-Module Linkages`) في هذه المرحلة، تم تنفيذ تدقيق عكسي شامل واستخراج كلي 100% لكافة الجداول والحقول والقيود المصدرية.

وقد تم الالتزام الدقيق بالمحاذير الهندسية العليا (**High-Level Architectural Advisory Warnings**):
1. **حوكمة الأمن والصلاحيات (RBAC & Enterprise Identity Governance):** تم بناء هياكل الصلاحيات والأدوار وسياسات الوصول في القسم الثامن ككيانات `POCO` عالية الهيكلة تعتمد على **مفاتيح نصية مرنة (`Custom String Permission Keys`)** بدل التعدادات الثابتة المحدودة (`Fragmented Enums`)، مع تصميم سجلات تتبع الجلسات ونشاط المستخدم وتدقيق النظام (`Audit Logs`) لتتحمل التدفق العالي للبيانات (`High-Throughput Logging`) وتطبق أنماط القراءة فقط غير القابلة للتعديل (`Absolute Read-Only Immutability Patterns`).
2. **مرونة الطوارئ والأثر المجتمعي (Emergency Resilience & High-Precision Financials):** تم تصميم كيانات إدارة الطوارئ والإغلاقات وعمليات الدمج وحالات العجز والفائض باستخدام الأنواع البدائية الآمنة المتوافقة مع سعات التخزين في **Oracle 19c**، مع الاعتماد المطلق على النوع المحاسبي فائق الدقة (`decimal`) لكافة الحسابات التقديرية والفعلية لخطط المعالجة وتكاليف الأضرار وتقييمات العجز والفائض.
3. **حرية الهيكلة والفصل العزلي للمرحلة الأولى:** تم فصل وتنظيم الكيانات بمرونة داخل `M7_EmergencyManagement/` و`M8_AuthenticationUsers/` لتحقيق أعلى درجات الوضوح والنمو المستقبلي، مع الحفاظ على عزلها التام وتوفير بناء سليم وبدون أي أخطاء أو تحذيرات.

---

## 2. جدول استخراج المخططات ومصادقة الكيانات البرمجية (Precise Extraction & Validation Catalog)

توضح الجداول التالية التطابق التام 1-to-1 بين المخططات المصدرية في الأرشيف والكيانات البرمجية المولدة حديثاً في طبقات المجال (`Domain Layer`)، مع تدقيق المنطق والنية المعمارية لكل كيان:

### أولاً: كتالوج كيانات إدارة الطوارئ والتميز والمجتمع (Module 7 - Emergency Management)

| الجدول المصدري المرجعي (`Legacy ERD Table`) | الكيان البرمجي المولد (`C# POCO Entity`) | عدد الحقول | سجل التدقيق والتحقق من المنطق والنية الاستراتيجية (`Validation Log & Intent`) |
| :--- | :--- | :---: | :--- |
| `EmergencyHosting` | `EmergencyHosting` | **30 حقلاً** | إدارة الاستضافة الطارئة للنازحين أو الطلاب الوافدين أو استخدام مرافق المدرسة كمراكز قيادة طارئة، يتتبع أرقام الاستضافة وأنواعها وتواريخها، ومعدلات الاستيعاب ونسب الإشغال (`UtilizationPercentage` كـ `decimal`)، وتتبع الموارد والمصاريف المالية الموثقة بصيغ `JSON`. |
| `EmergencyIncidents` | `EmergencyIncident` | **35 حقلاً** | تتبع الحوادث الطارئة (زلازل، حرائق، أوبئة، سيول) ودرجة خطورتها وأعداد المتضررين والمصابين والوفيات، مع التقدير المالي للأضرار في الممتلكات (`PropertyDamage` كـ `decimal`) وتوثيق روابط خطط الاستجابة ومحاضر التحقيق والدروس المستفادة. |
| `EmergencyClosures` | `EmergencyClosure` | **26 حقلاً** | توثيق قرارات الإغلاق الطارئ وأسبابه (جوية، صحية، أمنية) والجهة المتخذة للقرار، وتتبع إجمالي أيام الإغلاق وتفعيل منصات التعليم البديل (المتزامن وغير المتزامن) وإشعارات أولياء الأمور وربط الإغلاق بخطط التعويض الميداني. |
| `TransportationServices` | `TransportationService` | **30 حقلاً** | إدارة خطوط النقل الميداني وحافلات المدرسة، يتتبع رموز المسارات وأرقام اللوحات وبيانات السائق والمشرف وساعات الانطلاق والوصول ومحطات التوقف المجدولة (`StopsJson`) وعقود مشغلي النقل. |
| `SchoolMergers` | `SchoolMerger` | **20 حقلاً** | تتبع قرارات وإجراءات دمج المدارس (نقل الطلاب والمعلمين والأصول من المدارس المصدرية إلى المدرسة المستهدفة `TargetSchoolId`)، وتوثيق تواريخ الدمج ومستندات القرارات الوزارية وحالة تقدم عمليات النقل. |
| `SchoolAwards` | `SchoolAward` | **23 حقلاً** | توثيق التميز والجوائز المدرسية (محلياً، وطنياً، إقليمياً، دولياً)، وتتبع الجهات المانحة ومجالات التميز وأعداد الطلاب والمعلمين المشاركين والوثائق والشهادات والصور الداعمة للتميز. |
| `ExternalParticipations` | `ExternalParticipation` | **24 حقلاً** | تتبع المشاركات والتمثيل الخارجي للمدرسة في الفعاليات الرياضية والعلمية والثقافية والتطوعية، وتوثيق الجهات المنظمة والنتائج المحققة ومصادر التمويل والنفقات التقديرية والفعلية. |
| `CommunityPartnerships` | `CommunityPartnership` | **26 حقلاً** | إدارة اتفاقيات الشراكة المجتمعية مع الشركات والجامعات والجهات غير الربحية، وتتبع نوع الدعم (عيني، مالي، تدريبي، تجهيزات) وتقييم القيمة المالية للدعم (`SupportValueAmount` كـ `decimal`) وقياس الأثر الميداني. |
| `SafetySecurityReports` | `SafetySecurityReports` | **32 حقلاً** | تقارير السلامة والأمان الدورية (فحص طفايات الحريق، أنظمة الإنذار، مخارج الطوارئ، خرائط الإخلاء)، وتتبع عدد ومتوسط أوقات تجارب الإخلاء الميدانية وتشكيل لجان السلامة وساعات التدريب. |
| `SchoolDeficit` | `SchoolDeficit` | **26 حقلاً** | رصد وتتبع حالات العجز التعليمي أو التشغيلي (نقص فصول، معلمين، تجهيزات، ميزانية)، وقياس القيمة المالية والمقدار الفعلي للمطلوب والمتاح، وتحديد الأثر وتكاليف وتواريخ المعالجة التقديرية والفعلية (`EstimatedResolutionCost` كـ `decimal`). |
| `SchoolSurplus` | `SchoolSurplus` | **26 حقلاً** | رصد حالات الفائض (فصول زائدة، معلمين، ميزانيات، أصول)، وتتبع خطط الاستفادة وإعادة التوزيع الداخلي أو التأجير أو النقل لمدارس أخرى، وربط الفائض بخطط المعالجة. |
| `RemediationPlan` | `RemediationPlan` | **31 حقلاً** | خطط المعالجة التشغيلية لحل مشكلات العجز أو توظيف الفائض، وتحديد الخيارات التنفيذية وخطوات العمل والميزانية التقديرية والتكلفة الفعلية ونسب الإنجاز (`ProgressPercentage` كـ `decimal`). |
| `EmergencyPlans` | `EmergencyPlan` | **15 حقلاً** | الكيان الإرشادي الأساسي لخطط الاستجابة والطوارئ وموجز إجراءات الإخلاء وتواريخ التدريبات القادمة. |

---

### ثانياً: كتالوج كيانات نظام الصلاحيات والمستخدمين والتدقيق الأمني (Module 8 - Authentication & RBAC)

| الجدول المصدري المرجعي (`Legacy ERD Table`) | الكيان البرمجي المولد (`C# POCO Entity`) | عدد الحقول | سجل التدقيق والتحقق من المنطق والنية الاستراتيجية (`Validation Log & Intent`) |
| :--- | :--- | :---: | :--- |
| `SystemUser` | `SystemUser` | **48 حقلاً** | الكيان المركزي لإدارة الهوية والمصادقة، يدعم كلمات المرور المشفرة وإشعارات التحقق الثنائي (`TwoFactorMethod`)، وتتبع محاولات الدخول الفاشلة وأقفال الحسابات التلقائية والتفضيلات والإعدادات، مع روابط مرنة للموظف والطالب وولي الأمر. |
| `UserActivityLog` | `UserActivityLog` | **18 حقلاً** | سجل تتبع نشاطات المستخدمين والجلسات (دخول، خروج، تغيير كلمات مرور)، مصمم للتدفق العالي غير القابل للتعديل (`Read-Only Immutable Pattern`) مع توثيق عناوين `IP` ونوع الأجهزة والمتصفحات ومواقع الاتصال. |
| `PermissionType` | `PermissionType` | **18 حقلاً** | تصنيف أنواع الصلاحيات (عرض، إنشاء، تعديل، حذف، اعتماد) ومستويات المخاطرة (`RiskLevel`) ومتطلبات موافقة المشرفين. |
| `Permission` | `SystemPermission` | **20 حقلاً** | كيان الصلاحية النظامية الفردية، يعتمد على **مفاتيح نصية قياسية مرنة (`PermissionKey`)** مثل `students.create` و`finance.invoice.exempt` لضمان عدم التقيد بقوائم `enum` ثابتة وتسهيل الحوكمة الديناميكية. |
| `Role` | `SystemRole` | **17 حقلاً** | تعريف الأدوار الوظيفية (مدير مدرسة، معلم، محاسب) ودعم التسلسل الهرمي للأدوار (`HierarchyLevel`) وقابلية التوريث والتخصيص. |
| `RolePermission` | `RolePermission` | **18 حقلاً** | الكيان الوسيط لربط الصلاحيات بالأدوار مع دعم تخصيص النطاقات (`ScopeOverride`) وتتبع تاريخ وأصل التوريث. |
| `UserRole` | `UserRoleAssignment` | **18 حقلاً** | تعيين الأدوار للمستخدمين مع تحديد الدور الأساسي (`IsPrimary`) وسياق النطاق الميداني (`ScopeContextJson`) وتواريخ الصلاحية. |
| `GovernanceRBAC` | `GovernanceRbacRule` | **15 حقلاً** | قواعد حوكمة الصلاحيات والأدوار (تحديد الأدوار المخولة بمنح أو سحب أو تعديل أدوار وصلاحيات أخرى وتحديد صلاحية التفويض والموافقات). |
| `UserPermission` | `UserDirectPermission` | **18 حقلاً** | منح صلاحيات مباشرة واستثنائية على مستوى المستخدم الفردي (`Direct Override`) متجاوزة أو مكملة لصلاحيات أدواره المعتادة مع توثيق السبب والمدة. |
| `AccessPolicy` | `AccessPolicy` | **20 حقلاً** | سياسات الوصول الأمني الذكية (تقييد بالوقت، بالموقع الجغرافي، بنوع الجهاز أو بنطاق `IP Address`) وأثر السياسة (سماح، منع، طلب مصادقة إضافية). |
| `PermissionBase` | `PermissionBaseModule` | **17 حقلاً** | الوحدات الأساسية والأقسام التي تندرج تحتها الصلاحيات لتسهيل عرضها وتجميعها في واجهات الإدارة. |
| `StudentBasePermissions` | `StudentBasePermission` | **18 حقلاً** | مصفوفة صلاحيات شؤون الطلاب (تسجيل، نقل، ترفيع، انسحاب) وتحديد ارتباطها بموافقة مدير المدرسة أو ولي الأمر وتصنيف حساسيتها. |
| `StudentAcademicPermissions`| `StudentAcademicPermission` | **18 حقلاً** | مصفوفة صلاحيات الدرجات والحضور والغياب، مع تقييدها بالنوافذ الزمنية لرصد الدرجات وضوابط كسر القفل الأكاديمي (`RequiresLockOverride`). |
| `StudentFinancePermissions` | `StudentFinancePermission` | **18 حقلاً** | مصفوفة صلاحيات الخصومات والإعفاءات وتحصيل واسترجاع الفواتير، مقيدة بسقوف مالية عليا باستخدام دقة `decimal` فائقة (`MaxAmountLimit`, `MaxDiscountPercentage`) واشتراط موافقات الإدارة العليا والمجلس للمبالغ الكبيرة. |
| `OfficePermissions` | `OfficePermission` | **18 حقلاً** | صلاحيات مكاتب ومديريات التعليم والإشراف التربوي، وتحديد نطاقها (قطاع جغرافي، جميع المدارس) وصلاحية تجاوز قرارات المدرسة أو الاكتفاء بالاطلاع. |
| `BehaviorPermissionMatrix`| `BehaviorPermissionMatrix` | **18 حقلاً** | مصفوفة صلاحيات السلوك الطلابي حسب درجات المخالفة (الأولى إلى الخامسة) وتحديد الصلاحيات الحصرية للرصد والتحقيق وإقرار أو الإعفاء من العقوبات. |
| `BehaviorPermissions` | `BehaviorPermission` | **18 حقلاً** | صلاحيات التوجيه والإرشاد والسلوك الخاصة بالمعلمين والموجهين الطلابيين، وتحديد ضوابط السرية التامة لحالات الإرشاد النفسي. |
| `AuditLog` | `SystemAuditLog` | **28 حقلاً** | سجل التدقيق الجنائي والشامل لجميع العمليات الحساسة في النظام (`INSERT, UPDATE, DELETE, GRANT, REVOKE`)، يوثق القيم القديمة والجديدة (`OldValueJson`, `NewValueJson`) وحساب درجة المخاطرة (`RiskScore` كـ `decimal`) واكتشاف العمليات المشبوهة، ومصمم بوضعية غير قابلة للتعديل أو الحذف (`Read-Only Immutable`). |
| `StudentPermissionAudit` | `StudentPermissionAuditLog`| **18 حقلاً** | سجل تدقيق مخصص لرصد كل استعلام أو تعديل على بيانات أو صلاحيات الطلاب لضمان حماية الخصوصية المطلقة. |
| `RoleMatrix` | `RoleMatrix` | **16 حقلاً** | مصفوفة مرجعية لتخزين القوالب الجاهزة للأدوار والصلاحيات لتسهيل تهيئة المدارس الجديدة في النظام. |
| `PrivilegeRules` | `PrivilegeRule` | **18 حقلاً** | قواعد التدقيق والامتيازات التلقائية التي تطلق إجراءات آلية عند حدوث شروط محددة (إرسال تنبيه، التسجيل في سجل التدقيق الحساس، حظر العملية فوراً). |

---

## 3. التوافق المطلق مع معايير Oracle 19c وضوابط الأداء العالي

تم التحقق من تطبيق المعايير الصارمة لضمان التوافق المطلق مع البنية التحتية للمؤسسات:
1. **سلامة أسماء الحقول والمعرفات (Oracle 19c Identifiers):** جميع الكيانات المنجزة تستخدم أسماء برمجية بلغة `PascalCase` واضحة وخالية من أي رموز خاصة أو تعارضات مع الكلمات المحجوزة في Oracle، وتلتزم بالأنواع البدائية المدعومة بشكل أصيل في تعيينات `EF Core` (`long, int, string, DateTime, bool, decimal`).
2. **العمليات المحاسبية فائقة الدقة (`High-Precision Decimal Operations`):** تم استخدام نوع `decimal` لكافة المقاييس المالية والعددية الدقيقة في القسمين M7 و M8، بما في ذلك التكاليف التقديرية للمعالجة (`EstimatedResolutionCost`)، ومبالغ العجز والفائض، وقيم الدعم المجتمعي، ونسب الإنجاز والاستيعاب (`ProgressPercentage, UtilizationPercentage`)، وسقوف الصلاحيات المالية (`MaxAmountLimit`)، ودرجات المخاطرة الأمنية (`RiskScore`).
3. **أنماط التدفق العالي وغير القابلة للتعديل (`High-Throughput Read-Only Immutability`):** تم تصميم كيانات التدقيق الأمني (`SystemAuditLog`, `UserActivityLog`, `StudentPermissionAuditLog`) لتعمل كوثائق تاريخية ثابتة تسجل لحظياً كافة الأنشطة مع توثيق سياق التنفيذ الكامل (`IP Address, SessionId, AccessContextJson`)، بما يمنع أي تلاعب أو تعديل لاحق ويدعم الامتثال لمعايير الأمان المؤسسي.

---

## 4. التحقق من سلامة البناء البرمجي (Clean Portable SDK Build Verification)

تم تنفيذ أمر البناء الشامل لحل المشروع الكامل (`EduMS.slnx`) باستخدام حزمة تطوير .NET SDK (`10.0.301`)، وقد اجتازت جميع الطبقات البرمجية الاختبار بنجاح تام وبدون أي أخطاء أو تحذيرات (`0 Warning(s), 0 Error(s)`):

```text
  Determining projects to restore...
  All projects are up-to-date for restore.
  EduMS.Domain -> D:\EduMS-Unified-Workspace\EduMS.Backend\src\EduMS.Domain\bin\Debug\net10.0\EduMS.Domain.dll
  EduMS.Application -> D:\EduMS-Unified-Workspace\EduMS.Backend\src\EduMS.Application\bin\Debug\net10.0\EduMS.Application.dll
  EduMS.Infrastructure -> D:\EduMS-Unified-Workspace\EduMS.Backend\src\EduMS.Infrastructure\bin\Debug\net10.0\EduMS.Infrastructure.dll
  EduMS.WebApi -> D:\EduMS-Unified-Workspace\EduMS.Backend\src\EduMS.WebApi\bin\Debug\net10.0\EduMS.WebApi.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:20.73
```

---

## 5. تواقيع وهياكل الكيانات المنشأة (Entity Signatures & Architecture Overview)

تم هيكلة كافة الكيانات داخل نطاقات المجال المستقلة (`Namespace: EduMS.Domain.Entities`) واشتقاقها من الفئة الأساسية للتدقيق (`BaseAuditableEntity`). وفيما يلي ملخص لتواقيعها البرمجية الرئيسية:

### كيانات الإدارة المالية للمرحلة الأولى - القسم السابع (`M7_EmergencyManagement`)
```csharp
public class EmergencyHosting : BaseAuditableEntity { /* 30 properties: HostingNumber, UtilizationPercentage (decimal), TotalExpenses (decimal)... */ }
public class EmergencyIncident : BaseAuditableEntity { /* 35 properties: IncidentType, Severity, PropertyDamage (decimal), AffectedCount... */ }
public class EmergencyClosure : BaseAuditableEntity { /* 26 properties: ClosureReason, TotalClosureDays, AlternativeEducationActivated... */ }
public class TransportationService : BaseAuditableEntity { /* 30 properties: RouteCode, BusPlateNumber, DriverEmployeeId, StopsJson... */ }
public class SchoolMerger : BaseAuditableEntity { /* 20 properties: MergerNumber, SourceSchoolIdsJson, TargetSchoolId, EffectiveDate... */ }
public class SchoolAward : BaseAuditableEntity { /* 23 properties: AwardName, AwardLevel, IssuingBody, StudentParticipantsCount... */ }
public class ExternalParticipation : BaseAuditableEntity { /* 24 properties: EventName, EventType, Results, ExpensesJson... */ }
public class CommunityPartnership : BaseAuditableEntity { /* 26 properties: PartnerName, SupportType, SupportValueAmount (decimal), ImpactRating... */ }
public class SafetySecurityReport : BaseAuditableEntity { /* 32 properties: ReportNumber, DrillCount, DrillAverageTimeMinutes, SafetyLevel... */ }
public class SchoolDeficit : BaseAuditableEntity { /* 26 properties: DeficitType, DeficitAmount (decimal), EstimatedResolutionCost (decimal)... */ }
public class SchoolSurplus : BaseAuditableEntity { /* 26 properties: SurplusType, SurplusAmount (decimal), UtilizationPlan... */ }
public class RemediationPlan : BaseAuditableEntity { /* 31 properties: PlanNumber, PlanType, EstimatedBudget (decimal), ActualCost (decimal), ProgressPercentage (decimal)... */ }
public class EmergencyPlan : BaseAuditableEntity { /* 15 properties: PlanCode, PlanTitleAr, NextScheduledDrillDate... */ }
```

### كيانات الصلاحيات والمستخدمين والأمن - القسم الثامن (`M8_AuthenticationUsers`)
```csharp
public class SystemUser : BaseAuditableEntity { /* 48 properties: Username, PasswordHash, TwoFactorEnabled, UserType, EmployeeId... */ }
public class UserActivityLog : BaseAuditableEntity { /* 18 properties: UserId, ActivityType, IpAddress, SessionId, ActivityStatus... */ }
public class PermissionType : BaseAuditableEntity { /* 18 properties: TypeCode, Category, RiskLevel, RequiresApproval... */ }
public class SystemPermission : BaseAuditableEntity { /* 20 properties: PermissionKey (string), Module, ActionType, RiskLevel, IsSensitive... */ }
public class SystemRole : BaseAuditableEntity { /* 17 properties: RoleCode, HierarchyLevel, ParentRoleId, IsInheritable... */ }
public class RolePermission : BaseAuditableEntity { /* 18 properties: RoleId, PermissionId, ScopeOverride, IsInherited... */ }
public class UserRoleAssignment : BaseAuditableEntity { /* 18 properties: UserId, RoleId, IsPrimary, ScopeContextJson... */ }
public class GovernanceRbacRule : BaseAuditableEntity { /* 15 properties: RoleId, TargetRoleId, AllowedAction, CanDelegate, ApprovalRequired... */ }
public class UserDirectPermission : BaseAuditableEntity { /* 18 properties: UserId, PermissionId, ScopeOverride, Reason... */ }
public class AccessPolicy : BaseAuditableEntity { /* 20 properties: PolicyCode, PolicyType, PolicyRuleJson, PolicyEffect, Priority... */ }
public class PermissionBaseModule : BaseAuditableEntity { /* 17 properties: ModuleCode, SectionCode, DefaultPermissionsJson... */ }
public class StudentBasePermission : BaseAuditableEntity { /* 18 properties: PermissionKey, RequiresPrincipalApproval, RequiresGuardianConsent... */ }
public class StudentAcademicPermission : BaseAuditableEntity { /* 18 properties: PermissionKey, IsTimeBound, RequiresLockOverride... */ }
public class StudentFinancePermission : BaseAuditableEntity { /* 18 properties: PermissionKey, MaxAmountLimit (decimal), MaxDiscountPercentage (decimal)... */ }
public class OfficePermission : BaseAuditableEntity { /* 18 properties: PermissionKey, ScopeType, CanOverrideSchoolDecision, IsReadOnly... */ }
public class BehaviorPermissionMatrix : BaseAuditableEntity { /* 18 properties: RoleId, BehaviorLevel, CanRecord, CanInvestigate, CanDecidePenalty... */ }
public class BehaviorPermission : BaseAuditableEntity { /* 18 properties: PermissionKey, Category, IsConfidential, RequiresSocialWorkerRole... */ }
public class SystemAuditLog : BaseAuditableEntity { /* 28 properties: ActionType, EntityType, OldValueJson, NewValueJson, RiskScore (decimal), IsSuspicious... */ }
public class StudentPermissionAuditLog : BaseAuditableEntity { /* 18 properties: StudentId, PermissionKey, ActionType, RiskScore (decimal)... */ }
public class RoleMatrix : BaseAuditableEntity { /* 16 properties: RoleCode, RoleType, PermissionsJson, SortOrder... */ }
public class PrivilegeRule : BaseAuditableEntity { /* 18 properties: RuleCode, TriggerAction, ConditionJson, Priority... */ }
```

---

## 6. طلب التفويض الصريح (Request for Explicit Authorization)

تم إنجاز وتدقيق مرحلة البناء الأساسي للمرحلة الأولى (**Phase-1 Initial Scaffolding**) للقسم السابع (إدارة الطوارئ والتميز - M7) والقسم الثامن (نظام الصلاحيات والمستخدمين والتدقيق الأمني - M8) بنسبة **100%** وفق المخططات الأصلية والمحاذير الهندسية، وبثبات تام في البناء البرمجي الشامل (`Build Succeeded - 0 Warnings, 0 Errors`).

**نحن الآن بانتظار تفويضكم واعتمادكم الصريح على إنجاز هذه المرحلة الختامية للبناء الأساسي (Phase-1)، قبل البدء في مرحلة الدمج والتوحيد والتكامل الملاحي الشامل بين جميع الأقسام الثمانية (Phase-2 Grand Cross-Module Relational Integration).**
