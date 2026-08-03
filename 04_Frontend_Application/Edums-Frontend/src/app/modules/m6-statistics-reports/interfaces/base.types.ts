export interface BaseAuditFields {
  id: number;
  createdAt: string;
  modifiedAt: string | null;
}

export type ReportStatus = 'معلق' | 'قيد المراجعة' | 'معتمد' | 'مرفوض' | 'منشور';
export type ApprovalStatus = 'معلق' | 'قيد المراجعة' | 'معتمد' | 'مرفوض';
export type DraftStatus = 'مسودة' | 'قيد المراجعة' | 'معتمد' | 'مرفوض';
export type SubmissionStatus = 'معلق' | 'مقدم' | 'مقبول' | 'مرفوض';
export type DisposalStatus = 'معلق' | 'قيد التنفيذ' | 'منجز' | 'ملغي';
export type PeriodType = 'شهري' | 'ربع سنوي' | 'نصف سنوي' | 'سنوي';
export type AggregationMethod = 'معدل' | 'مجموع' | 'حد أدنى' | 'حد أقصى' | 'عدد';
export type ChartType = 'خطي' | 'أعمدة' | 'دائري' | 'مبعثر' | 'منطقة';
export type CalculationMethod = 'يدوي' | 'تلقائي';
export type SubmissionMethod = 'إلكتروني' | 'ورقي' | 'بريد إلكتروني' | 'نظام إلكتروني';
export type ReportFrequency = 'أسبوعي' | 'شهري' | 'ربع سنوي' | 'نصف سنوي' | 'سنوي';
export type GenerationMethod = 'يدوي' | 'تلقائي' | 'مجدول';
export type EntityType = 'مدرسة' | 'إدارة تعليمية' | 'وزارة' | 'جهة خارجية';
export type ComplianceReportType = 'امتثال' | 'تقرير سنوي' | 'تقرير نصف سنوي' | 'تقرير دوري';
export type FinancialReportType = 'تقرير أصول' | 'تقرير مالي شامل' | 'تقرير إيرادات' | 'تقرير مصروفات';
export type AnalysisStatus = 'قيد التحليل' | 'مكتمل' | 'معلق' | 'مراجع';
export type Priority = 'منخفض' | 'متوسط' | 'عالي' | 'حرج';
export type TrendDirection = 'صاعد' | 'هابط' | 'مستقر' | 'متذبذب';
export type AuditStatus = 'معلق' | 'قيد المراجعة' | 'معتمد' | 'مرفوض';
export type ComparisonType = 'سنوي' | 'ربع سنوي' | 'شهري' | 'فترة مقارنة';
export type GapType = 'نقص' | 'فائض' | 'مطابق';
export type ChangeType = 'إضافة' | 'تعديل' | 'حذف' | 'تحديث';
export type ChangeCategory = 'بيانات طلاب' | 'بيانات موظفين' | 'بيانات مالية' | 'بيانات أصول' | 'عام';
export type SourceReportType = 'إحصائيات' | 'تقرير مالي' | 'تقرير مقارن' | 'تحليل فجوات' | 'تحليل اتجاهات';
export type ReportCategory = 'إحصائي' | 'مالي' | 'أكاديمي' | 'إداري' | 'امتثال';
export type ForecastingMethod = 'انحدار خطي' | 'متوسط متحرك' | 'استخراج بيانات' | 'ARIMA';
export type FileFormat = 'PDF' | 'Excel' | 'CSV' | 'Word';
