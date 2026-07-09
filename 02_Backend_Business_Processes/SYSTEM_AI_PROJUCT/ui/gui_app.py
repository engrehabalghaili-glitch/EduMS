# -*- coding: utf-8 -*-
"""
===============================================
   نظام التحويل التعليمي بالذكاء الاصطناعي - واجهة المستخدم الرسومية
===============================================

# دليل الاستخدام - تفاصيل البيانات المطلوبة

## البيانات الدقيقة للإدخال في كل حقل:

### 1. المعلومات الأساسية
- اسم المدرسة: الاسم الرسمي الكامل للمؤسسة
- المنطقة: المنطقة الجغرافية التي توجد فيها المدرسة
- نوع المدرسة: حكومية، خاصة، أو مستقلة
- المراحل: رياض أطفال-5، 6-8، أو 9-12

### 2. البيانات الأكاديمية
- إجمالي عدد الطلاب: العدد الإجمالي الحالي
- عدد المعلمين: هيئة التدريس الدائمة
- متوسط درجات الرياضيات: المتوسط العام لدرجات الرياضيات
- متوسط درجات العلوم: المتوسط العام لدرجات العلوم
- متوسط درجات القراءة: المتوسط العام لدرجات القراءة
- متوسط درجات الكتابة: المتوسط العام لدرجات الكتابة
- معدل النجاح العام: نسبة الطلاب الناجحين

### 3. البيانات المالية
- الميزانية السنوية الإجمالية: الميزانية الإجمالية بالدولار/السنة
- الإنفاق لكل طالب: التكلفة السنوية لكل طالب
- متوسط رواتب المعلمين: الراتب السنوي المتوسط

### 4. البنية التحتية
- عدد الفصول الدراسية: إجمالي الفصول المتاحة
- المساحة الإجمالية: المساحة بالمتر المربع
- عدد المختبرات: مختبرات العلوم/الحاسوب
- عدد المكتبات: مساحات المكتبة
- الوصول للإنترنت: نعم/لا

### 5. المشاركة والحضور
- معدل الحضور: نسبة الحضور اليومي
- معدل المشاركة: المشاركة في الأنشطة
- عدد الأنشطة اللاصفية: الأندية والرياضة

### 6. الموارد البشرية
- نسبة المعلم إلى الطالب: عدد الطلاب لكل معلم
- معدل الاحتفاظ بالمعلمين: نسبة التجديد
- ساعات التدريب: التدريب المهني السنوي

### 7. العوامل النفسية
- درجة الرضا: استبيان الرضا (1-10)
- درجة الدافعية: مستوى الدافعية (1-10)
- درجة الرفاهية: الرفاهية العامة (1-10)

## أين تجد هذه البيانات:

### المصادر الأساسية:
1. **نظام معلومات المدرسة (SIS)**: البيانات الأكاديمية والديموغرافية
2. **التقارير المالية السنوية**: الميزانية والإنفاق
3. **سجلات الحضور**: بيانات الحضور
4. **التقييمات المعيارية**: الدرجات الأكاديمية
5. **الاستبيانات المدرسية**: الرضا والدافعية
6. **تقارير التفتيش**: البنية التحتية والموارد

### المصادر الثانوية:
1. **وزارة التربية والتعليم**: الإحصائيات الرسمية
2. **المنطقة التعليمية**: التقارير الموحدة
3. **دراسات السوق**: البيانات المقارنة
4. **الأبحاث الأكاديمية**: المعايير والأعراف

## التعليمات العملية:

### لإدخال مدرسة واحدة:
1. املأ جميع الحقول الإلزامية (*)
2. استخدم الأرقام الرقمية (لا تضع نص في الحقول الرقمية)
3. بالنسبة للنسب المئوية: استخدم 0.85 لـ 85%
4. بالنسبة للمبالغ: استخدم أرقام صحيحة (مثال: 50000)

### لاستيراد ملف:
1. جهز ملف Excel/CSV بنفس الأعمدة
2. استخدم نفس أسماء الأعمدة كما في النموذج
3. تأكد من اتساق تنسيقات البيانات
4. استورد الملف عبر زر "اختيار ملف"

## نصائح هامة:
- جودة التنبؤات تعتمد على جودة البيانات
- البيانات المفقودة أو غير الصحيحة تؤثر على النتائج
- استخدم بيانات حديثة للتنبؤات الدقيقة
- تحقق من الاتساق قبل الإرسال

===============================================
"""

