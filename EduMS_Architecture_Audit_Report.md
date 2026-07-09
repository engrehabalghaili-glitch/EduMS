# EduMS — Phase 1: Global Architecture & ERD Audit Report

**Reviewer:** Senior Software Architect / Database review
**Scope reviewed:** Physical data model (Oracle 19c DDL), Mermaid ERD for all 8 modules, per-section table-analysis documents, operations (365) documents, and the design-phase roadmap.
**Verified model size:** **203 `CREATE TABLE` statements** across 8 modules (≈ the "~210 tables" figure). **290** `createdByUserId/updatedByUserId` columns all pointing at `SystemUser`.

> Note on target DB: the physical script header says **"Oracle 19c Database Script"**, but Phase 2 asks for `Microsoft.EntityFrameworkCore`. This matters (provider choice, concurrency token strategy, cascade rules). Flagged in §5. The skeleton itself is provider-agnostic.

---

## 0. Module inventory (verified table counts)

| Module | Name | Tables |
|--------|------|-------:|
| M1 | SchoolAdmin (School & Office) | 47 |
| M2 | Student | 40 |
| M3 | Employee | 22 |
| M4 | Assets | 40 |
| M5 | Finance | **6** |
| M6 | Statistics / Reporting | 15 |
| M7 | Auth (Users / RBAC) | 21 |
| M8 | Emergency & Excellence | 12 |
| | **Total** | **203** |

**Observation:** the distribution is very lopsided. M1 (47) and M4 (40) are huge; **M5 Finance has only 6 tables** for what the operations docs describe as full fee/invoice/installment/payment management. This is almost certainly under-modeled (see §3.4).

---

## 1. Circular dependencies (Circular References)

This is the **most serious structural issue**. The schema is effectively one large strongly-connected graph — clean module boundaries do **not** exist at the data layer today.

### 1.1 The `SystemUser` mega-cycle (critical)
Every module writes audit columns `createdByUserId` / `updatedByUserId` (and M2 adds `deletededByUserId`, `reviewededByUserId`, `verifiededByUserId`) that **FK to `SystemUser` (M7)**. Simultaneously, `SystemUser` itself FKs **out** to M1/M2/M3:

```
SystemUser { schoolId→School(M1), officeId→Office(M1),
             employeeId→Employee(M3), studentId→Student(M2), guardianId→Guardian(M2) }
```

So we have hard 2-cycles:
- `Student (M2) ⇄ SystemUser (M7)`  (Student.createdByUserId→SystemUser ; SystemUser.studentId→Student)
- `Employee (M3) ⇄ SystemUser (M7)`
- `School (M1) ⇄ SystemUser (M7)`
- Plus `SystemUser.createdByUserId → SystemUser` (self-reference → **bootstrap problem**: the very first user has no creator).

**Consequence for Clean Architecture:** because *all 203 tables* depend on M7 and M7 depends back on M1/M2/M3, you **cannot** split these into independently-referencing assemblies or microservices. If you also model these 290 audit columns as EF navigation properties, `SystemUser` ends up with ~290 inverse collections — unusable.

### 1.2 Other concrete cross-module cycles
- **M1 ⇄ M3:** `SchoolDepartment.managerId→Employee`, `LeadershipNomination.candidateEmployeeId→Employee` … while `Employee.departmentId→SchoolDepartment`, `Employee.schoolId→School`, `Employee.officeId→Office`.
- **M1 ⇄ M2:** `ParentMeeting.studentId→Student`, `AcademicException.studentId→Student` … while M2 references M1 heavily (`schoolId, academicYearId, semesterId, gradeCapacityId, classSectionId, shiftId`).
- **M4 ⇄ M6:** `FinancialSummaryReports` is **declared in M6** but appears in M4's relationship block (`AssetCategory ||--o{ FinancialSummaryReports`) and FKs back with `assetCategoryId→AssetCategory(M4)`.
- **M2 → M3** (teaching): `CoursePlan.teacherId`, `ClassSection.homeroomTeacherId`, `CourseRegistration.teacherId`, `Activity.supervisorId`, `GuidanceSession.counselorId`, `TimetableSlot.teacherId` all point to `Employee`.
- **M3 ⇄ M4:** `EmployeeInventoryCustody.assetId→Asset`, `SelfServicePortalRequests.assetId→Asset`.

