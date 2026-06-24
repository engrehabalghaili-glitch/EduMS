/**
 * ============================================================
 *  مكتبة المكونات المشتركة - Shared Components Library
 *  توثيق كامل للمكونات والخدمات والأدوات
 * ============================================================
 *
 *  Architecture: Angular 22 Standalone Components + Signals
 *  UI Library: PrimeNG 21 (معزول داخل Shared Components فقط)
 *  Design System: Design Tokens (CSS Custom Properties)
 *  اللغة: العربية (RTL)
 *
 * ============================================================
 *  المكونات
 * ============================================================
 */

/**
 * ============================================================
 *  1. StatsCardComponent
 * ============================================================
 *  بطاقة إحصائية (KPI) بأيقونة ملونة
 *
 *  Inputs:
 *    - config: StatsCardConfig (مطلوب)
 *      - value: string | number  ← القيمة الرقمية
 *      - label: string            ← العنوان
 *      - icon: string             ← أيقونة PrimeIcon (مثال: 'pi pi-box')
 *      - color: 'info' | 'success' | 'warn' | 'danger' | 'primary' | 'gray'
 *      - trend?: { direction: 'up' | 'down'; value: string }  ← اتجاه التغير
 *
 *  مثال استخدام:
 *    <app-stats-card [config]="{
 *      value: totalAssets(),
 *      label: 'إجمالي الأصول',
 *      icon: 'pi pi-box',
 *      color: 'info'
 *    }" />
 *
 *  لا يستخدم في:
 *    - بطاقات تحتوي على محتوى مخصص غير رقمي
 *    - بطاقات تحتوي على أزرار أو تفاعلات معقدة
 */

/**
 * ============================================================
 *  2. StatusBadgeComponent
 * ============================================================
 *  شارة حالة ملونة بناءً على خريطة الحالات
 *
 *  Inputs:
 *    - value: string | number  ← القيمة الحالية (مفتاح في الخريطة)
 *    - map: StatusMap          ← خريطة تحويل القيم إلى نص ولون
 *      { [key: string]: { label: string; severity: 'success' | 'info' | 'warn' | 'danger' | 'secondary' } }
 *
 *  مثال استخدام:
 *    const STATUS_MAP: StatusMap = {
 *      active:    { label: 'نشط',    severity: 'success' },
 *      broken:    { label: 'عاطل',   severity: 'danger' },
 *    };
 *    <app-status-badge [value]="asset.status" [map]="STATUS_MAP" />
 *
 *  أفضل الممارسات:
 *    - عرّف الخرائط (StatusMap) كمتغيرات ثابتة على مستوى المكون
 *    - لا تُمرّر الخريطة إذا كانت القيم مختلفة لكل صف
 *
 *  لا يستخدم في:
 *    - شارات تحتوي على صيغ معقدة (مثال: عمليات تيرناري داخل القيمة)
 */

/**
 * ============================================================
 *  3. SidebarComponent
 * ============================================================
 *  شريط جانبي ثابت مع أيقونات وتنقل ورابط مستخدم
 *
 *  Inputs:
 *    - items: SidebarItem[] (مطلوب)  ← قائمة عناصر القائمة
 *    - logoText: string              ← نص الشعار (افتراضي: 'إدارة النظام')
 *    - userName: string              ← اسم المستخدم
 *    - userRole: string              ← دور المستخدم
 *    - userInitials: string          ← الأحرف الأولى للصورة الرمزية
 *    - activeLabel: string           ← العنصر النشط حالياً
 *
 *  Outputs:
 *    - itemClick: SidebarItem        ← حدث عند الضغط على عنصر (إذا لم يكن له route)
 *
 *  SidebarItem:
 *    - label: string                 ← النص
 *    - icon: string                  ← الأيقونة
 *    - route?: string                ← الرابط (إذا وُجد يُستخدم RouterLink)
 *    - badge?: number                ← عدد الإشعارات
 *    - disabled?: boolean            ← معطل؟
 *    - items?: SidebarItem[]         ← قائمة فرعية (غير مدعوم حالياً)
 *
 *  مثال استخدام (route-based):
 *    <app-sidebar [items]="navItems" logoText="نظامي" />
 *
 *  مثال استخدام (command-based):
 *    <app-sidebar [items]="menuItems" (itemClick)="onMenuClick($event)" />
 *
 *  لا يستخدم في:
 *    - صفحات بدون شريط جانبي
 */

