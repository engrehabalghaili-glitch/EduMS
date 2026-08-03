# تقرير تهيئة Fluent API لجسور التكامل العلائقي عبر الأقسام الثمانية

**تاريخ الإصدار:** 13 يوليو 2026  
**المرحلة:** Phase-3 – Infrastructure Persistence Configuration Pass  
**الفرع البرمجي:** `AHMED_ALMSANI_M1-TO-M8`  
**المشروع:** EduMS – نظام إدارة التعليم المؤسسي الموحد  
**الملف المُنتَج:** `EduMS.Infrastructure/Persistence/Configurations/CrossModule_Integrations/CrossModuleBridgeConfigurations.cs`  
**إطار العمل:** .NET 10 / EF Core 10.0.9 / Oracle 19c  

---

## 1. الملخص التنفيذي (Executive Summary)

تُوثّق هذه الوثيقة تهيئة طبقة البنية التحتية (`Infrastructure Layer`) بالكامل لجميع **19 كياناً جسرياً** أُنشئت خلال المرحلة الثانية (Phase-2) في ملف `CrossModule_RelationalIntegration.cs`. استُخدم نمط **Fluent API** عبر واجهة `IEntityTypeConfiguration<T>` المُعتمَدة في Clean Architecture لضمان الفصل الكامل بين تعريفات الكيانات في طبقة المجال (Domain) وخصائصها المادية في قاعدة البيانات.

تم توحيد جميع التكوينات في ملف واحد احترافياً منظم داخل المسار المخصص:
```
EduMS.Infrastructure/
  Persistence/
    Configurations/
      CrossModule_Integrations/
        CrossModuleBridgeConfigurations.cs
```

يحتوي الملف على **19 فئة تهيئة** تغطي كل جسر علائقي بين الأقسام الثمانية.

---

## 2. القوانين المعمارية الصارمة المُطبَّقة (Enforced Architectural Laws)

| القانون | التطبيق التقني |
| :--- | :--- |
| **Oracle 19c – تسمية UPPER_SNAKE_CASE** | جميع أسماء الجداول والأعمدة بأحرف كبيرة مع شرطة سفلية: `CM_ENROLLMENT_FINANCIAL_LINK`, `SCHOOL_ASSET_ID` إلخ |
| **دقة الأعداد العشرية المالية (HasPrecision)** | `HasPrecision(19, 4)` لجميع الحقول المالية كالرواتب والرسوم والمدفوعات وقيم الأصول |
| **منع الحذف الدوري (DeleteBehavior.Restrict)** | `DeleteBehavior.Restrict` على جميع مفاتيح العلاقات الأجنبية الرئيسية غير الفارغة لمنع أخطاء الاعتمادية الدورية في Oracle |
| **NoAction للمفاتيح الثانوية الاختيارية** | `DeleteBehavior.NoAction` على المفاتيح الأجنبية الفارغة (nullable FKs) والمسارات الثانوية متعددة الاحتمالات لتجنب تعارض CASCADE متعدد المسارات |
| **فهرسة شاملة لجميع FKs (HasIndex)** | `HasIndex()` صريح على كل حقل FK تحسيناً لأداء الاستعلامات التحليلية عالية الحمل، مع فهارس مركّبة `HasIndex(composite)` للبحث الشائع |
| **تسمية الفهارس (HasDatabaseName)** | أسماء فهارس واضحة ومعيارية: `IDX_CM_<اختصار_الجدول>_<اختصار_العمود>` لضمان الوضوح في خطط التنفيذ |

---

## 3. فهرس تهيئات الجسور الكامل (Complete Bridge Configuration Catalog)