### 1.3 Intra-module reference cycles
- `EmployeeAttendance.payrollId → EmployeePayroll` **and** `EmployeePayroll …→ EmployeeAttendance` ("salary based on attendance") — a 2-cycle.
- `PlanAmendment.linkedToRequestId → AmendmentRequest` while both also FK `approvedPlanId`.
- `EmployeeTermination ⇄ ExternalTransfer` (`ExternalTransfer.terminationId→EmployeeTermination`).
- Many self-referencing hierarchies: `Office.parentOfficeId`, `SchoolDepartment.parentDeptId`, `AssetCategory.parentCategoryId`, `AssetLocation.parentLocationId`, `Role.parentRoleId`, `ReferenceCoding.parentCodeId`, `GuidanceSession.parentSessionId`, `StudentComplaint.linkedComplaintId`. These need application-level **cycle prevention** + careful delete rules.

### Recommendations (R1)
1. **Treat audit-user columns as scalar values, not relationships.** Keep `CreatedByUserId`/`ModifiedByUserId` as plain `long` columns (optionally a single non-navigable FK with `DeleteBehavior.Restrict`). Do **not** generate `SystemUser` navigation collections for them. This single decision removes ~290 of the graph edges and makes the model tractable.
2. **Adopt a "Shared Kernel / Identity" core.** `UserId` becomes a cross-cutting value referenced by ID only. Put `SystemUser` identity in a foundational layer everything is allowed to reference one-way.
3. **Break true business cycles with one canonical direction.** e.g. don't have both `Attendance.payrollId` and `Payroll→Attendance` as FKs — pick the parent (Payroll aggregates Attendance) and drop the reverse FK. Same for Termination/ExternalTransfer and PlanAmendment/AmendmentRequest.
4. **Seed/bootstrap user:** make `SystemUser.createdByUserId` nullable and seed a `SYSTEM` user (Id = 0/1) so the first record is valid.

---

## 2. Missing core enterprise / audit fields (critical)

I grep'd the entire physical model. **There are zero temporal/lifecycle audit columns anywhere:**

