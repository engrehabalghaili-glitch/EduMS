import type { Asset, MaintenanceRequest, PreventiveMaintenance, InventoryItem, DepreciationInfo, AssetActivity } from '../../models/assets.model';

export const MOCK_ASSETS: Asset[] = [
  { id: 'A001', barcode: 'BRC-2024-001', name: 'حاسوب محمول Dell Latitude 5540', category: 'technology', location: 'مبنى الإدارة - الدور الثاني', status: 'active', purchaseDate: '2024-09-15', purchaseCost: 4500, currentValue: 3800, supplier: 'شركة الأفق للتقنية', invoiceNumber: 'INV-2024-891', warrantyEnd: '2027-09-15', warrantyStatus: 'valid', assignedTo: 'أ. محمد العلي', floor: 'الثاني', room: 'مكتب 204', description: 'لابتوب مخصص لأعمال الإدارة' },
  { id: 'A002', barcode: 'BRC-2024-002', name: 'طابعة HP LaserJet Pro', category: 'technology', location: 'مبنى الإدارة - الدور الأول', status: 'broken', purchaseDate: '2023-03-01', purchaseCost: 2800, currentValue: 1400, supplier: 'شركة الحلول الرقمية', invoiceNumber: 'INV-2023-234', warrantyEnd: '2025-03-01', warrantyStatus: 'expired', assignedTo: 'قسم السكرتارية', floor: 'الأول', room: 'مكتب 105', description: 'طابعة ليزر تحتاج صيانة لعطل في وحدة الطباعة' },
  { id: 'A003', barcode: 'BRC-2024-003', name: 'مكتب تنفيذي زجاجي', category: 'furniture', location: 'مبنى الإدارة - الدور الثالث', status: 'active', purchaseDate: '2024-01-10', purchaseCost: 3200, currentValue: 2900, supplier: 'معمل الأثاث العصري', invoiceNumber: 'INV-2024-045', warrantyEnd: '2029-01-10', warrantyStatus: 'valid', assignedTo: 'مدير المدرسة', floor: 'الثالث', room: 'مكتب المدير', description: 'مكتب زجاجي فاخر' },
  { id: 'A004', barcode: 'BRC-2023-045', name: 'حافلة مدرسية تويوتا كوستر', category: 'vehicle', location: 'موقف الحافلات', status: 'active', purchaseDate: '2023-09-20', purchaseCost: 285000, currentValue: 235000, supplier: 'شركة تويوتا السعودية', invoiceNumber: 'INV-2023-891', warrantyEnd: '2026-09-20', warrantyStatus: 'valid', assignedTo: 'قسم النقل', floor: '-', room: '-', description: 'حافلة لنقل الطلاب سعة 30 راكباً' },
  { id: 'A005', barcode: 'BRC-2022-102', name: 'مكيف سبليت 24,000 وحدة', category: 'technology', location: 'مبنى الفصول - الدور الأول', status: 'maintenance', purchaseDate: '2022-05-15', purchaseCost: 3500, currentValue: 1800, supplier: 'شركة تكييف الخليج', invoiceNumber: 'INV-2022-456', warrantyEnd: '2025-05-15', warrantyStatus: 'expired', assignedTo: 'الفصل 1-أ', floor: 'الأول', room: 'فصل 101', description: 'مكيف سبليت بحاجة إلى صيانة دورية' },
  { id: 'A006', barcode: 'BRC-2024-012', name: 'سبورة تفاعلية 65 بوصة', category: 'technology', location: 'مبنى الفصول - الدور الثاني', status: 'active', purchaseDate: '2024-02-01', purchaseCost: 8500, currentValue: 7800, supplier: 'شركة التعليم الذكي', invoiceNumber: 'INV-2024-112', warrantyEnd: '2027-02-01', warrantyStatus: 'valid', assignedTo: 'مختبر العلوم', floor: 'الثاني', room: 'مختبر 201', description: 'سبورة تفاعلية للتعليم الإلكتروني' },
  { id: 'A007', barcode: 'BRC-2023-078', name: 'مقعد طالب بلاستيكي', category: 'furniture', location: 'مبنى الفصول - الدور الأرضي', status: 'active', purchaseDate: '2023-08-15', purchaseCost: 180, currentValue: 120, supplier: 'شركة الأثاث المدرسي', invoiceNumber: 'INV-2023-567', warrantyEnd: '2026-08-15', warrantyStatus: 'valid', assignedTo: 'الفصل 2-ب', floor: 'الأرضي', room: 'فصل 002', description: 'مقعد بلاستيكي مزدوج' },
  { id: 'A008', barcode: 'BRC-2023-079', name: 'خزانة كتب معدنية', category: 'furniture', location: 'مكتبة المدرسة', status: 'active', purchaseDate: '2023-08-15', purchaseCost: 1200, currentValue: 850, supplier: 'شركة الأثاث المدرسي', invoiceNumber: 'INV-2023-567', warrantyEnd: '2026-08-15', warrantyStatus: 'valid', assignedTo: 'أمين المكتبة', floor: 'الأول', room: 'المكتبة', description: 'خزانة كتب معدنية كبيرة' },
  { id: 'A009', barcode: 'BRC-2021-033', name: 'مشروع توسعة المبنى الرئيسي', category: 'building', location: 'مبنى الإدارة', status: 'active', purchaseDate: '2021-03-01', purchaseCost: 520000, currentValue: 480000, supplier: 'شركة البناء الحديث', invoiceNumber: 'INV-2021-011', warrantyEnd: '2031-03-01', warrantyStatus: 'valid', assignedTo: 'إدارة المدرسة', floor: '-', room: '-', description: 'مشروع توسعة المبنى الرئيسي' },
  { id: 'A010', barcode: 'BRC-2024-020', name: 'حاسوب مكتبي Dell Optiplex', category: 'technology', location: 'مختبر الحاسب الآلي', status: 'active', purchaseDate: '2024-09-01', purchaseCost: 3200, currentValue: 3000, supplier: 'شركة الأفق للتقنية', invoiceNumber: 'INV-2024-892', warrantyEnd: '2027-09-01', warrantyStatus: 'valid', assignedTo: 'مختبر الحاسب', floor: 'الثاني', room: 'مختبر 203', description: 'حاسوب مكتبي للطلاب' },
  { id: 'A011', barcode: 'BRC-2024-021', name: 'سيت حاسب مكتبي', category: 'technology', location: 'مختبر الحاسب الآلي', status: 'active', purchaseDate: '2024-09-01', purchaseCost: 3200, currentValue: 3000, supplier: 'شركة الأفق للتقنية', invoiceNumber: 'INV-2024-892', warrantyEnd: '2027-09-01', warrantyStatus: 'valid', assignedTo: 'مختبر الحاسب', floor: 'الثاني', room: 'مختبر 203', description: 'حاسوب مكتبي للطلاب' },
  { id: 'A012', barcode: 'BRC-2024-022', name: 'سيت حاسب مكتبي', category: 'technology', location: 'مختبر الحاسب الآلي', status: 'active', purchaseDate: '2024-09-01', purchaseCost: 3200, currentValue: 3000, supplier: 'شركة الأفق للتقنية', invoiceNumber: 'INV-2024-892', warrantyEnd: '2027-09-01', warrantyStatus: 'valid', assignedTo: 'مختبر الحاسب', floor: 'الثاني', room: 'مختبر 203', description: 'حاسوب مكتبي للطلاب' },
  { id: 'A013', barcode: 'BRC-2023-088', name: 'شاحنة نقل صغيرة', category: 'vehicle', location: 'موقف الخدمات', status: 'active', purchaseDate: '2023-11-01', purchaseCost: 95000, currentValue: 82000, supplier: 'شركة السيارات الموحدة', invoiceNumber: 'INV-2023-901', warrantyEnd: '2026-11-01', warrantyStatus: 'valid', assignedTo: 'قسم الصيانة', floor: '-', room: '-', description: 'شاحنة صغيرة لنقل التجهيزات' },
  { id: 'A014', barcode: 'BRC-2022-056', name: 'جهاز عرض بيانات (بروجيكتور)', category: 'technology', location: 'مبنى الفصول - الدور الثالث', status: 'broken', purchaseDate: '2022-10-01', purchaseCost: 4200, currentValue: 1500, supplier: 'شركة الأفق للتقنية', invoiceNumber: 'INV-2022-678', warrantyEnd: '2025-10-01', warrantyStatus: 'expired', assignedTo: 'فصل 302', floor: 'الثالث', room: 'فصل 302', description: 'جهاز عرض معطل - مشكلة في المصباح' },
  { id: 'A015', barcode: 'BRC-2025-001', name: 'طاولة معمل علوم', category: 'furniture', location: 'مختبر العلوم', status: 'stored', purchaseDate: '2025-01-15', purchaseCost: 2400, currentValue: 2300, supplier: 'معمل الأثاث العصري', invoiceNumber: 'INV-2025-023', warrantyEnd: '2028-01-15', warrantyStatus: 'valid', assignedTo: 'المستودع', floor: '-', room: 'المستودع', description: 'طاولة معلم جديدة في المستودع' },
];