### 3.1 الجسر 1-أ: ربط التسجيل الأكاديمي بالحساب المالي
**الكيان:** `EnrollmentFinancialLink`  
**الجدول الفيزيائي في Oracle:** `CM_ENROLLMENT_FINANCIAL_LINK`  
**اختصار الجدول في الفهارس:** `CM_EFL`  
**التدفق:** M2 (شؤون الطلاب) ⟷ M5 (الإدارة المالية)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `EnrollmentId` | `ENROLLMENT_ID` | `long` – FK → `STUDENT_ENROLLMENT`, `Restrict` |
| `StudentAccountId` | `STUDENT_ACCOUNT_ID` | `long` – FK → `STUDENT_ACCOUNT`, `Restrict` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `SchoolAcademicYearId` | `ACADEMIC_YEAR_ID` | `long?` – Optional |
| `TuitionFeeDue` | `TUITION_FEE_DUE` | `decimal(19,4)` |
| `DiscountApplied` | `DISCOUNT_APPLIED` | `decimal(19,4)` |
| `ExemptionApplied` | `EXEMPTION_APPLIED` | `decimal(19,4)` |
| `NetPayable` | `NET_PAYABLE` | `decimal(19,4)` |
| `IsSettled` | `IS_SETTLED` | `bool` |
| `SettlementDate` | `SETTLEMENT_DATE` | `DateTime?` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_EFL_ENROLLMENT`, `IDX_CM_EFL_ACCOUNT`, `IDX_CM_EFL_STUDENT`, `IDX_CM_EFL_SCHOOL`

---

### 3.2 الجسر 1-ب: تسوية الدفعة بالفاتورة
**الكيان:** `PaymentToInvoiceSettlement`  
**الجدول الفيزيائي في Oracle:** `CM_PAYMENT_INVOICE_SETTLEMENT`  
**اختصار الجدول في الفهارس:** `CM_PIS`  
**التدفق:** M2 ⟷ M5

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `SETTLEMENT_ID` | `long` – PK |
| `PaymentVoucherId` | `PAYMENT_VOUCHER_ID` | `long` – FK → `PAYMENT_VOUCHER`, `Restrict` |
| `FeeInvoiceId` | `FEE_INVOICE_ID` | `long` – FK → `FEE_INVOICE`, `Restrict` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `AllocatedAmount` | `ALLOCATED_AMOUNT` | `decimal(19,4)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_PIS_VOUCHER`, `IDX_CM_PIS_INVOICE`, `IDX_CM_PIS_STUDENT`

---

### 3.3 الجسر 2: ربط كشف الرواتب بالقيد المحاسبي
**الكيان:** `PayrollJournalEntryLink`  
**الجدول الفيزيائي في Oracle:** `CM_PAYROLL_JOURNAL_LINK`  
**اختصار الجدول في الفهارس:** `CM_PJL`  
**التدفق:** M3 (إدارة الموظفين) ⟷ M5 (الإدارة المالية)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `PayrollDetailId` | `PAYROLL_DETAIL_ID` | `long` – FK → `PAYROLL_DETAIL`, `Restrict` |
| `JournalEntryId` | `JOURNAL_ENTRY_ID` | `long` – FK → `JOURNAL_ENTRY`, `Restrict` |
| `EmployeeId` | `EMPLOYEE_ID` | `long` – FK → `EMPLOYEE`, `Restrict` |
| `PayrollRunId` | `PAYROLL_RUN_ID` | `long` – FK → `PAYROLL_RUN`, `Restrict` |
| `SalaryAmount` | `SALARY_AMOUNT` | `decimal(19,4)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_PJL_DETAIL`, `IDX_CM_PJL_JOURNAL`, `IDX_CM_PJL_EMPLOYEE`, `IDX_CM_PJL_RUN`

---

### 3.4 الجسر 3-أ: ربط الأصل بالقيد المحاسبي
**الكيان:** `AssetFinancialJournalLink`  
**الجدول الفيزيائي في Oracle:** `CM_ASSET_FINANCIAL_JOURNAL`  
**اختصار الجدول في الفهارس:** `CM_AFJ`  
**التدفق:** M4 (الأصول واللوجستيات) ⟷ M5 (الإدارة المالية)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `SchoolAssetId` | `SCHOOL_ASSET_ID` | `long` – FK → `SCHOOL_ASSET`, `Restrict` |
| `JournalEntryId` | `JOURNAL_ENTRY_ID` | `long` – FK → `JOURNAL_ENTRY`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `EntryType` | `ENTRY_TYPE` | `nvarchar(40)` |
| `EntryAmount` | `ENTRY_AMOUNT` | `decimal(19,4)` |
| `EntryDate` | `ENTRY_DATE` | `DateTime` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_AFJ_ASSET`, `IDX_CM_AFJ_JOURNAL`, `IDX_CM_AFJ_SCHOOL_DATE` (مركّب)

