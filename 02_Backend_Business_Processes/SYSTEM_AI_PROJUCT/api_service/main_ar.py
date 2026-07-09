"""
===============================================================================
ملف: main_ar.py - خدمة واجهة برمجة التطبيقات التعليمية
===============================================================================

الغرض الأساسي:
-----------
هذا الملف يوفر خدمة REST API متكاملة لنظام التحليل التعليمي الذكي. يقوم
بتوفير نقاط نهاية لتحليل بيانات المدارس وتوليد خطط استراتيجية
لأصحاب المصلحة الأربعة: الطلاب، المعلمون، الإدارة المدرسية، ووزارة التعليم.

كيف يخدم المشروع:
----------------
1. يوفر واجهة قياسية للوصول إلى قدرات التحليل والتنبؤ
2. يربط بين مكونات النظام المختلفة (التعلم الآلي، التخطيط الاستراتيجي)
3. يوفر استجابات منظمة باللغة العربية
4. يدعم التوثيق التلقائي عبر Swagger UI

المميزات الرئيسية:
- نقطة نهاية رئيسية: /analyze-and-strategize (التحليل والتخطيط الشامل)
- نقاط نهاية مساعدة: /predict (التنبؤ)، /recommend (التوصيات)
- توثيق تفاعلي: Swagger UI و ReDoc
- معالجة الأخطاء الشاملة
- دعم اللغة العربية في جميع الاستجابات
===============================================================================
"""

from fastapi import FastAPI, HTTPException, BackgroundTasks
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel, Field
from typing import Dict, List, Any, Optional
import pandas as pd
import numpy as np
import json
import os
import sys
from datetime import datetime

# إضافة مسار المشروع إلى مسار Python
sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

# استيراد الوحدات
try:
    from strategy_engine.strategy_planner import EducationalStrategyPlanner
    from ml_core.model_trainer import EducationalModelTrainer
except ImportError as e:
    print(f"تحذير: لا يمكن استيراد الوحدات: {e}")
    # بديل للاختبار بدون الوحدات الكاملة
    EducationalStrategyPlanner = None
    EducationalModelTrainer = None

# تهيئة تطبيق FastAPI
app = FastAPI(
    title="واجهة التحليل التعليمي الذكي",
    description="نظام تحليل وتخطيط استراتيجي متقدم للمدارس",
    version="1.0.0",
    docs_url="/docs",
    redoc_url="/redoc"
)

