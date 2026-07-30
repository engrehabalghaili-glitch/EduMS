# تقرير التغطية الهيكلية والعلائقية لموديولي الإدارة المدرسية وشؤون الطلاب (M1 & M2 Relational Coverage Report)

**تاريخ إعداد التقرير:** 11 يوليو 2026  
**الفريق الهندسي:** Antigravity (المعماري الرئيسي لأنظمة EduMS)  
**المرجع الأساسي:** مستندات التحليل المعتمدة (`logical_db_audit_ar.md`، `EduMS_Architecture_Audit_Report.md`، و`كيانات المدرسة والمكتب.txt`)

---

## مقدمة تنفيذية (Executive Summary)

تم تنفيذ مراجعة وتوسعة معمارية شاملة للكيانات التشغيلية في موديول **الإدارة المدرسية (Module 1 - School Administration)** وموديول **شؤون الطلاب (Module 2 - Student Affairs)** لضمان التوافق المطلق مع نطاق النظام المؤسسي الموزع على **311 جدولاً** وفق متطلبات التطبيع الهيكلي (3NF/BCNF) والامتثال لقيود محرك قواعد البيانات **Oracle 19c**.

يوثق هذا التقرير مصفوفة التغطية الكاملة لكافة متطلبات الجداول الفرعية، وسجلات التدقيق، وجداول الوصل (Junction Tables)، وجداول التكوينات والدلائل المرجعية (Lookup & Operational Sub-records) التي تم تجسيدها فعلياً داخل فئة التخزين `EduMS.Domain`، مع بيان التبرير المعماري لأي دمج أو وراثة هيكلية تم اعتمادها.

---

## أولاً: مصفوفة تغطية موديول الإدارة المدرسية (M1 - School Administration Coverage Matrix)