import streamlit as st
import pandas as pd
import numpy as np
import joblib
import plotly.express as px
import plotly.graph_objects as go
from plotly.subplots import make_subplots
import arabic_reshaper
from bidi.algorithm import get_display
import warnings
import os
import sys
warnings.filterwarnings('ignore')

# إضافة مسار المشروع للوصول إلى core/
sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

# إعداد الصفحة
st.set_page_config(
    page_title="نظام التحويل التعليمي بالذكاء الاصطناعي",
    page_icon="schools",
    layout="wide",
    initial_sidebar_state="expanded"
)

# نمط CSS للواجهة العربية
st.markdown("""
<style>
    .rtl {
        direction: rtl;
        text-align: right;
        font-family: 'Arial', sans-serif;
    }
    .arabic-title {
        font-size: 2.5rem;
        font-weight: bold;
        color: #1f77b4;
        text-align: center;
        margin-bottom: 2rem;
    }
    .arabic-subtitle {
        font-size: 1.5rem;
        font-weight: bold;
        color: #ff7f0e;
        text-align: center;
        margin-bottom: 1rem;
    }
    .metric-card {
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        padding: 1.5rem;
        border-radius: 10px;
        color: white;
        text-align: center;
        margin: 0.5rem 0;
    }
    .section-header {
        background: linear-gradient(90deg, #1f77b4, #ff7f0e);
        padding: 1rem;
        border-radius: 10px;
        color: white;
        margin: 1rem 0;
        text-align: center;
    }
    .success-message {
        background-color: #d4edda;
        border: 1px solid #c3e6cb;
        color: #155724;
        padding: 1rem;
        border-radius: 5px;
        margin: 1rem 0;
    }
    .warning-message {
        background-color: #fff3cd;
        border: 1px solid #ffeaa7;
        color: #856404;
        padding: 1rem;
        border-radius: 5px;
        margin: 1rem 0;
    }
    .error-message {
        background-color: #f8d7da;
        border: 1px solid #f5c6cb;
        color: #721c24;
        padding: 1rem;
        border-radius: 5px;
        margin: 1rem 0;
    }
</style>
""", unsafe_allow_html=True)

# دالة لعرض النص العربي بشكل صحيح
def arabic_text(text):
    if text:
        reshaped_text = arabic_reshaper.reshape(text)
        return get_display(reshaped_text)
    return text

# دالة لتحميل النماذج
@st.cache_resource
def load_models():
    try:
        # التحقق من وجود مجلد النماذج
        models_dir = 'models'
        if not os.path.exists(models_dir):
            st.error(f"مجلد النماذج غير موجود: {models_dir}")
            return None
        
        # التحقق من ملفات النماذج المطلوبة
        required_files = [
            'randomforest_model.joblib',
            'xgboost_model.joblib', 
            'scaler.joblib',
            'label_encoders.joblib',
            'feature_names.joblib',
            'feature_importance.joblib'
        ]
        
        missing_files = []
        for file in required_files:
            if not os.path.exists(os.path.join(models_dir, file)):
                missing_files.append(file)
        
        if missing_files:
            st.error(f"ملفات النماذج المفقودة: {', '.join(missing_files)}")
            st.info("يرجى تشغيل التدريب أولاً لإنشاء ملفات النماذج المطلوبة.")
            return None
        
        models = {}
        models['rf'] = joblib.load(os.path.join(models_dir, 'randomforest_model.joblib'))
        models['xgb'] = joblib.load(os.path.join(models_dir, 'xgboost_model.joblib'))
        models['scaler'] = joblib.load(os.path.join(models_dir, 'scaler.joblib'))
        models['label_encoders'] = joblib.load(os.path.join(models_dir, 'label_encoders.joblib'))
        models['feature_names'] = joblib.load(os.path.join(models_dir, 'feature_names.joblib'))
        models['feature_importance'] = joblib.load(os.path.join(models_dir, 'feature_importance.joblib'))
        
        st.success("تم تحميل النماذج بنجاح!")
        return models
    except Exception as e:
        st.error(f"خطأ في تحميل النماذج: {e}")
        return None

