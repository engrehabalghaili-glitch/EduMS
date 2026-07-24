export type AccountType = 'أصول' | 'خصوم' | 'حقوق ملكية' | 'إيرادات' | 'مصروفات';

export type FeeCategory = 'دراسية' | 'نشاطات' | 'نقل' | 'وجبات' | 'أخرى';

export type BillingFrequency = 'Annual' | 'Semester' | 'Monthly' | 'Quarterly';

export type Currency = 'SAR' | 'USD' | 'EUR';

export type RecurrenceType = 'Monthly' | 'Quarterly' | 'SemiAnnual' | 'Annual';

export type InvoiceStatus = 'معلق' | 'صادر' | 'ملغي';

export type PaymentStatus = 'غير مدفوع' | 'مدفوع جزئياً' | 'مدفوع بالكامل';

export type InstallmentStatus = 'معلق' | 'مدفوع' | 'متأخر' | 'ملغي' | 'معفى';

export type JournalEntryStatus = 'معلق' | 'معتمد' | 'ملغي';

export type PayrollStatus = 'معلق' | 'قيد المعالجة' | 'مكتمل' | 'ملغي';

export type BalanceType = 'مدين' | 'دائن';

export type StudentAccountStatus = 'نشط' | 'موقوف' | 'مغلق';

export type PaymentMethodType = 'نقدي' | 'تحويل بنكي' | 'شيك' | 'بطاقة ائتمان' | 'محفظة إلكترونية';

export type ConfirmationStatus = 'معلق' | 'مؤكد' | 'مرفوض';

export type ParentApprovalStatus = 'معلق' | 'موافق' | 'مرفوض';

export type InvoiceCategoryType = 'Mandatory' | 'Optional';

export type PaymentVoucherMethod = 'نقدي' | 'تحويل بنكي' | 'شيك';

export interface AuditFields {
  createdAt: string;
}