export const MOCK_MAINTENANCE_REQUESTS: MaintenanceRequest[] = [
  { id: 'M001', assetId: 'A002', assetName: 'طابعة HP LaserJet Pro', assetBarcode: 'BRC-2024-002', reportedDate: '2026-06-20', priority: 'urgent', status: 'in-progress', technician: 'فني الصيانة أحمد', description: 'الطابعة لا تعمل - عطل في وحدة الطباعة' },
  { id: 'M002', assetId: 'A014', assetName: 'جهاز عرض بيانات (بروجيكتور)', assetBarcode: 'BRC-2022-056', reportedDate: '2026-06-18', priority: 'urgent', status: 'pending', technician: '-', description: 'جهاز العرض لا يضيء - يحتاج استبدال لمبة' },
  { id: 'M003', assetId: 'A005', assetName: 'مكيف سبليت 24,000 وحدة', assetBarcode: 'BRC-2022-102', reportedDate: '2026-06-15', priority: 'medium', status: 'pending', technician: '-', description: 'المكيف لا يبرد بشكل كافٍ' },
  { id: 'M004', assetId: 'A010', assetName: 'حاسوب مكتبي Dell Optiplex', assetBarcode: 'BRC-2024-020', reportedDate: '2026-06-10', priority: 'medium', status: 'in-progress', technician: 'فني الصيانة سامر', description: 'بطء شديد في الأداء' },
  { id: 'M005', assetId: 'A007', assetName: 'مقعد طالب بلاستيكي', assetBarcode: 'BRC-2023-078', reportedDate: '2026-06-08', priority: 'routine', status: 'completed', technician: 'فني الصيانة خالد', description: 'كسر في قاعدة المقعد' },
  { id: 'M006', assetId: 'A006', assetName: 'سبورة تفاعلية 65 بوصة', assetBarcode: 'BRC-2024-012', reportedDate: '2026-06-22', priority: 'urgent', status: 'pending', technician: '-', description: 'السبورة التفاعلية لا تستجيب للمس' },
  { id: 'M007', assetId: 'A013', assetName: 'شاحنة نقل صغيرة', assetBarcode: 'BRC-2023-088', reportedDate: '2026-06-05', priority: 'routine', status: 'completed', technician: 'فني الصيانة أحمد', description: 'تغيير زيت المحرك' },
];

