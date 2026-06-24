import { Routes } from '@angular/router';
import { authGuard } from './core/auth/auth-guard';
import { roleGuard } from './core/auth/role-guard';

export const routes: Routes = [
  // 1. التوجيه الرئيسي للتطبيق: ينقل المستخدم تلقائياً إلى مسار الـ auth والـ login كخطوة أولى
  { path: '', redirectTo: 'auth/login', pathMatch: 'full' },

  // 2. مسار حزمة التحقق والمصادقة الموحد (Auth Layout) والأبناء التابعين له
  {
    path: 'auth',
    loadComponent: () => import('./shared/layouts/auth-layout/auth-layout').then(m => m.AuthLayoutComponent),
    children: [
      {
        path: 'login',
        loadComponent: () => import('./features/auth/components/login/login').then(m => m.LoginComponent)
      },
      {
        path: 'forgot-password',
        loadComponent: () => import('./features/auth/components/forgot-password/forgot-password').then(m => m.ForgotPasswordComponent)
      },
      {
        path: 'reset-password',
        loadComponent: () => import('./features/auth/components/reset-password/reset-password').then(m => m.ResetPasswordComponent)
      }
    ]
  },

  // 3. مسار لوحة العمليات الرئيسية (Main Layout) المحمية بالدروع الأمنية
  {
    path: 'main-layout',
    loadComponent: () => import('./shared/layouts/main-layout/main-layout').then(m => m.MainLayoutComponent),
    canActivate: [authGuard], // الدرع الأساسي: يجب تسجيل الدخول للوصول لأي لوحة تحكم فرعية
    children: [
      // توجيه فرعي داخلي: إذا دخل المستخدم على /main-layout مباشرة يتم تحويله فوراً لـ لوحة تحكم المدير
      { path: '', redirectTo: 'finance/dashboard', pathMatch: 'full' },

      // لوحة تحكم المدير العام والنظام (Admin Dashboard)
      {
        path: 'admin/dashboard',
        loadComponent: () => import('./features/admin/components/admin-dashboard/admin-dashboard').then(m => m.AdminDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin'] }
      },

      // إدارة شؤون الطلاب والقبول والتسجيل
      {
        path: 'student-affairs/dashboard',
        loadComponent: () => import('./features/student-affairs/components/student-affairs-dashboard/student-affairs-dashboard').then(m => m.StudentAffairsDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'admission_officer'] }
      },



      // الإدارة المالية والحسابات المركزية (تم دمج التكرار وتوحيدها هنا)
      {
        path: 'finance/dashboard',
        loadComponent: () => import('./features/finance-portal/components/finance-dashboard/finance-dashboard').then(m => m.FinanceDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'accountant'] }
      },

      // إدارة الأصول والمستودعات والمرافق (تم تصحيح loadChildren وتوحيدها هنا)
      {
        path: 'asset-management/dashboard',
        loadComponent: () => import('./features/assets-management/components/assets-dashboard/assets-dashboard').then(m => m.AssetsDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'assets_manager', 'assets_mgr'] }
      },

      // إدارة الموارد البشرية وشؤون الموظفين
      {
        path: 'hr/dashboard',
        loadComponent: () => import('./features/hr/components/hr-dashboard/hr-dashboard').then(m => m.HrDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'hr_mgr'] }
      },

      // لوحة تحكم المعلم وإدارة الحصص الدراسية
      {
        path: 'teacher/dashboard',
        loadComponent: () => import('./features/teacher-portal/components/teacher-dashboard/teacher-dashboard').then(m => m.TeacherDashboardComponent),
      },

      // لوحة تحكم مدير المدرسة التنفيذي (Principal Portal)
      {
        path: 'principal/dashboard',
        loadComponent: () => import('./features/principal-portal/components/principal-dashboard/principal-dashboard').then(m => m.PrincipalDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'school_principal'] }
      },

      // الإشراف والتوجيه الأكاديمي والتربوي
      {
        path: 'supervision/dashboard',
        loadComponent: () => import('./features/academic-supervision/components/supervisor-dashboard/supervisor-dashboard').then(m => m.SupervisorDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'office_sup'] }
      },

      // الأنشطة المدرسية ورعاية الموهوبين
      {
        path: 'activities/dashboard',
        loadComponent: () => import('./features/activities/components/activities-dashboard/activities-dashboard').then(m => m.ActivitiesDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'activities_sup'] }
      },

      // بوابة أولياء الأمور
      {
        path: 'parent/dashboard',
        loadComponent: () => import('./features/parent-portal/components/parent-dashboard/parent-dashboard').then(m => m.ParentDashboardComponent),
        canActivate: [roleGuard],
        data: { roles: ['admin', 'parent'] }
      },

    ]
  },

  // 3ب. بوابة الطالب الذكية (Lazy-loaded Student Portal)
  {
    path: 'student',
    loadComponent: () => import('./features/student-portal/student-layout/student-layout').then(m => m.StudentLayoutComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['admin', 'student'] },
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadComponent: () => import('./features/student-management/components/dashboard/dashboard.component').then(m => m.DashboardComponent)
      },
      {
        path: 'registration',
        loadComponent: () => import('./features/students/registration/student-registration-wizard.component').then(m => m.StudentRegistrationWizardComponent)
      },
      {
        path: 'registration-manager',
        loadComponent: () => import('./features/students/registration/registration-manager.component').then(m => m.RegistrationManagerComponent)
      },
      {
        path: 'applications',
        loadComponent: () => import('./features/student-management/components/applications-list/applications-list.component').then(m => m.ApplicationsListComponent)
      },
      {
        path: 'applications/details/:id',
        loadComponent: () => import('./features/student-management/components/application-details/application-details.component').then(m => m.ApplicationDetailsComponent)
      },
      {
        path: 'installments',
        loadComponent: () => import('./features/student-management/components/financial-installments/financial-installments.component').then(m => m.FinancialInstallmentsComponent)
      },
      {
        path: 'tasks',
        loadComponent: () => import('./features/student-management/components/task-board/task-board.component').then(m => m.TaskBoardComponent)
      }
    ]
  },

  // 3ت. بوابة التسجيل الإلكترونية (عامة - بدون درع أمني)
  {
    path: 'registration',
    loadComponent: () => import('./features/registration-portal/registration-portal.component').then(m => m.RegistrationPortalComponent)
  },

  // 4. الحماية النهائية: أي رابط غير معروف يعيد توجيه المستخدم تلقائياً لصفحة الدخول الآمنة
  { path: '**', redirectTo: 'auth/login' }
];