- ❌ No `CreatedAt` / `CreatedDate` (only *who*, never *when*).
- ❌ No `ModifiedAt` / `UpdatedDate`.
- ❌ No `IsDeleted` / soft-delete flag — **no soft delete exists on any table**, yet the M2 model already has `deletededByUserId`, implying deletes are tracked by *who* but not by a recoverable flag. Inconsistent and risky.
- ❌ No `RowVersion` / optimistic-concurrency token (important for a 365-operation multi-user system → lost-update risk).
- ❌ No `IsActive` / status standardization.
- ❌ No `TenantId` / `SchoolId` standardization as a tenancy boundary (most tables have `schoolId`, some don't — see §3.1).

**Audit standard is also inconsistent across modules:**
- M1 / M3 / M4 / M5 / M6 / M8: only `createdByUserId`, `updatedByUserId`.
- M2 (Student): `createdByUserId, updatedByUserId, deletededByUserId, reviewededByUserId, verifiededByUserId` (5 columns).
- `SchoolAuditLog`, `HistoricalRecords` carry only a bare `userId`.

**Spelling defects baked into the physical model** (will become column names / C# properties if scaffolded as-is):
`deletededByUserId`, `reviewededByUserId`, `verifiededByUserId` (M2, repeated across ~15 tables), and `lockedByUserId`/`savedByUserId` styling in M6.

### Recommendations (R2)
Introduce a mandatory **`BaseAuditableEntity`** that every entity inherits:

```
abstract class BaseAuditableEntity {
    DateTimeOffset CreatedAt;
    long           CreatedByUserId;
    DateTimeOffset? ModifiedAt;
    long?          ModifiedByUserId;
    bool           IsDeleted;          // global EF Core query filter
    DateTimeOffset? DeletedAt;
    long?          DeletedByUserId;
    byte[]         RowVersion;         // concurrency token
}
```
- Enforce population via an EF Core `SaveChangesInterceptor` (single source of truth — never set audit fields by hand in 365 handlers).
- Apply a **global soft-delete query filter** so `IsDeleted = 1` rows disappear automatically.
- Fix the `deleteded/revieweded/verifieded` misspellings now, before any code is generated.
- For the few tables that genuinely should be hard, append-only logs (e.g. `UserActivityLog`, `AuditLog`), inherit a lighter `BaseEntity` (CreatedAt + CreatedByUserId only).

---

## 3. Logical bottlenecks & scalability issues

### 3.1 `SystemUser` as a god/hub table + polymorphic identity
`SystemUser` merges Student + Employee + Guardian + Office + School identities via 5 nullable FKs, and is the FK target of ~290 columns. Risks: write-hot single table, impossible hard-deletes, and every cross-module report must traverse it. **Mitigation:** keep identity thin; reference by `UserId` scalar (R1); index `SystemUser(employeeId)`, `(studentId)`, `(guardianId)` for reverse lookups; consider a separate `Person` vs `Login` split if a person can have multiple roles.

### 3.2 Unbounded high-write tables with no partitioning/retention strategy
`AttendanceDetail` (per student × per timetable slot × per day), `Attendance`, `Grade`, `ExamResult`, `UserActivityLog`, `AuditLog`, `AssetUsageLog`, `DepreciationTransactions`, `Notifications`, `AssetMovementHistory`. At enterprise scale these dominate the DB. **Mitigation:** Oracle range/interval **partitioning by academicYear/semester or month**; explicit retention/archival policy (some `*Archive` tables exist but no policy is defined); composite indexes aligned to the dominant access path (`studentId, academicYearId, semesterId`).

### 3.3 Polymorphic / "soft" references that the DB cannot enforce
- `HistoricalRecords(referenceId, referenceType VARCHAR)` — type-tagged pointer, **no FK**.
- `FacilityDepartmentAssignment(facilityId, facilityType VARCHAR)` — same pattern.
- `EmergencyIncidents.emergencyPlanId` — **no `EmergencyPlan` entity exists** → dangling reference.
These break referential integrity and make joins/reporting slow and error-prone. **Mitigation:** replace with explicit per-type FK tables, or a strict CHECK-constrained discriminator with covering indexes; add the missing `EmergencyPlan` table.

### 3.4 M5 Finance is under-modeled (6 tables)
Only `StudentAccount, StudentInvoice, InvoiceItem, Payment, FeeType, Installment`. No general ledger / chart of accounts, no refunds/credit notes, no payment-gateway/transaction reconciliation, no vendor/AP side, no link to `EmployeePayroll` (M3) or `PurchaseOrders`/`AssetExpenses` (M4). For a system with a dedicated "financial management" operations section this is a gap and a future bottleneck. **Mitigation:** decide scope now — either expand M5 (recommended) or formally document that payroll/asset finance live in their own modules and add the cross-module reconciliation views.

### 3.5 Reporting/statistics coupling (M6) and report-table sprawl
M6 (`KPI_Metrics`, `FinancialSummaryReports`, `GapAnalysisReports`, `ComparativeReport`, …) computes across **all** modules via live joins, and M1 separately holds many report tables (`QuarterlyReport`, `WeeklyProcessReport`, `MonthlyDisciplineReport`, `SemesterEndReport`, `AnnualComprehensiveReport`, `EducationalOutcomesReport`). Overlap between "M1 reports" and "M6 statistics" is unclear. **Mitigation:** consolidate reporting into M6 as the single reporting bounded context; serve it from **materialized views / a read-model (reporting schema)** rather than live OLTP joins; consider read replica for analytics.

### 3.6 Foreign keys are not actually declared yet
The physical script only **explicitly declares FKs to `SystemUser` for ~6 tables** and then notes *"the remaining 300+ implicit FKs … will be scaffolded directly."* Today integrity is largely unenforced. **Mitigation:** generate the full FK set with deliberate `ON DELETE` rules **before** data loads; default to `NO ACTION/RESTRICT` + soft delete (do not rely on cascade given the cycle graph in §1).

### 3.7 Missing uniqueness constraints on junctions
Junction/assignment tables (`UserRole`, `RolePermission`, `UserPermission`, `StudentGuardian`, `CommitteeMembers`, `CourseRegistration`) need composite **UNIQUE** constraints (e.g. `UserRole(userId, roleId, schoolId)`), otherwise duplicates and ambiguous permission resolution will appear. Only **1 UNIQUE** constraint exists in the entire script (`DashboardConfiguration.kpiCode`).

---

## 4. Naming / convention defects (fix before code-gen)

- **Singular vs plural table names** are mixed: `Student`, `Asset`, `Payment` (singular) vs `EmployeeDocuments`, `EmployeeViolations`, `MaintenanceTickets`, `PurchaseOrders`, `Notifications` (plural). Pick one (recommend **singular** for entities).
- **PascalCase vs camelCase FK columns**: `GuardianId` vs `guardianId`, `RouteId` vs `routeId`.
- **Entity-name casing**: `gradeType` (declared lowercase) vs `GradeType` (used in relationship).
- **Underscore outlier**: `KPI_Metrics` (everything else is camel/Pascal, no underscore).
- **Misspellings** (repeat of §2): `deletededByUserId`, `reviewededByUserId`, `verifiededByUserId`.
- **Module-numbering conflict between documents** (will confuse the team): the *table-analysis* docs number §6=Data/Statistics, §7=Permissions, §8=Emergency, whereas the *operations-365* docs number §6=Permissions, §7=Emergency, §8=Reports. The ERD uses M6=Statistics, M7=Auth, M8=Emergency. **Adopt one canonical module map** (recommend the ERD's M1–M8).

---

## 5. Target-platform note (Oracle vs EF Core)

The DDL targets **Oracle 19c**, but Phase 2 installs `Microsoft.EntityFrameworkCore`. Decide explicitly:
- If staying on Oracle → add `Oracle.EntityFrameworkCore` provider; concurrency token via `ORA_ROWSCN` (pseudo-column) rather than a SQL-Server `rowversion`.
- If moving to SQL Server / PostgreSQL → cascade-path limits (SQL Server) reinforce the "RESTRICT + soft delete" recommendation in §1/§3.6.
- The Clean Architecture skeleton built in Phase 2 is **provider-agnostic**; the concrete provider package is added in `EduMS.Infrastructure` once you confirm the database engine.

---

## 6. Prioritized recommendations summary

| # | Priority | Recommendation |
|---|----------|----------------|
| R1 | 🔴 Critical | Model audit-user columns as **scalar IDs (no navigations)**; introduce a Shared-Kernel `UserId`; break true business cycles to one direction; seed a bootstrap SYSTEM user. |
| R2 | 🔴 Critical | Add a standard **`BaseAuditableEntity`** (`CreatedAt/By, ModifiedAt/By, IsDeleted, DeletedAt/By, RowVersion`) via an EF interceptor + global soft-delete filter; fix misspelled columns. |
| R3 | 🟠 High | Define the full **FK set with deliberate `ON DELETE` (RESTRICT)** rules + composite **UNIQUE** constraints on junction tables. |
| R4 | 🟠 High | Replace **polymorphic VARCHAR-typed references** with real FKs; add the missing `EmergencyPlan` entity. |
| R5 | 🟠 High | **Partitioning + retention** strategy for high-volume tables; serve M6 reporting from materialized views / read model. |
| R6 | 🟡 Medium | Decide **M5 Finance scope** (expand, or document cross-module ownership of payroll/asset finance). |
| R7 | 🟡 Medium | Enforce **naming conventions** (singular entities, camelCase FKs, no underscores) and a single canonical module map. |
| R8 | 🟢 Confirm | Confirm **DB engine** (Oracle vs EF Core default) before Infrastructure provider is chosen. |

---

*This report covers the data/architecture audit only. No business code, entities, or tables were generated. Phase 2 builds the verified, empty Clean Architecture skeleton per the constraints provided.*