# دالة لتحضير البيانات
def prepare_data(input_data, models):
    try:
        # التحويل إلى DataFrame
        if isinstance(input_data, dict):
            df = pd.DataFrame([input_data])
        else:
            df = input_data.copy()
        
        # تحويل القيم العربية إلى الإنجليزية
        arabic_to_english = {
            'Region': {
                'شمال': 'North',
                'جنوب': 'South',
                'شرق': 'East',
                'غرب': 'West',
                'وسط': 'Central'
            },
            'School_Type': {
                'حكومية': 'Public',
                'خاصة': 'Private',
                'مستقلة': 'Charter'
            },
            'Grades': {
                'رياض أطفال-5': 'K-5',
                '6-8': '6-8',
                '9-12': '9-12'
            },
            'Curriculum': {
                'وطني': 'National',
                'دولي': 'International',
                'مهني': 'Vocational'
            }
        }
        
        # تطبيق التحويل
        for col, mapping in arabic_to_english.items():
            if col in df.columns:
                df[col] = df[col].map(mapping).fillna(df[col])
        
        # ترميز المتغيرات الفئوية
        for col in df.select_dtypes('object').columns:
            if col in models['label_encoders']:
                df[col] = models['label_encoders'][col].transform(df[col])
        
        # التأكد من وجود جميع الأعمدة المطلوبة
        for col in models['feature_names']:
            if col not in df.columns:
                df[col] = 0
        
        # إعادة ترتيب الأعمدة
        df = df[models['feature_names']]
        
        # التقييس
        df_scaled = models['scaler'].transform(df)
        
        return df_scaled
    except Exception as e:
        st.error(f"خطأ أثناء تحضير البيانات: {e}")
        return None

# دالة لعمل التنبؤات
def predict_school_performance(input_data, models):
    try:
        # تحضير البيانات
        data_scaled = prepare_data(input_data, models)
        if data_scaled is None:
            return None
        
        # التنبؤات
        rf_pred = models['rf'].predict(data_scaled)[0]
        xgb_pred = models['xgb'].predict(data_scaled)[0]
        
        # متوسط التنبؤات
        avg_pred = (rf_pred + xgb_pred) / 2
        
        return {
            'random_forest': rf_pred,
            'xgboost': xgb_pred,
            'average': avg_pred
        }
    except Exception as e:
        st.error(f"خطأ أثناء التنبؤ: {e}")
        return None