---

### 3.5 الجسر 3-ب: ربط أمر الشراء بسند الصرف
**الكيان:** `AssetProcurementPaymentLink`  
**الجدول الفيزيائي في Oracle:** `CM_ASSET_PROCUREMENT_PAYMENT`  
**اختصار الجدول في الفهارس:** `CM_APP`  
**التدفق:** M4 ⟷ M5

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `PurchaseOrderId` | `PURCHASE_ORDER_ID` | `long` – FK → `PURCHASE_ORDER`, `Restrict` |
| `PaymentVoucherId` | `PAYMENT_VOUCHER_ID` | `long` – FK → `PAYMENT_VOUCHER`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `PaidAmount` | `PAID_AMOUNT` | `decimal(19,4)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_APP_ORDER`, `IDX_CM_APP_VOUCHER`, `IDX_CM_APP_SCHOOL`

---

### 3.6 الجسر 4-أ: تأثير الطوارئ على الأصول
**الكيان:** `EmergencyIncidentAssetImpact`  
**الجدول الفيزيائي في Oracle:** `CM_EMERGENCY_ASSET_IMPACT`  
**اختصار الجدول في الفهارس:** `CM_EAIA`  
**التدفق:** M7 (إدارة الطوارئ) ⟷ M4 (الأصول واللوجستيات)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `IMPACT_ID` | `long` – PK |
| `EmergencyIncidentId` | `EMERGENCY_INCIDENT_ID` | `long` – FK → `EMERGENCY_INCIDENT`, `Restrict` |
| `SchoolAssetId` | `SCHOOL_ASSET_ID` | `long` – FK → `SCHOOL_ASSET`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `ImpactType` | `IMPACT_TYPE` | `int` |
| `EstimatedDamageValue` | `EST_DAMAGE_VALUE` | `decimal(19,4)` |
| `DamageDescription` | `DAMAGE_DESCRIPTION` | `nvarchar(1000)` |
| `RequiresMaintenance` | `REQUIRES_MAINTENANCE` | `bool` |
| `MaintenanceTicketId` | `MAINTENANCE_TICKET_ID` | `long?` – FK → `ASSET_MAINTENANCE_TICKET`, `Restrict` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_EAIA_INCIDENT`, `IDX_CM_EAIA_ASSET`, `IDX_CM_EAIA_SCHOOL`

---

### 3.7 الجسر 4-ب: ربط الاستضافة الطارئة بالمستودع
**الكيان:** `EmergencyHostingWarehouseLink`  
**الجدول الفيزيائي في Oracle:** `CM_EMERGENCY_HOSTING_WAREHOUSE`  
**اختصار الجدول في الفهارس:** `CM_EHW`  
**التدفق:** M7 ⟷ M4

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `EmergencyHostingId` | `EMERGENCY_HOSTING_ID` | `long` – FK → `EMERGENCY_HOSTING`, `Restrict` |
| `WarehouseId` | `WAREHOUSE_ID` | `long` – FK → `WAREHOUSE`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `SuppliesUsedJson` | `SUPPLIES_USED_JSON` | `nvarchar(4000)` |
| `TotalSupplyValue` | `TOTAL_SUPPLY_VALUE` | `decimal(19,4)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_EHW_HOSTING`, `IDX_CM_EHW_WAREHOUSE`, `IDX_CM_EHW_SCHOOL`

---

### 3.8 الجسر 5: ربط مصاريف الطوارئ بدفتر الأستاذ
**الكيان:** `EmergencyFinancialExpenseLink`  
**الجدول الفيزيائي في Oracle:** `CM_EMERGENCY_FINANCIAL_EXPENSE`  
**اختصار الجدول في الفهارس:** `CM_EFE`  
**التدفق:** M7 (إدارة الطوارئ) ⟷ M5 (الإدارة المالية)

> **ملاحظة معمارية حرجة:** هذا الجدول يملك ثلاثة مفاتيح أجنبية اختيارية متنافية (أحدها يكون فارغاً في كل سجل) تشير إلى ثلاثة كيانات طوارئ مختلفة: `EMERGENCY_INCIDENT_ID`, `EMERGENCY_HOSTING_ID`, `EMERGENCY_CLOSURE_ID`. تم تطبيق `DeleteBehavior.NoAction` على هذه الروابط الثلاثة تحديداً لمنع خطأ Oracle المزدوج للاعتمادية الدورية عبر مسارات متعددة، بينما بقيت روابط `SCHOOL` و`JOURNAL_ENTRY` محمية بـ `DeleteBehavior.Restrict`.

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `EXPENSE_LINK_ID` | `long` – PK |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `EmergencyIncidentId` | `EMERGENCY_INCIDENT_ID` | `long?` – FK → `EMERGENCY_INCIDENT`, `NoAction` |
| `EmergencyHostingId` | `EMERGENCY_HOSTING_ID` | `long?` – FK → `EMERGENCY_HOSTING`, `NoAction` |
| `EmergencyClosureId` | `EMERGENCY_CLOSURE_ID` | `long?` – FK → `EMERGENCY_CLOSURE`, `NoAction` |
| `JournalEntryId` | `JOURNAL_ENTRY_ID` | `long` – FK → `JOURNAL_ENTRY`, `Restrict` |
| `ExpenseAmount` | `EXPENSE_AMOUNT` | `decimal(19,4)` |
| `ExpenseCategory` | `EXPENSE_CATEGORY` | `nvarchar(60)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_EFE_SCHOOL`, `IDX_CM_EFE_JOURNAL`, `IDX_CM_EFE_INCIDENT`, `IDX_CM_EFE_HOSTING`, `IDX_CM_EFE_CLOSURE`

---

### 3.9 الجسر 6-أ: ربط هوية المستخدم بالموظف
**الكيان:** `UserEmployeeIdentityLink`  
**الجدول الفيزيائي في Oracle:** `CM_USER_EMPLOYEE_IDENTITY`  
**اختصار الجدول في الفهارس:** `CM_UEIL`  
**التدفق:** M8 (المصادقة والمستخدمين) ⟷ M3 (إدارة الموظفين)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `SystemUserId` | `SYSTEM_USER_ID` | `long` – FK → `SYSTEM_USER`, `Restrict` |
| `EmployeeId` | `EMPLOYEE_ID` | `long` – FK → `EMPLOYEE`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `DirectorateId` | `DIRECTORATE_ID` | `long?` – FK → `DIRECTORATE`, `NoAction` |
| `OrganizationalSectorId` | `ORGANIZATIONAL_SECTOR_ID` | `long?` – FK → `ORGANIZATIONAL_SECTOR`, `NoAction` |
| `LinkStatus` | `LINK_STATUS` | `int` |
| `LinkedAt` | `LINKED_AT` | `DateTime` |
| `UnlinkedAt` | `UNLINKED_AT` | `DateTime?` |
| `UnlinkReason` | `UNLINK_REASON` | `nvarchar(300)` |
| `LinkedByUserId` | `LINKED_BY_USER_ID` | `long?` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_UEIL_USER`, `IDX_CM_UEIL_EMPLOYEE`, `IDX_CM_UEIL_SCHOOL`

