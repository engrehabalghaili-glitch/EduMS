# تقرير الإنجاز — نظام إدارة المدارس

## School Management System — Angular 21 + PrimeNG 21 + Tailwind CSS 4

---

## 1. بنية المشروع (Project Architecture)

```
src/app/
├── app.config.ts              # Application config (HttpClient, PrimeNG, router)
├── app.routes.ts               # Root routing (auth, dashboard, 403)
├── app.ts                      # Bootstrap component (standalone, OnPush)
│
├── core/                       # Core layer
│   └── auth/
│       ├── auth.types.ts       # UserRole enum, User interface
│       ├── auth.service.ts      # HTTP login POST
│       ├── auth.store.ts        # Signals store (user, loading, isAuthenticated)
│       ├── guards/
│       │   └── auth.guard.ts   # CanActivateFn (RBAC via route.data.expectedRoles)
│       └── index.ts            # Barrel
│
├── modules/
│   └── auth/                   # Auth module (lazy)
│       ├── layouts/
│       │   └── auth-layout/    # RTL card shell
│       ├── pages/
│       │   ├── login/          # Login (presentational + feature page)
│       │   ├── forgot-password/
│       │   └── reset-password/
│       └── auth.routes.ts
│
├── shared/
│   ├── components/
│   │   ├── data-table/         # Generic DataTable<T> (Signals, OnPush)
│   │   ├── dashboard-placeholder/
│   │   └── unauthorized/       # 403 page
│   └── layouts/
│       └── main-layout/        # RTL shell + Sidebar + Header
│
└── modules/
    └── m1-school-office/
        └── data-access/
            ├── models/         # 41 TypeScript interfaces + DTOs
            └── services/       # 40 Angular services + barrel

environments/
├── environment.ts              # Production (replaced by CLI)
├── environment.development.ts  # Development (baseUrl: localhost:3000)
└── index.ts                    # Barrel

server/
├── db.json                     # 42 collections, 462 records, 219KB
└── generate-mock-data.js       # Seeder script (deterministic, no Faker)
```

---

## 2. التقنيات المستخدمة (Tech Stack)

| التقنية | الإصدار | الاستخدام |
|---|---|---|
| Angular | 21 | Framework (standalone components, zoneless) |
| PrimeNG | 21 | UI components (p-card, p-inputText, p-button, p-password) |
| Tailwind CSS | 4 | جميع التنسيقات (بدون custom CSS) |
| json-server | 0.17 | REST mock API |
| Vitest | - | Testing framework |
| RxJS | - | HTTP calls, finalize operator |
| Signals | - | كل حالة التطبيق (لا يوجد NgRx/Zustand) |

---

## 3. المصادقة والصلاحيات (Auth & RBAC)

### 8 أدوار مستخدم (User Roles)

| الاسم | الكود |
|---|---|
| مدير النظام | `SYSTEM_ADMIN` |
| مشرف مكتب إداري | `OFFICE_SUPERVISOR` |
| مدير مكتب إداري | `OFFICE_MANAGER` |
| مشرف مدرسة | `SCHOOL_SUPERVISOR` |
| مدير مدرسة | `SCHOOL_PRINCIPAL` |
| وكيل مدرسة | `SCHOOL_VICE_PRINCIPAL` |
| مرشد طلابي | `STUDENT_ADVISOR` |
| معلم | `TEACHER` |

### AuthStore (مثال الكود)

```typescript
@Injectable({ providedIn: 'root' })
export class AuthStore {
  private readonly _user = signal<User | null>(null);
  private readonly _loading = signal(false);

  readonly user = this._user.asReadonly();
  readonly loading = this._loading.asReadonly();
  readonly isAuthenticated = computed(() => this._user() !== null);

  login(credentials: LoginCredentials): void {
    // Dev bypass: supervisor@school.edu / Password123!
    if (credentials.email === 'supervisor@school.edu' && credentials.password === 'Password123!') {
      const devUser: User = {
        id: 1, name: 'زيبدة علي', email: 'supervisor@school.edu',
        role: UserRole.OFFICE_SUPERVISOR, token: 'mock-dev-jwt-token'
      };
      this._user.set(devUser);
      localStorage.setItem('user', JSON.stringify(devUser));
      this.router.navigate(['/dashboard']);
      return;
    }

    this._loading.set(true);
    this.authService.login(credentials).pipe(
      finalize(() => this._loading.set(false))
    ).subscribe({
      next: (user) => {
        this._user.set(user);
        localStorage.setItem('user', JSON.stringify(user));
        this.router.navigate(['/dashboard']);
      }
    });
  }

  logout(): void { this._user.set(null); localStorage.removeItem('user'); }
  checkAuth(): void { /* restore from localStorage */ }
}
```

### AuthGuard (RBAC)