# دالة لإنشاء التوصيات الاستراتيجية
def generate_strategic_recommendations(prediction, input_data):
    score = prediction['average']
    
    # تحديد مستوى الأداء
    if score >= 80:
        level = "ممتاز"
        color = "#28a745"
    elif score >= 60:
        level = "جيد"
        color = "#ffc107"
    elif score >= 40:
        level = "متوسط"
        color = "#fd7e14"
    else:
        level = "يحتاج تحسين"
        color = "#dc3545"
    
    # إنشاء توصيات ديناميكية بناءً على البيانات الفعلية
    student_actions = []
    teacher_actions = []
    admin_actions = []
    
    # تحليل البيانات الأكاديمية
    math_score = input_data.get('Math_Score', 0)
    science_score = input_data.get('Science_Score', 0)
    reading_score = input_data.get('Reading_Score', 0)
    writing_score = input_data.get('Writing_Score', 0)
    
    if math_score < 60:
        student_actions.append("برامج تقوية في الرياضيات")
        teacher_actions.append("تدريب خاص على طرق تدريس الرياضيات")
    if science_score < 60:
        student_actions.append("مختبرات علوم تفاعلية")
        teacher_actions.append("ورش عمل علوم عملية")
    if reading_score < 60:
        student_actions.append("برامج تحسين القراءة")
        admin_actions.append("شراء كتب ومواد قراءة")
    if writing_score < 60:
        student_actions.append("ورش كتابة إبداعية")
        teacher_actions.append("تدريب على تصحيح الإملاء والنحو")
    
    # تحليل المشاركة والحضور
    attendance_rate = input_data.get('Attendance_Rate', 0)
    participation_rate = input_data.get('Participation_Rate', 0)
    
    if attendance_rate < 85:
        student_actions.append("برامج تحفيز الحضور")
        admin_actions.append("نظام مراقبة الحضور الآلي")
    if participation_rate < 70:
        student_actions.append("أنشطة تفاعلية إضافية")
        admin_actions.append("توسيع برامج الأنشطة اللاصفية")
    
    # تحليل الموارد المالية
    annual_budget = input_data.get('Annual_Budget', 0)
    per_student_spending = input_data.get('Per_Student_Spending', 0)
    
    if per_student_spending < 5000:
        admin_actions.append("زيادة ميزانية الطالب")
        admin_actions.append("البحث عن مصادر تمويل إضافية")
    if annual_budget < 500000:
        admin_actions.append("تطوير خطة مالية طويلة المدى")
        admin_actions.append("تطبيق كفاءة الإنفاق")
    
    # تحليل البنية التحتية
    lab_count = input_data.get('Lab_Count', 0)
    library_count = input_data.get('Library_Count', 0)
    internet_access = input_data.get('Internet_Access', 0)
    
    if lab_count < 2:
        admin_actions.append("بناء مختبرات إضافية")
        admin_actions.append("تجهيز المختبرات الحديثة")
    if library_count < 1:
        admin_actions.append("إنشاء مكتبة مدرسية")
        admin_actions.append("شراء كتب وموادر تعليمية")
    if internet_access == 0:
        admin_actions.append("توفير إنترنت عالي السرعة")
        admin_actions.append("تجهيز فصول ذكية")
    
    # تحليل الموارد البشرية
    teacher_student_ratio = input_data.get('Teacher_Student_Ratio', 0)
    teacher_retention_rate = input_data.get('Teacher_Retention_Rate', 0)
    training_hours = input_data.get('Training_Hours', 0)
    
    if teacher_student_ratio > 25:
        admin_actions.append("توظيف معلمين إضافيين")
        admin_actions.append("تقليل حجم الفصول الدراسية")
    if teacher_retention_rate < 80:
        admin_actions.append("تحسين رواتب المعلمين")
        admin_actions.append("توفير مزايا إضافية للمعلمين")
    if training_hours < 20:
        teacher_actions.append("زيادة ساعات التدريب المهني")
        teacher_actions.append("برامج تطوير مهني مستمر")
    
    # تحليل العوامل النفسية
    satisfaction_score = input_data.get('Satisfaction_Score', 0)
    
    if satisfaction_score < 6:
        student_actions.append("برامج دعم نفسي")
        admin_actions.append("استبيانات رضا منتظمة")
        teacher_actions.append("ورش عمل الصحة النفسية")
    
    # إذا لم تكن هناك توصيات محددة، أضف توصيات عامة
    if not student_actions:
        student_actions = ["برامج تعليمية شخصية", "أنشطة تقوية أكاديمية", "مجموعات دراسية مشرفة"]
    if not teacher_actions:
        teacher_actions = ["تدريب تعليمي مستمر", "ورش عمل حول طرق التدريس الجديدة", "التعاون متعدد التخصصات"]
    if not admin_actions:
        admin_actions = ["تحسين الموارد المالية", "تخطيط استراتيجي طويل المدى", "تحسين البنية التحتية"]
    
    # إنشاء التوصيات
    recommendations = {
        "student": {
            "title": "استراتيجية للطلاب",
            "actions": student_actions
        },
        "teacher": {
            "title": "استراتيجية للمعلمين",
            "actions": teacher_actions
        },
        "administration": {
            "title": "استراتيجية للإدارة",
            "actions": admin_actions
        },
        "library": {
            "title": "استراتيجية للمكتبة",
            "actions": [
                "إثراء المجموعات الرقمية",
                "برامج محو الأمية الرقمية",
                "مساحات تعليمية تعاونية",
                "خدمات بحث متقدمة"
            ]
        }
    }
    
    return recommendations, level, color