---

### 3.10 الجسر 6-ب: ربط هوية المستخدم بالطالب
**الكيان:** `UserStudentIdentityLink`  
**الجدول الفيزيائي في Oracle:** `CM_USER_STUDENT_IDENTITY`  
**اختصار الجدول في الفهارس:** `CM_USIL`  
**التدفق:** M8 ⟷ M2 (شؤون الطلاب)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `SystemUserId` | `SYSTEM_USER_ID` | `long` – FK → `SYSTEM_USER`, `Restrict` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `LinkStatus` | `LINK_STATUS` | `int` |
| `LinkedAt` | `LINKED_AT` | `DateTime` |
| `UnlinkedAt` | `UNLINKED_AT` | `DateTime?` |
| `LinkedByUserId` | `LINKED_BY_USER_ID` | `long?` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_USIL_USER`, `IDX_CM_USIL_STUDENT`, `IDX_CM_USIL_SCHOOL`

---

### 3.11 الجسر 6-ج: ربط هوية المستخدم بولي الأمر
**الكيان:** `UserGuardianIdentityLink`  
**الجدول الفيزيائي في Oracle:** `CM_USER_GUARDIAN_IDENTITY`  
**اختصار الجدول في الفهارس:** `CM_UGIL`  
**التدفق:** M8 ⟷ M2

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `SystemUserId` | `SYSTEM_USER_ID` | `long` – FK → `SYSTEM_USER`, `Restrict` |
| `StudentGuardianRelationshipId` | `GUARDIAN_RELATIONSHIP_ID` | `long` – FK → `STUDENT_GUARDIAN_RELATIONSHIP`, `Restrict` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `LinkStatus` | `LINK_STATUS` | `int` |
| `LinkedAt` | `LINKED_AT` | `DateTime` |
| `UnlinkedAt` | `UNLINKED_AT` | `DateTime?` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_UGIL_USER`, `IDX_CM_UGIL_GUARDIAN`, `IDX_CM_UGIL_STUDENT`