# إضافة وسيط CORS
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# نماذج Pydantic للطلبات والاستجابات
class SchoolData(BaseModel):
    """
    ===============================================================================
    نموذج بيانات المدرسة
    ===============================================================================
    
    الغرض: التحقق من صحة بيانات المدرسة الواردة
    يستخدم: في جميع نقاط النهاية التي تتطلب بيانات المدرسة
    ===============================================================================
    """
    
    School_ID: str = Field(..., description="معرف المدرسة الفريد")
    Region: str = Field(..., description="المنطقة الجغرافية")
    School_Type: str = Field(..., description="نوع المدرسة (حكومية/خاصة/مجتمعية)")
    Student_Count: int = Field(..., ge=1, description="عدد الطلاب")
    Teacher_Count: int = Field(..., ge=1, description="عدد المعلمين")
    Term_1_Avg: float = Field(..., ge=0, le=100, description="متوسط درجات الفصل الأول")
    Term_2_Avg: float = Field(..., ge=0, le=100, description="متوسط درجات الفصل الثاني")
    STEM_Subject_Rate: float = Field(..., ge=0, le=100, description="معدل النجاح في المواد العلمية")
    Literacy_Rate: float = Field(..., ge=0, le=100, description="معدل القراءة")
    Failure_Risk_Index: float = Field(..., ge=0, le=100, description="مؤشر مخاطر الرسوب")
    Average_Attendance: float = Field(..., ge=0, le=100, description="معدل الحضور اليومي")
    Library_Usage_Hours: float = Field(..., ge=0, description="متوسط ساعات استخدام المكتبة")
    Extracurricular_Participation: float = Field(..., ge=0, le=100, description="نسبة المشاركة في الأنشطة اللامنهجية")
    LMS_Login_Frequency: float = Field(..., ge=0, description="تكرار تسجيل الدخول لنظام إدارة التعلم")
    Internet_Speed_Mbps: float = Field(..., ge=0, description="سرعة الإنترنت بالميجابت")
    Smart_Classroom_Ratio: float = Field(..., ge=0, le=1, description="نسبة الفصول الذكية")
    Lab_Equipment_Quality_Score: int = Field(..., ge=1, le=10, description="درجة جودة معدات المختبرات")
    Teacher_Turnover_Rate: float = Field(..., ge=0, le=100, description="معدل دوران المعلمين")
    Teacher_PhD_Ratio: float = Field(..., ge=0, le=1, description="نسبة المعلمين الحاصلين على الدكتوراه")
    Professional_Development_Hours_Per_Year: float = Field(..., ge=0, description="ساعات التطوير المهني السنوية")
    Budget_Per_Student: float = Field(..., ge=0, description="الميزانية لكل طالب")
    Budget_Allocation_IT: float = Field(..., ge=0, le=1, description="تخصيص الميزانية لتكنولوجيا المعلومات")
    Budget_Allocation_Scholarships: float = Field(..., ge=0, le=1, description="تخصيص الميزانية للمنح الدراسية")
    Regional_Economic_Index: float = Field(..., ge=0, le=1, description="المؤشر الاقتصادي الإقليمي")
    Student_Wellbeing_Score: float = Field(..., ge=1, le=10, description="مؤشر رفاهية الطلاب")
    Teacher_Burnout_Index: float = Field(..., ge=1, le=10, description="مؤشر إرهاق المعلمين")

class AnalysisResponse(BaseModel):
    """
    ===============================================================================
    نموذج استجابة التحليل
    ===============================================================================
    
    الغرض: تنظيم استجابة التحليل الشامل باللغة العربية
    يستخدم: في نقطة النهاية الرئيسية للتحليل والتخطيط
    ===============================================================================
    """
    
    success: bool = Field(..., description="نجاح العملية")
    timestamp: str = Field(..., description="وقت التحليل")
    school_id: str = Field(..., description="معرف المدرسة")
    predicted_score: float = Field(..., description="الدرجة المتوقعة")
    confidence_interval: Dict[str, float] = Field(..., description="فترة الثقة")
    critical_factors: List[str] = Field(..., description="العوامل الحرجة")
    feature_importance: Dict[str, float] = Field(..., description="أهمية الميزات")
    strategy_plan: Dict[str, Any] = Field(..., description="الخطة الاستراتيجية")
    processing_time_ms: float = Field(..., description="وقت المعالجة بالمللي ثانية")

class HealthResponse(BaseModel):
    """
    ===============================================================================
    نموذج استجابة الفحص الصحي
    ===============================================================================
    
    الغرض: توفير معلومات حالة النظام باللغة العربية
    ===============================================================================
    """
    
    status: str = Field(..., description="حالة النظام")
    timestamp: str = Field(..., description="وقت الفحص")
    version: str = Field(..., description="إصدار النظام")
    components: Dict[str, str] = Field(..., description="حالة المكونات")

# تهيئة المكونات
strategy_planner = EducationalStrategyPlanner() if EducationalStrategyPlanner else None
model_trainer = None

