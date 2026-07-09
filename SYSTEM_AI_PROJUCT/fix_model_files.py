import os
import shutil

# مسار مجلد models
models_dir = r'c:\Users\Elite\Desktop\SYSTEM_AI_PROJUCT\models'

# الملفات
fake_file = os.path.join(models_dir, 'random_forest_model.joblib')
real_file = os.path.join(models_dir, 'randomforest_model.joblib')

print("=== إصلاح ملفات النماذج ===")
print(f"المسار: {models_dir}")

# حذف الملف الوهمي
if os.path.exists(fake_file):
    size = os.path.getsize(fake_file)
    print(f"حذف الملف الوهمي: random_forest_model.joblib ({size} bytes)")
    os.remove(fake_file)
else:
    print("الملف الوهمي غير موجود")

# نسخ الملف الحقيقي
if os.path.exists(real_file):
    size = os.path.getsize(real_file)
    print(f"نسخ الملف الحقيقي: randomforest_model.joblib ({size} bytes)")
    shutil.copy(real_file, fake_file)
    
    # التحقق
    if os.path.exists(fake_file):
        new_size = os.path.getsize(fake_file)
        print(f"تم النسخ بنجاح: random_forest_model.joblib ({new_size} bytes)")
    else:
        print("فشل النسخ")
else:
    print("الملف الحقيقي غير موجود")

# عرض جميع الملفات
print("\n=== الملفات الموجودة ===")
for file in os.listdir(models_dir):
    filepath = os.path.join(models_dir, file)
    size = os.path.getsize(filepath)
    print(f"  - {file} ({size} bytes)")

print("\n=== تم الإصلاح ===")