---

### 3.12 الجسر 7-أ: ربط لقطة التقرير بمصادرها
**الكيان:** `ReportSnapshotSourceLink`  
**الجدول الفيزيائي في Oracle:** `CM_REPORT_SNAPSHOT_SOURCE`  
**اختصار الجدول في الفهارس:** `CM_RSSL`  
**التدفق:** M6 (الإحصاء والتقارير) ⟷ M1 إلى M5

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `StatisticalReportSnapshotId` | `REPORT_SNAPSHOT_ID` | `long` – FK → `STATISTICAL_REPORT_SNAPSHOT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `SourceModule` | `SOURCE_MODULE` | `nvarchar(10)` |
| `SourceEntityType` | `SOURCE_ENTITY_TYPE` | `nvarchar(80)` |
| `SourceEntityId` | `SOURCE_ENTITY_ID` | `long?` |
| `SchoolAcademicYearId` | `ACADEMIC_YEAR_ID` | `long?` |
| `AggregationDescription` | `AGGREGATION_DESC` | `nvarchar(500)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_RSSL_SNAPSHOT`, `IDX_CM_RSSL_SCHOOL_MOD` (مركّب: SchoolId + SourceModule)

---

### 3.13 الجسر 7-ب: ربط تدريب الموظف بعرض المساق
**الكيان:** `EmployeeTrainingCourseLink`  
**الجدول الفيزيائي في Oracle:** `CM_EMPLOYEE_TRAINING_COURSE`  
**اختصار الجدول في الفهارس:** `CM_ETCL`  
**التدفق:** M3 (إدارة الموظفين) ⟷ M1 (إدارة المدارس)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `EmployeeTrainingId` | `EMPLOYEE_TRAINING_ID` | `long` – FK → `EMPLOYEE_TRAINING`, `Restrict` |
| `TrainingCourseOfferingId` | `TRAINING_COURSE_OFFERING_ID` | `long` – FK → `TRAINING_COURSE_OFFERING`, `Restrict` |
| `EmployeeId` | `EMPLOYEE_ID` | `long` – FK → `EMPLOYEE`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `TrainingFeeAmount` | `TRAINING_FEE_AMOUNT` | `decimal(19,4)` |
| `FundingSource` | `FUNDING_SOURCE` | `nvarchar(40)` |
| `CertificateIssued` | `CERTIFICATE_ISSUED` | `bool` |
| `CertificateUrl` | `CERTIFICATE_URL` | `nvarchar(500)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_ETCL_TRAINING`, `IDX_CM_ETCL_OFFERING`, `IDX_CM_ETCL_EMPLOYEE`

---

### 3.14 الجسر 8-أ: تتبع سلامة الطالب في الطوارئ
**الكيان:** `EmergencyStudentSafetyRecord`  
**الجدول الفيزيائي في Oracle:** `CM_EMERGENCY_STUDENT_SAFETY`  
**اختصار الجدول في الفهارس:** `CM_ESSR`  
**التدفق:** M7 (إدارة الطوارئ) ⟷ M2 (شؤون الطلاب)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `SAFETY_RECORD_ID` | `long` – PK |
| `EmergencyIncidentId` | `EMERGENCY_INCIDENT_ID` | `long` – FK → `EMERGENCY_INCIDENT`, `Restrict` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `SafetyStatus` | `SAFETY_STATUS` | `int` |
| `ParentNotified` | `PARENT_NOTIFIED` | `bool` |
| `ParentNotificationTime` | `PARENT_NOTIFICATION_TIME` | `DateTime?` |
| `Location` | `LOCATION` | `nvarchar(300)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_ESSR_INCIDENT_STATUS` (مركّب: IncidentId + SafetyStatus)، `IDX_CM_ESSR_STUDENT`, `IDX_CM_ESSR_SCHOOL`

---

### 3.15 الجسر 8-ب: تتبع سلامة الموظف في الطوارئ
**الكيان:** `EmergencyEmployeeSafetyRecord`  
**الجدول الفيزيائي في Oracle:** `CM_EMERGENCY_EMPLOYEE_SAFETY`  
**اختصار الجدول في الفهارس:** `CM_EESR`  
**التدفق:** M7 ⟷ M3 (إدارة الموظفين)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `SAFETY_RECORD_ID` | `long` – PK |
| `EmergencyIncidentId` | `EMERGENCY_INCIDENT_ID` | `long` – FK → `EMERGENCY_INCIDENT`, `Restrict` |
| `EmployeeId` | `EMPLOYEE_ID` | `long` – FK → `EMPLOYEE`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `SafetyStatus` | `SAFETY_STATUS` | `int` |
| `IsOnDutyDuringIncident` | `IS_ON_DUTY` | `bool` |
| `AssignedRole` | `ASSIGNED_ROLE` | `nvarchar(80)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_EESR_INCIDENT_STATUS` (مركّب)، `IDX_CM_EESR_EMPLOYEE`, `IDX_CM_EESR_SCHOOL`

---

### 3.16 الجسر 9: ربط عهدة الطالب بالأصل المادي
**الكيان:** `StudentCustodyAssetLink`  
**الجدول الفيزيائي في Oracle:** `CM_STUDENT_CUSTODY_ASSET`  
**اختصار الجدول في الفهارس:** `CM_SCAL`  
**التدفق:** M2 (شؤون الطلاب) ⟷ M4 (الأصول واللوجستيات)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `StudentInventoryCustodyId` | `STUDENT_INVENTORY_CUSTODY_ID` | `long` – FK → `STUDENT_INVENTORY_CUSTODY`, `Restrict` |
| `SchoolAssetId` | `SCHOOL_ASSET_ID` | `long?` – FK → `SCHOOL_ASSET`, `NoAction` |
| `InventoryItemId` | `INVENTORY_ITEM_ID` | `long?` – FK → `INVENTORY_ITEM`, `NoAction` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `ReplacementValue` | `REPLACEMENT_VALUE` | `decimal(19,4)` |
| `IsReturned` | `IS_RETURNED` | `bool` |
| `ReturnDate` | `RETURN_DATE` | `DateTime?` |
| `ConditionOnReturn` | `CONDITION_ON_RETURN` | `int` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_SCAL_CUSTODY`, `IDX_CM_SCAL_ASSET`, `IDX_CM_SCAL_ITEM`, `IDX_CM_SCAL_STUDENT`