# تحميل النموذج المدرب مسبقاً
def load_model():
    """
    ===============================================================================
    تحميل النموذج المدرب
    ===============================================================================
    
    الوظيفة: تحميل النموذج المدرب والمعالجات المسبقة
    
    العملية: محاولة تحميل النموذج من الملفات المحفوظة
    
    الأهمية: توفير قدرات التنبؤ للاستخدام في الـ API
    ===============================================================================
    """
    global model_trainer
    try:
        model_trainer = EducationalModelTrainer(model_type='xgboost')
        
        # محاولة تحميل النموذج المحفوظ
        model_path = os.path.join(os.path.dirname(os.path.dirname(__file__)), 'models', 'xgboost_model.joblib')
        if os.path.exists(model_path):
            import joblib
            model_trainer.model = joblib.load(model_path)
            model_trainer.scaler = joblib.load(os.path.join(os.path.dirname(model_path), 'scaler.joblib'))
            model_trainer.label_encoders = joblib.load(os.path.join(os.path.dirname(model_path), 'label_encoders.joblib'))
            model_trainer.feature_names = joblib.load(os.path.join(os.path.dirname(model_path), 'feature_names.joblib'))
            model_trainer.feature_importance = joblib.load(os.path.join(os.path.dirname(model_path), 'feature_importance.joblib'))
            print("تم تحميل النموذج بنجاح")
            return True
        else:
            print("ملف النموذج غير موجود، سيتم استخدام تنبؤات وهمية")
            return False
    except Exception as e:
        print(f"خطأ في تحميل النموذج: {e}")
        return False

# تهيئة النموذج عند بدء التشغيل
@app.on_event("startup")
async def startup_event():
    """
    ===============================================================================
    حدث بدء تشغيل الـ API
    ===============================================================================
    
    الوظيفة: تهيئة مكونات الـ API عند البدء
    
    العملية: تحميل النموذج والتحقق من المكونات
    
    الأهمية: ضمان جاهزية النظام للاستخدام
    ===============================================================================
    """
    print("بدء تشغيل واجهة التحليل التعليمي الذكي...")
    load_model()
    print("اكتمل بدء تشغيل الـ API")

@app.get("/", response_model=HealthResponse)
async def root():
    """
    ===============================================================================
    نقطة النهاية الجذر
    ===============================================================================
    
    الوظيفة: توفير فحص صحي شامل للنظام
    
    المخرجات: حالة النظام والمكونات باللغة العربية
    
    الأهمية: نقطة بداية للتحقق من حالة النظام
    ===============================================================================
    """
    return HealthResponse(
        status="نشط",
        timestamp=datetime.now().isoformat(),
        version="1.0.0",
        components={
            "مخطط_الاستراتيجيات": "تشغيل" if strategy_planner else "بديل",
            "النموذج_الذكي": "محمل" if model_trainer and model_trainer.model else "وهمي",
            "محرك_البيانات": "جاهز"
        }
    )

@app.get("/health")
async def health_check():
    """
    ===============================================================================
    فحص صحي مفصل
    ===============================================================================
    
    الوظيفة: توفير معلومات تفصيلية عن حالة النظام
    
    المخرجات: حالة جميع المكونات ونقاط النهاية المتاحة
    
    الأهمية: مراقبة وتشخيص أداء النظام
    ===============================================================================
    """
    return {
        "status": "نشط",
        "timestamp": datetime.now().isoformat(),
        "version": "1.0.0",
        "components": {
            "مخطط_الاستراتيجيات": "تشغيل" if strategy_planner else "بديل",
            "النموذج_الذكي": "محمل" if model_trainer and model_trainer.model else "وهمي",
            "محرك_البيانات": "جاهز"
        },
        "endpoints": {
            "analyze_and_strategize": "/analyze-and-strategize",
            "predict": "/predict",
            "recommend": "/recommend",
            "docs": "/docs"
        }
    }