# الواجهة الرئيسية
def main():
    # العنوان الرئيسي
    st.markdown('<h1 class="arabic-title">نظام التحويل التعليمي بالذكاء الاصطناعي</h1>', unsafe_allow_html=True)
    st.markdown('<h2 class="arabic-subtitle">AI Educational Transformation System</h2>', unsafe_allow_html=True)
    
    # الشريط الجانبي
    st.sidebar.markdown("### القائمة الرئيسية")
    page = st.sidebar.selectbox(
        "اختر صفحة:",
        ["الرئيسية", "تحليل مدرسة", "تحليل ملف", "حول النظام"]
    )
    
    # تحميل النماذج
    models = load_models()
    if models is None:
        st.error("تعذر تحميل النماذج. يرجى التأكد من وجود ملفات النماذج.")
        st.info("لإنشاء النماذج، قم بتشغيل: python scripts/train_models.py")
        return
    
    if page == "الرئيسية":
        show_home_page()
    elif page == "تحليل مدرسة":
        show_single_school_analysis(models)
    elif page == "تحليل ملف":
        show_batch_analysis(models)
    elif page == "حول النظام":
        show_about_page()

def show_home_page():
    st.markdown('<div class="section-header">مرحباً بك في نظام التحويل التعليمي</div>', unsafe_allow_html=True)
    
    col1, col2 = st.columns(2)
    
    with col1:
        st.markdown("### ما هو هذا النظام؟")
        st.write("""
        يستخدم هذا النظام الذكاء الاصطناعي لـ:
        - تحليل أداء المدارس
        - تحديد عوامل التحسين
        - إنشاء توصيات استراتيجية
        - التنبؤ بالاتجاهات المستقبلية
        """)
        
        st.markdown("### كيفية الاستخدام؟")
        st.write("""
        1. أدخل بيانات مدرسة يدوياً
        2. أو استورد ملف Excel/CSV
        3. احصل على تحليل شامل وتوصيات
        """)
    
    with col2:
        st.markdown("### الميزات الرئيسية")
        st.write("""
        - تحليل متقدم بالذكاء الاصطناعي
        - تصورات تفاعلية
        - توصيات شخصية
        - دعم متعدد اللغات
        - واجهة سهلة الاستخدام
        """)
        
        st.markdown("### البيانات المطلوبة")
        st.write("""
        - معلومات أكاديمية
        - بيانات مالية
        - بنية تحتية
        - مشاركة الطلاب
        - موارد بشرية
        """)