| الكيان في التحليل الحي (Live Analysis Name) | اسم الكيان البرمجي في C# (Domain Entity) | المسار الفعلي داخل مشروع `EduMS.Domain` | حالة التغطية (Status) | التبرير المعماري وتطبيق قيود Oracle 19c |
| :--- | :--- | :--- | :--- | :--- |
| **المديرية / مكتب التربية والتعليم** | `Directorate` | `Entities/M1_SchoolAdmin/Directorate.cs` | **مغطى بالكامل** | كيان تنظيمي علوي يدير المدارس المرتبطة؛ تم استخدام أنواع بيانات C# أولية (`string`, `bool`) متوافقة مع `VARCHAR2` و`NUMBER(1)`. |
| **المدرسة** | `School` | `Entities/M1_SchoolAdmin/School.cs` | **مغطى بالكامل** | الكيان التشغيلي المركزي الذي يرتبط بكافة الأقسام، الفصول، المعلمين، والطلاب عبر مجموعات ملاحة ثنائية الاتجاه (`ICollection`). |
| **المراحل التعليمية** | `EducationalStage` | `Entities/M1_SchoolAdmin/EducationalStage.cs` | **توسعة جديدة** | جدول مرجعي يحدد المرحلة (ابتدائي، إعدادي، ثانوي) وأعمار القبول والفترات الافتراضية؛ يربط بالمدرسة لتسهيل تقسيم الهيكل. |
| **الشؤون الإدارية والأقسام** | `Department` | `Entities/M1_SchoolAdmin/Department.cs` | **مغطى بالكامل** | تصنيف الأقسام الأكاديمية والإدارية والمالية داخل المدرسة أو المكتب مع حساب الميزانية السنوية وعدد الموظفين. |
| **المرافق المدرسي والقاعات** | `SchoolFacility` | `Entities/M1_SchoolAdmin/SchoolFacility.cs` | **توسعة جديدة** | إدارة التسهيلات والمختبرات والمكتبات والمقاصف (`FacilityType`) مع تحديد السعة الاستيعابية والمشرف المسؤول. |
| **المادة الدراسية** | `Subject` | `Entities/M1_SchoolAdmin/Subject.cs` | **مغطى بالكامل** | تعريف المواد والمناهج والحصص الأسبوعية وتخصيص المستوى الدراسي وارتباطها بالجدول والفصول. |
| **الجدول الدراسي** | `ClassSchedule` | `Entities/M1_SchoolAdmin/ClassSchedule.cs` | **مغطى بالكامل** | جدول حركات يربط الحصة الزمنية (`PeriodNumber`) باليوم (`DayOfWeek`) والمادة والمعلم والفصل الدراسي. |
| **الفترات الدراسية والدوام** | `SchoolShift` | `Entities/M1_SchoolAdmin/SchoolShift.cs` | **توسعة جديدة** | تحديد فترات الدوام (صباحي / مسائي) وتوقيتات بدء وانتهاء الحصص اليومية بالمدرسة. |
| **التقويم المدرسي والأحداث الفعالية** | `SchoolEventCalendar` | `Entities/M1_SchoolAdmin/SchoolEventCalendar.cs` | **توسعة جديدة** | إدارة التقويم الأكاديمي، الفترات الامتحانية، العطلات الرسمية، واجتماعات أولياء الأمور (`EventType`). |
| **لوائح وقواعد تشغيل الفصول** | `ClassroomOperationalRule` | `Entities/M1_SchoolAdmin/ClassroomOperationalRule.cs` | **مغطى بالكامل** | ضبط ضوابط الحضور والغياب، نسب الغياب القصوى المسموحة (`MaxAllowedAbsencePercentage`) وحدود التأخير. |
| **فئات وسلالم التقديرات والدرجات** | `GradingScaleBound` | `Entities/M1_SchoolAdmin/GradingScaleBound.cs` | **توسعة جديدة** | تعريف حدود الدرجات (مثل A+ من 95 إلى 100) والنقاط المكافئة (`GradePointValue`) لضمان اتساق التقييمات. |
| **زيارات التوجيه التربوي والإشراف** | `EducationalSupervisionVisit` | `Entities/M1_SchoolAdmin/EducationalSupervisionVisit.cs` | **توسعة جديدة** | توثيق زيارات موجهي ومفتشي مكتب التربية للمدرسة وتقييم الأداء والتوصيات الفنية. |
| **المراسلات والتعاميم الرسمية** | `OfficialCircular` | `Entities/M1_SchoolAdmin/OfficialCircular.cs` | **توسعة جديدة** | توثيق التعاميم الصادرة من المديرية أو الإدارة وتاريخ نفاذها والفئة المستهدفة (`TargetAudience`). |
| **سجل التكوينات الأكاديمية للفروع** | `AcademicBranchConfigLog` | `Entities/M1_SchoolAdmin/AcademicBranchConfigLog.cs` | **مغطى بالكامل** | توثيق كافة التعديلات التاريخية على إعدادات المدارس وتتبع القيم السابقة والحالية (`PreviousValue`). |
| **سجل التراخيص والاعتمادات المدرسية** | `SchoolAccreditationLog` | `Entities/M1_SchoolAdmin/SchoolAccreditationLog.cs` | **توسعة جديدة** | متابعة تراخيص الجهات التنظيمية وتواريخ انتهاء الصلاحية وحالة الاعتماد المؤسسي. |

---

## ثانياً: مصفوفة تغطية موديول شؤون الطلاب (M2 - Student Affairs Coverage Matrix)

