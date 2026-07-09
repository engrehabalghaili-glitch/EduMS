"""
سكربت تدريب النماذج
====================
هذا السكربت يستخدم لتدريب نماذج التعلم الآلي للنظام.

المتطلبات:
- وجود ملف البيانات في data/reference/comprehensive_school_data.csv
- المكتبات المطلوبة في requirements.txt

الاستخدام:
    python scripts/train_models.py
"""

import sys  # استيراد مكتبة sys للتعامل مع مسارات النظام
import os  # استيراد مكتبة os للتعامل مع نظام الملفات

# إضافة مسار المشروع إلى sys.path
sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))  # إضافة المسار الأب للسكربت إلى مسارات البحث

from core.model_trainer import EducationalModelTrainer, train_and_save_models  # استيراد فئات تدريب النماذج من core/

def main():  # تعريف الدالة الرئيسية
    """الدالة الرئيسية لتدريب النماذج"""  # وصف الدالة
    print("=" * 60)  # طباعة خط فاصل
    print("بدء تدريب نماذج التعلم الآلي")  # طباعة رسالة البدء
    print("=" * 60)  # طباعة خط فاصل
    
    # مسار ملف البيانات
    data_path = 'data/reference/comprehensive_school_data.csv'  # تحديد مسار ملف البيانات
    
    # التحقق من وجود ملف البيانات
    if not os.path.exists(data_path):  # التحقق من وجود الملف
        print(f"خطأ: ملف البيانات غير موجود: {data_path}")  # طباعة رسالة خطأ
        print("يرجى التأكد من وجود ملف البيانات في المسار الصحيح")  # طباعة رسالة توجيه
        return  # إنهاء الدالة
    
    # تدريب وحفظ النماذج
    try:  # محاولة تنفيذ الكود
        train_and_save_models(data_path)  # استدعاء دالة تدريب وحفظ النماذج
        print("\n" + "=" * 60)  # طباعة خط فاصل
        print("تم تدريب النماذج وحفظها بنجاح!")  # طباعة رسالة نجاح
        print("=" * 60)  # طباعة خط فاصل
    except Exception as e:  # التقاط أي خطأ
        print(f"\nخطأ أثناء التدريب: {e}")  # طباعة رسالة الخطأ
        return  # إنهاء الدالة

if __name__ == "__main__":  # التحقق من تشغيل السكربت مباشرة
    main()  # استدعاء الدالة الرئيسية