def show_single_school_analysis(models):
    st.markdown('<div class="section-header">تحليل مدرسة فردية</div>', unsafe_allow_html=True)
    
    # نموذج الإدخال
    with st.form("school_data_form"):
        st.markdown("### المعلومات الأساسية")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            school_name = st.text_input("اسم المدرسة*", "مدرسة مثال")
            region = st.selectbox("المنطقة", ["شمال", "جنوب", "شرق", "غرب", "وسط"])
            school_type = st.selectbox("نوع المدرسة", ["حكومية", "خاصة", "مستقلة"])
        
        with col2:
            grades = st.selectbox("المراحل", ["رياض أطفال-5", "6-8", "9-12"])
            curriculum = st.selectbox("المنهج", ["وطني", "دولي", "مهني"])
            total_students = st.number_input("إجمالي عدد الطلاب*", min_value=1, value=500)
        
        with col3:
            total_teachers = st.number_input("عدد المعلمين*", min_value=1, value=30)
            total_classrooms = st.number_input("عدد الفصول الدراسية", min_value=1, value=20)
            total_area = st.number_input("المساحة الإجمالية (م²)", min_value=100, value=5000)
        
        st.markdown("### البيانات الأكاديمية")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            math_score = st.slider("متوسط درجات الرياضيات", 0, 100, 70)
            science_score = st.slider("متوسط درجات العلوم", 0, 100, 75)
        
        with col2:
            reading_score = st.slider("متوسط درجات القراءة", 0, 100, 65)
            writing_score = st.slider("متوسط درجات الكتابة", 0, 100, 68)
        
        with col3:
            success_rate = st.slider("معدل النجاح (%)", 0, 100, 85)
            attendance_rate = st.slider("معدل الحضور (%)", 0, 100, 92)
        
        st.markdown("### البيانات المالية")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            annual_budget = st.number_input("الميزانية السنوية الإجمالية ($)", min_value=1000, value=1000000)
            per_student_spending = st.number_input("الإنفاق لكل طالب ($)", min_value=100, value=8000)
        
        with col2:
            teacher_salary = st.number_input("متوسط رواتب المعلمين ($)", min_value=10000, value=45000)
            lab_count = st.number_input("عدد المختبرات", min_value=0, value=3)
        
        with col3:
            library_count = st.number_input("عدد المكتبات", min_value=0, value=1)
            internet_access = st.selectbox("الوصول للإنترنت", [1, 0], format_func=lambda x: "نعم" if x == 1 else "لا")
        
        st.markdown("### المشاركة والموارد")
        col1, col2, col3 = st.columns(3)
        
        with col1:
            participation_rate = st.slider("معدل المشاركة (%)", 0, 100, 78)
            extracurricular_count = st.number_input("الأنشطة اللاصفية", min_value=0, value=10)
        
        with col2:
            teacher_student_ratio = st.number_input("نسبة المعلم إلى الطالب", min_value=1, max_value=50, value=17)
            teacher_retention_rate = st.slider("معدل الاحتفاظ بالمعلمين (%)", 0, 100, 88)
        
        with col3:
            training_hours = st.number_input("ساعات التدريب السنوية", min_value=0, value=40)
            satisfaction_score = st.slider("درجة الرضا (1-10)", 1, 10, 7)
        
        # زر الإرسال
        submitted = st.form_submit_button("تحليل المدرسة", use_container_width=True)
        
        if submitted:
            # تحضير البيانات
            input_data = {
                'School_Name': school_name,
                'Region': region,
                'School_Type': school_type,
                'Grades': grades,
                'Curriculum': curriculum,
                'Total_Students': total_students,
                'Total_Teachers': total_teachers,
                'Total_Classrooms': total_classrooms,
                'Total_Area': total_area,
                'Math_Score': math_score,
                'Science_Score': science_score,
                'Reading_Score': reading_score,
                'Writing_Score': writing_score,
                'Success_Rate': success_rate,
                'Attendance_Rate': attendance_rate,
                'Annual_Budget': annual_budget,
                'Per_Student_Spending': per_student_spending,
                'Teacher_Salary': teacher_salary,
                'Lab_Count': lab_count,
                'Library_Count': library_count,
                'Internet_Access': internet_access,
                'Participation_Rate': participation_rate,
                'Extracurricular_Count': extracurricular_count,
                'Teacher_Student_Ratio': teacher_student_ratio,
                'Teacher_Retention_Rate': teacher_retention_rate,
                'Training_Hours': training_hours,
                'Satisfaction_Score': satisfaction_score
            }
            
            # عمل التنبؤ
            with st.spinner("جاري التحليل..."):
                prediction = predict_school_performance(input_data, models)
            
            if prediction:
                # تخزين النتائج في session state
                st.session_state['prediction'] = prediction
                st.session_state['input_data'] = input_data
                st.session_state['school_name'] = school_name
                st.session_state['models'] = models
                st.session_state['show_results'] = True
    
    # عرض النتائج خارج النموذج
    if st.session_state.get('show_results', False):
        display_results(
            st.session_state['prediction'],
            st.session_state['input_data'],
            st.session_state['school_name'],
            st.session_state['models']
        )