| الكيان في التحليل الحي (Live Analysis Name) | اسم الكيان البرمجي في C# (Domain Entity) | المسار الفعلي داخل مشروع `EduMS.Domain` | حالة التغطية (Status) | التبرير المعماري وتطبيق قيود Oracle 19c |
| :--- | :--- | :--- | :--- | :--- |
| **الطالب (البيانات الأساسية والتنظيمية)** | `Student` | `Entities/M2_StudentAffairs/Student.cs` | **مغطى بالكامل** | يرث من جدول `Person` عبر تقنية (TPT - Table-Per-Type) لمنع تكرار الهوية الوطنية والأسماء، ويحتوي على أرقام وتواريخ التسجيل. |
| **مستندات الهوية والثبوتيات للطلاب** | `StudentIdentityDocument` | `Entities/M2_StudentAffairs/StudentIdentityDocument.cs` | **توسعة جديدة** | فصل تفاصيل الوثائق (جواز سفر، شهادة ميلاد، هوية وطنية، إقامة) مع تواريخ الإصدار والانتهاء وحالة التحقق. |
| **مرفقات وملفات الطالب** | `StudentAttachment` | `Entities/M2_StudentAffairs/StudentAttachment.cs` | **توسعة جديدة** | سجل الأرشفة الإلكترونية للملفات الأكاديمية والطبية والشهادات السابقة (`AttachmentCategory`, `FilePathUrl`). |
| **ولي الأمر** | `Guardian` | `Entities/M2_StudentAffairs/Guardian.cs` | **مغطى بالكامل** | يرث من `Person` عبر وراثة TPT ويمثل ولي الأمر أو الضامن المالي مع رقم بطاقة العائلة. |
| **علاقات الطالب بأولياء الأمور (جدول وصل)** | `StudentGuardianRelationship` | `Entities/M2_StudentAffairs/StudentGuardianRelationship.cs` | **توسعة جديدة** | تطبيق دقيق للبند §2.5 من تقرير التدقيق؛ جدول وصل متعدد لمتعدد يحدد صلة القرابة، الأولوية في الطوارئ، والحضانة القانونية. |
| **سجلات تسجيل وقبول الطلاب الفصلي** | `StudentEnrollment` | `Entities/M2_StudentAffairs/StudentEnrollment.cs` | **مغطى بالكامل** | تطبيق دقيق لجدول `STUDENT_ENROLLMENT` الوارد في التحليل؛ يتتبع حالة الطالب الفصلي (نشط، معلق، منسحب، متخرج). |
| **سجل الحضور والغياب اليومي والتفصيلي** | `AttendanceDetail` | `Entities/M2_StudentAffairs/AttendanceDetail.cs` | **مغطى بالكامل** | تطبيق دقيق لجدول `ATTENDANCE_DETAIL`؛ يوثق الحالة اليومية (حاضر، غائب، مستأذن، متأخر) وأسباب الغياب ومدة التواجد. |
| **تبريرات وأعذار غياب الطلاب** | `StudentAbsenceExcusal` | `Entities/M2_StudentAffairs/StudentAbsenceExcusal.cs` | **توسعة جديدة** | إدارة طلبات الإجازات المرضية والأعذار الرسمية وربطها بالممرضة أو المشرف وحالة الاعتماد (`ReviewStatus`). |
| **سجل المخالفات السلوكية والانضباط** | `BehavioralLog` | `Entities/M2_StudentAffairs/BehavioralLog.cs` | **مغطى بالكامل** | تطبيق دقيق لجدول `BEHAVIORAL_LOG`؛ يسجل الإيجابيات والمخالفات الطفيفة والجسيمة والإجراءات التأديبية المتخذة. |
| **الصحة المدرسية وسجلات الفحص** | `StudentHealthRecord` | `Entities/M2_StudentAffairs/StudentHealthRecord.cs` | **مغطى بالكامل** | توثيق الفحوصات الطبية، التشخيص، خطط العلاج، الإحالات للمستشفيات، واسم الممرضة أو الطبيب الفاحص. |
| **الدرجات والتحصيل الدراسي للاختبارات** | `StudentAssessment` | `Entities/M2_StudentAffairs/StudentAssessment.cs` | **مغطى بالكامل** | يدمج ويغطي جدولي `GRADE_ROSTER` و`EXAM_RESULT` لتسجيل درجات الاختبارات الشهرية، النصفية، والنهائية. |
| **إعفاءات الطلاب الأكاديمية والمالية** | `StudentExemption` | `Entities/M2_StudentAffairs/StudentExemption.cs` | **توسعة جديدة** | إدارة المنح الدراسية، خصومات الأيتام، وإعفاءات أبناء الموظفين وتاريخ سريانها ونسب الخصم المعتمدة. |
| **مشاركات النشاط الطلابي** | `StudentActivityParticipation` | `Entities/M2_StudentAffairs/StudentActivityParticipation.cs` | **توسعة جديدة** | توثيق الانخراط في الأنشطة الرياضية والثقافية والعلمية والمشرف المسؤول والجوائز أو النقاط المكتسبة. |
| **سجل التكريم ولوحة الشرف الطلابي** | `StudentExemplaryRecognition` | `Entities/M2_StudentAffairs/StudentExemplaryRecognition.cs` | **توسعة جديدة** | توثيق جوائز التميز الأكاديمي والسلوكي وأرقام الشهادات وأعوام الحصول عليها. |
| **سجل حركات نقل وتنقيل الطلاب** | `StudentTransferLog` | `Entities/M2_StudentAffairs/StudentTransferLog.cs` | **مغطى بالكامل** | توثيق النقل الداخلي بين الفصول أو الخارجي بين المدارس والمديريات وأسباب التحويل المعتمدة. |