```typescript
export const authGuard: CanActivateFn = (route) => {
  const store = inject(AuthStore);
  store.checkAuth();
  if (!store.isAuthenticated()) return inject(Router).createUrlTree(['/login']);
  const expectedRoles = route.data['expectedRoles'] as UserRole[] | undefined;
  if (expectedRoles && !expectedRoles.includes(store.user()!.role))
    return inject(Router).createUrlTree(['/unauthorized']);
  return true;
};
```

---

## 4. صفحة تسجيل الدخول (Login Page)

- DDD: `LoginComponent` (presentational) ← `LoginPageComponent` (feature wrapper)
- RTL: `dir="rtl"` على AuthLayout
- نموذج مسبق التعبئة: supervisor@school.edu / Password123!
- جميع النصوص بالعربية
- PrimeNG: p-card, p-inputText, p-password, p-button

---

## 5. التخطيط الرئيسي (Main Layout)

- `dir="rtl"` على مستوى الـ host
- Sidebar: قائمة تنقل مصفاة حسب الدور (9 عناصر)
- Header: اسم المستخدم + زر تسجيل الخروج
- PrimeNG: p-panelMenu, p-avatar, p-button

---

## 6. خدمات البيانات (Data Services) — النموذج الأساسي

أُنشئت **40 خدمة Angular** في `modules/m1-school-office/data-access/services/` لكل Domain في النظام. كل خدمة تتبع نفس النمط (Pattern):

### مثال: SchoolService

```typescript
import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments';
import type { School, CreateSchoolDto, UpdateSchoolDto } from '../models/school';

@Injectable({ providedIn: 'root' })
export class SchoolService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/schools`;

  getAll(): Observable<School[]> {
    return this.http.get<School[]>(this.baseUrl);
  }

  getById(id: number): Observable<School> {
    return this.http.get<School>(`${this.baseUrl}/${id}`);
  }

  getByDirectorateId(directorateId: number): Observable<School[]> {
    return this.http.get<School[]>(`${this.baseUrl}?directorateId=${directorateId}`);
  }

  create(dto: CreateSchoolDto): Observable<School> {
    return this.http.post<School>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdateSchoolDto): Observable<School> {
    return this.http.put<School>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
```

### نمط الخدمة الموحد (Standard Pattern)

```typescript
@Injectable({ providedIn: 'root' })
export class XxxService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.baseUrl}/xxx`;

  getAll(): Observable<Xxx[]>                        // GET /xxx
  getById(id): Observable<Xxx>                       // GET /xxx/:id
  getByXxxId(xxxId): Observable<Xxx[]>               // GET /xxx?xxxId=...
  // optional query filters                          // GET /xxx?field=value
  create(dto: CreateXxxDto): Observable<Xxx>         // POST /xxx
  update(id, dto: UpdateXxxDto): Observable<Xxx>     // PUT /xxx/:id
  delete(id): Observable<void>                       // DELETE /xxx/:id
}
```

### قائمة الخدمات كاملة (40 Service)

| # | Domain | Service Class | Endpoint |
|---|---|---|---|
| 1 | AcademicBranchConfigLog | `AcademicBranchConfigLogService` | `academicBranchConfigLogs` |
| 2 | AcademicLockPeriod | `AcademicLockPeriodService` | `academicLockPeriods` |
| 3 | AcademicWarningPolicy | `AcademicWarningPolicyService` | `academicWarningPolicies` |
| 4 | ClassSchedule | `ClassScheduleService` | `classSchedules` |
| 5 | Classroom | `ClassroomService` | `classrooms` |
| 6 | ClassroomOperationalRule | `ClassroomOperationalRuleService` | `classroomOperationalRules` |
| 7 | ClassroomResourceAllocation | `ClassroomResourceAllocationService` | `classroomResourceAllocations` |
| 8 | CurriculumTextbookDistribution | `CurriculumTextbookDistributionService` | `curriculumTextbookDistributions` |
| 9 | Department | `DepartmentService` | `departments` |
| 10 | Directorate | `DirectorateService` | `directorates` |
| 11 | DirectorateExamCenterAssignment | `DirectorateExamCenterAssignmentService` | `directorateExamCenterAssignments` |
| 12 | DirectorateLegalCaseLog | `DirectorateLegalCaseLogService` | `directorateLegalCaseLogs` |
| 13 | DirectorateStatisticalReport | `DirectorateStatisticalReportService` | `directorateStatisticalReports` |
| 14 | EducationalStage | `EducationalStageService` | `educationalStages` |
| 15 | EducationalSupervisionVisit | `EducationalSupervisionVisitService` | `educationalSupervisionVisits` |
| 16 | ExamDistributionTimetable | `ExamDistributionTimetableService` | `examDistributionTimetables` |
| 17 | GradeCapacity | `GradeCapacityService` | `gradeCapacities` |
| 18 | GradingScaleBound | `GradingScaleBoundService` | `gradingScaleBounds` |
| 19 | OfficialCircular | `OfficialCircularService` | `officialCirculars` |
| 20 | ReferenceCodingLookup | `ReferenceCodingLookupService` | `referenceCodingLookups` |
| 21 | School | `SchoolService` | `schools` |
| 22 | SchoolAcademicYear | `SchoolAcademicYearService` | `schoolAcademicYears` |
| 23 | SchoolAccreditationLog | `SchoolAccreditationLogService` | `schoolAccreditationLogs` |
| 24 | SchoolAnnouncementLog | `SchoolAnnouncementLogService` | `schoolAnnouncementLogs` |
| 25 | SchoolAuditLog | `SchoolAuditLogService` | `schoolAuditLogs` |
| 26 | SchoolCanteenItem | `SchoolCanteenItemService` | `schoolCanteenItems` |
| 27 | SchoolContactInfo | `SchoolContactInfoService` | `schoolContactInfos` |
| 28 | SchoolCurriculumPlan | `SchoolCurriculumPlanService` | `schoolCurriculumPlans` |
| 29 | SchoolEventCalendar | `SchoolEventCalendarService` | `schoolEventCalendars` |
| 30 | SchoolFacility | `SchoolFacilityService` | `facilities` |
| 31 | SchoolFacilityMaintenanceLog | `SchoolFacilityMaintenanceLogService` | `schoolFacilityMaintenanceLogs` |
| 32 | SchoolLevel | `SchoolLevelService` | `schoolLevels` |
| 33 | SchoolLibraryItem | `SchoolLibraryItemService` | `schoolLibraryItems` |
| 34 | SchoolOperationalBudgetLog | `SchoolOperationalBudgetLogService` | `schoolOperationalBudgetLogs` |
| 35 | SchoolSemester | `SchoolSemesterService` | `schoolSemesters` |
| 36 | SchoolShift | `SchoolShiftService` | `schoolShifts` |
| 37 | SchoolTransportationRoute | `SchoolTransportationRouteService` | `schoolTransportationRoutes` |
| 38 | Subject | `SubjectService` | `subjects` |
| 39 | TrainingCourseOffering | `TrainingCourseOfferingService` | `trainingCourseOfferings` |
| 40 | VisitorEntryLog | `VisitorEntryLogService` | `visitorEntryLogs` |