/**
 * ============================================================
 *  4. PageHeaderComponent
 * ============================================================
 *  رأس الصفحة مع عنوان وأزرار وشريط بحث
 *
 *  Inputs:
 *    - config: PageHeaderConfig (مطلوب)
 *      - title: string               ← العنوان الرئيسي
 *      - subtitle?: string           ← نص فرعي
 *      - showSearch?: boolean        ← إظهار شريط البحث
 *      - searchPlaceholder?: string  ← نص الحقل
 *      - searchValue?: string        ← قيمة البحث الحالية
 *      - actions?: PageAction[]      ← قائمة الأزرار
 *        PageAction:
 *          - label: string
 *          - icon: string
 *          - severity?: string
 *          - outlined?: boolean
 *          - disabled?: boolean
 *          - command: () => void
 *
 *  Outputs:
 *    - searchChange: string    ← عند تغيير نص البحث
 *
 *  مثال استخدام:
 *    <app-page-header [config]="{
 *      title: 'الأصول',
 *      subtitle: 'إدارة وتتبع الأصول',
 *      showSearch: true,
 *      actions: [
 *        { label: 'إضافة', icon: 'pi pi-plus', command: addAsset }
 *      ]
 *    }" (searchChange)="onSearch($event)" />
 *
 *  لا يستخدم في:
 *    - صفحات بدون أزرار أو بحث علوي
 *    - صفحات ذات تصميم رأس مختلف تماماً
 */

/**
 * ============================================================
 *  5. SearchBoxComponent
 * ============================================================
 *  مربع بحث بأيقونة
 *
 *  Inputs:
 *    - value: string                  ← القيمة الحالية
 *    - placeholder: string            ← النص التوجيهي (افتراضي: 'بحث...')
 *    - width: string                  ← العرض (افتراضي: '320px')
 *
 *  Outputs:
 *    - valueChange: string            ← عند تغيير النص
 *
 *  مثال استخدام:
 *    <app-search-box [value]="searchQuery()" (valueChange)="searchQuery.set($event)" />
 *
 *  لا يستخدم في:
 *    - حالات تحتاج حقول متعددة للبحث المتقدم
 */

/**
 * ============================================================
 *  6. DataTableComponent
 * ============================================================
 *  جدول بيانات مع ترقيم صفحات وفرز واختيار وأزرار
 *
 *  Inputs:
 *    - data: any[] (مطلوب)            ← البيانات
 *    - columns: TableColumn[] (مطلوب) ← تعريف الأعمدة
 *      - field: string                ← حقل البيانات
 *      - header: string               ← عنوان العمود
 *      - sortable?: boolean           ← فرز
 *      - filterable?: boolean         ← تصفية
 *      - width?: string               ← عرض العمود
 *      - align?: 'left'|'center'|'right'
 *      - type?: 'text'|'number'|'date'|'status'|'currency'|'badge'
 *      - statusMap?: StatusMap        ← للأعمدة من نوع status/badge
 *      - hidden?: boolean             ← إخفاء العمود
 *    - actions: TableAction[]         ← أزرار على مستوى الصف
 *      - label: string
 *      - icon?: string
 *      - command: (row) => void
 *      - visible?: (row) => boolean
 *      - disabled?: (row) => boolean
 *      - outlined?: boolean
 *    - config: TableConfig            ← إعدادات الجدول
 *      - paginator?: boolean
 *      - rows?: number
 *      - rowsPerPageOptions?: number[]
 *      - sortField?: string
 *      - sortOrder?: number
 *      - selectionMode?: 'single'|'multiple'
 *      - exportEnabled?: boolean
 *      - loading?: boolean
 *      - lazy?: boolean
 *      - totalRecords?: number
 *
 *  Outputs:
 *    - rowSelect: any                 ← عند اختيار صف
 *    - rowUnselect: any               ← عند إلغاء اختيار صف
 *    - lazyLoad: any                  ← عند التحميل البطيء
 *
 *  مثال استخدام:
 *    <app-data-table
 *      [data]="assets()"
 *      [columns]="[
 *        { field: 'name', header: 'الاسم', sortable: true },
 *        { field: 'status', header: 'الحالة', type: 'status', statusMap: assetStatusMap }
 *      ]"
 *      [actions]="[{ label: 'عرض', icon: 'pi pi-eye', command: showDetails }]"
 *    />
 *
 *  لا يستخدم في:
 *    - جداول تحتوي على قوالب مخصصة معقدة داخل الخلايا
 *    - جداول تحتاج دمج خلايا أو تنسيق خاص
 */

