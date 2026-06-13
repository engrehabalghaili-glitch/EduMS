# 🏛️ EduMS Enterprise — التوثيق الهندسي الكامل والشامل
## Complete Software Architecture Documentation Package

---

## 📊 إحصائيات النظام الموثَّق

| المقياس | القيمة |
|---|---:|
| الوحدات الوظيفية | **8** |
| الجداول المُحلَّلة | **205** |
| الحقول الموثَّقة | **6,795** |
| علاقات المفاتيح الأجنبية | **1,285** |
| المخططات الهندسية | **122** |
| العمليات والسيناريوهات | **300+** |

---

## 📁 محتويات هذه الحزمة

### `01_html_site/` — الموقع التفاعلي الكامل
موقع HTML متعدد الصفحات للقراءة والتنقل بسهولة. **ابدأ من `index.html`**.

| الملف | المحتوى | عدد المخططات |
|---|---|:---:|
| `index.html` | الفهرس الرئيسي والنظرة العامة | — |
| `01_dfd.html` | مخططات السياق وتدفق البيانات | 10 |
| `02_usecase.html` | مخططات حالات الاستخدام (مفصَّلة لكل وحدة) | 9 |
| `03_sequence.html` | مخططات التسلسل (Sequence) لكل عملية حرجة | 23 |
| `04_activity.html` | مخططات النشاط ودورة الحياة (State Machines) | 17 |
| `05_class.html` | مخططات الكلاسات UML الكاملة لكل وحدة | 8 |
| `06_erd.html` | مخططات قاعدة البيانات (Master + Module + Sub-Group ERDs) | 53 |
| `07_architecture.html` | مكونات النظام والتوزيع (Microservices + Deployment) | 2 |

> **💡 تشغيل الموقع:** افتح `index.html` في أي متصفح حديث (Chrome / Firefox / Edge).

### `02_source_files/` — المصادر القابلة للتعديل
- **`.mmd`** — مصادر Mermaid لكل مخطط (افتحها في [Mermaid Live Editor](https://mermaid.live))
- **`.puml`** — مصادر PlantUML لكل مخطط (افتحها في [PlantText](https://www.planttext.com) أو IntelliJ)
- **`EduMS_Full_Schema.sql`** — DDL كامل بـ SQL يُنشئ جميع الـ 205 جدول

### `03_full_schema_with_fields.json`
قاموس بيانات JSON يحتوي على كل جدول مع كل حقوله ووصفها.

### `04_enriched_schema_with_fk.json`
نفس البيانات مُدعَّمة بمفاتيح PK المُكتشفة و علاقات FK.

### `05_all_diagrams_metadata.json`
بيانات وصفية لكل المخططات الـ 122 (id, title, type, level, مصدر Mermaid و PlantUML).

### `06_complete_single_page.html`
**صفحة واحدة** تجمع كل الـ 122 مخطط (~2MB). أبطأ في التحميل لكنها مناسبة للطباعة كـ PDF واحد.

---

## 🎯 المخططات حسب النوع

### 1️⃣ Context & DFD (10 مخططات)
- **CTX-01** — Context Diagram المؤسسي
- **DFD-L0** — DFD Level 0 (الوحدات الـ 8)
- **DFD-L1-M1...M8** — DFD Level 1 لكل وحدة

### 2️⃣ Use Case Diagrams (9 مخططات)
- **UC-MASTER** — حزم Use Cases المؤسسية
- **UC-M1...M8** — Use Case تفصيلي لكل وحدة (يحتوي 12-38 حالة استخدام لكل واحدة)

### 3️⃣ Sequence Diagrams (23 مخطط)
- تسجيل طالب، حضور، درجات، ترقية، نقل، دفع
- تعيين موظف، راتب، إجازة، نقل، إنهاء خدمة
- تسجيل أصل، صيانة، جرد، شطب
- إنشاء مدرسة، تقرير سنوي، تنفيذ تعميم
- تسجيل دخول مستخدم، تطبيق RBAC
- استجابة طوارئ، تدريب، توليد تقارير

### 4️⃣ Activity & State Diagrams (17 مخطط)
- **State Machines (8):** Student, Employee, Asset, Application, Invoice, Maintenance, Plan, Leave
- **Activity Diagrams (9):** احتساب درجة، نقل طالب، صيانة، جرد، خطة سنوية، إجازة، طوارئ، إدارة أدوار، توليد تقرير

### 5️⃣ Class Diagrams (8 مخططات)
- **CLASS-M1...M8** — مخطط كلاسات UML كامل لكل وحدة بالـ:
  - Attributes (مع PK/FK)
  - Methods (مُستنبَطة من حالات الاستخدام)
  - علاقات Association/Aggregation/Composition

### 6️⃣ ERD Diagrams (53 مخطط)
- **ERD-MASTER** — مخطط عالي المستوى للـ Aggregate Roots
- **CROSS-MODULE** — العلاقات بين الوحدات
- **ERD-FULL-M1...M8** — ERD كامل لكل وحدة (بجميع الحقول)
- **ERD-SLIM-M1...M8** — ERD مختصر (أهم 8 حقول لكل جدول)
- **ERD-SG-*** — 35 ERD مفصَّل للمجموعات الفرعية داخل الوحدات (سهلة القراءة)

### 7️⃣ Architecture (2 مخطط)
- **COMP-01** — Component Diagram (Microservices + Event-Driven)
- **DEPLOY-01** — Deployment Diagram (Kubernetes + HA + DR)

---

## 🛠️ تقنيات وأدوات مستخدمة

| الأداة | الاستخدام |
|---|---|
| **Mermaid 10.9.1** | الرسم التفاعلي في المتصفح |
| **PlantUML** | مصادر بديلة قابلة للتحرير |
| **UML 2.5** | معايير الكلاسات والـ Sequence |
| **Crow's Foot Notation** | تمثيل علاقات ERD |
| **Yourdon-DeMarco** | معايير DFD |
| **ISO 55000** | معيار إدارة الأصول |
| **RBAC + ABAC** | نموذج الصلاحيات |

---

## 📋 خطوات الاستخدام الموصى بها

1. **ابدأ بـ** `01_html_site/index.html` للحصول على نظرة عامة
2. **استكشف** كل قسم على حدة (ERD → Class → Sequence → Activity)
3. **للتعديل**:
   - افتح ملف `.mmd` المقابل من `02_source_files/`
   - الصقه في [Mermaid Live Editor](https://mermaid.live) أو [PlantText](https://www.planttext.com)
4. **لإنشاء قاعدة البيانات**:
   - استخدم `02_source_files/EduMS_Full_Schema.sql`
5. **للطباعة كـ PDF**:
   - استخدم `06_complete_single_page.html` ثم Ctrl+P

---

## 📜 الترخيص

هذا التوثيق تم إنشاؤه بناءً على وثائق التحليل المُقدَّمة من المشروع.

**EduMS Enterprise** — نظام أتمتة العمليات التعليمية والإدارية لمكتب التربية والتعليم والمدارس التابعة له.

---

✅ **متوافق مع:** UML 2.5 · Yourdon-DeMarco DFD · Chen-Crow ERD · ISO 55000 · RBAC/ABAC