---

## 7. مكون (DataTable) عام

```typescript
// Generic component with Signals + OnPush
@Component({
  selector: 'app-data-table',
  template: `<p-table [value]="data()" ...>`
})
export class DataTable<T> {
  data = input<T[]>([]);
  columns = input<ColumnDef<T>[]>([]);
  loading = input(false);
  // ...
}
```

---

## 8. النماذج (Models)

41 واجهة TypeScript في `modules/m1-school-office/data-access/models/`:
- كل واجهة رئيسية (مثل `School`, `Classroom`, `Subject`)
- `CreateXxxDto` — Omit للحقول التي ينشئها السيرفر
- `UpdateXxxDto` — Omit للحقول غير القابلة للتحديث
- `common.ts` — أنواع مشتركة (RecordStatus, GenderAllocation, DayOfWeek, ...)

---

## 9. البيانات الوهمية (Mock Data)

- ملف `server/db.json`: 42 keys, 462 records, 219KB
- Script `server/generate-mock-data.js`: منشئ بدون Faker، مع IDs مترابطة
- Endpoint: `http://localhost:3000`

---

## 10. إحصائيات المشروع

| البند | العدد |
|---|---|
| Service files | 40 |
| Model interfaces | 41 |
| Model DTOs | ~80 (Create + Update لكل نموذج) |
| Components | 10 (AuthLayout, Login, LoginPage, ForgotPassword, ForgotPasswordPage, ResetPassword, ResetPasswordPage, DataTable, DashboardPlaceholder, Unauthorized) |
| Layouts | 2 (AuthLayout, MainLayout) |
| Guards | 1 (AuthGuard with RBAC) |
| Stores | 1 (AuthStore with Signals) |
| Routes files | 2 (app.routes.ts, auth.routes.ts) |
| db.json collections | 42 |
| db.json records | 462 |

---

## 11. بنية التوجيه (Routing)

| Path | Component | Guard |
|---|---|---|
| `/` | → redirect to `/auth/login` | - |
| `/auth/login` | `LoginPage` | - |
| `/auth/forgot-password` | `ForgotPasswordPage` | - |
| `/auth/reset-password` | `ResetPasswordPage` | - |
| `/dashboard` | `MainLayout` + `DashboardPlaceholder` | `authGuard` |
| `/unauthorized` | `UnauthorizedComponent` | - |

---

## 12. الأخطاء التي تم إصلاحها أثناء العمل (Bugs Fixed)

1. **مفقود `AnalysisStatus`** في `m6-StatisticsReports/data-access/models/base.types.ts` — أُضيف type
2. **مسارات env خاطئة** في الخدمات القديمة — صُححت من `../../modules/...` إلى مسارات نسبية صحيحة
3. **مكرر `SchoolAcademicYearService`** في barrel index — أُزيل التكرار
4. **مفقود `provideHttpClient()`** في `app.config.ts` — أُضيف

---

*التقرير منشئ بتاريخ: 2026-07-15*