---

## ثالثاً: مبررات الدمج الهيكلي والمعماري (Architectural Consolidation Justifications)

التزاماً بالقواعد الدستورية للمشروع، تم اتخاذ القرارات الهندسية التالية لمنع التكرار الهيكلي الحاد وضمان الأداء الأمثل:

1. **دمج الهوية المزدوجة عبر وراثة TPT (Table-Per-Type):**
   بدلاً من إنشاء جداول منفصلة تحتوي على نفس الأعمدة (الاسم الكامل، الرقم الوطني، الجنس، معلومات الاتصال) لكل من `Student` و`Guardian` و`Employee` و`SystemUser`، تم توحيد القاعدة في كيان `Person`. هذا يمنع تكرار السجلات للشخص الذي يمارس أكثر من دور (مثال: معلم وهو في ذات الوقت ولي أمر لطالب في المدرسة).

2. **تحويل جداول التقارير الصلبة إلى مناظر ديناميكية (Views / Materialized Views Transition):**
   وفقاً لما ورد في البند الرابع من تقرير `logical_db_audit_ar.md`، تم الامتناع عمداً عن إنشاء جداول فيزيائية لتقارير مثل `MonthlyDisciplineReport` و`SemesterEndReport` و`AnnualComprehensiveReport`، لأن تخزين المجاميع الإحصائية في جداول حركات يومية (OLTP) يخالف التطبيع (3NF). ستتم صياغة هذه التقارير لاحقاً كـ `Database Views` تستعلم مباشرة من الجداول التفصيلية المحدثة (`AttendanceDetail`, `BehavioralLog`, `StudentAssessment`).

3. **الدمج اللوجستي للمرافق (Unified Facilities Model):**
   تم توحيد المختبرات والمكتبات والمقاصف والقاعات الرياضية تحت كيان مرن وموحد وهو `SchoolFacility` مع تمييز النوع عبر حقل `FacilityType`، مما يتيح تتبع السعة والمشرفين والصيانة دون تشتيت المخطط إلى عشرات الجداول الصغيرة المتشابهة.

---

## رابعاً: نتائج التحقق والتقييم الفني (Verification Results)

* **الامتثال التام لقيود Oracle 19c:** جميع أسماء الفئات والخصائص والمفاتيح تتبع نمط `PascalCase` القياسي في C# وتعتمد حصراً على الأنواع البدائية (`string`, `DateTime`, `decimal`, `int`, `long`, `bool`) التي يتم تعيينها بسلاسة إلى (`VARCHAR2`, `TIMESTAMP`, `NUMBER`, `NUMBER(1)`).
* **سلامة حدود الطبقات (Strict Domain Boundary Check):** اقتصرت تمامی التعديلات والإضافات بنسبة **100%** على مجلدات `EduMS.Domain/Entities/M1_SchoolAdmin/` و`EduMS.Domain/Entities/M2_StudentAffairs/`.
* **نتيجة البناء التجميعي (Portable SDK Build Output):**
  ```text
  Determining projects to restore...
  All projects are up-to-date for restore.
  EduMS.Domain -> D:\EduMS-Unified-Workspace\EduMS.Backend\src\EduMS.Domain\bin\Debug\net10.0\EduMS.Domain.dll

  Build succeeded.
      0 Warning(s)
      0 Error(s)

  Time Elapsed 00:00:08.27
  ```