export const MOCK_PREVENTIVE_MAINTENANCE: PreventiveMaintenance[] = [
  { id: 'PM001', assetId: 'A005', assetName: 'مكيف سبليت 24,000 وحدة', scheduledDate: '2026-06-30', remainingDays: 8, type: 'صيانة دورية للمكيفات', assignedTo: 'شركة تكييف الخليج' },
  { id: 'PM002', assetId: 'A005', assetName: 'مكيف سبليت 24,000 وحدة - الفصل 102', scheduledDate: '2026-07-05', remainingDays: 13, type: 'صيانة دورية للمكيفات', assignedTo: 'شركة تكييف الخليج' },
  { id: 'PM003', assetId: 'A002', assetName: 'طابعة HP LaserJet Pro', scheduledDate: '2026-07-10', remainingDays: 18, type: 'فحص دوري للطابعات', assignedTo: 'فني الصيانة أحمد' },
  { id: 'PM004', assetId: 'A010', assetName: 'حاسوب مكتبي Dell Optiplex', scheduledDate: '2026-07-15', remainingDays: 23, type: 'صيانة أجهزة المختبر', assignedTo: 'فني الصيانة سامر' },
  { id: 'PM005', assetId: 'A013', assetName: 'شاحنة نقل صغيرة', scheduledDate: '2026-07-01', remainingDays: 9, type: 'صيانة دورية للمركبات', assignedTo: 'مركز صيانة السيارات' },
  { id: 'PM006', assetId: 'A006', assetName: 'سبورة تفاعلية 65 بوصة', scheduledDate: '2026-07-20', remainingDays: 28, type: 'فحص الأجهزة التفاعلية', assignedTo: 'شركة التعليم الذكي' },
];