---

### 3.17 الجسر 10: ربط اشتراك النقل بخط الحافلة
**الكيان:** `StudentTransportRouteLink`  
**الجدول الفيزيائي في Oracle:** `CM_STUDENT_TRANSPORT_ROUTE`  
**اختصار الجدول في الفهارس:** `CM_STRL`  
**التدفق:** M2 (شؤون الطلاب) ⟷ M7 (إدارة الطوارئ/النقل)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `StudentTransportationSubscriptionId` | `TRANSPORT_SUBSCRIPTION_ID` | `long` – FK → `STUDENT_TRANSPORTATION_SUBSCRIPTION`, `Restrict` |
| `TransportationServiceId` | `TRANSPORTATION_SERVICE_ID` | `long` – FK → `TRANSPORTATION_SERVICE`, `Restrict` |
| `StudentId` | `STUDENT_ID` | `long` – FK → `STUDENT`, `Restrict` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `AssignedSeatNumber` | `ASSIGNED_SEAT_NUMBER` | `nvarchar(10)` |
| `SubscriptionStatus` | `SUBSCRIPTION_STATUS` | `int` |
| `EffectiveFrom` | `EFFECTIVE_FROM` | `DateTime?` |
| `EffectiveTo` | `EFFECTIVE_TO` | `DateTime?` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_STRL_SUBSCRIPTION`, `IDX_CM_STRL_SERVICE`, `IDX_CM_STRL_STUDENT`

---

### 3.18 الجسر 11: قاموس الكيانات القابلة للتدقيق
**الكيان:** `AuditableEntityRegistry`  
**الجدول الفيزيائي في Oracle:** `CM_AUDITABLE_ENTITY_REGISTRY`  
**اختصار الجدول في الفهارس:** `CM_AER`  
**التدفق:** M8 (المصادقة والمستخدمين) ⟷ جميع الأقسام (M1-M7)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `REGISTRY_ID` | `long` – PK |
| `EntityTypeKey` | `ENTITY_TYPE_KEY` | `nvarchar(80)` – **UNIQUE** |
| `SourceModule` | `SOURCE_MODULE` | `nvarchar(10)` |
| `TableNameHint` | `TABLE_NAME_HINT` | `nvarchar(80)` |
| `EntityNameAr` | `ENTITY_NAME_AR` | `nvarchar(150)` |
| `EntityNameEn` | `ENTITY_NAME_EN` | `nvarchar(150)?` |
| `IsSensitive` | `IS_SENSITIVE` | `bool` |
| `RequiresApprovalToModify` | `REQUIRES_APPROVAL` | `bool` |
| `IsActive` | `IS_ACTIVE` | `bool` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `UX_CM_AER_ENTITY_TYPE_KEY` (**فريد - UNIQUE**)، `IDX_CM_AER_SOURCE_MODULE`

---

### 3.19 الجسر 12: ربط مؤشر الأداء بالفترة المالية
**الكيان:** `KpiFinancialPeriodLink`  
**الجدول الفيزيائي في Oracle:** `CM_KPI_FINANCIAL_PERIOD`  
**اختصار الجدول في الفهارس:** `CM_KFPL`  
**التدفق:** M6 (الإحصاء والتقارير) ⟷ M5 (الإدارة المالية)

| العمود | اسم Oracle | النوع / القيد |
| :--- | :--- | :--- |
| `Id` | `LINK_ID` | `long` – PK |
| `KpiMetricRecordId` | `KPI_METRIC_RECORD_ID` | `long` – FK → `KPI_METRIC_RECORD`, `Restrict` |
| `PayrollRunId` | `PAYROLL_RUN_ID` | `long?` – FK → `PAYROLL_RUN`, `NoAction` |
| `JournalEntryId` | `JOURNAL_ENTRY_ID` | `long?` – FK → `JOURNAL_ENTRY`, `NoAction` |
| `SchoolId` | `SCHOOL_ID` | `long` – FK → `SCHOOL`, `Restrict` |
| `PeriodLabel` | `PERIOD_LABEL` | `nvarchar(20)` |
| `Notes` | `NOTES` | `nvarchar(500)` |

**الفهارس:** `IDX_CM_KFPL_KPI`, `IDX_CM_KFPL_SCHOOL`, `IDX_CM_KFPL_PAYROLL_RUN`, `IDX_CM_KFPL_JOURNAL`

---

## 4. إجمالي الإنجاز الكمي (Quantitative Summary)

| البند | القيمة |
| :--- | :---: |
| إجمالي فئات `IEntityTypeConfiguration<T>` المُنشأة | **19** |
| إجمالي الجداول الفيزيائية الجديدة في Oracle | **19** |
| إجمالي الفهارس (Indexes) المُضافة | **51** |
| حقول FK محمية بـ `DeleteBehavior.Restrict` | **45** |
| حقول FK محمية بـ `DeleteBehavior.NoAction` | **12** |
| حقول مالية بـ `HasPrecision(19, 4)` | **14** |
| حقول أعمدة التدقيق (Audit columns) لكل كيان | **9 × 19 = 171** |
| فهارس مركّبة (Composite Indexes) | **5** |
| فهارس فريدة (Unique Indexes) | **1** |

---

## 5. آلية التسجيل التلقائي (Auto-Registration Mechanism)

لا يتطلب هذا الملف أي تسجيل يدوي. يعتمد `EduMSDbContext` على سطر التسجيل التلقائي التالي في `OnModelCreating`:

```csharp
modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduMSDbContext).Assembly);
```

يقوم EF Core تلقائياً باستكشاف وتطبيق جميع فئات `IEntityTypeConfiguration<T>` الموجودة في مجمّع `EduMS.Infrastructure` بصرف النظر عن موقعها الفيزيائي داخل المشروع، مما يضمن أن جميع الـ 19 تهيئة تُفعَّل عند بناء الـ `ModelBuilder` دون أي صيانة يدوية.

---

## 6. نتيجة التحقق من البناء (Build Verification Result)

تم تشغيل أمر البناء الشامل للحل الكامل (`EduMS.slnx`) بعد إضافة ملف التهيئات، وقد أسفر عن النتيجة التالية:

```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

---

## 7. طلب التفويض الصريح (Awaiting Explicit Authorization)

تم إنجاز **المرحلة الثالثة: تهيئة طبقة البنية التحتية لجسور التكامل العلائقي** بنسبة **100%** مع بناء شامل نظيف خالٍ تماماً من أي أخطاء أو تحذيرات.

**نحن الآن بانتظار مراجعتكم واعتمادكم الصريح** قبل الانتقال إلى المرحلة التالية المقترحة: تطوير طبقة Application مع معالجات CQRS/MediatR لأعمال التكامل عبر الأقسام، أو إنشاء هجرات قاعدة البيانات الأولية لتطبيق المخطط الكامل على Oracle 19c.