def show_batch_analysis(models):
    st.markdown('<div class="section-header">تحليل الملفات</div>', unsafe_allow_html=True)
    
    # رفع الملف
    uploaded_file = st.file_uploader(
        "اختر ملف Excel أو CSV",
        type=['xlsx', 'xls', 'csv'],
        help="يجب أن يحتوي الملف على نفس الأعمدة في نموذج الإدخال اليدوي"
    )
    
    if uploaded_file is not None:
        try:
            # قراءة الملف
            if uploaded_file.name.endswith('.csv'):
                df = pd.read_csv(uploaded_file)
            else:
                df = pd.read_excel(uploaded_file)
            
            st.success(f"تم تحميل الملف بنجاح! تم العثور على {len(df)} مدرسة.")
            
            # عرض معاينة
            st.markdown("### معاينة البيانات")
            st.dataframe(df.head())
            
            # التحليل
            if st.button("تحليل جميع المدارس", use_container_width=True):
                with st.spinner("جاري التحليل..."):
                    results = []
                    for index, row in df.iterrows():
                        input_data = row.to_dict()
                        prediction = predict_school_performance(input_data, models)
                        if prediction:
                            results.append({
                                'school_name': input_data.get('School_Name', f'مدرسة {index+1}'),
                                'prediction': prediction['average']
                            })
                    
                    if results:
                        display_batch_results(results)
        
        except Exception as e:
            st.error(f"خطأ أثناء قراءة الملف: {e}")
    
    # التعليمات
    st.markdown("### تعليمات للملف")
    st.info("""
    يجب أن يحتوي الملف على الأعمدة التالية:
    - School_Name (اسم المدرسة)
    - Region (المنطقة)
    - School_Type (نوع المدرسة)
    - Grades (المراحل)
    - Curriculum (المنهج)
    - Total_Students (إجمالي عدد الطلاب)
    - Total_Teachers (عدد المعلمين)
    - Total_Classrooms (عدد الفصول الدراسية)
    - Total_Area (المساحة الإجمالية)
    - Math_Score (متوسط درجات الرياضيات)
    - Science_Score (متوسط درجات العلوم)
    - Reading_Score (متوسط درجات القراءة)
    - Writing_Score (متوسط درجات الكتابة)
    - Success_Rate (معدل النجاح)
    - Attendance_Rate (معدل الحضور)
    - Annual_Budget (الميزانية السنوية الإجمالية)
    - Per_Student_Spending (الإنفاق لكل طالب)
    - Teacher_Salary (متوسط رواتب المعلمين)
    - Lab_Count (عدد المختبرات)
    - Library_Count (عدد المكتبات)
    - Internet_Access (الوصول للإنترنت)
    - Participation_Rate (معدل المشاركة)
    - Extracurricular_Count (الأنشطة اللاصفية)
    - Teacher_Student_Ratio (نسبة المعلم إلى الطالب)
    - Teacher_Retention_Rate (معدل الاحتفاظ بالمعلمين)
    - Training_Hours (ساعات التدريب السنوية)
    - Satisfaction_Score (درجة الرضا)
    """)

def display_results(prediction, input_data, school_name, models):
    st.markdown('<div class="section-header">نتائج التحليل</div>', unsafe_allow_html=True)
    
    # النتيجة الرئيسية
    col1, col2, col3 = st.columns([1, 2, 1])
    
    with col1:
        st.empty()
    
    with col2:
        # عداد الأداء
        fig = go.Figure(go.Indicator(
            mode = "gauge+number+delta",
            value = prediction['average'],
            domain = {'x': [0, 1], 'y': [0, 1]},
            title = {'text': f"درجة الأداء - {school_name}"},
            delta = {'reference': 70},
            gauge = {
                'axis': {'range': [None, 100]},
                'bar': {'color': "darkblue"},
                'steps': [
                    {'range': [0, 40], 'color': "lightgray"},
                    {'range': [40, 70], 'color': "gray"},
                    {'range': [70, 100], 'color': "lightgreen"}
                ],
                'threshold': {
                    'line': {'color': "red", 'width': 4},
                    'thickness': 0.75,
                    'value': 90
                }
            }
        ))
        
        fig.update_layout(height=400)
        st.plotly_chart(fig, use_container_width=True)
    
    with col3:
        st.empty()
    
    # التوصيات الاستراتيجية
    recommendations, level, color = generate_strategic_recommendations(prediction, input_data)
    
    st.markdown("### التوصيات الاستراتيجية")
    
    # عرض التوصيات حسب الفئة
    for key, rec in recommendations.items():
        with st.expander(rec['title']):
            for action in rec['actions']:
                st.write(f"  - {action}")
    
    # أهمية الخصائص
    st.markdown("### العوامل الرئيسية للأداء")
    
    feature_importance = models['feature_importance']
    feature_names = models['feature_names']
    
    # تحويل feature_importance من dict إلى list إذا لزم الأمر
    if isinstance(feature_importance, dict):
        # التأكد من أن feature_names هي list
        if isinstance(feature_names, list):
            importance_values = [feature_importance.get(name, 0) for name in feature_names]
        else:
            importance_values = list(feature_importance.values())
            feature_names = list(feature_importance.keys())
    else:
        importance_values = feature_importance
    
    importance_df = pd.DataFrame({
        'feature': feature_names,
        'importance': importance_values
    }).sort_values('importance', ascending=False).head(10)
    
    fig = px.bar(
        importance_df,
        x='importance',
        y='feature',
        orientation='h',
        title="أهم 10 عوامل مؤثرة"
    )
    fig.update_layout(height=400)
    st.plotly_chart(fig, use_container_width=True)
    
    # تصدير النتائج
    st.markdown("### تصدير النتائج")
    
    results_df = pd.DataFrame({
        'المدرسة': [school_name],
        'درجة_RF': [prediction['random_forest']],
        'درجة_XGB': [prediction['xgboost']],
        'المتوسط': [prediction['average']],
        'المستوى': [level]
    })
    
    csv = results_df.to_csv(index=False)
    st.download_button(
        label="تحميل النتائج (CSV)",
        data=csv,
        file_name=f"results_{school_name}.csv",
        mime="text/csv"
    )

