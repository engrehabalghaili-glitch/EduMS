"""
===============================================================================
ملف: data_generator.py - مولد البيانات التعليمية المتقدم
===============================================================================

الغرض الأساسي:
-----------
هذا الملف مسؤول عن توليد بيانات تعليمية شاملة وواقعية للمدارس. يقوم بإنشاء
بيانات افتراضية لـ 1000+ مدرسة مع 27+ ميزة مختلفة تغطي جميع جوانب العملية
التعليمية.

كيف يخدم المشروع:
----------------
1. يوفر بيانات تدريب متكاملة لنماذج التعلم الآلي
2. يحاكي العلاقات الواقعية بين مختلف مقاييس الأداء المدرسي
3. يدعم تحليل متعدد الأبعاد للبيانات التعليمية
4. يمثل أساس نظام التحليل الاستراتيجي الشامل

المميزات الرئيسية:
- توليد بيانات أكاديمية (متوسطات الدرجات، معدلات النجاح)
- بيانات المشاركة والتفاعل الطلابي
- مقاييس البنية التحتية والتكنولوجيا
- بيانات رأس المال البشري (المعلمين والموظفين)
- معلومات مالية واقتصادية
- مؤشرات نفسية مجهولة المصدر (رضا الطلاب، إرهاق المعلمين)
===============================================================================
"""

import pandas as pd  # مكتبة لمعالجة البيانات الجدولية
import numpy as np   # مكتبة للعمليات الحسابية والمصفوفات
import random        # مكتبة لتوليد أرقام عشوائية
from datetime import datetime  # لمعالجة التواريخ والأوقات
import os          # للتعامل مع نظام الملفات والمجلدات

