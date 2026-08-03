/* =========================================================================
   EduMS Enterprise — Mock Data
   Realistic data for SPA simulation
   ========================================================================= */

window.EduMSData = {
  // Current logged-in user (changes when role is switched)
  currentUser: {
    id: 1,
    name: 'أحمد محمد عبدالله',
    role: 'principal',
    roleArabic: 'مدير المدرسة',
    avatar: 'أ.م',
    school: 'متوسطة الملك فهد',
    permissions: ['*']  // wildcard = all
  },

  // Available roles (for the role switcher)
  roles: [
    { id: 'principal',  name: 'مدير المدرسة',         avatar: 'م.م', color: '#1E3A8A' },
    { id: 'teacher',    name: 'معلم',                 avatar: 'م.ع', color: '#059669' },
    { id: 'guardian',   name: 'ولي أمر',              avatar: 'و.أ', color: '#D4AF37' },
    { id: 'student',    name: 'طالب',                 avatar: 'ط.ب', color: '#7C3AED' },
    { id: 'registrar',  name: 'موظف شؤون الطلاب',     avatar: 'ش.ط', color: '#0891B2' },
    { id: 'accountant', name: 'محاسب',                avatar: 'م.ح', color: '#DC2626' },
    { id: 'assets_mgr', name: 'إدارة الأصول',          avatar: 'إ.أ', color: '#EA580C' },
    { id: 'office_sup', name: 'مشرف المكتب',           avatar: 'م.ك', color: '#7C3AED' },
    { id: 'hr_mgr',     name: 'مدير الموارد البشرية', avatar: 'هـ.ر', color: '#BE185D' },
    { id: 'sysadmin',   name: 'مدير النظام',           avatar: 'م.ن', color: '#475569' }
  ],

  // KPIs / Stats per role - Dashboard widgets data
  dashboardStats: {
    principal: [
      { label: 'إجمالي الطلاب',     value: '1,247', change: '+12 هذا الشهر',  trend: 'up',   icon: '🎓', variant: 'primary' },
      { label: 'إجمالي الموظفين',   value: '87',    change: '+3 معلمين جدد', trend: 'up',   icon: '👥', variant: 'gold' },
      { label: 'نسبة الحضور اليوم', value: '94.2%', change: '+1.4% مقارنة بأمس', trend: 'up', icon: '✅', variant: 'success' },
      { label: 'إجمالي الأصول',     value: '342',   change: 'تحت الصيانة: 8',  trend: 'down', icon: '📦', variant: 'warning' },
      { label: 'الإيرادات الشهرية', value: '4.2M ر', change: '+8.5%',           trend: 'up',   icon: '💰', variant: 'success' },
      { label: 'البلاغات المعلقة',  value: '12',    change: '4 عاجلة',         trend: 'down', icon: '🚨', variant: 'danger' }
    ],
    teacher: [
      { label: 'شعبي اليوم',         value: '5',     change: 'الحصة القادمة 10:30', trend: 'up',   icon: '🏫', variant: 'primary' },
      { label: 'طلابي الإجمالي',     value: '178',   change: 'موزعين على 5 شعب',    trend: 'up',   icon: '🎓', variant: 'gold' },
      { label: 'درجات بانتظار الرصد', value: '47',    change: '3 شعب',             trend: 'down', icon: '📊', variant: 'warning' },
      { label: 'الغياب اليوم',       value: '7',     change: 'في شعبتي',          trend: 'down', icon: '❌', variant: 'danger' }
    ],
    guardian: [
      { label: 'أبنائي في المدرسة',  value: '3',    change: 'نشطين',               trend: 'up',   icon: '👨‍👩‍👧', variant: 'primary' },
      { label: 'متوسط الأداء',       value: '88.5%', change: '+2.1%',               trend: 'up',   icon: '⭐', variant: 'gold' },
      { label: 'الحضور هذا الشهر',   value: '96%',   change: 'ممتاز',               trend: 'up',   icon: '📅', variant: 'success' },
      { label: 'الرسوم المستحقة',   value: '1,250 ر', change: 'موعد الاستحقاق 28', trend: 'down', icon: '💳', variant: 'danger' }
    ],
    student: [
      { label: 'معدلي الفصلي',       value: '92.3', change: 'تقدير: ممتاز',        trend: 'up',   icon: '🏆', variant: 'gold' },
      { label: 'ترتيبي بالشعبة',     value: '3',    change: 'من أصل 28',           trend: 'up',   icon: '🥉', variant: 'primary' },
      { label: 'الحضور هذا الفصل',  value: '98%',   change: '46 يوم حضور',         trend: 'up',   icon: '📅', variant: 'success' },
      { label: 'الواجبات المعلقة',  value: '2',    change: 'مادة الرياضيات',      trend: 'down', icon: '📝', variant: 'warning' }
    ],
    registrar: [
      { label: 'طلبات تسجيل جديدة', value: '23',   change: 'بانتظار المراجعة',    trend: 'up',   icon: '📋', variant: 'primary' },
      { label: 'الطلاب الجدد',       value: '47',   change: 'هذا الفصل',           trend: 'up',   icon: '🎓', variant: 'gold' },
      { label: 'طلبات النقل',        value: '8',    change: '3 قيد المعالجة',     trend: 'down', icon: '🔄', variant: 'warning' },
      { label: 'وثائق ناقصة',        value: '15',   change: 'طلب وثائق',           trend: 'down', icon: '⚠️', variant: 'danger' }
    ],
    accountant: [
      { label: 'إجمالي الإيرادات',  value: '4.2M ر', change: '+8.5% الشهر',         trend: 'up',   icon: '💰', variant: 'success' },
      { label: 'المستحقات',         value: '847K ر', change: 'متأخر السداد',        trend: 'down', icon: '⏰', variant: 'danger' },
      { label: 'فواتير اليوم',       value: '42',    change: '38 مدفوعة',          trend: 'up',   icon: '🧾', variant: 'primary' },
      { label: 'الرواتب الشهرية',   value: '1.8M ر', change: 'دُفعت في 1/الشهر',   trend: 'up',   icon: '💳', variant: 'gold' }
    ],
    assets_mgr: [
      { label: 'إجمالي الأصول',     value: '342',   change: '+15 هذا الشهر',       trend: 'up',   icon: '📦', variant: 'primary' },
      { label: 'تحت الصيانة',       value: '8',     change: '3 عاجلة',             trend: 'down', icon: '🛠️', variant: 'warning' },
      { label: 'بلاغات جديدة',       value: '14',    change: 'بانتظار الاستجابة',   trend: 'down', icon: '🚨', variant: 'danger' },
      { label: 'القيمة الإجمالية',   value: '3.4M ر', change: 'دفترية',               trend: 'up',   icon: '💵', variant: 'gold' }
    ],
    office_sup: [
      { label: 'المدارس التابعة',   value: '47',   change: 'مدرسة نشطة',           trend: 'up',   icon: '🏫', variant: 'primary' },
      { label: 'تقارير معلقة',       value: '23',   change: 'بانتظار المراجعة',     trend: 'down', icon: '📊', variant: 'warning' },
      { label: 'تعاميم نشطة',       value: '12',    change: '5 ينتهي قريباً',        trend: 'down', icon: '📣', variant: 'danger' },
      { label: 'إحصائيات مرفوعة',   value: '847',   change: 'هذا الفصل',           trend: 'up',   icon: '📈', variant: 'gold' }
    ],
    hr_mgr: [
      { label: 'إجمالي الموظفين',   value: '187',   change: '+5 هذا الشهر',         trend: 'up',   icon: '👥', variant: 'primary' },
      { label: 'الوظائف الشاغرة',   value: '12',    change: 'مفتوحة للتقديم',       trend: 'up',   icon: '💼', variant: 'gold' },
      { label: 'طلبات إجازة',       value: '7',     change: 'بانتظار الاعتماد',    trend: 'down', icon: '🏖️', variant: 'warning' },
      { label: 'تقييمات الأداء',    value: '34/87', change: 'هذا الربع',           trend: 'up',   icon: '⭐', variant: 'success' }
    ],
    sysadmin: [
      { label: 'المستخدمون النشطون', value: '1,247', change: 'متصل الآن: 87',       trend: 'up',   icon: '👤', variant: 'primary' },
      { label: 'الأدوار المعرّفة',  value: '24',    change: 'صلاحيات: 213',        trend: 'up',   icon: '🔐', variant: 'gold' },
      { label: 'سجل التدقيق',        value: '4,892', change: 'هذا الأسبوع',         trend: 'up',   icon: '📋', variant: 'success' },
      { label: 'تنبيهات أمنية',     value: '3',     change: 'محاولات مشبوهة',      trend: 'down', icon: '⚠️', variant: 'danger' }
    ]
  },

  // Sample Students
  students: [
    { id: 1001, code: 'STU-001', name: 'محمد عبدالله السيد', grade: '3 متوسط', section: 'أ', gender: 'ذكر', gpa: 92.5, status: 'نشط', attendance: '98%', guardianName: 'عبدالله السيد' },
    { id: 1002, code: 'STU-002', name: 'فاطمة أحمد المالكي', grade: '3 متوسط', section: 'ب', gender: 'أنثى', gpa: 95.1, status: 'نشط', attendance: '100%', guardianName: 'أحمد المالكي' },
    { id: 1003, code: 'STU-003', name: 'يوسف محمد القرني',  grade: '2 متوسط', section: 'أ', gender: 'ذكر', gpa: 78.2, status: 'نشط', attendance: '87%', guardianName: 'محمد القرني' },
    { id: 1004, code: 'STU-004', name: 'سارة خالد الزهراني', grade: '1 متوسط', section: 'ج', gender: 'أنثى', gpa: 88.7, status: 'نشط', attendance: '94%', guardianName: 'خالد الزهراني' },
    { id: 1005, code: 'STU-005', name: 'عبدالرحمن سعيد العتيبي', grade: '3 متوسط', section: 'أ', gender: 'ذكر', gpa: 65.3, status: 'متعثر', attendance: '72%', guardianName: 'سعيد العتيبي' },
    { id: 1006, code: 'STU-006', name: 'نورة فهد الشمري',   grade: '2 متوسط', section: 'ب', gender: 'أنثى', gpa: 91.4, status: 'نشط', attendance: '96%', guardianName: 'فهد الشمري' },
    { id: 1007, code: 'STU-007', name: 'علي حسن الدوسري',  grade: '1 متوسط', section: 'أ', gender: 'ذكر', gpa: 82.8, status: 'نشط', attendance: '91%', guardianName: 'حسن الدوسري' },
    { id: 1008, code: 'STU-008', name: 'هند سلطان الرشيد', grade: '3 متوسط', section: 'ب', gender: 'أنثى', gpa: 89.6, status: 'نشط', attendance: '93%', guardianName: 'سلطان الرشيد' }
  ],

  // Sample Employees
  employees: [
    { id: 2001, code: 'EMP-001', name: 'د. خالد محمد الفيصل',    job: 'معلم رياضيات', dept: 'القسم العلمي', status: 'نشط', joined: '2020-09-01', salary: 8500 },
    { id: 2002, code: 'EMP-002', name: 'أ. نورا أحمد العمري',     job: 'معلمة لغة عربية', dept: 'القسم الأدبي', status: 'نشط', joined: '2018-09-15', salary: 7800 },
    { id: 2003, code: 'EMP-003', name: 'أ. عبدالله سعد القحطاني', job: 'معلم فيزياء', dept: 'القسم العلمي', status: 'في إجازة', joined: '2019-02-01', salary: 8200 },
    { id: 2004, code: 'EMP-004', name: 'أ. منى ياسر الحربي',      job: 'مرشدة طلابية', dept: 'الإرشاد', status: 'نشط', joined: '2021-09-01', salary: 7200 },
    { id: 2005, code: 'EMP-005', name: 'أ. ماجد فيصل الغامدي',    job: 'وكيل المدرسة', dept: 'الإدارة', status: 'نشط', joined: '2015-09-01', salary: 11000 }
  ],

  // Sample Assets
  assets: [
    { id: 3001, code: 'AST-2026-00001', name: 'حاسب آلي محمول Dell', category: 'إلكترونيات', location: 'معمل الحاسب 1', status: 'يعمل', value: 4500, condition: 'ممتاز' },
    { id: 3002, code: 'AST-2026-00002', name: 'سبورة ذكية Smart Board', category: 'تعليمي', location: 'فصل 3-أ', status: 'يعمل', value: 12000, condition: 'جيد' },
    { id: 3003, code: 'AST-2026-00003', name: 'بروجكتر EPSON', category: 'تعليمي', location: 'فصل 2-ب', status: 'صيانة', value: 3200, condition: 'يحتاج إصلاح' },
    { id: 3004, code: 'AST-2026-00004', name: 'طابعة HP LaserJet', category: 'إلكترونيات', location: 'إدارة المدرسة', status: 'يعمل', value: 1800, condition: 'جيد جداً' }
  ],

  // Recent Activities (Timeline)
  recentActivities: [
    { id: 1, icon: '🎓', color: 'success',  title: 'تسجيل طالب جديد', desc: 'محمد عبدالله السيد - الصف 3 متوسط', user: 'مسجلة الطلاب', time: 'منذ 5 دقائق' },
    { id: 2, icon: '💰', color: 'gold',     title: 'دفع رسوم', desc: 'فاطمة أحمد المالكي - مبلغ 2,500 ر', user: 'بوابة الدفع', time: 'منذ 15 دقيقة' },
    { id: 3, icon: '📋', color: 'primary',  title: 'رفع تقرير الحضور اليومي', desc: '94.2% نسبة الحضور - 14 غائب', user: 'النظام التلقائي', time: 'منذ 30 دقيقة' },
    { id: 4, icon: '⚠️', color: 'warning', title: 'إنذار غياب', desc: 'عبدالرحمن سعيد العتيبي - تجاوز 10%', user: 'النظام التلقائي', time: 'منذ ساعة' },
    { id: 5, icon: '📣', color: 'info',    title: 'تعميم جديد من المكتب', desc: 'موعد الاختبارات النهائية', user: 'مكتب التربية', time: 'منذ ساعتين' },
    { id: 6, icon: '🛠️', color: 'danger',  title: 'بلاغ صيانة عاجل', desc: 'بروجكتر فصل 2-ب', user: 'أ. خالد الفيصل', time: 'منذ 3 ساعات' }
  ],

  // Announcements (تعاميم)
  announcements: [
    { id: 1, type: 'urgent', title: 'تعميم رقم 247/2026: موعد الاختبارات النهائية', source: 'مكتب التربية والتعليم', date: '2026-05-15', deadline: '2026-05-20', priority: 'عاجل', isRead: false },
    { id: 2, type: 'official', title: 'تعميم رقم 245/2026: تحديث نظام الحضور الإلكتروني', source: 'إدارة المدرسة', date: '2026-05-13', deadline: '2026-05-30', priority: 'عام', isRead: false },
    { id: 3, type: 'info', title: 'تعميم رقم 240/2026: جدول الإجازات الرسمية', source: 'مكتب التربية والتعليم', date: '2026-05-10', deadline: null, priority: 'معلوماتي', isRead: true }
  ],

  // Notifications
  notifications: [
    { id: 1, type: 'info',     title: 'تعميم جديد', message: 'موعد الاختبارات النهائية', time: 'منذ 5 دقائق', read: false },
    { id: 2, type: 'success',  title: 'تم اعتماد طلبك', message: 'طلب الإجازة رقم #4521 تم اعتماده', time: 'منذ ساعة', read: false },
    { id: 3, type: 'warning',  title: 'مستحق قريباً', message: 'فاتورة الرسوم تنتهي في 28/الشهر', time: 'منذ 3 ساعات', read: false },
    { id: 4, type: 'danger',   title: 'بلاغ صيانة عاجل', message: 'تعطل بروجكتر فصل 2-ب', time: 'منذ يوم', read: true }
  ],

  // Calendar events
  calendarEvents: [
    { date: '2026-05-20', title: 'اجتماع مجلس الأمناء', type: 'meeting' },
    { date: '2026-05-22', title: 'يوم الأنشطة الرياضية', type: 'activity' },
    { date: '2026-05-25', title: 'بداية الاختبارات', type: 'exam' },
    { date: '2026-05-28', title: 'موعد سداد الرسوم', type: 'finance' }
  ],

  // Chart data
  charts: {
    attendanceTrend: {
      labels: ['السبت', 'الأحد', 'الإثنين', 'الثلاثاء', 'الأربعاء', 'الخميس'],
      data: [94.2, 93.5, 95.1, 92.8, 94.7, 95.4]
    },
    studentsBySection: {
      labels: ['1 متوسط', '2 متوسط', '3 متوسط', '1 ثانوي', '2 ثانوي', '3 ثانوي'],
      data: [185, 210, 198, 225, 219, 210]
    },
    gradesDistribution: {
      labels: ['ممتاز (90-100)', 'جيد جداً (80-89)', 'جيد (70-79)', 'مقبول (60-69)', 'راسب (<60)'],
      data: [342, 487, 268, 112, 38],
      colors: ['#10B981', '#3B82F6', '#F59E0B', '#F97316', '#DC2626']
    },
    revenueMonthly: {
      labels: ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو'],
      data: [3.8, 4.1, 3.9, 4.0, 4.2]
    },
    assetsByCategory: {
      labels: ['إلكترونيات', 'أثاث', 'تعليمي', 'مختبرات', 'رياضي'],
      data: [142, 87, 56, 32, 25],
      colors: ['#1E3A8A', '#D4AF37', '#059669', '#7C3AED', '#DC2626']
    }
  },

  // Role-based menu items (sidebar nav)
  // permissions key controls who sees what
  menuItems: [
    // Universal (everyone)
    { id: 'dashboard', label: 'لوحة التحكم', icon: '🏠', route: '#/dashboard', roles: ['*'] },
    
    // School Admin (M1)
    { id: 'school-section', type: 'section', label: 'الإدارة المدرسية', roles: ['principal','office_sup','sysadmin'] },
    { id: 'school-info',    label: 'بيانات المدرسة', icon: '🏫', route: '#/school/info', roles: ['principal','office_sup','sysadmin'] },
    { id: 'school-plans',   label: 'الخطط السنوية', icon: '📋', route: '#/school/plans', roles: ['principal','office_sup'] },
    { id: 'school-circs',   label: 'التعاميم', icon: '📣', route: '#/school/circulars', roles: ['principal','office_sup','registrar'], badge: 12 },
    { id: 'school-reports', label: 'التقارير الدورية', icon: '📊', route: '#/school/reports', roles: ['principal','office_sup'] },

    // Students (M2)
    { id: 'students-section', type: 'section', label: 'إدارة الطلاب', roles: ['principal','teacher','registrar','office_sup'] },
    { id: 'students-list',    label: 'قائمة الطلاب', icon: '🎓', route: '#/students/list', roles: ['principal','teacher','registrar','office_sup'] },
    { id: 'students-enroll',  label: 'تسجيل جديد', icon: '➕', route: '#/students/enroll', roles: ['principal','registrar'] },
    { id: 'students-attend',  label: 'الحضور والغياب', icon: '✅', route: '#/students/attendance', roles: ['principal','teacher','registrar'] },
    { id: 'students-grades',  label: 'الدرجات', icon: '📊', route: '#/students/grades', roles: ['principal','teacher'] },
    { id: 'students-behavior',label: 'السلوك والمتابعة', icon: '⚖️', route: '#/students/behavior', roles: ['principal','teacher','registrar'] },

    // Employees (M3)
    { id: 'employees-section', type: 'section', label: 'الموارد البشرية', roles: ['principal','hr_mgr','office_sup'] },
    { id: 'employees-list',    label: 'قائمة الموظفين', icon: '👥', route: '#/employees/list', roles: ['principal','hr_mgr','office_sup'] },
    { id: 'employees-attend',  label: 'الحضور والانصراف', icon: '🕐', route: '#/employees/attendance', roles: ['principal','hr_mgr'] },
    { id: 'employees-leaves',  label: 'الإجازات', icon: '🏖️', route: '#/employees/leaves', roles: ['principal','hr_mgr','teacher'], badge: 7 },
    { id: 'employees-payroll', label: 'الرواتب', icon: '💰', route: '#/employees/payroll', roles: ['principal','hr_mgr','accountant'] },

    // Assets (M4)
    { id: 'assets-section', type: 'section', label: 'الأصول والمرافق', roles: ['principal','assets_mgr','office_sup'] },
    { id: 'assets-list',    label: 'سجل الأصول', icon: '📦', route: '#/assets/list', roles: ['principal','assets_mgr'] },
    { id: 'assets-maint',   label: 'الصيانة', icon: '🛠️', route: '#/assets/maintenance', roles: ['principal','assets_mgr'], badge: 14 },
    { id: 'assets-inv',     label: 'الجرد', icon: '📋', route: '#/assets/inventory', roles: ['principal','assets_mgr'] },

    // Finance (M5)
    { id: 'finance-section', type: 'section', label: 'الإدارة المالية', roles: ['principal','accountant','guardian'] },
    { id: 'finance-invoices', label: 'الفواتير', icon: '🧾', route: '#/finance/invoices', roles: ['principal','accountant','guardian'] },
    { id: 'finance-payments', label: 'المدفوعات', icon: '💳', route: '#/finance/payments', roles: ['principal','accountant'] },
    { id: 'finance-reports',  label: 'التقارير المالية', icon: '📈', route: '#/finance/reports', roles: ['principal','accountant'] },

    // Statistics (M6)
    { id: 'stats-section', type: 'section', label: 'البيانات والإحصاء', roles: ['principal','office_sup','sysadmin'] },
    { id: 'stats-dashboard', label: 'مؤشرات الأداء KPI', icon: '📊', route: '#/stats/dashboard', roles: ['principal','office_sup'] },
    { id: 'stats-reports',   label: 'تقارير مخصصة', icon: '📑', route: '#/stats/reports', roles: ['principal','office_sup'] },

    // Auth & Security (M7)
    { id: 'auth-section', type: 'section', label: 'الأمن والصلاحيات', roles: ['sysadmin','principal'] },
    { id: 'auth-users',  label: 'المستخدمون', icon: '👤', route: '#/auth/users', roles: ['sysadmin'] },
    { id: 'auth-roles',  label: 'الأدوار والصلاحيات', icon: '🔐', route: '#/auth/roles', roles: ['sysadmin'] },
    { id: 'auth-audit',  label: 'سجل التدقيق', icon: '📜', route: '#/auth/audit', roles: ['sysadmin','principal'] },

    // Emergency (M8)
    { id: 'emergency-section', type: 'section', label: 'الطوارئ والتميز', roles: ['principal','office_sup'] },
    { id: 'emergency-cases',  label: 'حالات الطوارئ', icon: '🚨', route: '#/emergency/cases', roles: ['principal','office_sup'] },
    { id: 'emergency-awards', label: 'الجوائز والتميز', icon: '🏆', route: '#/emergency/awards', roles: ['principal','office_sup'] },

    // Personal items (guardian/student)
    { id: 'my-children', label: 'أبنائي', icon: '👨‍👩‍👧', route: '#/my/children', roles: ['guardian'] },
    { id: 'my-fees',     label: 'الرسوم والمدفوعات', icon: '💳', route: '#/my/fees', roles: ['guardian'] },
    { id: 'my-grades',   label: 'درجاتي', icon: '📊', route: '#/my/grades', roles: ['student'] },
    { id: 'my-schedule', label: 'جدولي الدراسي', icon: '📅', route: '#/my/schedule', roles: ['student','teacher'] },
    { id: 'my-classes',  label: 'شعبي', icon: '🏫', route: '#/my/classes', roles: ['teacher'] },

    // Settings (universal)
    { id: 'profile',  label: 'ملفي الشخصي', icon: '👤', route: '#/profile', roles: ['*'] },
    { id: 'settings', label: 'الإعدادات', icon: '⚙️', route: '#/settings', roles: ['*'] }
  ]
};