@app.post("/predict", response_model=Dict[str, Any])
async def predict_school_performance(school_data: SchoolData):
    """
    ===============================================================================
    نقطة نهاية التنبؤ بالأداء المدرسي
    ===============================================================================
    
    الوظيفة: التنبؤ بدرجة أداء المدرسة بناءً على البيانات
    
    المعلمات:
    - school_data: بيانات المدرسة الكاملة
    
    المخرجات: درجة متوقعة مع فترة ثقة
    
    الأهمية: توفير تقييم كمي للأداء المدرسي
    ===============================================================================
    """
    start_time = datetime.now()
    
    try:
        # تحويل إلى قاموس
        data_dict = school_data.dict()
        
        if model_trainer and model_trainer.model:
            # استخدام النموذج الحقيقي
            df = pd.DataFrame([data_dict])
            
            # المعالجة المسبقة
            X = df.drop(['School_ID'], axis=1)
            
            # معالجة المتغيرات الفئوية
            for col in X.select_dtypes(include=['object']).columns:
                if col in model_trainer.label_encoders:
                    X[col] = model_trainer.label_encoders[col].transform(X[col])
            
            # التأكد من ترتيب الميزات
            X = X[model_trainer.feature_names]
            
            # تحجيم الميزات
            X_scaled = model_trainer.scaler.transform(X)
            
            # التنبؤ
            prediction = model_trainer.model.predict(X_scaled)[0]
            
            # حساب فترة الثقة (مبسط)
            confidence = 5.0  # هامش ثقة وهمي
            
        else:
            # تنبؤ وهمي بناءً على المقاييس الرئيسية
            prediction = (
                data_dict['Term_1_Avg'] * 0.3 +
                data_dict['Term_2_Avg'] * 0.3 +
                data_dict['STEM_Subject_Rate'] * 0.2 +
                data_dict['Average_Attendance'] * 0.1 +
                data_dict['Student_Wellbeing_Score'] * 2
            ) / 2
            prediction = max(0, min(100, prediction))
            confidence = 8.0
        
        processing_time = (datetime.now() - start_time).total_seconds() * 1000
        
        return {
            "success": True,
            "school_id": data_dict['School_ID'],
            "predicted_score": round(float(prediction), 2),
            "confidence_interval": {
                "lower": max(0, round(float(prediction - confidence), 2)),
                "upper": min(100, round(float(prediction + confidence), 2))
            },
            "processing_time_ms": round(processing_time, 2)
        }
        
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"خطأ في التنبؤ: {str(e)}")

@app.post("/recommend", response_model=Dict[str, Any])
async def get_recommendations(school_data: SchoolData):
    """
    ===============================================================================
    نقطة نهاية التوصيات الاستراتيجية
    ===============================================================================
    
    الوظيفة: توليد توصيات استراتيجية للمدرسة
    
    المعلمات:
    - school_data: بيانات المدرسة الكاملة
    
    المخرجات: خطط استراتيجية لأصحاب المصلحة الأربعة
    
    الأهمية: توفير إرشادات عملية لتحسين الأداء
    ===============================================================================
    """
    start_time = datetime.now()
    
    try:
        data_dict = school_data.dict()
        
        if strategy_planner:
            # استخدام مخطط الاستراتيجيات الحقيقي
            strategy_plan = strategy_planner.generate_comprehensive_strategy(data_dict)
        else:
            # خطة استراتيجية وهمية
            strategy_plan = create_mock_strategy(data_dict)
        
        processing_time = (datetime.now() - start_time).total_seconds() * 1000
        
        return {
            "success": True,
            "school_id": data_dict['School_ID'],
            "strategy_plan": strategy_plan,
            "processing_time_ms": round(processing_time, 2)
        }
        
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"خطأ في التوصيات: {str(e)}")