export const MOCK_INVENTORY: InventoryItem[] = [
  { id: 'INV001', name: 'حبر طابعة HP 85A', category: 'ink', currentQuantity: 3, minThreshold: 10, unit: 'خرطوشة' },
  { id: 'INV002', name: 'حبر طابعة Canon 045', category: 'ink', currentQuantity: 2, minThreshold: 8, unit: 'خرطوشة' },
  { id: 'INV003', name: 'ورق تصوير A4', category: 'stationery', currentQuantity: 15, minThreshold: 20, unit: 'كرتون' },
  { id: 'INV004', name: 'أقلام سبورة بيضاء', category: 'stationery', currentQuantity: 25, minThreshold: 30, unit: 'علبة' },
  { id: 'INV005', name: 'لمبة بروجيكتور Epson', category: 'spare-parts', currentQuantity: 1, minThreshold: 3, unit: 'قطعة' },
  { id: 'INV006', name: 'مروحة مكيف سبليت', category: 'spare-parts', currentQuantity: 0, minThreshold: 2, unit: 'قطعة' },
  { id: 'INV007', name: 'كراسات اختبارات', category: 'stationery', currentQuantity: 200, minThreshold: 50, unit: 'كراسة' },
  { id: 'INV008', name: 'مسحوق حبر ليزر', category: 'ink', currentQuantity: 5, minThreshold: 6, unit: 'كيلو' },
];

export const MOCK_DEPRECIATION: DepreciationInfo[] = [
  { category: 'أجهزة تقنية', bookValue: 27100, accumulatedDepreciation: 8200, annualDepreciation: 4100, assetCount: 8 },
  { category: 'أثاث', bookValue: 6170, accumulatedDepreciation: 2530, annualDepreciation: 850, assetCount: 4 },
  { category: 'مركبات', bookValue: 317000, accumulatedDepreciation: 56000, annualDepreciation: 28000, assetCount: 2 },
  { category: 'مباني ومرافق', bookValue: 480000, accumulatedDepreciation: 40000, annualDepreciation: 13000, assetCount: 1 },
];

export const MOCK_EXPIRED_ASSETS = [
  { name: 'طابعة HP LaserJet Pro', category: 'أجهزة تقنية', purchaseYear: 2023, replacementCost: 3200, reason: 'انتهى العمر الافتراضي (3 سنوات)' },
  { name: 'مكيف سبليت 24,000 وحدة', category: 'أجهزة تقنية', purchaseYear: 2022, replacementCost: 4000, reason: 'انتهى العمر الافتراضي (4 سنوات)' },
  { name: 'جهاز عرض بيانات (بروجيكتور)', category: 'أجهزة تقنية', purchaseYear: 2022, replacementCost: 5500, reason: 'انتهى العمر الافتراضي (3 سنوات)' },
  { name: 'مقعد طالب بلاستيكي', category: 'أثاث', purchaseYear: 2023, replacementCost: 200, reason: 'تجاوز الحد المسموح من الاهتلاك' },
];

export const MOCK_ASSET_ACTIVITIES: Record<string, AssetActivity[]> = {
  'A001': [
    { date: '2024-09-15', event: 'شراء الجهاز من شركة الأفق للتقنية - فاتورة رقم INV-2024-891', type: 'purchase' },
    { date: '2024-09-20', event: 'توزيع الجهاز إلى أ. محمد العلي - مكتب 204', type: 'distribution' },
    { date: '2025-03-15', event: 'صيانة دورية - تنظيف وفحص عام', type: 'maintenance' },
    { date: '2025-09-15', event: 'تمديد الضمان لمدة عام إضافي', type: 'warranty' },
    { date: '2026-01-10', event: 'استبدال البطارية - صيانة طارئة', type: 'maintenance' },
  ],
  'A002': [
    { date: '2023-03-01', event: 'شراء الطابعة من شركة الحلول الرقمية', type: 'purchase' },
    { date: '2023-03-05', event: 'توزيع الطابعة إلى قسم السكرتارية', type: 'distribution' },
    { date: '2024-06-15', event: 'صيانة دورية - استبدال خراطيش الحبر', type: 'maintenance' },
    { date: '2025-03-01', event: 'انتهاء الضمان', type: 'warranty' },
    { date: '2026-06-20', event: 'بلاغ عطل - الطابعة لا تعمل (قيد الإصلاح)', type: 'maintenance' },
  ],
};

export const MOCK_BUREAU_REPORT = {
  localCount: 15,
  bureauCount: 14,
  extraAssets: ['مقعد طالب بلاستيكي (BRC-2023-078) - غير مسجل في كشف المكتب'],
  missingAssets: ['حاسوب محمول Lenovo (BRC-2021-015) - مسجل في كشف المكتب ولكن غير موجود'],
  lastSyncDate: '2026-05-30',
  status: 'partial-match' as const,
};
