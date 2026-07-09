import os
import shutil

# المسارات
models_dir = r'c:\Users\Elite\Desktop\SYSTEM_AI_PROJUCT\models'
fake_file = os.path.join(models_dir, 'random_forest_model.joblib')
real_file = os.path.join(models_dir, 'randomforest_model.joblib')

print("=== إصلاح ملفات النماذج ===")
print(f"مجلد النماذج: {models_dir}")

# حذف الملف الوهمي
if os.path.exists(fake_file):
    size = os.path.getsize(fake_file)
    print(f"\n1. حذف الملف الوهمي: random_forest_model.joblib ({size} bytes)")
    try:
        os.remove(fake_file)
        print("   ✓ تم الحذف")
    except Exception as e:
        print(f"   ✗ فشل الحذف: {e}")
else:
    print("\n1. الملف الوهمي غير موجود")

# نسخ الملف الحقيقي
if os.path.exists(real_file):
    size = os.path.getsize(real_file)
    print(f"\n2. نسخ الملف الحقيقي: randomforest_model.joblib ({size} bytes)")
    try:
        shutil.copy(real_file, fake_file)
        print("   ✓ تم النسخ")
    except Exception as e:
        print(f"   ✗ فشل النسخ: {e}")
else:
    print("\n2. الملف الحقيقي غير موجود")

# التحقق النهائي
print("\n=== التحقق النهائي ===")
if os.path.exists(fake_file):
    size = os.path.getsize(fake_file)
    print(f"random_forest_model.joblib: {size} bytes")
else:
    print("random_forest_model.joblib: غير موجود")

if os.path.exists(real_file):
    size = os.path.getsize(real_file)
    print(f"randomforest_model.joblib: {size} bytes")
else:
    print("randomforest_model.joblib: غير موجود")

print("\n=== تم ===")
input("اضغط Enter للخروج...")