@app.post("/analyze-and-strategize", response_model=AnalysisResponse)
async def analyze_and_strategize(school_data: SchoolData):
    """
    ===============================================================================
    نقطة النهاية الرئيسية: التحليل والتخطيط الشامل
    ===============================================================================
    
    الوظيفة: تحليل بيانات المدرسة وتوليد خطة استراتيجية شاملة
    
    المعلمات:
    - school_data: بيانات المدرسة الكاملة
    
    المخرجات:
    - درجة متوقعة مع فترة ثقة
    - العوامل الحرجة المؤثرة
    - أهمية الميزات
    - 4 خطط استراتيجية لأصحاب المصلحة
    
    الأهمية: نقطة النهاية المتكاملة التي تجمع كل قدرات النظام
    ===============================================================================
    """
    start_time = datetime.now()
    
    try:
        data_dict = school_data.dict()
        
        # الخطوة 1: التنبؤ بدرجة الأداء
        if model_trainer and model_trainer.model:
            df = pd.DataFrame([data_dict])
            X = df.drop(['School_ID'], axis=1)
            
            # معالجة المتغيرات الفئوية
            for col in X.select_dtypes(include=['object']).columns:
                if col in model_trainer.label_encoders:
                    X[col] = model_trainer.label_encoders[col].transform(X[col])
            
            X = X[model_trainer.feature_names]
            X_scaled = model_trainer.scaler.transform(X)
            prediction = model_trainer.model.predict(X_scaled)[0]
            feature_importance = model_trainer.feature_importance
        else:
            # تنبؤ وهمي
            prediction = (
                data_dict['Term_1_Avg'] * 0.3 +
                data_dict['Term_2_Avg'] * 0.3 +
                data_dict['STEM_Subject_Rate'] * 0.2 +
                data_dict['Average_Attendance'] * 0.1 +
                data_dict['Student_Wellbeing_Score'] * 2
            ) / 2
            prediction = max(0, min(100, prediction))
            
            # أهمية الميزات الوهمية
            feature_importance = {
                'Term_1_Avg': 0.15,
                'Term_2_Avg': 0.14,
                'STEM_Subject_Rate': 0.12,
                'Average_Attendance': 0.11,
                'Student_Wellbeing_Score': 0.10,
                'Budget_Per_Student': 0.09,
                'Teacher_PhD_Ratio': 0.08,
                'Internet_Speed_Mbps': 0.07,
                'Lab_Equipment_Quality_Score': 0.06,
                'Teacher_Burnout_Index': 0.05
            }
        
        # الخطوة 2: تحديد العوامل الحرجة
        critical_factors = identify_critical_factors(data_dict)
        
        # الخطوة 3: توليد الخطة الاستراتيجية
        if strategy_planner:
            strategy_plan = strategy_planner.generate_comprehensive_strategy(data_dict)
        else:
            strategy_plan = create_mock_strategy(data_dict)
        
        # الخطوة 4: حساب فترة الثقة
        confidence = 5.0 if model_trainer and model_trainer.model else 8.0
        
        processing_time = (datetime.now() - start_time).total_seconds() * 1000
        
        return AnalysisResponse(
            success=True,
            timestamp=datetime.now().isoformat(),
            school_id=data_dict['School_ID'],
            predicted_score=round(float(prediction), 2),
            confidence_interval={
                "lower": max(0, round(float(prediction - confidence), 2)),
                "upper": min(100, round(float(prediction + confidence), 2))
            },
            critical_factors=critical_factors,
            feature_importance=feature_importance,
            strategy_plan=strategy_plan,
            processing_time_ms=round(processing_time, 2)
        )
        
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"خطأ في التحليل: {str(e)}")