def display_batch_results(results):
    st.markdown('<div class="section-header">نتائج التحليل بالدفعة</div>', unsafe_allow_html=True)
    
    # DataFrame النتائج
    results_df = pd.DataFrame(results)
    
    # الإحصائيات
    col1, col2, col3, col4 = st.columns(4)
    
    with col1:
        st.metric("المدارس المحللة", len(results))
    
    with col2:
        avg_score = results_df['prediction'].mean()
        st.metric("المتوسط", f"{avg_score:.2f}")
    
    with col3:
        max_score = results_df['prediction'].max()
        st.metric("أعلى درجة", f"{max_score:.2f}")
    
    with col4:
        min_score = results_df['prediction'].min()
        st.metric("أدنى درجة", f"{min_score:.2f}")
    
    # رسم بياني للنتائج
    fig = px.histogram(
        results_df,
        x='prediction',
        nbins=20,
        title="توزيع درجات الأداء"
    )
    fig.update_layout(height=400)
    st.plotly_chart(fig, use_container_width=True)
    
    # جدول النتائج
    st.markdown("### النتائج التفصيلية")
    st.dataframe(results_df)
    
    # التصدير
    csv = results_df.to_csv(index=False)
    st.download_button(
        label="تحميل جميع النتائج (CSV)",
        data=csv,
        file_name="batch_results.csv",
        mime="text/csv"
    )

def show_about_page():
    st.markdown('<div class="section-header">حول النظام</div>', unsafe_allow_html=True)
    
    st.markdown("### ما هو نظام التحويل التعليمي بالذكاء الاصطناعي؟")
    st.write("""
    يستخدم هذا النظام الذكاء الاصطناعي لتحليل وتحسين أداء المدارس.
    يجمع بين تقنيات التعلم الآلي المتقدمة مع واجهة سهلة الاستخدام لتوفير
    تحليلات شاملة وتوصيات قابلة للتنفيذ.
    """)
    
    st.markdown("### الميزات الرئيسية")
    st.write("""
    - **التحليل التنبؤي**: يستخدم Random Forest و XGBoost للتنبؤات الدقيقة
    - **واجهة سهلة الاستخدام**: سهلة الاستخدام للمعلمين والمسؤولين
    - **دعم متعدد اللغات**: واجهة عربية مع دعم اللغات الأخرى
    - **تصورات تفاعلية**: رسوم بيانية ولوحات معلومات ديناميكية
    - **توصيات شخصية**: استراتيجيات مصممة خصيصاً لكل مدرسة
    """)
    
    st.markdown("### التقنيات المستخدمة")
    st.write("""
    - **التعلم الآلي**: Random Forest، XGBoost
    - **الواجهة**: Streamlit
    - **التصورات**: Plotly
    - **المعالجة**: Pandas، NumPy
    - **النشر**: Python، Joblib
    """)
    
    st.markdown("### للتواصل")
    st.write("""
    لمزيد من المعلومات أو للحصول على دعم فني،
    يرجى الاتصال بفريق التطوير.
    """)

if __name__ == "__main__":
    main()