class EducationalDataGenerator:
    """
    ===============================================================================
    فئة مولد البيانات التعليمية
    ===============================================================================
    
    وظيفتها: إنشاء بيانات تعليمية شاملة ومترابطة للمدارس
    تستخدم: لتدريب نماذج الذكاء الاصطناعي وتحليل الأداء المدرسي
    ===============================================================================
    """
    
    def __init__(self, num_schools=1000, random_seed=42):
        """
        ===========================================================================
        المُنشئ: تهيئة مولد البيانات
        ===========================================================================
        
        المعلمات:
        - num_schools: عدد المدارس المراد توليد بياناتها (افتراضي: 1000)
        - random_seed: بذرة عشوائية لضمان تكرار النتائج (افتراضي: 42)
        
        الغرض: إعداد البيئة لتوليد بيانات متسقة وقابلة للتكرار
        ===========================================================================
        """
        self.num_schools = num_schools  # تخزين عدد المدارس
        self.random_seed = random_seed    # تخزين البذرة العشوائية
        np.random.seed(random_seed)       # ضبط بذرة NumPy
        random.seed(random_seed)          # ضبط بذرة Python
        
    def generate_basic_demographics(self):
        """
        ===========================================================================
        توليد البيانات الديموغرافية الأساسية
        ===========================================================================
        
        الوظيفة: إنشاء معلومات أساسية عن المدارس (معرف، منطقة، نوع، أعداد)
        
        المخرجات:
        - معرف المدرسة الفريد
        - المنطقة الجغرافية
        - نوع المدرسة (حكومية/خاصة/مجتمعية)
        - أعداد الطلاب والمعلمين
        
        الأهمية: تمثل الهيكل الأساسي لكل مدرسة في النظام
        ===========================================================================
        """
        return {
            'School_ID': [f'SCH_{i:04d}' for i in range(1, self.num_schools + 1)],  # إنشاء معرفات فريدة
            'Region': np.random.choice(['الشمال', 'الجنوب', 'الشرق', 'الغرب', 'المركز'], self.num_schools),  # توزيع المناطق
            'School_Type': np.random.choice(['حكومية', 'خاصة', 'مجتمعية'], self.num_schools, p=[0.7, 0.2, 0.1]),  # توزيع أنواع المدارس
            'Student_Count': np.random.randint(200, 2500, self.num_schools),  # أعداد الطلاب
            'Teacher_Count': np.random.randint(15, 200, self.num_schools)  # أعداد المعلمين
        }
    
    def generate_academic_metrics(self, base_quality):
        """
        ===========================================================================
        توليد المقاييس الأكاديمية
        ===========================================================================
        
        الوظيفة: إنشاء مؤشرات الأداء الأكاديمي للمدارس
        
        المعلمات:
        - base_quality: جودة أساسية لضمان ارتباط واقعي بين المقاييس
        
        المخرجات:
        - متوسطات الدرجات للفصلين الدراسيين
        - معدلات النجاح في المواد العلمية والقراءة
        - مؤشر مخاطر الرسوب
        
        الأهمية: تمثل الأساس لتقييم الأداء التعليمي الفعلي
        ===========================================================================
        """
        return {
            'Term_1_Avg': np.clip(np.random.normal(base_quality * 100, 15, self.num_schools), 0, 100),  # متوسط الفصل الأول
            'Term_2_Avg': np.clip(np.random.normal(base_quality * 100, 15, self.num_schools), 0, 100),  # متوسط الفصل الثاني
            'STEM_Subject_Rate': np.clip(np.random.normal(base_quality * 100, 20, self.num_schools), 0, 100),  # معدل المواد العلمية
            'Literacy_Rate': np.clip(np.random.normal(base_quality * 110, 10, self.num_schools), 0, 100),  # معدل القراءة
            'Failure_Risk_Index': np.clip(np.random.normal((1-base_quality) * 50, 15, self.num_schools), 0, 100)  # مؤشر مخاطر الرسوب
        }
    
    def generate_engagement_metrics(self, base_quality):
        """
        ===========================================================================
        توليد مقاييس المشاركة والتفاعل
        ===========================================================================
        
        الوظيفة: قياس مستوى تفاعل الطلاب مع الأنشطة المدرسية
        
        المخرجات:
        - معدل الحضور اليومي
        - ساعات استخدام المكتبة
        - نسبة المشاركة في الأنشطة اللامنهجية
        - تكرار تسجيل الدخول لنظام إدارة التعلم
        
        الأهمية: تعكس مدى اندماج الطلاب في البيئة التعليمية
        ===========================================================================
        """
        return {
            'Average_Attendance': np.clip(np.random.normal(85 + base_quality * 10, 8, self.num_schools), 60, 100),  # معدل الحضور
            'Library_Usage_Hours': np.random.exponential(2 + base_quality * 3, self.num_schools),  # ساعات المكتبة
            'Extracurricular_Participation': np.clip(np.random.normal(base_quality * 80, 20, self.num_schools), 0, 100),  # الأنشطة اللامنهجية
            'LMS_Login_Frequency': np.clip(np.random.normal(base_quality * 15, 5, self.num_schools), 0, 30)  # تكرار الدخول لنظام التعلم
        }
    
    def generate_infrastructure_metrics(self, base_quality):
        """
        ===========================================================================
        توليد مقاييس البنية التحتية والتكنولوجيا
        ===========================================================================
        
        الوظيفة: تقييم حالة المرافق والتجهيزات التكنولوجية
        
        المخرجات:
        - سرعة الإنترنت بالميجابت
        - نسبة الفصول الذكية
        - جودة معدات المختبرات
        
        الأهمية: تمثل الأساس المادي لعملية التعليم الحديث
        ===========================================================================
        """
        return {
            'Internet_Speed_Mbps': np.clip(np.random.normal(base_quality * 100, 30, self.num_schools), 10, 1000),  # سرعة الإنترنت
            'Smart_Classroom_Ratio': np.clip(np.random.normal(base_quality * 0.6, 0.2, self.num_schools), 0, 1),  # نسبة الفصول الذكية
            'Lab_Equipment_Quality_Score': np.random.randint(1, 11, self.num_schools)  # جودة معدات المختبرات
        }
    
    def generate_human_capital_metrics(self, base_quality):
        """
        ===========================================================================
        توليد مقاييس رأس المال البشري
        ===========================================================================
        
        الوظيفة: قياس جودة واستقرار القوى العاملة في التعليم
        
        المخرجات:
        - معدل دوران المعلمين
        - نسبة المعلمين الحاصلين على الدكتوراه
        - ساعات التطوير المهني السنوية
        
        الأهمية: تعكس جودة الكادر التعليمي واستدامته
        ===========================================================================
        """
        return {
            'Teacher_Turnover_Rate': np.clip(np.random.normal((1-base_quality) * 25, 10, self.num_schools), 0, 50),  # معدل دوران المعلمين
            'Teacher_PhD_Ratio': np.clip(np.random.normal(base_quality * 0.3, 0.15, self.num_schools), 0, 1),  # نسبة الدكاترة
            'Professional_Development_Hours_Per_Year': np.clip(np.random.normal(20 + base_quality * 30, 15, self.num_schools), 0, 100)  # ساعات التطوير المهني
        }
    
    def generate_financial_metrics(self, base_quality):
        """
        ===========================================================================
        توليد المقاييس المالية والاقتصادية
        ===========================================================================
        
        الوظيفة: تحليل الجوانب المادية والاقتصادية للمدارس
        
        المخرجات:
        - الميزانية لكل طالب
        - تخصيص الميزانية لتكنولوجيا المعلومات
        - تخصيص الميزانية للمنح الدراسية
        - المؤشر الاقتصادي الإقليمي
        
        الأهمية: تمثل الموارد المادية المتاحة للعملية التعليمية
        ===========================================================================
        """
        return {
            'Budget_Per_Student': np.clip(np.random.normal(3000 + base_quality * 7000, 2000, self.num_schools), 500, 20000),  # الميزانية للطالب
            'Budget_Allocation_IT': np.clip(np.random.normal(base_quality * 0.15, 0.05, self.num_schools), 0.01, 0.5),  # تخصيص تكنولوجيا المعلومات
            'Budget_Allocation_Scholarships': np.clip(np.random.normal(base_quality * 0.1, 0.03, self.num_schools), 0.01, 0.3),  # تخصيص المنح
            'Regional_Economic_Index': np.random.uniform(0.3, 1.0, self.num_schools)  # المؤشر الاقتصادي الإقليمي
        }
    
    def generate_psychological_metrics(self, base_quality):
        """
        ===========================================================================
        توليد المقاييس النفسية (مجهولة المصدر)
        ===========================================================================
        
        الوظيفة: قياس الجوانب النفسية والصحية للطلاب والمعلمين
        
        المخرجات:
        - مؤشر رفاهية الطلاب
        - مؤشر إرهاق المعلمين
        
        الأهمية: تعكس البيئة الصحية النفسية للمدرسة
        ===========================================================================
        """
        return {
            'Student_Wellbeing_Score': np.clip(np.random.normal(base_quality * 8, 2, self.num_schools), 1, 10),  # رفاهية الطلاب
            'Teacher_Burnout_Index': np.clip(np.random.normal((1-base_quality) * 6, 2, self.num_schools), 1, 10)  # إرهاق المعلمين
        }
    
    def calculate_overall_quality_score(self, df):
        """
        ===========================================================================
        حساب درجة الجودة الشاملة للمدرسة
        ===========================================================================
        
        الوظيفة: دمج جميع المقاييس في درجة جودة شاملة موزونة
        
        المعلمات:
        - df: DataFrame يحتوي جميع بيانات المدرسة
        
        الطريقة: استخدام صيغة موزونة تجمع مختلف الأبعاد:
        - الأكاديمية (30%)
        - المشاركة (20%)
        - البنية التحتية (15%)
        - رأس المال البشري (20%)
        - المالية (10%)
        - النفسية (5%)
        
        الأهمية: تمثل المؤشر الرئيسي لتقييم أداء المدرسة
        ===========================================================================
        """
        # تحديد أوزان كل بُعد
        academic_weight = 0.3      # الوزن الأكاديمي
        engagement_weight = 0.2    # وزن المشاركة
        infrastructure_weight = 0.15 # وزن البنية التحتية
        human_capital_weight = 0.2  # وزن رأس المال البشري
        financial_weight = 0.1      # الوزن المالي
        psychological_weight = 0.05  # الوزن النفسي
        
        # حساب درجة الأداء الأكاديمي
        academic_score = (
            df['Term_1_Avg'] * 0.3 + 
            df['Term_2_Avg'] * 0.3 + 
            df['STEM_Subject_Rate'] * 0.2 + 
            df['Literacy_Rate'] * 0.2 - 
            df['Failure_Risk_Index'] * 0.1
        ) / 100
        
        # حساب درجة المشاركة والتفاعل
        engagement_score = (
            df['Average_Attendance'] / 100 * 0.4 +
            np.clip(df['Library_Usage_Hours'] / 10, 0, 1) * 0.2 +
            df['Extracurricular_Participation'] / 100 * 0.2 +
            np.clip(df['LMS_Login_Frequency'] / 20, 0, 1) * 0.2
        )
        
        # حساب درجة البنية التحتية
        infrastructure_score = (
            np.clip(df['Internet_Speed_Mbps'] / 100, 0, 1) * 0.4 +
            df['Smart_Classroom_Ratio'] * 0.3 +
            df['Lab_Equipment_Quality_Score'] / 10 * 0.3
        )
        
        # حساب درجة رأس المال البشري
        human_capital_score = (
            np.clip(1 - df['Teacher_Turnover_Rate'] / 50, 0, 1) * 0.4 +
            df['Teacher_PhD_Ratio'] * 0.3 +
            np.clip(df['Professional_Development_Hours_Per_Year'] / 50, 0, 1) * 0.3
        )
        
        # حساب الدرجة المالية
        financial_score = (
            np.clip(df['Budget_Per_Student'] / 10000, 0, 1) * 0.4 +
            df['Budget_Allocation_IT'] * 2 * 0.3 +
            df['Budget_Allocation_Scholarships'] * 2 * 0.3
        )
        
        # حساب الدرجة النفسية
        psychological_score = (
            df['Student_Wellbeing_Score'] / 10 * 0.6 +
            np.clip(1 - df['Teacher_Burnout_Index'] / 10, 0, 1) * 0.4
        )
        
        # حساب الدرجة الشاملة الموزونة
        overall_score = (
            academic_score * academic_weight +
            engagement_score * engagement_weight +
            infrastructure_score * infrastructure_weight +
            human_capital_score * human_capital_weight +
            financial_score * financial_weight +
            psychological_score * psychological_weight
        )
        
        return np.clip(overall_score * 100, 0, 100)  # التأكد من أن النتيجة بين 0-100
    
    def generate_comprehensive_dataset(self):
        """
        ===========================================================================
        توليد مجموعة البيانات الشاملة
        ===========================================================================
        
        الوظيفة: إنشاء مجموعة بيانات متكاملة تجمع جميع أبعاد الأداء المدرسي
        
        العملية:
        1. توليد عامل جودة أساسي لضمان ارتباط واقعي
        2. إنشاء جميع فئات المقاييس
        3. دمج البيانات في DataFrame واحد
        4. حساب درجة الجودة الشاملة
        5. إضافة مقاييس مشتقة
        
        المخرجات: DataFrame يحتوي بيانات 1000+ مدرسة بـ 27+ ميزة
        
        الأهمية: يمثل الأساس الكامل لنظام التحليل والتنبؤ
        ===========================================================================
        """
        print(f"جاري توليد مجموعة البيانات الشاملة لـ {self.num_schools} مدرسة...")
        
        # توليد عامل جودة أساسي للارتباطات الواقعية
        base_quality = np.random.beta(2, 2, self.num_schools)  # توزيع واقعي للجودة
        
        # توليد جميع فئات المقاييس
        data = {}
        data.update(self.generate_basic_demographics())
        data.update(self.generate_academic_metrics(base_quality))
        data.update(self.generate_engagement_metrics(base_quality))
        data.update(self.generate_infrastructure_metrics(base_quality))
        data.update(self.generate_human_capital_metrics(base_quality))
        data.update(self.generate_financial_metrics(base_quality))
        data.update(self.generate_psychological_metrics(base_quality))
        
        # إنشاء DataFrame
        df = pd.DataFrame(data)
        
        # حساب درجة الجودة الشاملة
        df['Overall_School_Quality_Score'] = self.calculate_overall_quality_score(df)
        
        # إضافة مقاييس مشتقة
        df['Teacher_to_Student_Ratio'] = df['Teacher_Count'] / df['Student_Count']  # نسبة المعلمين للطلاب
        df['Budget_Efficiency_Score'] = df['Overall_School_Quality_Score'] / (df['Budget_Per_Student'] / 1000)  # كفاءة الميزانية
        
        # تقريب الأعمدة الرقمية
        numeric_columns = df.select_dtypes('number').columns
        for col in numeric_columns:
            if col != 'School_ID':
                df[col] = df[col].round(2)
        
        return df
    
    def save_dataset(self, df, filename='comprehensive_school_data.csv'):
        """
        ===========================================================================
        حفظ مجموعة البيانات
        ===========================================================================
        
        الوظيفة: حفظ البيانات في ملف CSV
        
        المعلمات:
        - df: DataFrame المراد حفظه
        - filename: اسم الملف الافتراضي
        
        العملية: إنشاء مجلد البيانات وحفظ الملف
        
        الأهمية: توفير البيانات للاستخدام في مراحل المشروع التالية
        ===========================================================================
        """
        # إنشاء مجلد البيانات إذا لم يكن موجوداً
        data_dir = os.path.join(os.path.dirname(os.path.dirname(os.path.abspath(__file__))), 'data', 'reference')
        os.makedirs(data_dir, exist_ok=True)
        
        filepath = os.path.join(data_dir, filename)
        df.to_csv(filepath, index=False)
        print(f"تم حفظ مجموعة البيانات في {filepath}")
        return filepath
    
    def display_summary_statistics(self, df):
        """
        ===========================================================================
        عرض إحصائيات موجزة
        ===========================================================================
        
        الوظيفة: عرض إحصائيات موجزة عن مجموعة البيانات
        
        المعلمات:
        - df: DataFrame المراد عرض إحصائياته
        
        الأهمية: توفير نظرة عامة عن مجموعة البيانات
        ===========================================================================
        """
        print("\n" + "="*80)
        print("ملخص مجموعة البيانات التعليمية الشاملة")
        print("="*80)
        print(f"شكل مجموعة البيانات: {df.shape}")
        print(f"عدد المدارس: {len(df)}")
        print(f"عدد الميزات: {len(df.columns)}")
        
        print(f"\nإحصائيات درجة الجودة الشاملة:")
        print(f"  المتوسط: {df['Overall_School_Quality_Score'].mean():.2f}")
        print(f"  الانحراف المعياري: {df['Overall_School_Quality_Score'].std():.2f}")
        print(f"  الحد الأدنى: {df['Overall_School_Quality_Score'].min():.2f}")
        print(f"  الحد الأعلى: {df['Overall_School_Quality_Score'].max():.2f}")
        print(f"  الوسيط: {df['Overall_School_Quality_Score'].median():.2f}")
        
        print(f"\nبيانات العينة (أول 3 مدارس):")
        print(df.head(3).to_string(index=False))
        
        # Display correlations with target variable
        numeric_cols = df.select_dtypes(include=[np.number]).columns
        correlations = df[numeric_cols].corr()['Overall_School_Quality_Score'].sort_values(ascending=False)
        
        print(f"\nأهم 10 ميزات مرتبطة بدرجة الجودة الشاملة:")
        print(correlations.head(11).to_string())  # 11 لأنه يشمل المتغير الهدف نفسه
        
        print("="*80)
        
        return correlations

def main():
    """
    ===============================================================================
    الدالة الرئيسية للتنفيذ
    ===============================================================================
    
    الوظيفة: تنفيذ عملية توليد البيانات بالكامل
    
    العملية:
    1. إنشاء مولد البيانات
    2. توليد مجموعة البيانات الشاملة
    3. عرض الإحصائيات الملخصة
    4. حفظ البيانات
    
    المخرجات: بيانات جاهزة للاستخدام في نظام الذكاء الاصطناعي
    ===============================================================================
    """
    generator = EducationalDataGenerator(num_schools=1000, random_seed=42)
    
    # توليد مجموعة البيانات
    df = generator.generate_comprehensive_dataset()
    
    # عرض الملخص الإحصائي
    correlations = generator.display_summary_statistics(df)
    
    # حفظ مجموعة البيانات
    filepath = generator.save_dataset(df)
    
    print(f"\n🎉 اكتمل توليد البيانات بنجاح!")
    print(f"📊 تم حفظ البيانات في: {filepath}")
    print(f"📈 تم توليد {len(df)} مدرسة بـ {len(df.columns)} ميزة")
    
    return df, correlations

if __name__ == "__main__":
    df, correlations = main()