def identify_critical_factors(data_dict: Dict[str, Any]) -> List[str]:
    """
    ===============================================================================
    تحديد العوامل الحرجة المؤثرة
    ===============================================================================
    
    الوظيفة: تحديد العوامل الرئيسية التي تؤثر على أداء المدرسة
    
    المعلمات:
    - data_dict: بيانات المدرسة
    
    المخرجات: قائمة بالعوامل الحرجة
    
    الأهمية: تسليط الضوء على المشاكل الرئيسية التي تحتاج إلى حل
    ===============================================================================
    """
    factors = []
    
    # العوامل الأكاديمية
    if data_dict['STEM_Subject_Rate'] < 50:
        factors.append("انخفاض أداء المواد العلمية")
    if data_dict['Literacy_Rate'] < 60:
        factors.append("مخاوف في مستوى القراءة")
    if data_dict['Failure_Risk_Index'] > 25:
        factors.append("ارتفاع مخاطر الرسوب")
    
    # عوامل المشاركة
    if data_dict['Average_Attendance'] < 80:
        factors.append("انخفاض معدل الحضور")
    if data_dict['Student_Wellbeing_Score'] < 5:
        factors.append("مشاكل في رفاهية الطلاب")
    
    # عوامل البنية التحتية
    if data_dict['Internet_Speed_Mbps'] < 50:
        factors.append("بطء في سرعة الإنترنت")
    if data_dict['Lab_Equipment_Quality_Score'] < 5:
        factors.append("ضعف في جودة معدات المختبرات")
    
    # عوامل رأس المال البشري
    if data_dict['Teacher_Turnover_Rate'] > 20:
        factors.append("ارتفاع معدل دوران المعلمين")
    if data_dict['Teacher_Burnout_Index'] > 6:
        factors.append("ارتفاع مستوى إرهاق المعلمين")
    
    # العوامل المالية
    if data_dict['Budget_Per_Student'] < 3000:
        factors.append("انخفاض الميزانية للطالب")
    
    return factors

def create_mock_strategy(data_dict: Dict[str, Any]) -> Dict[str, Any]:
    """
    ===============================================================================
    إنشاء خطة استراتيجية وهمية
    ===============================================================================
    
    الوظيفة: توليد خطة استراتيجية بديلة عند عدم توفر المخطط الحقيقي
    
    المعلمات:
    - data_dict: بيانات المدرسة
    
    المخرجات: خطة استراتيجية هيكلية بالعربية
    
    الأهمية: ضمان عمل النظام حتى في حالة عدم توفر المكونات الكاملة
    ===============================================================================
    """
    return {
        'school_id': data_dict['School_ID'],
        'analysis_timestamp': datetime.now().isoformat(),
        'overall_quality_score': data_dict.get('Overall_School_Quality_Score', 75),
        'urgency_level': 'متوسطة',
        'total_issues_identified': 4,
        'stakeholder_strategies': {
            'students': {
                'priority_issues': ['يحتاج تحسين الأداء الأكاديمي'],
                'action_plans': ['برامج تعلمية مخصصة'],
                'resources': ['تراخيص برامج تعليمية'],
                'timeline': ['3-6 أشهر'],
                'expected_outcomes': ['تحسن 10-15% في الدرجات']
            },
            'teachers': {
                'priority_issues': ['يحتاج تطوير مهني'],
                'professional_development': ['تدريب على التكامل التكنولوجي'],
                'technology_support': ['أدوات الفصل الدراسي المعكوس'],
                'expected_outcomes': ['تحسين فعالية التدريس']
            },
            'administration': {
                'critical_issues': ['يحتاج تحسين البنية التحتية'],
                'infrastructure_investments': ['ترقية الشبكة'],
                'resource_allocation': ['زيادة ميزانية التكنولوجيا'],
                'implementation_timeline': ['6-12 شهراً']
            },
            'education_office': {
                'policy_recommendations': ['مراجعة توزيع الميزانية'],
                'funding_strategies': ['تقديم طلبات المنح'],
                'systemic_improvements': ['التعاون الإقليمي'],
                'implementation_roadmap': ['12-18 شهراً']
            }
        },
        'priority_ranking': {
            'students': 1,
            'teachers': 1,
            'administration': 1,
            'education_office': 1
        }
    }

if __name__ == "__main__":
    import uvicorn
    print("بدء تشغيل واجهة التحليل التعليمي الذكي...")
    uvicorn.run(app, host="0.0.0.0", port=8000, reload=True)