/**
 * ============================================================
 *  7. FilterBarComponent
 * ============================================================
 *  شريط تصفية ديناميكي مع حقول متعددة
 *
 *  Inputs:
 *    - fields: FilterField[] (مطلوب) ← تعريف حقول التصفية
 *      - field: string
 *      - header: string
 *      - type: 'text' | 'select' | 'date' | 'date-range'
 *      - options?: {label, value}[]
 *      - placeholder?: string
 *    - filters: Record<string, any>   ← القيم الحالية
 *    - showReset: boolean             ← إظهار زر مسح
 *
 *  Outputs:
 *    - filterChange: {field, value}   ← عند تغيير قيمة حقل
 *    - reset: void                    ← عند الضغط على مسح
 *
 *  مثال استخدام:
 *    <app-filter-bar
 *      [fields]="filterFields"
 *      [filters]="activeFilters"
 *      (filterChange)="onFilterChange($event)"
 *      (reset)="resetFilters()"
 *    />
 *
 *  لا يستخدم في:
 *    - صفحات تحتاج تصفية مخصصة غير قياسية
 */

/**
 * ============================================================
 *  8. ConfirmationDialogComponent
 * ============================================================
 *  نافذة تأكيد تفاعلية
 *
 *  Inputs:
 *    - visible: boolean               ← إظهار/إخفاء
 *    - config: ConfirmationConfig
 *      - title: string                ← العنوان
 *      - message: string              ← الرسالة
 *      - icon?: string                ← الأيقونة
 *      - acceptLabel?: string         ← نص زر القبول
 *      - rejectLabel?: string         ← نص زر الرفض
 *
 *  Outputs:
 *    - accept: void                   ← عند القبول
 *    - reject: void                   ← عند الرفض
 *
 *  مثال استخدام:
 *    <app-confirmation-dialog
 *      [visible]="showConfirm()"
 *      [config]="{ title: 'تأكيد', message: 'هل أنت متأكد؟' }"
 *      (accept)="onAccept()"
 *      (reject)="onReject()"
 *    />
 *
 *  لا يستخدم في:
 *    - نماذج تحتوي على إدخال بيانات
 *    - نوافذ منبثقة تحتوي على محتوى معقد
 */

/**
 * ============================================================
 *  9. FormActionsComponent
 * ============================================================
 *  أزرار الإجراءات السفلية للنماذج (حفظ + إلغاء)
 *
 *  Inputs:
 *    - config: FormActionConfig
 *      - submitLabel?: string         ← نص زر الحفظ
 *      - cancelLabel?: string         ← نص زر الإلغاء
 *      - submitIcon?: string
 *      - cancelIcon?: string
 *      - submitDisabled?: boolean
 *      - submitLoading?: boolean
 *      - showCancel?: boolean
 *
 *  Outputs:
 *    - submit: void
 *    - cancel: void
 *
 *  مثال استخدام:
 *    <app-form-actions
 *      [config]="{ submitDisabled: !form.valid }"
 *      (submit)="save()"
 *      (cancel)="cancel()"
 *    />
 *
 *  لا يستخدم في:
 *    - صفحات بدون نماذج
 *    - حالات تحتاج أكثر من زرين
 */

/**
 * ============================================================
 *  10. EntityDetailsComponent
 * ============================================================
 *  عرض تفاصيل كيان في شبكة معلومات
 *
 *  Inputs:
 *    - sections: EntityDetailSection[] (مطلوب)
 *      - title: string                ← عنوان القسم
 *      - icon?: string                ← أيقونة القسم
 *      - fields: EntityDetailField[]
 *        - label: string              ← تسمية الحقل
 *        - value: string|number|null  ← القيمة
 *        - type?: 'text'|'currency'|'date'|'badge'|'status'
 *        - statusMap?: StatusMap      ← للأعمدة من نوع status/badge
 *        - copyable?: boolean
 *        - colspan?: 1 | 2            ← امتداد العمود
 *
 *  مثال استخدام:
 *    <app-entity-details [sections]="[
 *      {
 *        title: 'معلومات عامة',
 *        icon: 'pi pi-info-circle',
 *        fields: [
 *          { label: 'الاسم', value: asset.name },
 *          { label: 'الحالة', value: asset.status, type: 'status', statusMap }
 *        ]
 *      }
 *    ]" />
 *
 *  لا يستخدم في:
 *    - صفحات تحتوي على تخطيط مختلف للتفاصيل
 *    - حالات تحتاج حقول تفاعلية
 */

/**
 * ============================================================
 *  11. EmptyStateComponent
 * ============================================================
 *  عرض فارغ عند عدم وجود بيانات
 *
 *  Inputs:
 *    - config: EmptyStateConfig
 *      - title: string                ← العنوان
 *      - message?: string             ← رسالة توضيحية
 *      - icon?: string                ← الأيقونة
 *      - actionLabel?: string         ← نص زر الإجراء
 *      - actionIcon?: string
 *
 *  Outputs:
 *    - action: void                   ← عند الضغط على الزر
 *
 *  مثال استخدام:
 *    <app-empty-state [config]="{
 *      title: 'لا توجد أصول',
 *      message: 'لم يتم تسجيل أي أصل بعد',
 *      actionLabel: 'إضافة أصل',
 *      actionIcon: 'pi pi-plus'
 *    }" (action)="openAddDialog()" />
 *
 *  لا يستخدم في:
 *    - حالات الخطأ (استخدم صفحة خطأ منفصلة)
 */

/**
 * ============================================================
 *  12. LoadingOverlayComponent
 * ============================================================
 *  طبقة تحميل شفافة مع مؤشر تقدم
 *
 *  Inputs:
 *    - visible: boolean               ← إظهار/إخفاء
 *    - message?: string               ← رسالة التحميل
 *
 *  مثال استخدام:
 *    <app-loading-overlay [visible]="isLoading()" message="جاري التحميل..." />
 *
 *  لا يستخدم في:
 *    - صفحات بدون عمليات غير متزامنة
 */

/**
 * ============================================================
 *  الخدمات (Services)
 * ============================================================
 */

/**
 *  NotificationService
 *  ====================
 *  الهدف: تغليف MessageService من PrimeNG لعرض الإشعارات
 *  الطرق:
 *    - success(summary, detail?)
 *    - error(summary, detail?)
 *    - warn(summary, detail?)
 *    - info(summary, detail?)
 *  مثال:
 *    inject(NotificationService).success('تم الحفظ', 'تم حفظ البيانات بنجاح')
 */

/**
 *  DialogService
 *  ==============
 *  الهدف: إدارة نوافذ التأكيد برمجياً
 *  الطرق:
 *    - confirm(config: ConfirmationConfig): Promise<boolean>
 *  مثال:
 *    const confirmed = await inject(DialogService).confirm({
 *      title: 'تأكيد الحذف',
 *      message: 'هل أنت متأكد؟'
 *    });
 *    if (confirmed) { ... }
 */

/**
 *  SidebarService
 *  ===============
 *  الهدف: إدارة حالة الشريط الجانبي
 *  الإشارات:
 *    - collapsed: Signal<boolean>
 *    - mobileOpen: Signal<boolean>
 *  الطرق:
 *    - toggle()
 *    - toggleMobile()
 *    - closeMobile()
 */

/**
 * ============================================================
 *  التوجيهات (Directives)
 * ============================================================
 */

/**
 *  AutoFocusDirective
 *  ===================
 *  التركيز التلقائي على عنصر الإدخال
 *  مثال: <input appAutoFocus />
 */

/**
 *  ClickOutsideDirective
 *  ======================
 *  حدث عند الضغط خارج العنصر
 *  مثال:
 *    <div (appClickOutside)="closeMenu()">...</div>
 */

/**
 * ============================================================
 *  الأنابيب (Pipes)
 * ============================================================
 */

/**
 *  StatusLabelPipe
 *  ================
 *  تحويل قيمة الحالة إلى نص
 *  مثال: {{ asset.status | statusLabel: STATUS_MAP }}
 */

/**
 *  SeverityPipe
 *  =============
 *  تحويل قيمة الحالة إلى severity
 */

/**
 * ============================================================
 *  أفضل الممارسات العامة
 * ============================================================
 *
 *  1. كل Shared Component هو Standalone Component
 *  2. استخدم input() للإشارات القادمة من الأب
 *  3. استخدم output() للأحداث الصادرة
 *  4. لا تربط المكون بمنطق الأعمال مطلقاً
 *  5. المسؤولية الوحيدة للمكون: العرض والتفاعل
 *  6. الصفحات مسؤولة فقط عن: جلب البيانات، إدارة الحالة، استدعاء المكونات
 *  7. PrimeNG يُستخدم فقط داخل Shared Components
 *  8. عند إضافة مكون مشترك جديد:
 *     a. حدد واجهة Inputs/Outputs أولاً
 *     b. نفّذ القالب باستخدام Design Tokens
 *     c. اختبر في صفحة اختبار
 *     d. وثّق في هذا الملف
 */
